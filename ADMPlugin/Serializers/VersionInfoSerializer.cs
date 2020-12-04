using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using AgGateway.ADAPT.ADMPlugin.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

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

  public class NetCoreApp31CompatibleVersionConverter : JsonConverter<Version>
  {
      public override void WriteJson(JsonWriter writer, Version value, JsonSerializer serializer)
      {
          throw new NotImplementedException();
      }

      public override Version ReadJson(JsonReader reader, Type objectType, Version existingValue, bool hasExistingValue,
          JsonSerializer serializer)
      {
          if (existingValue != null)
              return existingValue;

          var versionJObject = JToken.ReadFrom(reader);

          if (Version.TryParse(versionJObject.ToString(), out var version))
              return version;


          var versionString = $"{versionJObject.Value<string>("Major")}.{versionJObject.Value<string>("Minor")}.{versionJObject.Value<string>("Build")}.{versionJObject.Value<string>("Revision")}";
          return Version.Parse(versionString);
      }
  }
}
