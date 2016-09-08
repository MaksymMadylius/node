using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Measurement.Providers.JsonProviders;
using Measurement.Managers.RequestManagers;
using System.Net.Http;
using Measurement.Managers.MeasurementManagers;
using System.IO;

namespace Scheduler.IntegrationTests
{
    [TestClass]
    public class WorkControllerIntegrationTest
    {
        #region Fields

        private string _jsonProviderType = ConfigurationSettings.AppSettings["jsonProviderType"];
        private string _xmlJsonProviderFilePath = ConfigurationSettings.AppSettings["xmlJsonProviderFilePath"];
        private string _dimensionsTxtFilePath = ConfigurationSettings.AppSettings["dimentionResFilePath"];
        private string url = ConfigurationSettings.AppSettings["url"];

        private readonly IJsonProvider _jsonProvider;
        private readonly IRequester _requester;
        private readonly IMeasurementSaver _measurementSaver;

        #endregion

        #region Ctors

        public WorkControllerIntegrationTest()
        {
            _jsonProvider = new JsonFabricProvider(_jsonProviderType, new[] { GetFullPath(_xmlJsonProviderFilePath) });
            _requester = new Requester(GetHttpClient());
            _measurementSaver = new MeasurementSaver();
        }

        #endregion

        [TestMethod]
        public void SetWorkersTest()
        {
            var dimensionResTextFileFullPath = GetFullPath(_dimensionsTxtFilePath);

            var jArray = _jsonProvider.GetJson();
            var userCount = 20;

            var response = _requester.Post(url, userCount, jArray);
            _measurementSaver.SaveDimensions(response, userCount, dimensionResTextFileFullPath);
        }

        #region Helpers

        private HttpClient GetHttpClient()
        {
            var server = new HttpClientHandler();
            var client = new HttpClient(server);

            return client;
        }

        private string GetFullPath(string path)
        {
            return Path.GetFullPath(Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDi‌​rectory, "..\\..\\..\\"), path));
        }

        #endregion
    }
}
