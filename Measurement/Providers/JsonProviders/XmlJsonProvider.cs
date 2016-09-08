using System;
using System.Collections.Generic;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Measurement.Providers.JsonProviders
{
    public class XmlJsonProvider : IJsonProvider
    {
        #region Private

        private readonly string _xmlPath;

        #endregion

        #region Ctors

        public XmlJsonProvider(string xmlPath)
        {
            _xmlPath = xmlPath;
        }

        #endregion

        #region Methods

        public JArray GetJson()
        {
            var xmlNodeList = GetXmlDocument();

            var jArray = new JArray();
            foreach(XmlNode node in xmlNodeList)
            {
                var jObjStr = JsonConvert.SerializeXmlNode(node);
                jArray.Add(JObject.Parse(jObjStr));
            }

            return jArray;
        }

        #endregion

        #region Helpers

        private XmlNodeList GetXmlDocument()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(_xmlPath);

            return xmlDoc.DocumentElement.ChildNodes;
        }

        #endregion
    }
}
