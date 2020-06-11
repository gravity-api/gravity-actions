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
    public static class CapabilitiesProvider
    {
        #region *** capabilities: single browser    ***
        public static IEnumerable Win10Chrome
            => Get(driver: Driver.Chrome, capabilities: Provider.Windows10LatestBrowser);

        public static IEnumerable Win10Edge
            => Get(driver: Driver.Edge, capabilities: Provider.Windows10LatestBrowser);

        public static IEnumerable Win10Firefox
            => Get(driver: Driver.Firefox, capabilities: Provider.Windows10LatestBrowser);

        public static IEnumerable Win10InternetExplorer
            => Get(driver: Driver.InternetExplorer, capabilities: Provider.Windows10LatestBrowser);

        public static IEnumerable Win7InternetExplorer
            => Get(driver: Driver.InternetExplorer, capabilities: Provider.Windows7IE10);

        public static IEnumerable OSXMojaveSafari
            => Get(driver: Driver.Safari, capabilities: Provider.OSXMojaveSafari);

        public static IEnumerable OSXCatalinaChrome
            => Get(driver: Driver.Chrome, capabilities: Provider.OSXCatalinaLatestBrowser);

        public static IEnumerable OSXCatalinaEdge
            => Get(driver: Driver.Edge, capabilities: Provider.OSXCatalinaLatestBrowser);

        public static IEnumerable OSXCatalinaFirefox
            => Get(driver: Driver.Firefox, capabilities: Provider.OSXCatalinaLatestBrowser);

        public static IEnumerable AndroidChrome
            => Get(driver: Driver.Android, capabilities: Provider.AndroidChrome);

        public static IEnumerable IphoneSafari
            => Get(driver: Driver.iOS, capabilities: Provider.iPhoneSafari);
        #endregion

        #region *** capabilities: multiple browsers ***
        public static IEnumerable Capabilities => GetCapabilities();

        public static IEnumerable CapabilitiesNoEdgeNoSafari => GetCapabilitiesNoEdgeNoSafari();

        public static IEnumerable CapabilitiesNoIe11NoIos => GetCapabilitiesNoIe11NoIos();

        public static IEnumerable CapabilitiesNoIos => GetCapabilitiesNoIos();

        public static IEnumerable CapabilitiesNoSafari => GetCapabilitiesNoSafari();

        public static IEnumerable CapabilitiesMobileWeb => GetCapabilitiesMobileWeb();

        public static IEnumerable CapabilitiesMobileNative => GetCapabilitiesMobileNative();

        public static IEnumerable CapabilitiesNoMobile => GetCapabilitiesNoMobile();

        public static IEnumerable CapabilitiesNoIeNoSafari => GetCapabilitiesNoIeNoSafari();

        private static IEnumerable GetCapabilities()
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

            // TODO: return when iOS is stable on browser stack.
            // iOS
            // yield return Provider.Get(driver: Driver.iOS, capabilities: Provider.iPhoneSafari);
        }

        private static IEnumerable GetCapabilitiesNoEdgeNoSafari()
        {
            // Windows 10
            yield return Get(driver: Driver.Chrome, capabilities: Provider.Windows10LatestBrowser);
            yield return Get(driver: Driver.Firefox, capabilities: Provider.Windows10LatestBrowser);
            yield return Get(driver: Driver.InternetExplorer, capabilities: Provider.Windows10LatestBrowser);

            // Windows 7
            yield return Get(driver: Driver.InternetExplorer, capabilities: Provider.Windows7IE10);

            // OSX: Catalina
            yield return Get(driver: Driver.Chrome, capabilities: Provider.OSXCatalinaLatestBrowser);
            yield return Get(driver: Driver.Firefox, capabilities: Provider.OSXCatalinaLatestBrowser);

            // Android
            yield return Get(driver: Driver.Android, capabilities: Provider.AndroidChrome);
        }

        private static IEnumerable GetCapabilitiesNoIe11NoIos()
        {
            // Windows 10
            yield return Provider.Get(driver: Driver.Chrome, capabilities: Provider.Windows10LatestBrowser);
            yield return Provider.Get(driver: Driver.Edge, capabilities: Provider.Windows10LatestBrowser);
            yield return Provider.Get(driver: Driver.Firefox, capabilities: Provider.Windows10LatestBrowser);
            //yield return Provider.Get(driver: Driver.InternetExplorer, capabilities: Provider.Windows10LatestBrowser);

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

            // TODO: return when iOS is stable on browser stack.
            // iOS
            // yield return Provider.Get(driver: Driver.iOS, capabilities: Provider.iPhoneSafari);
        }

        private static IEnumerable GetCapabilitiesNoIos()
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

        private static IEnumerable GetCapabilitiesNoSafari()
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

        private static IEnumerable GetCapabilitiesMobileWeb()
        {
            // Android
            yield return Provider.Get(driver: Driver.Android, capabilities: Provider.AndroidChrome);

            // TODO: return when iOS is stable on browser stack.
            // iOS
            // yield return Provider.Get(driver: Driver.iOS, capabilities: Provider.iPhoneSafari);
        }

        private static IEnumerable GetCapabilitiesMobileNative()
        {
            // Android
            yield return Provider.Get(driver: Driver.Android, capabilities: Provider.AndroidNative);

            // TODO: return when iOS is stable on browser stack.
            // iOS
            // yield return GetCapabilities(driver: Driver.iOS, capabilities: Provider.iPhoneSafari);
        }

        private static IEnumerable GetCapabilitiesNoMobile()
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

        private static IEnumerable GetCapabilitiesNoIeNoSafari()
        {
            // Windows 10
            yield return Provider.Get(driver: Driver.Chrome, capabilities: Provider.Windows10LatestBrowser);
            yield return Provider.Get(driver: Driver.Edge, capabilities: Provider.Windows10LatestBrowser);
            yield return Provider.Get(driver: Driver.Firefox, capabilities: Provider.Windows10LatestBrowser);

            // OSX: Catalina
            yield return Provider.Get(driver: Driver.Chrome, capabilities: Provider.OSXCatalinaLatestBrowser);
            yield return Provider.Get(driver: Driver.Edge, capabilities: Provider.OSXCatalinaLatestBrowser);
            yield return Provider.Get(driver: Driver.Firefox, capabilities: Provider.OSXCatalinaLatestBrowser);

            // Android
            yield return Provider.Get(driver: Driver.Android, capabilities: Provider.AndroidChrome);
        }
        #endregion

        private static IEnumerable Get(string driver, string capabilities)
        {
            yield return Provider.Get(driver, capabilities);
        }
    }
}