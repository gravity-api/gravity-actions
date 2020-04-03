using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Base
{
    public class AutomationEnvironment
    {
        public IDictionary<string, object> SystemParams { get; set; }
        public IDictionary<string, object> TestParams { get; set; }
    }
}
