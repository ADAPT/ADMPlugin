using System.Collections.Generic;
using System.Linq;
using AgGateway.ADAPT.ADMPlugin.Models;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.Representation.RepresentationSystem.ExtensionMethods;
using AgGateway.ADAPT.Representation.UnitSystem.ExtensionMethods;

namespace AgGateway.ADAPT.ADMPlugin.Converters
{
    public class SpatialRecordConverter : ISpatialRecordConverter
    {
        public IEnumerable<SpatialRecord> ConvertToSpatialRecords(IEnumerable<SerializableSpatialRecord> protobufSpatialRecords, IEnumerable<WorkingData> workingData)
        {
            if (protobufSpatialRecords == null || workingData == null)
            {
                return Enumerable.Empty<SpatialRecord>();
            }

            var workingDataById = workingData.ToDictionary(meter => meter.Id.ReferenceId, meter => meter);

            return protobufSpatialRecords.Select(protobufSpatialRecord => ConvertToSpatialRecord(protobufSpatialRecord, workingDataById));
        }

        public IEnumerable<SerializableSpatialRecord> ConvertToSerializableSpatialRecords(IEnumerable<SpatialRecord> spatialRecords, List<WorkingData> workingData)
        {
            if (spatialRecords == null || workingData == null)
            {
                return Enumerable.Empty<SerializableSpatialRecord>();
            }

            return spatialRecords.Select(spatialRecord => ConvertToSerializableSpatialRecord(spatialRecord, workingData));
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
                ConvertEnumeratedValue(workingDataById, enumeratedMeterValue, spatialRecord);
            }
            foreach (var numericMeterValue in protobufSpatialRecord.NumericMeterValues)
            {
                ConvertNumericValue(workingDataById, numericMeterValue, spatialRecord);
            }
            foreach (var stringMeterValue in protobufSpatialRecord.StringMeterValues)
            {
                ConvertStringValue(workingDataById, stringMeterValue, spatialRecord);
            }

            return spatialRecord;
        }

        private static void ConvertStringValue(Dictionary<int, WorkingData> workingDataById, KeyValuePair<int, string> stringMeterValue, SpatialRecord spatialRecord)
        {
            var workingData = workingDataById[stringMeterValue.Key];
            var stringValue = new StringValue
            {
                Representation = workingData.Representation as StringRepresentation,
                Value = stringMeterValue.Value
            };
            spatialRecord.SetMeterValue(workingData, stringValue);
        }

        private static void ConvertNumericValue(Dictionary<int, WorkingData> workingDataById, KeyValuePair<int, double> numericMeterValue, SpatialRecord spatialRecord)
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

        private static void ConvertEnumeratedValue(Dictionary<int, WorkingData> workingDataById, KeyValuePair<int, long> enumeratedMeterValue, SpatialRecord spatialRecord)
        {
            var workingData = workingDataById[enumeratedMeterValue.Key] as EnumeratedWorkingData;
            var representation = workingData.Representation as EnumeratedRepresentation;
            var enumeratedValue = representation.ToInternalRepresentation().EnumerationMembers[enumeratedMeterValue.Value].ToModelEnumMember();
            var value = new EnumeratedValue
            {
                Representation = representation,
                Value = enumeratedValue,
                Code = (int?)enumeratedMeterValue.Value
            };
            spatialRecord.SetMeterValue(workingData, value);
        }

        private static SerializableSpatialRecord ConvertToSerializableSpatialRecord(SpatialRecord spatialRecord, List<WorkingData> workingData)
        {
            var serializableSpatialRecord = new SerializableSpatialRecord()
            {
                Geometry = spatialRecord.Geometry,
                Timestamp = spatialRecord.Timestamp
            };

            foreach (var currentWorkingData in workingData)
            {
                var appliedLatency = spatialRecord.GetAppliedLatency(currentWorkingData);
                if (appliedLatency.HasValue)
                {
                    serializableSpatialRecord.AppliedLatencyValues[currentWorkingData.Id.ReferenceId] = appliedLatency;
                }

                var meterValue = spatialRecord.GetMeterValue(currentWorkingData);
                switch (meterValue)
                {
                    case null:
                        break;
                    case NumericRepresentationValue numericValue:
                        var numericWorkingData = currentWorkingData as NumericWorkingData;
                        if (numericWorkingData.UnitOfMeasure == null)
                        {
                            numericWorkingData.UnitOfMeasure = numericValue.Value.UnitOfMeasure;
                        }
                        double value = numericValue.Value.ConvertToUnit(numericWorkingData.UnitOfMeasure.ToInternalUom());
                        serializableSpatialRecord.NumericMeterValues[currentWorkingData.Id.ReferenceId] = value;
                        break;
                    case EnumeratedValue enumeratedValue:
                        serializableSpatialRecord.EnumeratedMeterValues[currentWorkingData.Id.ReferenceId] = enumeratedValue.Value.Code;
                        break;
                    case StringValue stringValue:
                        serializableSpatialRecord.StringMeterValues[currentWorkingData.Id.ReferenceId] = stringValue.Value;
                        break;
                }
            }

            return serializableSpatialRecord;
        }
    }
}
