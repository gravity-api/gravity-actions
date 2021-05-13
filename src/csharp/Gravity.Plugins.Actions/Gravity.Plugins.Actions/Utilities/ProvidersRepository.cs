///*
// * CHANGE LOG - keep only last 5 threads
// * 
// * RESOURCES
// */
//using Gravity.Extensions;
//using Gravity.Plugins.Attributes;
//using Gravity.Plugins.Contracts;
//using Gravity.Plugins.Framework;

//using System;
//using System.Collections.Generic;

//namespace Gravity.Plugins.Actions.Utilities
//{
//    /// <summary>
//    /// A collection of DataProvider methods.
//    /// </summary>
//    public class ProvidersRepository : DataProvidersBase
//    {
//        /// <summary>
//        /// Creates a new instance of ProvidersRepository.
//        /// </summary>
//        /// <param name="dataProvider">GravityDataProvider to use with the repository.</param>
//        /// <param name="types">A collection of <see cref="Type"/> to use with the repository.</param>
//        public ProvidersRepository(GravityDataProvider dataProvider, IEnumerable<Type> types)
//            : base(dataProvider, types)
//        { }

//        /// <summary>
//        /// Save the Extraction as CSV file.
//        /// </summary>
//        /// <param name="extraction">Extraction object to save.</param>
//        [DataProvider(GravityDataProviders.CSV)]
//        public void Csv(Extraction extraction)
//        {
//            // setup
//            DataProvider.Type = GravityDataProviders.CSV;

//            // save
//            extraction.ToDataTable().Save(DataProvider);
//        }

//        /// <summary>
//        /// Save the Extraction as XML file.
//        /// </summary>
//        /// <param name="extraction">Extraction object to save.</param>
//        [DataProvider(GravityDataProviders.XML)]
//        public void Xml(Extraction extraction)
//        {
//            // setup
//            DataProvider.Type = GravityDataProviders.XML;

//            // save
//            extraction.ToDataTable().Save(DataProvider);
//        }
//    }
//}
