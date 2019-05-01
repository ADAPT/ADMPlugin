using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace AgGateway.ADAPT.ADMPlugin.Json
{
  public class InternalJsonTextReader : JsonTextReader
  {
    private readonly Dictionary<string, string> _version108To110ChangedPropertyNames = new Dictionary<string, string>
        {
            {"DeviceConfigurationId", "DeviceElementConfigurationId"}
        };

    public InternalJsonTextReader(TextReader reader) : base(reader)
    {

    }

    public override object Value
    {
      get
      {
        var value = base.Value;

        if (TokenType != JsonToken.PropertyName)
          return value;

        if (_version108To110ChangedPropertyNames.ContainsKey(value.ToString()))
        {
          return _version108To110ChangedPropertyNames[value.ToString()];
        }

        return value;
      }
    }
  }
}
