using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Measurement.Providers.JsonProviders;
using Measurement.Managers.RequestManagers;
using System.Net.Http;
using Measurement.Managers.MeasurementManagers;

namespace Scheduler.IntegrationTests
{
    [TestClass]
    public class WorkControllerIntegrationTest
    {
        #region Consts

        private const string JsonProviderTypeKey = "jsonProviderType";

        #endregion

        #region Fields

        private readonly IJsonProvider _jsonProvider;
        private readonly IRequester _requester;
        private readonly IMeasurementSaver _measureSaver;

        #endregion

        #region Ctors

        public WorkControllerIntegrationTest()
        {
            _jsonProvider = new JsonFabricProvider(ConfigurationSettings.AppSettings[JsonProviderTypeKey]);
            _requester = new Requester(GetHttpClient());
            _measureSaver = new MeasurementSaver();
        }

        #endregion


        [TestMethod]
        public void SetWorkersTest()
        {
            var jArray = _jsonProvider.GetJson();
            var url = "someUrl";
            var userCount = 20;
            var response = _requester.Post(url, userCount, jArray);
            _measureSaver.SaveDimensions(response, userCount);
        }

        #region Helpers

        private HttpClient GetHttpClient()
        {
            var server = new HttpClientHandler();
            var client = new HttpClient(server);

            return client;
        }

        #endregion
    }
}
