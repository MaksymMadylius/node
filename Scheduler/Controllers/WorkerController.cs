using Scheduler.Models.Providers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Scheduler.Controllers
{
    public class WorkerController : ApiController
    {
        private IWorkerProvider _workerProvider;

        public WorkerController()
        {
            _workerProvider = new AppSettingsWorkerProvider();
        }

        [HttpGet]
        [Route("{controllerName}")]
        public async Task<HttpResponseMessage> Get(string controllerName)
        {
            string method = "get";
            Uri baseUri = new Uri(_workerProvider.Url);
            Uri fullUri = new Uri(baseUri,  controllerName);
            WebRequest request = WebRequest.Create(fullUri);
            request.Method = method;
            var workerResponse = (HttpWebResponse)await request.GetResponseAsync();
            using (var reader = new StreamReader(workerResponse.GetResponseStream()))
            {
                var response = Request.CreateResponse(workerResponse.StatusCode);
                var content = await reader.ReadToEndAsync();
                response.Content = new StringContent(content, Encoding.UTF8, workerResponse.ContentType.Split(';')[0]);
                return response;
            }
        }

        [HttpPost]
        [Route("{controllerName}")]
        public async Task<HttpResponseMessage> Post(string controller)
        {
            string method = "post";
            Uri baseUri = new Uri(_workerProvider.Url);
            Uri fullUri = new Uri(baseUri, controller);
            WebRequest request = WebRequest.Create(fullUri);

            request.Method = method;
            var requestSream = await request.GetRequestStreamAsync();
            var requestContent = await Request.Content.ReadAsByteArrayAsync();
            await requestSream.WriteAsync(requestContent, 0, requestContent.Length);

            var workerResponse = (HttpWebResponse)await request.GetResponseAsync();
            using (var reader = new StreamReader(workerResponse.GetResponseStream()))
            {
                var response = Request.CreateResponse(workerResponse.StatusCode);
                var content = await reader.ReadToEndAsync();
                response.Content = new StringContent(content, Encoding.UTF8, workerResponse.ContentType.Split(';')[0]);
                return response;
            }
        }
    }
}
