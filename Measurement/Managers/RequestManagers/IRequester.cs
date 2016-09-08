using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;


namespace Measurement.Managers.RequestManagers
{
    public interface IRequester
    {
        IEnumerable<Tuple<HttpResponseMessage, TimeSpan>> Get(string url, int usersCount);
        IEnumerable<Tuple<HttpResponseMessage, TimeSpan>> Post(string url, int usersCount, JArray jsonArray);
    }
}
