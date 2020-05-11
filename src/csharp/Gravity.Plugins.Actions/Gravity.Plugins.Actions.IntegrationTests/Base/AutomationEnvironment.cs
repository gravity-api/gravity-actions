﻿using System.Collections.Generic;

namespace Gravity.IntegrationTests.Base
{
    public class Context
    {
        public IDictionary<string, object> SystemParams { get; set; }
        public IDictionary<string, object> TestParams { get; set; }
    }
}
