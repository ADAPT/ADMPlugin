using System.IO;
using Newtonsoft.Json;

namespace AgGateway.ADAPT.ADMPlugin
{
    public interface IAdmVersionInfoReader
    {
        AdmVersionInfoModel ReadVersionInfoModel(string filename);
    }

    public class AdmVersionInfoReader : IAdmVersionInfoReader
    {
        public AdmVersionInfoModel ReadVersionInfoModel(string filename)
        {
            if (!File.Exists(filename))
                return null;

            var fileString = File.ReadAllText(filename);

            var model = JsonConvert.DeserializeObject<AdmVersionInfoModel>(fileString);
            return model;
        }
    }
}
