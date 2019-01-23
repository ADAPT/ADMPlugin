using System;
using System.Collections.Generic;
using System.Text;
using AgGateway.ADAPT.ADMPlugin.Models;

namespace AgGateway.ADAPT.ADMPlugin.Serializers
{
    public interface IVersionInfoSerializer
    {
        void Serialize(SerializationVersionEnum serializationVersion, string dataPath);

        AdmVersionInfo Deserialize(string dataPath);
    }
}
