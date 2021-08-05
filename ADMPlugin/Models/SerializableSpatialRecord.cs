using System;
using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;
using ProtoBuf;

namespace AgGateway.ADAPT.ADMPlugin.Models
{
    [ProtoContract]
    public class SerializableSpatialRecord
    {
        public SerializableSpatialRecord()
        {
            AppliedLatencyValues = new Dictionary<int, int?>();
            NumericMeterValues = new Dictionary<int, double>();
            EnumeratedMeterValues = new Dictionary<int, long>();
            StringMeterValues = new Dictionary<int, string>();
        }

        [ProtoMember(1)]
        public Shape Geometry { get; set; }

        [ProtoMember(2)]
        public DateTime Timestamp { get; set; }

        [ProtoMember(3)]
        public Dictionary<int, int?> AppliedLatencyValues { get; set; }

        [ProtoMember(4)]
        public Dictionary<int, double> NumericMeterValues { get; set; }

        [ProtoMember(5)]
        public Dictionary<int, long> EnumeratedMeterValues { get; set; }

        [ProtoMember(6)]
        public Dictionary<int, string> StringMeterValues { get; set; }

    }
}
