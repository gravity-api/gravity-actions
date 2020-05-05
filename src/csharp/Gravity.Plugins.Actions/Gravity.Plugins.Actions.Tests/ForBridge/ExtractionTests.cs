using Gravity.Plugins.Contracts;
using Gravity.Plugins.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Gravity.Plugins.UnitTests.Engine
{
    [TestClass]
    public class ExtractionTests
    {
        [TestMethod]
        public void ExtractionToDataTable()
        {
            var entities = new[]
            {
                new Entity
                {
                    Content = new Dictionary<string, object>
                    {
                        ["boolean"] = true
                    }
                },
                new Entity
                {
                    Content = new Dictionary<string, object>
                    {
                        ["boolean"] = true,
                        ["string"] = "value1"
                    }
                },
                new Entity
                {
                    Content = new Dictionary<string, object>
                    {
                        ["boolean"] = true,
                        ["string"] = "value1",
                        ["integer"] = 1
                    }
                },
                new Entity
                {
                    Content = new Dictionary<string, object>
                    {
                        ["boolean"] = true,
                        ["string"] = "value1",
                        ["integer"] = 1,
                        ["double"] = 1.1
                    }
                },
                new Entity
                {
                    Content = new Dictionary<string, object>
                    {
                        ["boolean"] = false,
                        ["string"] = "value2",
                        ["integer"] = 2,
                        ["double"] = 2.2,
                        ["date_time"] = DateTime.Now
                    }
                },
            };

            new Extraction
            {
                Key = "test_extraction",
                Entities = entities
            }.Populate(dataSource: null);

            var a = "";
        }
    }
}
