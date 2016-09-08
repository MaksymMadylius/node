using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Scheduler.IntegrationTests.RequestManager
{
    class Requester : IRequester
    {
        private HttpClient _client;
        private List<Tuple<HttpResponseMessage, TimeSpan>> _responseMessageCollection;

        public Requester(HttpClient client)
        {
            _client = client;
        }

        private HttpResponseMessage Get(string url)
        {
            var request = new HttpRequestMessage { RequestUri = new Uri(url) };
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Method = HttpMethod.Get;

            HttpResponseMessage response = _client.SendAsync(request, new CancellationTokenSource().Token).Result;
            return response;
        }

        private HttpResponseMessage Post(string url, JArray jsonArray)
        {

            var request = new HttpRequestMessage { RequestUri = new Uri(url) };
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Method = HttpMethod.Post;
            request.Content = new ObjectContent<JArray>(jsonArray, new JsonMediaTypeFormatter());

            HttpResponseMessage response = _client.SendAsync(request, new CancellationTokenSource().Token).Result;

            return response;
        }
        IEnumerable<Tuple<HttpResponseMessage, TimeSpan>> IRequester.Get(string url, int usersCount)
        {
            _responseMessageCollection = new List<Tuple<HttpResponseMessage, TimeSpan>>();

            Parallel.For(0, usersCount, i =>
            {
                var stopWatch = Stopwatch.StartNew();
                var response = Get(url);
                _responseMessageCollection.Add(new Tuple<HttpResponseMessage, TimeSpan>(response, stopWatch.Elapsed));
            });

            return _responseMessageCollection;
        }

        IEnumerable<Tuple<HttpResponseMessage, TimeSpan>> IRequester.Post(string url, int usersCount, JArray jsonArray)
        {
            _responseMessageCollection = new List<Tuple<HttpResponseMessage, TimeSpan>>();

            Parallel.For(0, usersCount, i =>
            {
                var stopWatch = Stopwatch.StartNew();
                var response = Post(url, jsonArray);
                _responseMessageCollection.Add(new Tuple<HttpResponseMessage, TimeSpan>(response, stopWatch.Elapsed));
            });

            return _responseMessageCollection;

        }
    }
}
