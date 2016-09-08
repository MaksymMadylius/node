using System;
using System.Collections.Generic;

namespace Measurement.Models
{
    public class DimensionResults
    {
        public int UsersCount { get; set; }

        public IList<RequestInfo> Requests { get; set; }
       
    }

    public class RequestInfo
    {
        public TimeSpan ElapsedTime { get; set; }
        public long JsonSize { get; set; }
    }
}
