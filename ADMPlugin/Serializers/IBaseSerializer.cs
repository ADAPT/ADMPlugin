using System;
using System.Collections.Generic;
using System.Text;

namespace AgGateway.ADAPT.ADMPlugin.Serializers
{
    public interface IBaseSerializer
    {
        void Serialize<T>(T content, string path);

        T Deserialize<T>(string path);

        void SerializeWithLengthPrefix<T>(IEnumerable<T> content, string path) where T : new();

        IEnumerable<T> DeserializeWithLengthPrefix<T>(string path) where T : new();
    }
}
