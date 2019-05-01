using System;
using System.Collections.Generic;
using System.Reflection;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AgGateway.ADAPT.ADMPlugin.Json
{
  public class AdaptContractResolver : DefaultContractResolver
  {
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
      var property = base.CreateProperty(member, memberSerialization);

      if (property.PropertyType == typeof(Func<IEnumerable<SpatialRecord>>)
          || property.PropertyType == typeof(Func<int, IEnumerable<DeviceElementUse>>)
          || property.PropertyType == typeof(Func<IEnumerable<WorkingData>>)
          || property.PropertyType == typeof(IEnumerable<DeviceElementUse>)
          || property.PropertyType == typeof(IEnumerable<WorkingData>))
      {
        return null;
      }

      return property;
    }
  }
}
