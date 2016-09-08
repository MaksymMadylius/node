using Measurement.Models;
using Measurement.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Xml;

namespace Measurement.Managers.MeasurementManagers
{
    public class MeasurementSaver : IMeasurementSaver
    {
        private readonly IFileRepository _fileRepository;

        public MeasurementSaver()
        {
            _fileRepository = new FileRepository();
        }

        public void SaveDimensions(IEnumerable<Tuple<HttpResponseMessage, TimeSpan>> result, int userCount, string filePath)
        {
            var dimensionResults = GetResults(result, userCount);
            SaveResults(dimensionResults, filePath);
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

        private void SaveResults(DimensionResults results, string filePath)
        {
            var serializedResult = JsonConvert.SerializeObject(results);
            _fileRepository.AppendToTxtFile(filePath, serializedResult);
        }
    }
}
