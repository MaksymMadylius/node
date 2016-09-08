using System.Xml;

namespace Measurement.Repositories
{
    public class FileRepository : IFileRepository
    {
        public void AppendToTxtFile(string filePath, string data)
        {
            System.IO.File.AppendText(data);
        }

        public string GetTxtDocument(string filePath)
        {
            return System.IO.File.ReadAllText(filePath);
        }

        public XmlDocument GetXmlDocument(string filePath)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            return xmlDoc;
        }
    }
}
