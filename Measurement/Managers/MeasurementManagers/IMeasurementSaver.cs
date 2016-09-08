using System;
using System.Collections.Generic;
using System.Net.Http;


namespace Measurement.Managers.MeasurementManagers
{
    public interface IMeasurementSaver
    {
        void SaveDimensions(IEnumerable<Tuple<HttpResponseMessage, TimeSpan>> result, int userCount, string filePath);
    }
}
