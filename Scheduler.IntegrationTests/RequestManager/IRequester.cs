using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;


namespace Scheduler.IntegrationTests.RequestManager
{
    interface IRequester
    {
        IEnumerable<Tuple<HttpResponseMessage, TimeSpan>> Get(string url, int usersCount, JArray jsonArray);
        IEnumerable<Tuple<HttpResponseMessage, TimeSpan>> Post(string url, int usersCount, JArray jsonArray);
    }
}
