using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Tests.RequestManager
{
    interface IRequester
    {
        IEnumerable<Tuple<HttpResponseMessage, TimeSpan>> Get(string url, int usersCount, JArray jsonArray);
        IEnumerable<Tuple<HttpResponseMessage, TimeSpan>> Post(string url, int usersCount, JArray jsonArray);
    }
}
