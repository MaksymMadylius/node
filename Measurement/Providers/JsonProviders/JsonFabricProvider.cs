using System;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Configuration;
using Measurement.Providers.DirectoryProviders;

namespace Measurement.Providers.JsonProviders
{
    public class JsonFabricProvider : IJsonProvider
    {
        private const string xmlJsonFileNameKey = "xmlJsonFile";

        private IJsonProvider _jSonProvider;

        public JsonFabricProvider(string providerType)
        {
            InitProvider(providerType);
        }

        public JArray GetJson()
        {
            return _jSonProvider.GetJson();
        }

        protected void InitProvider(string providerType)
        {
            var type = Type.GetType(providerType);

            if (type == typeof(XmlJsonProvider))
            {
                _jSonProvider = (IJsonProvider)Activator.CreateInstance(type, new[] { DirectoryProvider.GetFullPath(xmlJsonFileNameKey) });
            }
        }
    }
}
