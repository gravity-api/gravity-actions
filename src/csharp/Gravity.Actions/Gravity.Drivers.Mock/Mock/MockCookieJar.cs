using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace OpenQA.Selenium.Mock
{
    /// <summary>
    /// Defines an interface allowing the user to manipulate cookies on the current page.
    /// </summary>
    /// <seealso cref="=ICookieJar" />
    public class MockCookieJar : ICookieJar
    {
        private readonly IList<Cookie> m_CookieJar;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockCookieJar"/> class.
        /// </summary>
        public MockCookieJar()
        {
            m_CookieJar = new ReadOnlyCollection<Cookie>(new List<Cookie>
            {
                new Cookie("mock-cookie-01", "mock cookie 01 value"),
                new Cookie("mock-cookie-02", "mock cookie 02 value")
            });
        }

        /// <summary>
        /// Gets all cookies defined for the current page.
        /// </summary>
        public ReadOnlyCollection<Cookie> AllCookies => new ReadOnlyCollection<Cookie>(m_CookieJar);

        /// <summary>
        /// Adds a cookie to the current page.
        /// </summary>
        /// <param name="cookie">The <see cref="Cookie" /> object to be added.</param>
        public void AddCookie(Cookie cookie)
        {
            m_CookieJar.Add(cookie);
        }

        /// <summary>
        /// Deletes all cookies from the page.
        /// </summary>
        public void DeleteAllCookies()
        {
            m_CookieJar.Clear();
        }

        /// <summary>
        /// Deletes the specified cookie from the page.
        /// </summary>
        /// <param name="cookie">The <see cref="=Cookie" /> to be deleted.</param>
        public void DeleteCookie(Cookie cookie)
        {
            m_CookieJar.Remove(cookie);
        }

        /// <summary>
        /// Deletes the cookie with the specified name from the page.
        /// </summary>
        /// <param name="name">The name of the cookie to be deleted.</param>
        public void DeleteCookieNamed(string name)
        {
            //-- get cookie
            var cookie = m_CookieJar.FirstOrDefault(c => c.Name == name);
            //
            //-- exit conditions
            if (cookie == null) return;
            //
            //-- remove cookie
            m_CookieJar.Remove(cookie);
        }

        /// <summary>
        /// Gets a cookie with the specified name.
        /// </summary>
        /// <param name="name">The name of the cookie to retrieve.</param>
        /// <returns>
        /// The <see cref="Cookie" /> containing the name. Returns <see langword="null" />
        /// if no cookie with the specified name is found.
        /// </returns>
        public Cookie GetCookieNamed(string name)
        {
            //-- get cookie
            return m_CookieJar.FirstOrDefault(c => c.Name == name);
        }
    }
}
