using System.Web.Configuration;

namespace Scheduler.Models.Providers
{
    public class AppSettingsWorkerProvider : IWorkerProvider
    {
        public string Url
        {
            get
            {
                return WebConfigurationManager.AppSettings["WorkerUrl"];
            }
        }
    }
}