using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace AgGateway.ADAPT.ADMPlugin
{

    public interface IAdmVersionInfoWriter
    {
        void WriteVersionInfoFile(string filename);
    }

    public class AdmVersionInfoWriter : IAdmVersionInfoWriter
    {
        public void WriteVersionInfoFile(string filename)
        {
            var directory = Path.GetDirectoryName(filename);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            var version = Assembly.GetExecutingAssembly().GetName().Version;
            var versionModel = new AdmVersionInfoModel() {AdmVersion = version.ToString()};
            var versionModelString = JsonConvert.SerializeObject(versionModel);

            File.WriteAllText(filename, versionModelString);
        }
    }
}
