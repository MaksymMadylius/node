using Measurement.Models;
using Measurement.Providers.DirectoryProviders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Xml;

namespace Measurement.Managers.MeasurementManagers
{
    public class MeasurementSaver : IMeasurementSaver
    {
        private const string MeasurementFilePath = "measurementFilePath";

        public void SaveDimensions(IEnumerable<Tuple<HttpResponseMessage, TimeSpan>> result, int userCount)
        {
            var dimensionResults = GetResults(result, userCount);
            SaveResults(dimensionResults);
        }

        private DimensionResults GetResults(IEnumerable<Tuple<HttpResponseMessage, TimeSpan>> result, int userCount)
        {
            var dimensionResult = new DimensionResults
            {
                UsersCount = userCount,
                Requests = new List<RequestInfo>()
            };

            foreach(var x in result)
            {
                var contentLength = x.Item1.Content.Headers.ContentLength;
                dimensionResult.Requests.Add(new RequestInfo
                {
                    ElapsedTime = x.Item2,
                    JsonSize = x.Item1.Content.Headers.ContentLength.GetValueOrDefault()
                });
            }

            return dimensionResult;
        }

        private void SaveResults(DimensionResults results)
        {
            var xmlDocument = GetXmlDocument(DirectoryProvider.GetFullPath(MeasurementFilePath));
            var xmlNodeResult = ConvertDimensionResultToXmlNode(results);

            xmlDocument.InsertAfter(xmlDocument.LastChild, xmlNodeResult);
        }

        private XmlDocument GetXmlDocument(string filePath)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            return xmlDoc;
        }

        private XmlNode ConvertDimensionResultToXmlNode(DimensionResults result)
        {
            var serializedResult = JsonConvert.SerializeObject(result);
            var xmlNode = JsonConvert.DeserializeXmlNode(serializedResult);

            return xmlNode;
        }
    }
}
