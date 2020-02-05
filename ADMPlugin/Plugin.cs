using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AgGateway.ADAPT.ADMPlugin.Serializers;
using AgGateway.ADAPT.ApplicationDataModel.ADM;

namespace AgGateway.ADAPT.ADMPlugin
{
  public class Plugin : IPlugin
  {
    IAdmSerializer _admSerializer;

    public Plugin() : this(new AdmSerializer())
    {
    }

    public Plugin(SerializationVersionEnum defaultSerializationVersion) : this(new AdmSerializer(defaultSerializationVersion))
    {
    }

    public Plugin(IAdmSerializer admSerializer)
    {
      _admSerializer = admSerializer;
    }

    public string Name => "ADM";

    public string Owner => "AgGateway";

    public string Version => Assembly.GetExecutingAssembly().GetName().Version.ToString();

    public IList<IError> Errors { get; set; }

    public void Initialize(string args = null)
    {
    }
    public Properties GetProperties(string dataPath)
    {
      return new Properties();
    }

    public bool IsDataCardSupported(string path, Properties properties = null)
    {
      var dataPath = Path.Combine(path, DatacardConstants.DataFolder);

      if (!(Directory.Exists(dataPath) && Directory.GetFiles(dataPath, String.Format(DatacardConstants.FileFormat, "*"), SearchOption.AllDirectories).Any()))
      {
        return false;
      }

      var currentVersion = Assembly.GetExecutingAssembly().GetName().Version;

      var dataVersionInfo = _admSerializer.VersionSerializer.Deserialize(dataPath);

      if (dataVersionInfo == null || dataVersionInfo.PluginVersion == null)
      {
        return true;
      }

      if (currentVersion.Major >= dataVersionInfo.PluginVersion.Major)
      {
        return true;
      }

      return false;
    }

    public IList<IError> ValidateDataOnCard(string path, Properties properties = null)
    {
      return new List<IError>();
    }

    public IList<ApplicationDataModel.ADM.ApplicationDataModel> Import(string path, Properties properties = null)
    {
      if (!IsDataCardSupported(path, properties))
      {
        return null;
      }

      return new List<ApplicationDataModel.ADM.ApplicationDataModel>
            {
                _admSerializer.Deserialize(path)
            };
    }

    public void Export(ApplicationDataModel.ADM.ApplicationDataModel dataModel, string path, Properties properties = null)
    {
      _admSerializer.Serialize(dataModel, path);
    }
  }
}
