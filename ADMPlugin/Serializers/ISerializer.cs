using System;
using System.Collections.Generic;
using System.Text;

namespace AgGateway.ADAPT.ADMPlugin.Serializers
{
    public interface ISerializer<T>
    {
        void Serialize(IBaseSerializer baseSerializer, T content, string path);

        T Deserialize(IBaseSerializer baseSerializer, string path);
    }
}
