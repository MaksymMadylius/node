using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scheduler.IntegrationTests.Providers;
using System.IO;

namespace Scheduler.IntegrationTests
{
    [TestClass]
    public class WorkControllerIntegrationTest
    {
        #region Consts

        private const string xmlJsonFileNameKey = "xmlJsonFile";

        #endregion

        #region Fields

        private readonly IJsonProvider _jsonProvider;
        
        #endregion

        #region Ctors

        public WorkControllerIntegrationTest()
        {
            _jsonProvider = new XmlJsonProvider(GetFullPathToXmlJsonData());
        }

        #endregion


        [TestMethod]
        public void SetWorkersTest()
        {
            var jArray = _jsonProvider.GetJson();
        }

        #region Helpers



        private string GetFullPathToXmlJsonData()
        {
            var confPath = ConfigurationSettings.AppSettings[xmlJsonFileNameKey];
            var appPath = AppDomain.CurrentDomain.BaseDirectory;

            return Path.Combine(appPath, confPath);
        }

        #endregion
    }
}
