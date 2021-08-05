using System.Collections.Generic;
using System.Linq;
using AgGateway.ADAPT.ADMPlugin.Models;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.Representation.RepresentationSystem.ExtensionMethods;

namespace AgGateway.ADAPT.ADMPlugin.Converters
{
    public class SpatialRecordConverter
    {
        public static IEnumerable<SpatialRecord> ConvertToSpatialRecords(IEnumerable<SerializableSpatialRecord> protobufSpatialRecords, IEnumerable<WorkingData> workingData)
        {
            if (protobufSpatialRecords == null)
            {
                return Enumerable.Empty<SpatialRecord>();
            }

            var workingDataById = workingData.ToDictionary(meter => meter.Id.ReferenceId, meter => meter);

            return protobufSpatialRecords.Select(protobufSpatialRecord => ConvertToSpatialRecord(protobufSpatialRecord, workingDataById));
        }

        private static SpatialRecord ConvertToSpatialRecord(SerializableSpatialRecord protobufSpatialRecord, Dictionary<int, WorkingData> workingDataById)
        {
            if (protobufSpatialRecord == null)
            {
                return null;
            }

            var spatialRecord = new SpatialRecord
            {
                Geometry = protobufSpatialRecord.Geometry,
                Timestamp = protobufSpatialRecord.Timestamp
            };
            foreach (var appliedLatencyValue in protobufSpatialRecord.AppliedLatencyValues)
            {
                spatialRecord.SetAppliedLatency(workingDataById[appliedLatencyValue.Key], appliedLatencyValue.Value);
            }

            foreach (var enumeratedMeterValue in protobufSpatialRecord.EnumeratedMeterValues)
            {
                var workingData = workingDataById[enumeratedMeterValue.Key] as EnumeratedWorkingData;
                var representation = workingData?.Representation as EnumeratedRepresentation;
                var enumeratedValue = representation.ToInternalRepresentation().EnumerationMembers[enumeratedMeterValue.Value].ToModelEnumMember();
                var value = new EnumeratedValue
                {
                    Representation = representation,
                    Value = enumeratedValue,
                    Code = (int?)enumeratedMeterValue.Value
                };
                spatialRecord.SetMeterValue(workingData, value);
            }

            foreach (var numericMeterValue in protobufSpatialRecord.NumericMeterValues)
            {
                var workingData = workingDataById[numericMeterValue.Key] as NumericWorkingData;
                var representation = workingData.Representation as NumericRepresentation;
                var numericValue = new NumericRepresentationValue
                {
                    Representation = representation,
                    UserProvidedUnitOfMeasure = workingData.UnitOfMeasure,
                    Value = new NumericValue(workingData.UnitOfMeasure, numericMeterValue.Value)
                };
                spatialRecord.SetMeterValue(workingData, numericValue);
            }

            // TODO: String workingData
            // TODO: Reduce duplication
            // TODO: What about the missing crap on these RepresentationValue objects?

            return spatialRecord;
        }

        public static IEnumerable<SerializableSpatialRecord> ConvertToSerializableSpatialRecords(IEnumerable<SpatialRecord> spatialRecords, List<WorkingData> workingData)
        {
            if (spatialRecords == null)
            {
                return Enumerable.Empty<SerializableSpatialRecord>();
            }

            return spatialRecords.Select(spatialRecord => ConvertToSerializableSpatialRecord(spatialRecord, workingData));
        }

        private static SerializableSpatialRecord ConvertToSerializableSpatialRecord(SpatialRecord spatialRecord, List<WorkingData> workingData)
        {
            var serializableSpatialRecord = new SerializableSpatialRecord()
            {
                Geometry = spatialRecord.Geometry,
                Timestamp = spatialRecord.Timestamp
            };
            foreach (var meter in workingData)
            {
                var appliedLatency = spatialRecord.GetAppliedLatency(meter);
                if (appliedLatency.HasValue)
                {
                    serializableSpatialRecord.AppliedLatencyValues[meter.Id.ReferenceId] = appliedLatency;
                }

                var meterValue = spatialRecord.GetMeterValue(meter);
                switch (meterValue)
                {
                    case null:
                        break;
                    case NumericRepresentationValue numericValue:
                        serializableSpatialRecord.NumericMeterValues[meter.Id.ReferenceId] = numericValue.Value.Value;
                        break;
                    case EnumeratedValue enumeratedValue:
                        serializableSpatialRecord.EnumeratedMeterValues[meter.Id.ReferenceId] = enumeratedValue.Value.Code;
                        break;
                    case StringValue stringValue:
                        serializableSpatialRecord.StringMeterValues[meter.Id.ReferenceId] = stringValue.Value;
                        break;
                }
            }

            return serializableSpatialRecord;
        }
    }
}
