using System.IO;
using System.Reflection;
using AgGateway.ADAPT.ADMPlugin.Json;
using AgGateway.ADAPT.ADMPlugin.Models;
using Newtonsoft.Json;

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
      dynamic json = JsonConvert.DeserializeObject(fileString);

      // due to a breaking change in Newtonsoft between Core 2.0 and Core 3.1+, need to handle version info that was originally emitted as a dict rather than a string.
      // 3.1+ expects the version info to be in a string format therefore we use this logic to convert to a string if the PluginVersion type is null (not a primitive type).
      if (json["PluginVersion"] != null && json["PluginVersion"].Type == null)
      {
        var major = json["PluginVersion"].Major;
        var minor = json["PluginVersion"].Minor;
        var build = json["PluginVersion"].Build;
        var revision = json["PluginVersion"].Revision;

        json["PluginVersion"] = $"{major}.{minor}.{build}.{revision}";
      }
            
      var model = JsonConvert.DeserializeObject<AdmVersionInfo>(json.ToString());
      return model;
    }
  }
}
