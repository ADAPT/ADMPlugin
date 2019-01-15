using System;
using System.Collections.Generic;
using System.Text;

namespace AgGateway.ADAPT.ADMPlugin.Serializers
{
    public interface IAdmSerializer
    {
        IVersionInfoSerializer VersionSerializer { get; }

        void Serialize(ApplicationDataModel.ADM.ApplicationDataModel dataModel, string path);

        ApplicationDataModel.ADM.ApplicationDataModel Deserialize(string path);
    }
}
