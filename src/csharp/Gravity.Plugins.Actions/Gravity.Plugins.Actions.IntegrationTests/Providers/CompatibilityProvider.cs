/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources   
 */
using Gravity.Abstraction.Contracts;
using Gravity.IntegrationTests.Base;
using System.Collections;

namespace Gravity.IntegrationTests.Providers
{
    public static class CompatibilityProvider
    {
        /// <summary>
        /// Gets browsers compatibility matrix for Web UI testing.
        /// </summary>
        public static IEnumerable Compatibilities => GetCompatibilities();

        public static IEnumerable CompatibilitiesContextClick => GetCompatibilitiesContextClick();

        /// <summary>
        /// Gets browsers compatibility matrix for Web UI testing.
        /// </summary>
        public static IEnumerable CompatibilitiesPopups => GetCompatibilitiesPopups();

        public static IEnumerable CompatibilitiesCloseWindow => GetCompatibilitiesCloseWindow();

        public static IEnumerable CompatibilitiesNoIos => GetCompatibilitiesNoIos();

        public static IEnumerable CompatibilitiesNoSafari => GetCompatibilitiesNoSafari();

        public static IEnumerable CompatibilitiesMobile => GetCompatibilitiesMobile();

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

        public static IEnumerable CompatibilitiesSafariMojave
        {
            get
            {
                yield return Provider.Get(driver: Driver.Safari, capabilities: Provider.OSXMojaveSafari);
            }
        }

        /// <summary>
        /// Gets browsers compatibility matrix for Web UI testing.
        /// </summary>
        public static IEnumerable CompatibilitiesEdge
        {
            get
            {
                yield return Provider.Get(driver: Driver.Edge, capabilities: Provider.Windows10Edge80);
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
            //yield return Provider.Get(driver: Driver.iOS, capabilities: Provider.iPhoneSafari);
        }

        private static IEnumerable GetCompatibilitiesContextClick()
        {
            // Windows 10
            yield return Provider.Get(driver: Driver.Chrome, capabilities: Provider.Windows10LatestBrowser);
            yield return Provider.Get(driver: Driver.Firefox, capabilities: Provider.Windows10LatestBrowser);
            yield return Provider.Get(driver: Driver.InternetExplorer, capabilities: Provider.Windows10LatestBrowser);

            // Windows 7
            yield return Provider.Get(driver: Driver.InternetExplorer, capabilities: Provider.Windows7IE10);

            // OSX: Catalina
            yield return Provider.Get(driver: Driver.Chrome, capabilities: Provider.OSXCatalinaLatestBrowser);
            yield return Provider.Get(driver: Driver.Firefox, capabilities: Provider.OSXCatalinaLatestBrowser);

            // Android
            yield return Provider.Get(driver: Driver.Android, capabilities: Provider.AndroidChrome);
        }

        private static IEnumerable GetCompatibilitiesPopups()
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

        private static IEnumerable GetCompatibilitiesCloseWindow()
        {
            // Windows 10
            yield return Provider.Get(driver: Driver.InternetExplorer, capabilities: Provider.Windows10LatestBrowser);
            yield return Provider.Get(driver: Driver.Chrome, capabilities: Provider.Windows10LatestBrowser);
            yield return Provider.Get(driver: Driver.Edge, capabilities: Provider.Windows10LatestBrowser);
            yield return Provider.Get(driver: Driver.Firefox, capabilities: Provider.Windows10LatestBrowser);

            // Windows 7
            yield return Provider.Get(driver: Driver.InternetExplorer, capabilities: Provider.Windows7IE10);

            // OSX: Catalina
            yield return Provider.Get(driver: Driver.Chrome, capabilities: Provider.OSXCatalinaLatestBrowser);
            yield return Provider.Get(driver: Driver.Edge, capabilities: Provider.OSXCatalinaLatestBrowser);
            yield return Provider.Get(driver: Driver.Firefox, capabilities: Provider.OSXCatalinaLatestBrowser);

            // Android
            yield return Provider.Get(driver: Driver.Android, capabilities: Provider.AndroidChrome);
        }

        private static IEnumerable GetCompatibilitiesNoIos()
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
        }

        private static IEnumerable GetCompatibilitiesNoSafari()
        {
            // Windows 10
            yield return Provider.Get(driver: Driver.Chrome, capabilities: Provider.Windows10LatestBrowser);
            yield return Provider.Get(driver: Driver.Edge, capabilities: Provider.Windows10LatestBrowser);
            yield return Provider.Get(driver: Driver.Firefox, capabilities: Provider.Windows10LatestBrowser);
            yield return Provider.Get(driver: Driver.InternetExplorer, capabilities: Provider.Windows10LatestBrowser);

            // Windows 7
            yield return Provider.Get(driver: Driver.InternetExplorer, capabilities: Provider.Windows7IE10);

            // OSX: Catalina
            yield return Provider.Get(driver: Driver.Chrome, capabilities: Provider.OSXCatalinaLatestBrowser);
            yield return Provider.Get(driver: Driver.Edge, capabilities: Provider.OSXCatalinaLatestBrowser);
            yield return Provider.Get(driver: Driver.Firefox, capabilities: Provider.OSXCatalinaLatestBrowser);

            // Android
            yield return Provider.Get(driver: Driver.Android, capabilities: Provider.AndroidChrome);
        }

        private static IEnumerable GetCompatibilitiesMobile()
        {
            // Android
            yield return Provider.Get(driver: Driver.Android, capabilities: Provider.AndroidChrome);

            // iOS
            yield return Provider.Get(driver: Driver.iOS, capabilities: Provider.iPhoneSafari);
        }
    }
}
