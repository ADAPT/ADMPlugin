using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AgGateway.ADAPT.ADMPlugin.Json
{
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
