using System.Xml;

namespace Measurement.Repositories
{
    public interface IFileRepository
    {
        XmlDocument GetXmlDocument(string filePath);

        string GetTxtDocument(string filePath);

        void AppendToTxtFile(string filePath, string data);
    }
}
