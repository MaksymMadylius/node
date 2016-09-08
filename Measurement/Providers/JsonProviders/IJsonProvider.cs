using Newtonsoft.Json.Linq;

namespace Measurement.Providers.JsonProviders
{
    public interface IJsonProvider
    {
        JArray GetJson();
    }
}
