using System;
using Newtonsoft.Json.Linq;

namespace Measurement.Providers.JsonProviders
{
    public class JsonFabricProvider : IJsonProvider
    {
        private IJsonProvider _jSonProvider;

        public JsonFabricProvider(string providerType, object[] objs)
        {
            InitProvider(providerType, objs);
        }

        public JArray GetJson()
        {
            return _jSonProvider.GetJson();
        }

        protected void InitProvider(string providerType, object[] objs)
        {
            var type = Type.GetType(providerType);

            if (type == typeof(XmlJsonProvider))
            {
                _jSonProvider = (IJsonProvider)Activator.CreateInstance(type, objs);
            }
        }
    }
}
