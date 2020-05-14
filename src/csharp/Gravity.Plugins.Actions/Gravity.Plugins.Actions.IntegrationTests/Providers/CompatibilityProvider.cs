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
        #region *** capabilities: single browser    ***
        public static IEnumerable Win10Chrome
            => GetCapabilities(driver: Driver.Chrome, capabilities: Provider.Windows10LatestBrowser);

        public static IEnumerable Win10Edge
            => GetCapabilities(driver: Driver.Edge, capabilities: Provider.Windows10LatestBrowser);

        public static IEnumerable Win10Firefox
            => GetCapabilities(driver: Driver.Firefox, capabilities: Provider.Windows10LatestBrowser);

        public static IEnumerable Win10InternetExplorer
            => GetCapabilities(driver: Driver.InternetExplorer, capabilities: Provider.Windows10LatestBrowser);

        public static IEnumerable Win7InternetExplorer
            => GetCapabilities(driver: Driver.InternetExplorer, capabilities: Provider.Windows7IE10);

        public static IEnumerable OSXMojaveSafari
            => GetCapabilities(driver: Driver.Safari, capabilities: Provider.OSXMojaveSafari);

        public static IEnumerable OSXCatalinaChrome
            => GetCapabilities(driver: Driver.Chrome, capabilities: Provider.OSXCatalinaLatestBrowser);

        public static IEnumerable OSXCatalinaEdge
            => GetCapabilities(driver: Driver.Edge, capabilities: Provider.OSXCatalinaLatestBrowser);

        public static IEnumerable OSXCatalinaFirefox
            => GetCapabilities(driver: Driver.Firefox, capabilities: Provider.OSXCatalinaLatestBrowser);

        public static IEnumerable AndroidChrome
            => GetCapabilities(driver: Driver.Android, capabilities: Provider.AndroidChrome);

        public static IEnumerable IphoneSafari
            => GetCapabilities(driver: Driver.iOS, capabilities: Provider.iPhoneSafari);
        #endregion

        #region *** capabilities: multiple browsers ***
        public static IEnumerable Compatibilities => GetCompatibilities();

        public static IEnumerable CompatibilitiesNoEdgeNoSafari => GetCompatibilitiesNoEdgeNoSafari();

        public static IEnumerable CompatibilitiesNoIe11NoIos => GetCompatibilitiesNoIe11NoIos();

        public static IEnumerable CompatibilitiesNoIos => GetCompatibilitiesNoIos();

        public static IEnumerable CompatibilitiesNoSafari => GetCompatibilitiesNoSafari();

        public static IEnumerable CompatibilitiesMobileWeb => GetCompatibilitiesMobileWeb();

        public static IEnumerable CompatibilitiesMobileNative => GetCompatibilitiesMobileNative();

        public static IEnumerable CompatibilitiesNoMobile => GetCompatibilitiesNoMobile();

        private static IEnumerable GetCompatibilities()
        {
            yield return GetCapabilities(driver: Driver.Chrome, capabilities: Provider.Windows10LatestBrowser);

            // Windows 10
            yield return GetCapabilities(driver: Driver.Chrome, capabilities: Provider.Windows10LatestBrowser);
            yield return GetCapabilities(driver: Driver.Edge, capabilities: Provider.Windows10LatestBrowser);
            yield return GetCapabilities(driver: Driver.Firefox, capabilities: Provider.Windows10LatestBrowser);
            yield return GetCapabilities(driver: Driver.InternetExplorer, capabilities: Provider.Windows10LatestBrowser);

            // Windows 7
            yield return GetCapabilities(driver: Driver.InternetExplorer, capabilities: Provider.Windows7IE10);

            // OSX: Mojave
            yield return GetCapabilities(driver: Driver.Safari, capabilities: Provider.OSXMojaveSafari);

            // OSX: Catalina
            yield return GetCapabilities(driver: Driver.Chrome, capabilities: Provider.OSXCatalinaLatestBrowser);
            yield return GetCapabilities(driver: Driver.Edge, capabilities: Provider.OSXCatalinaLatestBrowser);
            yield return GetCapabilities(driver: Driver.Firefox, capabilities: Provider.OSXCatalinaLatestBrowser);

            // Android
            yield return GetCapabilities(driver: Driver.Android, capabilities: Provider.AndroidChrome);

            // TODO: return when iOS is stable on browser stack.
            // iOS
            // yield return GetCapabilities(driver: Driver.iOS, capabilities: Provider.iPhoneSafari);
        }

        private static IEnumerable GetCompatibilitiesNoEdgeNoSafari()
        {
            // Windows 10
            yield return GetCapabilities(driver: Driver.Chrome, capabilities: Provider.Windows10LatestBrowser);
            yield return GetCapabilities(driver: Driver.Firefox, capabilities: Provider.Windows10LatestBrowser);
            yield return GetCapabilities(driver: Driver.InternetExplorer, capabilities: Provider.Windows10LatestBrowser);

            // Windows 7
            yield return GetCapabilities(driver: Driver.InternetExplorer, capabilities: Provider.Windows7IE10);

            // OSX: Catalina
            yield return GetCapabilities(driver: Driver.Chrome, capabilities: Provider.OSXCatalinaLatestBrowser);
            yield return GetCapabilities(driver: Driver.Firefox, capabilities: Provider.OSXCatalinaLatestBrowser);

            // Android
            yield return GetCapabilities(driver: Driver.Android, capabilities: Provider.AndroidChrome);
        }

        private static IEnumerable GetCompatibilitiesNoIe11NoIos()
        {
            // Windows 10
            yield return GetCapabilities(driver: Driver.Chrome, capabilities: Provider.Windows10LatestBrowser);
            yield return GetCapabilities(driver: Driver.Edge, capabilities: Provider.Windows10LatestBrowser);
            yield return GetCapabilities(driver: Driver.Firefox, capabilities: Provider.Windows10LatestBrowser);

            // Windows 7
            yield return GetCapabilities(driver: Driver.InternetExplorer, capabilities: Provider.Windows7IE10);

            // OSX: Mojave
            yield return GetCapabilities(driver: Driver.Safari, capabilities: Provider.OSXMojaveSafari);

            // OSX: Catalina
            yield return GetCapabilities(driver: Driver.Chrome, capabilities: Provider.OSXCatalinaLatestBrowser);
            yield return GetCapabilities(driver: Driver.Edge, capabilities: Provider.OSXCatalinaLatestBrowser);
            yield return GetCapabilities(driver: Driver.Firefox, capabilities: Provider.OSXCatalinaLatestBrowser);

            // Android
            yield return GetCapabilities(driver: Driver.Android, capabilities: Provider.AndroidChrome);
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

        private static IEnumerable GetCompatibilitiesMobileWeb()
        {
            // Android
            yield return Provider.Get(driver: Driver.Android, capabilities: Provider.AndroidChrome);

            // TODO: return when iOS is stable on browser stack.
            // iOS
            // yield return GetCapabilities(driver: Driver.iOS, capabilities: Provider.iPhoneSafari);
        }

        private static IEnumerable GetCompatibilitiesMobileNative()
        {
            // Android
            yield return Provider.Get(driver: Driver.Android, capabilities: Provider.AndroidNative);

            // TODO: return when iOS is stable on browser stack.
            // iOS
            // yield return GetCapabilities(driver: Driver.iOS, capabilities: Provider.iPhoneSafari);
        }

        private static IEnumerable GetCompatibilitiesNoMobile()
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
        }
        #endregion

        private static IEnumerable GetCapabilities(string driver, string capabilities)
        {
            yield return Provider.Get(driver, capabilities);
        }
    }
}