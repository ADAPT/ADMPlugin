using System.Collections.Generic;
using System.Linq;
using AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ADMPlugin
{
    public interface IProtobufReferenceLayerConverter
    {
        SerializableReferenceLayer ConvertToSerializableReferenceLayer(ReferenceLayer referenceLayer);
        ReferenceLayer ConvertToReferenceLayer(SerializableReferenceLayer serializableReferenceLayer);
    }

    public class ProtobufReferenceLayerConverter : IProtobufReferenceLayerConverter
    {
        public SerializableReferenceLayer ConvertToSerializableReferenceLayer(ReferenceLayer referenceLayer)
        {
            if (referenceLayer.GetType() == typeof(RasterReferenceLayer))
            {
                var rasterReferenceLayer = referenceLayer as RasterReferenceLayer;
                var stringValues = GetStringValues(rasterReferenceLayer);
                var enumeratedValues = GetEnumeratedValues(rasterReferenceLayer);
                var numericValues = GetNumericValues(rasterReferenceLayer);
                return new SerializableReferenceLayer()
                {
                    RasterReferenceLayer = rasterReferenceLayer,
                    StringValues = stringValues,
                    EnumerationMemberValues = enumeratedValues,
                    NumericValueValues = numericValues
                };
            }

            if (referenceLayer.GetType() == typeof(ShapeReferenceLayer))
            {
                var shapeReferenceLayer = referenceLayer as ShapeReferenceLayer;

                if (shapeReferenceLayer != null && (shapeReferenceLayer.ShapeLookups == null || !shapeReferenceLayer.ShapeLookups.Any()))
                    return new SerializableReferenceLayer { ShapeReferenceLayer = shapeReferenceLayer };

                return new SerializableReferenceLayer
                {
                    ShapeReferenceLayer = shapeReferenceLayer,
                    ShapeLookupValues = new List<SerializableShapeData> { new SerializableShapeData { shapeLookups = shapeReferenceLayer?.ShapeLookups } }
                };
            }

            return null;
        }

        private List<SerializableRasterData<NumericValue>> GetNumericValues(RasterReferenceLayer rasterReferenceLayer)
        {
            if (rasterReferenceLayer.NumericRasterValues == null)
                return null;

            var data = new List<SerializableRasterData<NumericValue>>();
            foreach (var rasterValue in rasterReferenceLayer.NumericRasterValues)
            {
                var list = new List<NumericValue>();
                for (int i = 0; i < rasterReferenceLayer.ColumnCount; i++)
                {
                    for (int j = 0; j < rasterReferenceLayer.RowCount; j++)
                    {
                        list.Add(rasterValue.Values[i, j]);
                    }
                }
                data.Add(new SerializableRasterData<NumericValue> { values = list, Representation = rasterValue.Representation });
            }
            return data;
        }

        private List<SerializableRasterData<EnumerationMember>> GetEnumeratedValues(RasterReferenceLayer rasterReferenceLayer)
        {
            if (rasterReferenceLayer.EnumeratedRasterValues == null)
                return null;

            var data = new List<SerializableRasterData<EnumerationMember>>();
            foreach (var rasterValue in rasterReferenceLayer.EnumeratedRasterValues)
            {
                var list = new List<EnumerationMember>();

                for (int i = 0; i < rasterReferenceLayer.ColumnCount; i++)
                {
                    for (int j = 0; j < rasterReferenceLayer.RowCount; j++)
                    {
                        list.Add(rasterValue.Values[i, j]);
                    }
                }
                data.Add(new SerializableRasterData<EnumerationMember> { values = list, Representation = rasterValue.Representation });
            }
            return data;
        }

        private List<SerializableRasterData<string>> GetStringValues(RasterReferenceLayer rasterReferenceLayer)
        {
            if (rasterReferenceLayer.StringRasterValues == null)
                return null;

            var data = new List<SerializableRasterData<string>>();

            foreach (var stringRasterValue in rasterReferenceLayer.StringRasterValues)
            {
                var list = new List<string>();

                for (int i = 0; i < rasterReferenceLayer.ColumnCount; i++)
                {
                    for (int j = 0; j < rasterReferenceLayer.RowCount; j++)
                    {
                        list.Add(stringRasterValue.Values[i, j]);
                    }
                }

                data.Add(new SerializableRasterData<string> { values = list, Representation = stringRasterValue.Representation });
            }
            return data;
        }

        public ReferenceLayer ConvertToReferenceLayer(SerializableReferenceLayer serializableReferenceLayer)
        {
            if (serializableReferenceLayer.RasterReferenceLayer != null)
            {
                var convertToReferenceLayer = serializableReferenceLayer.RasterReferenceLayer;
                convertToReferenceLayer.StringRasterValues = GetStringValues(serializableReferenceLayer);
                convertToReferenceLayer.EnumeratedRasterValues = GetEnumeratedValues(serializableReferenceLayer);
                convertToReferenceLayer.NumericRasterValues = GetNumericValues(serializableReferenceLayer);
                return convertToReferenceLayer;
            }

            if (serializableReferenceLayer.ShapeReferenceLayer != null)
            {
                var convertToShapeReferenceLayer = serializableReferenceLayer.ShapeReferenceLayer;

                if (serializableReferenceLayer.ShapeLookupValues == null || !serializableReferenceLayer.ShapeLookupValues.Any())
                    return convertToShapeReferenceLayer;

                convertToShapeReferenceLayer.ShapeLookups = serializableReferenceLayer.ShapeLookupValues
                                                                .Where(a => a.shapeLookups != null)
                                                                .SelectMany(a => a.shapeLookups).ToList();

                return convertToShapeReferenceLayer;
            }

            return null;
        }

        private List<RasterData<NumericRepresentation, NumericValue>> GetNumericValues(SerializableReferenceLayer serializableReferenceLayer)
        {
            var values = serializableReferenceLayer.NumericValueValues;
            if (values == null || !values.Any())
                return null;

            var rowCount = serializableReferenceLayer.RasterReferenceLayer.RowCount;
            var columnCount = serializableReferenceLayer.RasterReferenceLayer.ColumnCount;

            var data = new List<RasterData<NumericRepresentation, NumericValue>>();
            foreach (var value in values)
            {
                var list = new NumericValue[columnCount, rowCount];
                for (int i = 0; i < columnCount; i++)
                {
                    for (int j = 0; j < rowCount; j++)
                    {
                        list[i, j] = value.values[i * rowCount + j];
                    }
                }
                data.Add(new RasterData<NumericRepresentation, NumericValue> { Values = list, Representation = value.Representation as NumericRepresentation });
            }

            return data;
        }

        private List<RasterData<EnumeratedRepresentation, EnumerationMember>> GetEnumeratedValues(SerializableReferenceLayer serializableReferenceLayer)
        {
            var values = serializableReferenceLayer.EnumerationMemberValues;
            if (values == null || !values.Any())
                return null;

            var rowCount = serializableReferenceLayer.RasterReferenceLayer.RowCount;
            var columnCount = serializableReferenceLayer.RasterReferenceLayer.ColumnCount;

            var data = new List<RasterData<EnumeratedRepresentation, EnumerationMember>>();
            foreach (var value in values)
            {
                var list = new EnumerationMember[columnCount, rowCount];
                for (int i = 0; i < columnCount; i++)
                {
                    for (int j = 0; j < rowCount; j++)
                    {
                        list[i, j] = value.values[i * rowCount + j];
                    }
                }
                data.Add(new RasterData<EnumeratedRepresentation, EnumerationMember> { Values = list, Representation = value.Representation as EnumeratedRepresentation });
            }
            return data;
        }

        private List<RasterData<StringRepresentation, string>> GetStringValues(SerializableReferenceLayer serializableReferenceLayer)
        {
            var values = serializableReferenceLayer.StringValues;
            if (values == null || !values.Any())
                return null;

            var rowCount = serializableReferenceLayer.RasterReferenceLayer.RowCount;
            var columnCount = serializableReferenceLayer.RasterReferenceLayer.ColumnCount;

            var data = new List<RasterData<StringRepresentation, string>>();
            foreach (var value in values)
            {

                var list = new string[columnCount, rowCount];
                for (int i = 0; i < columnCount; i++)
                {
                    for (int j = 0; j < rowCount; j++)
                    {
                        list[i, j] = value.values[i * rowCount + j];
                    }
                }

                data.Add(new RasterData<StringRepresentation, string> { Values = list, Representation = value.Representation as StringRepresentation });
            }

            return data;
        }
    }
}
