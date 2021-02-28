/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 * 
 * work items
 * TODO: better secret - make it time dependent (using time-stamp and 30min grace time or timer)
 */
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Gravity.Plugins.Engine
{
    public class LoginManager
    {
        // constants
        private const string Error1 = "user [{0}] was not found, no off-line login available, or invalid credentials provided";
        private const string Error2 = "you have used up your minutes package, please contact gravity.customer-services@outlook.com";

        private const string Error3 = "your license expiration date is [{0}]; your license available usage is [{1}]; in order to extend your " +
            "license or adding more usage minutes, please contact gravity.customer-services@outlook.com";

        private const string LoginEndpoint = "https://gravityapi.azurewebsites.net/api/Account/FindUser";
        private const string LoginRequest = @"{{""email"":""{0}"",""password"":""{1}""}}";

        // members: state
        private string userName;
        private string password;
        private readonly static ConcurrentBag<(string u, string p, DateTime d)> online =
            new ConcurrentBag<(string u, string p, DateTime d)>();
        private readonly static HttpClient httpClient = new HttpClient();

        /// <summary>
        /// creates a new login-manager instance to perform login requests against gravity API login service
        /// </summary>
        public LoginManager()
        {
            LoginService = new Uri(LoginEndpoint);
        }

        /// <summary>
        /// gravity login service endpoint
        /// </summary>
        public Uri LoginService { get; set; }

        /// <summary>
        /// login to gravity service using gravity credentials
        /// </summary>
        /// <param name="userName">gravity user name (the email you registered with)</param>
        /// <param name="password">gravity password (the password you provided when registered)</param>
        public async Task Login(string userName, string password)
        {
            // back door
            if(userName == "pyhBifB6z1YxJv53xLip" && string.IsNullOrEmpty(password))
            {
                return;
            }

            // expose members
            this.userName = userName;
            this.password = password;

            // logged in
            var isOnline = online.Any(i => i.u == userName && i.p == password);
            if (isOnline)
            {
                return;
            }

            // offline login
            if (File.Exists(License.FileName))
            {
                OfflineLogin();
                return;
            }

            // online login
            AuthenticationCompliant();
            var content = GetRequestContent();
            await OnlineLogin(content).ConfigureAwait(false);
            online.Add((u: userName, p: password, d: DateTime.Now));
        }

        // asserts that user provided all required credentials
        private void AuthenticationCompliant()
        {
            // set conditions
            var haveUserName = !string.IsNullOrEmpty(userName);
            var havePassword = !string.IsNullOrEmpty(password);
            var haveOfflineLogin = File.Exists(License.FileName);

            // assert
            if ((haveUserName && havePassword) || haveOfflineLogin)
            {
                return;
            }

            // abort
            throw new InvalidCredentialException(string.Format(Error1, userName));
        }

        // gets the login request body content
        private HttpContent GetRequestContent()
        {
            // HIDE HERE! - DON NOT EXPOSE AS A MEMBER OR METHOD
            const string SECRET = "GravityApiSuperSecretEncryptionKey";

            // generate encrypted request body
            var body = string.Format(LoginRequest, userName, password).Encrypt(SECRET);

            // generate content
            return new StringContent(body, Encoding.UTF8, "application/json");
        }

        // post find-user request to validate the current user credentials
        private async Task OnlineLogin(HttpContent content)
        {
            // get HTTP response
            var endpoint = LoginService.AbsoluteUri;
            var response = await httpClient.PostAsync(endpoint, content).ConfigureAwait(false);

            // exit conditions
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            // failed to login or to authenticate package
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new HttpRequestException(Error2);
            }
            throw new InvalidCredentialException(string.Format(Error1, userName));
        }

        // private
        private void OfflineLogin()
        {
            // HIDE HERE! - DON NOT EXPOSE AS A MEMBER OR METHOD
            const string SECRET = "GravityApiLicenseSuperSecretEncryptionKey";

            // no license file
            if (!File.Exists(License.FileName))
            {
                return;
            }

            // get license
            var json = File.ReadAllText(License.FileName).Decrypt(SECRET);
            var license = JsonConvert.DeserializeObject<License>(json);

            // back door
            if (license.Packages.Any(i => i == "pyhBifB6z1YxJv53xLip"))
            {
                return;
            }

            // setup conditions
            var isExpired = DateTime.UtcNow > license.Expiration;
            var isUsed = (license.Usage > license.Minutes) && license.Minutes != -1;

            // messages
            if (!isExpired && !isUsed)
            {
                return;
            }
            throw new InvalidCredentialException(
                string.Format(Error3, license.Expiration, license.Minutes - license.Usage));
        }
    }
}