using System;
using System.Collections.Generic;
using System.Reflection;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ADMPlugin
{
    public class AdaptContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (property.PropertyType == typeof(Func<IEnumerable<SpatialRecord>>) 
                || property.PropertyType == typeof(Func<int, IEnumerable<Section>>) 
                || property.PropertyType == typeof(Func<IEnumerable<Meter>>))
            {
                return null;
            }

            return property;
        }
    }
}
