using System;
using System.Collections.Generic;
using System.IO;
using AgGateway.ADAPT.ADMPlugin.Json;
using AgGateway.ADAPT.ADMPlugin.Serializers;
using Newtonsoft.Json;

namespace AgGateway.ADAPT.ADMPlugin.Json
{
  public class BaseJsonSerializer : IBaseSerializer
  {
    private static BaseJsonSerializer _instance;

    public static BaseJsonSerializer Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new BaseJsonSerializer();
        }
        return _instance;
      }
    }

    private readonly JsonSerializer _jsonSerializer;

    private BaseJsonSerializer()
    {
      _jsonSerializer = new JsonSerializer
      {
        NullValueHandling = NullValueHandling.Ignore,
        DefaultValueHandling = DefaultValueHandling.Ignore,
        TypeNameHandling = TypeNameHandling.All,
        ContractResolver = new AdaptContractResolver(),
        SerializationBinder = new InternalSerializationBinder()
      };
    }

    public void Serialize<T>(T dataModel, string path)
    {
      var tempPath = Path.GetTempFileName();
      try
      {
        using (var fileStream = File.Open(tempPath, FileMode.Create, FileAccess.ReadWrite))
        using (var streamWriter = new StreamWriter(fileStream))
        using (var textWriter = new JsonTextWriter(streamWriter) { Formatting = Formatting.Indented })
        {
          _jsonSerializer.Serialize(textWriter, dataModel);
        }
        ZipUtil.Zip(path, tempPath);
      }
      finally
      {
        try
        {
          File.Delete(tempPath);
        }
        catch { }
      }
    }

    public T Deserialize<T>(string path)
    {
      var tempPath = Path.GetTempFileName();
      try
      {
        ZipUtil.Unzip(path, tempPath);

        using (var fileStream = File.Open(tempPath, FileMode.Open))
        using (var streamReader = new StreamReader(fileStream))
        using (var textReader = new InternalJsonTextReader(streamReader))
        {
          return _jsonSerializer.Deserialize<T>(textReader);
        }
      }
      finally
      {
        try
        {
          File.Delete(tempPath);
        }
        catch { }
      }
    }

    public void SerializeWithLengthPrefix<T>(IEnumerable<T> content, string path) where T : new()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<T> DeserializeWithLengthPrefix<T>(string path) where T : new()
    {
      throw new NotImplementedException();
    }
  }
}
