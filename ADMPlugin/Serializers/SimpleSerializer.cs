using System.IO;
using AgGateway.ADAPT.ApplicationDataModel.ADM;

namespace AgGateway.ADAPT.ADMPlugin.Serializers
{
  public class SimpleSerializer<T> : ISerializer<T> where T : new()
  {
    private readonly string _fileName;

    public SimpleSerializer(string fileName)
    {
      _fileName = fileName;
    }

    public void Serialize(IBaseSerializer baseSerializer, T content, string dataPath)
    {
      if (content == null)
      {
        return;
      }

      var filePath = Path.Combine(dataPath, _fileName);

      baseSerializer.Serialize(content, filePath);
    }

    public T Deserialize(IBaseSerializer baseSerializer, string dataPath)
    {
      var filePath = Path.Combine(dataPath, _fileName);

      if (!File.Exists(filePath))
      {
        return new T();
      }

      return baseSerializer.Deserialize<T>(filePath);
    }
  }
}
