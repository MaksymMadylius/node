using Measurement.Repositories;
using Newtonsoft.Json.Linq;


namespace Measurement.Providers.JsonProviders
{
    public class TextJsonProvider: BaseJsonFileProvider, IJsonProvider
    {
        public TextJsonProvider(string filePath): base(filePath)
        {
            fileRepository = new FileRepository();
        }

        public JArray GetJson()
        {
            var jsonsStr = fileRepository.GetTxtDocument(filePath);
            var jArr = JArray.Parse(jsonsStr);

            return jArr;
        }
    }
}
