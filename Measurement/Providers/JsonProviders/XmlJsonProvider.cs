using System;
using System.Collections.Generic;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Measurement.Repositories;

namespace Measurement.Providers.JsonProviders
{
    public class XmlJsonProvider: BaseJsonFileProvider, IJsonProvider
    {
        public XmlJsonProvider(string xmlPath): base(xmlPath)
        {
            fileRepository = new FileRepository();
        }

        public JArray GetJson()
        {
            var xmlNodeList = fileRepository.GetXmlDocument(filePath).DocumentElement.ChildNodes;

            var jArray = new JArray();
            foreach(XmlNode node in xmlNodeList)
            {
                var jObjStr = JsonConvert.SerializeXmlNode(node);
                jArray.Add(JObject.Parse(jObjStr));
            }

            return jArray;
        }
    }
}
