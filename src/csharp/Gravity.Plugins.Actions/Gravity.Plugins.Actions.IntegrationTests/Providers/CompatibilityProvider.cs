/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Abstraction.Contracts;
using Gravity.Plugins.Actions.IntegrationTests.Base;
using System.Collections;

namespace Gravity.Plugins.Actions.IntegrationTests.Providers
{
    public static class CompatibilityProvider
    {
        /// <summary>
        /// Gets browsers compatibility matrix for Web UI testing.
        /// </summary>
        public static IEnumerable Compatibilities => GetCompatibilities();

        /// <summary>
        /// Gets browsers compatibility matrix for Web UI testing.
        /// </summary>
        public static IEnumerable CompatibilitiesAlert => GetCompatibilitiesAlert();

        /// <summary>
        /// Gets browsers compatibility matrix for Web UI testing.
        /// </summary>
        public static IEnumerable CompatibilitiesChrome
        {
            get
            {
                yield return Provider.Get(driver: Driver.Chrome, capabilities: Provider.Windows10LatestBrowser);
            }
        }

        /// <summary>
        /// Gets browsers compatibility matrix for Web UI testing.
        /// </summary>
        public static IEnumerable CompatibilitiesAndroidChrome
        {
            get
            {
                yield return Provider.Get(driver: Driver.Android, capabilities: Provider.AndroidChrome);
            }
        }

        /// <summary>
        /// Gets browsers compatibility matrix for Web UI testing.
        /// </summary>
        public static IEnumerable CompatibilitiesIosSafari
        {
            get
            {
                yield return Provider.Get(driver: Driver.iOS, capabilities: Provider.iPhoneSafari);
            }
        }

        private static IEnumerable GetCompatibilities()
        {
            // Windows 10
            yield return Provider.Get(driver: Driver.Chrome, capabilities: Provider.Windows10LatestBrowser);
            yield return Provider.Get(driver: Driver.Edge, capabilities: Provider.Windows10LatestBrowser);
            yield return Provider.Get(driver: Driver.Firefox, capabilities: Provider.Windows10LatestBrowser);
            yield return Provider.Get(driver: Driver.InternetExplorer, capabilities: Provider.Windows10LatestBrowser);

            // Windows 7
            yield return Provider.Get(driver: Driver.InternetExplorer, capabilities: Provider.Windows7IE10);

            // OSX: Mojave
            yield return Provider.Get(driver: Driver.Safari, capabilities: Provider.OSXMojaveSafari);

            // OSX: Catalina
            yield return Provider.Get(driver: Driver.Chrome, capabilities: Provider.OSXCatalinaLatestBrowser);
            yield return Provider.Get(driver: Driver.Edge, capabilities: Provider.OSXCatalinaLatestBrowser);
            yield return Provider.Get(driver: Driver.Firefox, capabilities: Provider.OSXCatalinaLatestBrowser);

            // Android
            yield return Provider.Get(driver: Driver.Android, capabilities: Provider.AndroidChrome);

            // iOS
            yield return Provider.Get(driver: Driver.iOS, capabilities: Provider.iPhoneSafari);
        }

        private static IEnumerable GetCompatibilitiesAlert()
        {
            // Windows 10
            yield return Provider.Get(driver: Driver.Chrome, capabilities: Provider.Windows10LatestBrowser);
            yield return Provider.Get(driver: Driver.Edge, capabilities: Provider.Windows10LatestBrowser);
            yield return Provider.Get(driver: Driver.Firefox, capabilities: Provider.Windows10LatestBrowser);

            // Windows 7
            yield return Provider.Get(driver: Driver.InternetExplorer, capabilities: Provider.Windows7IE10);

            // OSX: Mojave
            yield return Provider.Get(driver: Driver.Safari, capabilities: Provider.OSXMojaveSafari);

            // OSX: Catalina
            yield return Provider.Get(driver: Driver.Chrome, capabilities: Provider.OSXCatalinaLatestBrowser);
            yield return Provider.Get(driver: Driver.Edge, capabilities: Provider.OSXCatalinaLatestBrowser);
            yield return Provider.Get(driver: Driver.Firefox, capabilities: Provider.OSXCatalinaLatestBrowser);

            // Android
            yield return Provider.Get(driver: Driver.Android, capabilities: Provider.AndroidChrome);
        }
    }
}
