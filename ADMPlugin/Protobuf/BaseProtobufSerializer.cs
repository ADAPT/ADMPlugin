using System;
using System.Collections.Generic;
using System.IO;
using AgGateway.ADAPT.ADMPlugin.Models;
using AgGateway.ADAPT.ADMPlugin.Protobuf;
using AgGateway.ADAPT.ADMPlugin.Protobuf.V1;
using AgGateway.ADAPT.ADMPlugin.Protobuf.V2;
using AgGateway.ADAPT.ADMPlugin.Serializers;
using AgGateway.ADAPT.ApplicationDataModel.ADM;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Documents;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries;
using AgGateway.ADAPT.ApplicationDataModel.Guidance;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.ApplicationDataModel.Logistics;
using AgGateway.ADAPT.ApplicationDataModel.Notes;
using AgGateway.ADAPT.ApplicationDataModel.Prescriptions;
using AgGateway.ADAPT.ApplicationDataModel.Products;
using AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers;
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;
using ProtoBuf;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf
{
  public class BaseProtobufSerializer : IBaseSerializer
  {
    private static BaseProtobufSerializer _instanceV1;
    private static BaseProtobufSerializer _instanceV2;

    public static BaseProtobufSerializer InstanceV1
    {
      get
      {
        if (_instanceV1 == null)
        {
          _instanceV1 = new BaseProtobufSerializer(AdaptTypeModelV1.CreateTypeModel());
        }
        return _instanceV1;
      }
    }

    public static BaseProtobufSerializer InstanceV2
    {
      get
      {
        if (_instanceV2 == null)
        {
          _instanceV2 = new BaseProtobufSerializer(AdaptTypeModelV2.CreateTypeModel());
        }
        return _instanceV2;
      }
    }

    private readonly RuntimeTypeModel _model;

    private BaseProtobufSerializer(RuntimeTypeModel model)
    {
      _model = model;
    }

    public void Serialize<T>(T content, string path)
    {
      var directoryPath = Path.GetDirectoryName(path);
      if (!Directory.Exists(directoryPath))
      {
        Directory.CreateDirectory(directoryPath);
      }

      var type = content.GetType();
      if (!type.Namespace.StartsWith("System") && !type.Namespace.StartsWith("AgGateway.ADAPT.ApplicationDataModel"))
      {
        var baseType = type.BaseType;
        Serialize(Convert.ChangeType(content, baseType), path);
      }
      else
      {
        using (var fileStream = File.Open(path, FileMode.Create))
        {
          _model.Serialize(fileStream, content);
        }
      }
    }

    public T Deserialize<T>(string path)
    {
      using (var fileStream = File.OpenRead(path))
      {
        return (T)_model.Deserialize(fileStream, null, typeof(T));
      }
    }

    public void SerializeWithLengthPrefix<T>(IEnumerable<T> content, string path) where T : new()
    {
      using (var fileStream = File.Open(path, FileMode.Create))
      {
        foreach (var item in content)
        {
          _model.SerializeWithLengthPrefix(fileStream, item, typeof(T), PrefixStyle.Base128, 1);
        }
      }
    }

    public IEnumerable<T> DeserializeWithLengthPrefix<T>(string path) where T : new()
    {
      var itemCol = new List<T>();

      using (var fileStream = File.OpenRead(path))
      {
        while (!IsEndOfStream(fileStream))
        {
          var item = new T();
          _model.DeserializeWithLengthPrefix(fileStream, item, typeof(T), PrefixStyle.Base128, 1);
          itemCol.Add(item);
        }
      }

      return itemCol;
    }

    private bool IsEndOfStream(FileStream fileStream)
    {
      return fileStream.Position + 20 > fileStream.Length;
    }
  }
}
