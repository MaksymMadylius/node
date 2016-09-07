using Newtonsoft.Json.Linq;

namespace Scheduler.IntegrationTests.Providers
{
    public interface IJsonProvider
    {
        JArray GetJson();
    }
}
