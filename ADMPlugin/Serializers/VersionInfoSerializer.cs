using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using AgGateway.ADAPT.ADMPlugin.Json;
using AgGateway.ADAPT.ADMPlugin.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AgGateway.ADAPT.ADMPlugin.Serializers
{
  public class VersionInfoSerializer : IVersionInfoSerializer
  {
    public void Serialize(SerializationVersionEnum serializationVersion, string dataPath)
    {
      if (!Directory.Exists(dataPath))
      {
        Directory.CreateDirectory(dataPath);
      }

      var version = Assembly.GetExecutingAssembly().GetName().Version;
      var versionModel = new AdmVersionInfo()
      {
        PluginVersion = version,
        SerializationVersion = serializationVersion
      };

      var versionModelString = JsonConvert.SerializeObject(versionModel);
      File.WriteAllText(Path.Combine(dataPath, DatacardConstants.VersionFile), versionModelString);
    }

    public AdmVersionInfo Deserialize(string dataPath)
    {
      var filePath = Path.Combine(dataPath, DatacardConstants.VersionFile);

      if (!File.Exists(filePath))
      {
        return null;
      }

      var fileString = File.ReadAllText(filePath);

      var model = JsonConvert.DeserializeObject<AdmVersionInfo>(fileString, new NetCoreApp31CompatibleVersionConverter());
      return model;
    }
  }
}
