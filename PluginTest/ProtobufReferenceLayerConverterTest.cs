using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADMPlugin;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers;
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace PluginTest
{
    [TestFixture]
    public class ProtobufReferenceLayerConverterTest
    {
        private RasterReferenceLayer _referenceLayer;
        private ProtobufReferenceLayerConverter _converter;

        [SetUp]
        public void Setup()
        {
            _referenceLayer = new RasterReferenceLayer();

            _converter = new ProtobufReferenceLayerConverter();
        }

        [Test]
        public void GivenRasterLayerWhenConvertToSerialThenIsConverted()
        {
            var rasterData = new RasterData<StringRepresentation, string>();
            var array2Db = new string[3, 2] { { "one", "two" }, { "three", "four" },
                                        { "five", "six" } };
            rasterData.Values = array2Db;
            var rasterDatas = new List<RasterData<StringRepresentation, string>> { rasterData };

            _referenceLayer.StringRasterValues = rasterDatas;
            _referenceLayer.ColumnCount = 3;
            _referenceLayer.RowCount = 2;

            var serializable = _converter.ConvertToSerializableReferenceLayer(_referenceLayer);

            Assert.AreEqual(3, serializable.ReferenceLayer.ColumnCount);
            Assert.AreEqual(2, serializable.ReferenceLayer.RowCount);

            var expectedStringValues = new List<string> {"one", "two", "three", "four", "five", "six"};

            for (int i = 0; i < expectedStringValues.Count; i++)
            {
                Assert.AreEqual(expectedStringValues[i], serializable.StringValues.First().values[i]);    
            }
        }

        [Test]
        public void GivenRasterLayersWhenConvertToSerialThenStringValuesAreConverted()
        {
            var rasterData = new RasterData<StringRepresentation, string>();
            var array2Db = new string[3, 2] {{"one", "two"}, {"three", "four"}, {"five", "six"}};
            rasterData.Values = array2Db;

            var rasterData2 = new RasterData<StringRepresentation, string>();
            var array2Db2 = new string[3, 2] {{"11", "12"}, {"13", "14"}, {"15", "16"}};
            rasterData2.Values = array2Db2;

            var rasterDatas = new List<RasterData<StringRepresentation, string>> {rasterData, rasterData2};
            _referenceLayer.StringRasterValues = rasterDatas;
            _referenceLayer.ColumnCount = 3;
            _referenceLayer.RowCount = 2;

            var serializable = _converter.ConvertToSerializableReferenceLayer(_referenceLayer);

            Assert.AreEqual(3, serializable.ReferenceLayer.ColumnCount);
            Assert.AreEqual(2, serializable.ReferenceLayer.RowCount);

            Assert.AreEqual(rasterDatas.Count, serializable.StringValues.Count);

            for (int rasterDataIndex = 0; rasterDataIndex < rasterDatas.Count; rasterDataIndex++)
            {
                var array = rasterDatas[rasterDataIndex].Values;
                var serializableData = serializable.StringValues[rasterDataIndex];

                for (int columnIndex = 0; columnIndex < _referenceLayer.ColumnCount; columnIndex++)
                {
                    for (int rowIndex = 0; rowIndex < _referenceLayer.RowCount; rowIndex++)
                    {
                        Assert.AreEqual(array[columnIndex, rowIndex],
                            serializableData.values[(columnIndex*_referenceLayer.RowCount) + rowIndex]);
                    }
                }
            }
        }

        [Test]
        public void GivenRasterLayerWithEnumeratedRepWhenConvertToSerialThenIsConverted()
        {
            var rasterData = new RasterData<EnumeratedRepresentation, EnumerationMember>();
            var array2Db = new EnumerationMember[3, 2] { { new EnumerationMember{Value = "1"}, new EnumerationMember{Value = "2"} }, { new EnumerationMember{Value = "3"}, new EnumerationMember{Value = "4"} },
                                        { new EnumerationMember{Value = "5"}, new EnumerationMember{Value = "6"} } };
            rasterData.Values = array2Db;
            var rasterDatas = new List<RasterData<EnumeratedRepresentation, EnumerationMember>> { rasterData };

            _referenceLayer.EnumeratedRasterValues = rasterDatas;
            _referenceLayer.ColumnCount = 3;
            _referenceLayer.RowCount = 2;

            var serializable = _converter.ConvertToSerializableReferenceLayer(_referenceLayer);

            Assert.AreEqual(3, serializable.ReferenceLayer.ColumnCount);
            Assert.AreEqual(2, serializable.ReferenceLayer.RowCount);

            var expectedStringValues = new List<string> { "1", "2", "3", "4", "5", "6" };

            for (int i = 0; i < expectedStringValues.Count; i++)
            {
                Assert.AreEqual(expectedStringValues[i], serializable.EnumerationMemberValues.First().values[i].Value);
            }
        }

        [Test]
        public void GivenRasterLayersWithEnumeratedRepWhenConvertToSerialThenEmnumeratedValuesAreConverted()
        {
            var rasterData = new RasterData<EnumeratedRepresentation, EnumerationMember>();
            var array2Db = new EnumerationMember[3, 2] { { new EnumerationMember{Value = "1"}, new EnumerationMember{Value = "2"} }, { new EnumerationMember{Value = "3"}, new EnumerationMember{Value = "4"} },
                                        { new EnumerationMember{Value = "5"}, new EnumerationMember{Value = "6"} } };
            rasterData.Values = array2Db;

            var rasterData2 = new RasterData<EnumeratedRepresentation, EnumerationMember>();
            var array2Db2 = new EnumerationMember[3, 2] { { new EnumerationMember{Value = "7"}, new EnumerationMember{Value = "8"} }, { new EnumerationMember{Value = "9"}, new EnumerationMember{Value = "10"} },
                                        { new EnumerationMember{Value = "11"}, new EnumerationMember{Value = "13"} } };
            rasterData2.Values = array2Db2;

            var rasterDatas = new List<RasterData<EnumeratedRepresentation, EnumerationMember>> { rasterData, rasterData2 };
            _referenceLayer.EnumeratedRasterValues = rasterDatas;
            _referenceLayer.ColumnCount = 3;
            _referenceLayer.RowCount = 2;

            var serializable = _converter.ConvertToSerializableReferenceLayer(_referenceLayer);

            Assert.AreEqual(3, serializable.ReferenceLayer.ColumnCount);
            Assert.AreEqual(2, serializable.ReferenceLayer.RowCount);

            Assert.AreEqual(rasterDatas.Count, serializable.EnumerationMemberValues.Count);

            for (int rasterDataIndex = 0; rasterDataIndex < rasterDatas.Count; rasterDataIndex++)
            {
                var array = rasterDatas[rasterDataIndex].Values;
                var serializableData = serializable.EnumerationMemberValues[rasterDataIndex];

                for (int columnIndex = 0; columnIndex < _referenceLayer.ColumnCount; columnIndex++)
                {
                    for (int rowIndex = 0; rowIndex < _referenceLayer.RowCount; rowIndex++)
                    {
                        Assert.AreEqual(array[columnIndex, rowIndex], serializableData.values[(columnIndex * _referenceLayer.RowCount) + rowIndex]);
                    }
                }
            }
        }

        [Test]
        public void GivenRasterLayerWithNumericRepWhenConvertToSerialThenIsConverted()
        {
            var rasterData = new RasterData<NumericRepresentation, NumericValue>();
            var array2Db = new NumericValue[3, 2] { { new NumericValue(new UnitOfMeasure(), 1), new NumericValue(new UnitOfMeasure(), 2) },
                                                    { new NumericValue(new UnitOfMeasure(), 3), new NumericValue(new UnitOfMeasure(), 4) },
                                                    { new NumericValue(new UnitOfMeasure(), 5), new NumericValue(new UnitOfMeasure(), 6) }};

            rasterData.Values = array2Db;
            var rasterDatas = new List<RasterData<NumericRepresentation, NumericValue>> { rasterData };

            _referenceLayer.NumericRasterValues = rasterDatas;
            _referenceLayer.ColumnCount = 3;
            _referenceLayer.RowCount = 2;

            var serializable = _converter.ConvertToSerializableReferenceLayer(_referenceLayer);

            Assert.AreEqual(3, serializable.ReferenceLayer.ColumnCount);
            Assert.AreEqual(2, serializable.ReferenceLayer.RowCount);

            var expectedStringValues = new List<double> { 1, 2, 3, 4, 5, 6 };

            for (int i = 0; i < expectedStringValues.Count; i++)
            {
                Assert.AreEqual(expectedStringValues[i], serializable.NumericValueValues.First().values[i].Value);
            }
        }

        [Test]
        public void GivenRasterLayersWithNumericRepWhenConvertToSerialThenNumericValuesAreConverted()
        {
            var rasterData = new RasterData<NumericRepresentation, NumericValue>();
            var array2Db = new NumericValue[3, 2] { { new NumericValue(new UnitOfMeasure(), 1), new NumericValue(new UnitOfMeasure(), 2) },
                                                    { new NumericValue(new UnitOfMeasure(), 3), new NumericValue(new UnitOfMeasure(), 4) },
                                                    { new NumericValue(new UnitOfMeasure(), 5), new NumericValue(new UnitOfMeasure(), 6) }};
            rasterData.Values = array2Db;

            var rasterData2 = new RasterData<NumericRepresentation, NumericValue>();
            var array2Db2 = new NumericValue[3, 2] { { new NumericValue(new UnitOfMeasure(), 7), new NumericValue(new UnitOfMeasure(), 8) },
                                                    { new NumericValue(new UnitOfMeasure(), 9), new NumericValue(new UnitOfMeasure(), 11) },
                                                    { new NumericValue(new UnitOfMeasure(), 12), new NumericValue(new UnitOfMeasure(), 13) }};
            rasterData2.Values = array2Db2;

            var rasterDatas = new List<RasterData<NumericRepresentation, NumericValue>> { rasterData, rasterData2 };
            _referenceLayer.NumericRasterValues = rasterDatas;
            _referenceLayer.ColumnCount = 3;
            _referenceLayer.RowCount = 2;

            var serializable = _converter.ConvertToSerializableReferenceLayer(_referenceLayer);

            Assert.AreEqual(3, serializable.ReferenceLayer.ColumnCount);
            Assert.AreEqual(2, serializable.ReferenceLayer.RowCount);

            Assert.AreEqual(rasterDatas.Count, serializable.NumericValueValues.Count);

            for (int rasterDataIndex = 0; rasterDataIndex < rasterDatas.Count; rasterDataIndex++)
            {
                var array = rasterDatas[rasterDataIndex].Values;
                var serializableData = serializable.NumericValueValues[rasterDataIndex];

                for (int columnIndex = 0; columnIndex < _referenceLayer.ColumnCount; columnIndex++)
                {
                    for (int rowIndex = 0; rowIndex < _referenceLayer.RowCount; rowIndex++)
                    {
                        Assert.AreEqual(array[columnIndex, rowIndex], serializableData.values[(columnIndex * _referenceLayer.RowCount) + rowIndex]);
                    }
                }
            }
        }

        [Test]
        public void GivenSerializedRasterLayerWhenConvertToReferenceLayerThenStringValuesAreConverted()
        { 
            var serialzedReferenceLayer = new SerializableReferenceLayer();
            serialzedReferenceLayer.StringValues = new List<SerializableRasterData<string>> { new SerializableRasterData<string>{values = new List<string>{"one", "two", "three", "four", "five", "six" } } };
            serialzedReferenceLayer.ReferenceLayer = _referenceLayer;

            _referenceLayer.StringRasterValues = null;
            _referenceLayer.ColumnCount = 3;
            _referenceLayer.RowCount = 2;

            var referenceLayer = _converter.ConvertToReferenceLayer(serialzedReferenceLayer) as RasterReferenceLayer;

            var expected = new string[3, 2] { { "one", "two" }, { "three", "four" },
                                        { "five", "six" } };

            for (int i = 0; i < _referenceLayer.ColumnCount; i++)
            {
                for (int j = 0; j < _referenceLayer.RowCount; j++)
                {
                    Assert.AreEqual(expected[i,j], referenceLayer.StringRasterValues.First().Values[i, j]);
                }
            }
        }

        [Test]
        public void GivenSerializedRasterLayesrWhenConvertToReferenceLayerThenStringValuesAreConverted()
        {
            var serialzedReferenceLayer = new SerializableReferenceLayer();
            serialzedReferenceLayer.StringValues = new List<SerializableRasterData<string>>
            {
                new SerializableRasterData<string> { values = new List<string> { "one", "two", "three", "four", "five", "six" } },
                new SerializableRasterData<string> { values = new List<string> { "11", "12", "13", "14", "15", "16" } }
            };
            serialzedReferenceLayer.ReferenceLayer = _referenceLayer;

            _referenceLayer.StringRasterValues = null;
            _referenceLayer.ColumnCount = 3;
            _referenceLayer.RowCount = 2;

            var referenceLayer = _converter.ConvertToReferenceLayer(serialzedReferenceLayer) as RasterReferenceLayer;

            var expected = new string[3, 2] { { "one", "two" }, { "three", "four" },
                                        { "five", "six" } };

            for (int rasterDataIndex = 0;
                rasterDataIndex < serialzedReferenceLayer.StringValues.Count;
                rasterDataIndex++)
            {
                var serializableData = serialzedReferenceLayer.StringValues[rasterDataIndex];
                var referenceLayerData = referenceLayer.StringRasterValues[rasterDataIndex];

                for (int i = 0; i < _referenceLayer.ColumnCount; i++)
                {
                    for (int j = 0; j < _referenceLayer.RowCount; j++)
                    {
                        Assert.AreEqual(serializableData.values[(i*_referenceLayer.RowCount) + j],
                            referenceLayerData.Values[i, j]);
                    }
                }
            }
        }

        [Test]
        public void GivenSerializedRasterLayerWhenConvertToReferenceLayerThenEnumeratedValuesAreConverted()
        {
            var serialzedReferenceLayer = new SerializableReferenceLayer();
            serialzedReferenceLayer.EnumerationMemberValues = new List<SerializableRasterData<EnumerationMember>>{ new SerializableRasterData<EnumerationMember>{ values = new List<EnumerationMember>{ new EnumerationMember {Value = "one" },  new EnumerationMember {Value = "two"},
                                                                                            new EnumerationMember {Value = "three"},  new EnumerationMember {Value = "four"},
                                                                                            new EnumerationMember {Value = "five"},  new EnumerationMember {Value = "six" } } } };
            serialzedReferenceLayer.ReferenceLayer = _referenceLayer;

            _referenceLayer.EnumeratedRasterValues = null;
            _referenceLayer.ColumnCount = 3;
            _referenceLayer.RowCount = 2;

            var referenceLayer = _converter.ConvertToReferenceLayer(serialzedReferenceLayer) as RasterReferenceLayer;

            var expected = new string[3, 2] { { "one", "two" }, { "three", "four" },
                                        { "five", "six" } };

            for (int i = 0; i < _referenceLayer.ColumnCount; i++)
            {
                for (int j = 0; j < _referenceLayer.RowCount; j++)
                {
                    Assert.AreEqual(expected[i, j], referenceLayer.EnumeratedRasterValues.First().Values[i, j].Value);
                }
            }
        }

        [Test]
        public void GivenSerializedRasterLayersWhenConvertToReferenceLayerThenEnumeratedValuesAreConverted()
        {
            var serialzedReferenceLayer = new SerializableReferenceLayer();
            serialzedReferenceLayer.EnumerationMemberValues = new List<SerializableRasterData<EnumerationMember>>{ 
                new SerializableRasterData<EnumerationMember>{ values = new List<EnumerationMember>{ new EnumerationMember {Value = "one" },  new EnumerationMember {Value = "two"},
                                                                                            new EnumerationMember {Value = "three"},  new EnumerationMember {Value = "four"},
                                                                                            new EnumerationMember {Value = "five"},  new EnumerationMember {Value = "six" } } },
                
                new SerializableRasterData<EnumerationMember>{ values = new List<EnumerationMember>{ new EnumerationMember {Value = "1" },  new EnumerationMember {Value = "2"},
                new EnumerationMember {Value = "3"},  new EnumerationMember {Value = "4"},
                new EnumerationMember {Value = "5"},  new EnumerationMember {Value = "6" } } }
            };
            serialzedReferenceLayer.ReferenceLayer = _referenceLayer;

            _referenceLayer.EnumeratedRasterValues = null;
            _referenceLayer.ColumnCount = 3;
            _referenceLayer.RowCount = 2;

            var referenceLayer = _converter.ConvertToReferenceLayer(serialzedReferenceLayer) as RasterReferenceLayer;

            for (int layerIndex = 0; layerIndex < serialzedReferenceLayer.EnumerationMemberValues.Count; layerIndex++)
            {
                var serializedLayer = serialzedReferenceLayer.EnumerationMemberValues[layerIndex];
                var referenceData = referenceLayer.EnumeratedRasterValues[layerIndex];

                for (int i = 0; i < _referenceLayer.ColumnCount; i++)
                {
                    for (int j = 0; j < _referenceLayer.RowCount; j++)
                    {
                        Assert.AreEqual(serializedLayer.values[(i * _referenceLayer.RowCount) + j].Value, referenceData.Values[i, j].Value);
                    }
                }
            }
        }

        [Test]
        public void GivenSerializedRasterLayerWhenConvertToReferenceLayerThenNumericValuesAreConverted()
        {
            var serialzedReferenceLayer = new SerializableReferenceLayer();
            serialzedReferenceLayer.NumericValueValues = new List<SerializableRasterData<NumericValue>> { new SerializableRasterData<NumericValue> { values = new List<NumericValue> { new NumericValue(new UnitOfMeasure(), 1),
                new NumericValue(new UnitOfMeasure(), 2),
                new NumericValue(new UnitOfMeasure(), 3),
                new NumericValue(new UnitOfMeasure(), 4),
                new NumericValue(new UnitOfMeasure(), 5),
                new NumericValue(new UnitOfMeasure(), 6)}}};

            serialzedReferenceLayer.ReferenceLayer = _referenceLayer;

            _referenceLayer.ColumnCount = 3;
            _referenceLayer.RowCount = 2;

            var referenceLayer = _converter.ConvertToReferenceLayer(serialzedReferenceLayer) as RasterReferenceLayer;

            var expected = new double[3, 2] { { 1, 2}, { 3, 4 }, { 5, 6 } };

            for (int i = 0; i < _referenceLayer.ColumnCount; i++)
            {
                for (int j = 0; j < _referenceLayer.RowCount; j++)
                {
                    Assert.AreEqual(expected[i, j], referenceLayer.NumericRasterValues.First().Values[i, j].Value);
                }
            }
        }

        [Test]
        public void GivenSerializedRasterLayersWhenConvertToReferenceLayerThenNumericValuesAreConverted()
        {
            var serialzedReferenceLayer = new SerializableReferenceLayer();
            serialzedReferenceLayer.NumericValueValues = new List<SerializableRasterData<NumericValue>> { new SerializableRasterData<NumericValue> { values = new List<NumericValue> { new NumericValue(new UnitOfMeasure(), 1),
                new NumericValue(new UnitOfMeasure(), 2),
                new NumericValue(new UnitOfMeasure(), 3),
                new NumericValue(new UnitOfMeasure(), 4),
                new NumericValue(new UnitOfMeasure(), 5),
                new NumericValue(new UnitOfMeasure(), 6)}},
                new SerializableRasterData<NumericValue> { values = new List<NumericValue> { new NumericValue(new UnitOfMeasure(), 7),
                new NumericValue(new UnitOfMeasure(), 8),
                new NumericValue(new UnitOfMeasure(), 9),
                new NumericValue(new UnitOfMeasure(), 10),
                new NumericValue(new UnitOfMeasure(), 11),
                new NumericValue(new UnitOfMeasure(), 14)}},
            };

            serialzedReferenceLayer.ReferenceLayer = _referenceLayer;

            _referenceLayer.ColumnCount = 3;
            _referenceLayer.RowCount = 2;

            var referenceLayer = _converter.ConvertToReferenceLayer(serialzedReferenceLayer) as RasterReferenceLayer;

            for (int layerIndex = 0; layerIndex < serialzedReferenceLayer.NumericValueValues.Count; layerIndex++)
            {
                var serializedLayer = serialzedReferenceLayer.NumericValueValues[layerIndex];
                var referenceData = referenceLayer.NumericRasterValues[layerIndex];

                for (int i = 0; i < _referenceLayer.ColumnCount; i++)
                {
                    for (int j = 0; j < _referenceLayer.RowCount; j++)
                    {
                        Assert.AreEqual(serializedLayer.values[(i * _referenceLayer.RowCount) + j].Value, referenceData.Values[i, j].Value);
                    }
                }
            }
        }

        [Test]
        public void GivenRasterLayersWhenConvertToSerialThenStringRepresentationsAreConverted()
        {
            var rasterData = new RasterData<StringRepresentation, string>();
            rasterData.Representation = new StringRepresentation
            {
                Description = "First One",
                Code = "Code1",
                CodeSource = RepresentationCodeSourceEnum.ISO11783_DDI,
                LongDescription = "Long Description 1"
            };

            var rasterData2 = new RasterData<StringRepresentation, string>();
            rasterData2.Representation = new StringRepresentation
            {
                Description = "Second One",
                Code = "Code2",
                CodeSource = RepresentationCodeSourceEnum.ADAPT,
                LongDescription = "Long Description"
            };

            var rasterDatas = new List<RasterData<StringRepresentation, string>> { rasterData, rasterData2 };
            _referenceLayer.StringRasterValues = rasterDatas;

            var serializable = _converter.ConvertToSerializableReferenceLayer(_referenceLayer);

            Assert.AreEqual(rasterDatas.Count, serializable.StringValues.Count);

            for (int rasterDataIndex = 0; rasterDataIndex < rasterDatas.Count; rasterDataIndex++)
            {
                var serializableData = serializable.StringValues[rasterDataIndex];

                var rasterDataAtIndex = rasterDatas[rasterDataIndex];
                Assert.AreSame(rasterDataAtIndex.Representation, serializableData.Representation);
            }
        }

        [Test]
        public void GivenRasterLayersWhenConvertToSerialThenNumericRepresentationsAreConverted()
        {
            var rasterData = new RasterData<NumericRepresentation, NumericValue>();
            rasterData.Representation = new NumericRepresentation
            {
                Description = "First One",
                Code = "Code1",
                CodeSource = RepresentationCodeSourceEnum.ISO11783_DDI,
                LongDescription = "Long Description 1"
            };

            var rasterData2 = new RasterData<NumericRepresentation, NumericValue>();
            rasterData2.Representation = new NumericRepresentation
            {
                Description = "Second One",
                Code = "Code2",
                CodeSource = RepresentationCodeSourceEnum.ADAPT,
                LongDescription = "Long Description"
            };

            var rasterDatas = new List<RasterData<NumericRepresentation, NumericValue>> { rasterData, rasterData2 };
            _referenceLayer.NumericRasterValues = rasterDatas;

            var serializable = _converter.ConvertToSerializableReferenceLayer(_referenceLayer);

            Assert.AreEqual(rasterDatas.Count, serializable.NumericValueValues.Count);

            for (int rasterDataIndex = 0; rasterDataIndex < rasterDatas.Count; rasterDataIndex++)
            {
                var serializableData = serializable.NumericValueValues[rasterDataIndex];

                var rasterDataAtIndex = rasterDatas[rasterDataIndex];
                Assert.AreSame(rasterDataAtIndex.Representation, serializableData.Representation);
            }
        }

        [Test]
        public void GivenRasterLayersWhenConvertToSerialThenEnumeratedRepresentationsAreConverted()
        {
            var rasterData = new RasterData<EnumeratedRepresentation, EnumerationMember>();
            rasterData.Representation = new EnumeratedRepresentation
            {
                Description = "First One",
                Code = "Code1",
                CodeSource = RepresentationCodeSourceEnum.ISO11783_DDI,
                LongDescription = "Long Description 1"
            };

            var rasterData2 = new RasterData<EnumeratedRepresentation, EnumerationMember>();
            rasterData2.Representation = new EnumeratedRepresentation
            {
                Description = "Second One",
                Code = "Code2",
                CodeSource = RepresentationCodeSourceEnum.ADAPT,
                LongDescription = "Long Description"
            };

            var rasterDatas = new List<RasterData<EnumeratedRepresentation, EnumerationMember>> { rasterData, rasterData2 };
            _referenceLayer.EnumeratedRasterValues = rasterDatas;

            var serializable = _converter.ConvertToSerializableReferenceLayer(_referenceLayer);

            Assert.AreEqual(rasterDatas.Count, serializable.EnumerationMemberValues.Count);

            for (int rasterDataIndex = 0; rasterDataIndex < rasterDatas.Count; rasterDataIndex++)
            {
                var serializableData = serializable.EnumerationMemberValues[rasterDataIndex];

                var rasterDataAtIndex = rasterDatas[rasterDataIndex];
                Assert.AreSame(rasterDataAtIndex.Representation, serializableData.Representation);
            }
        }

        [Test]
        public void GivenSerializedRasterLayesrWhenConvertToReferenceLayerThenStringRepresentationsAreConverted()
        {
            var serialzedReferenceLayer = new SerializableReferenceLayer();
            var stringRepresentation1 = new StringRepresentation
            {
                Description = "First One",
                Code = "Code1",
                CodeSource = RepresentationCodeSourceEnum.ISO11783_DDI,
                LongDescription = "Long Description 1"
            };

            var stringRepresentation2 = new StringRepresentation
            {
                Description = "Second One",
                Code = "Code2",
                CodeSource = RepresentationCodeSourceEnum.ADAPT,
                LongDescription = "Long Description 2"
            };

            serialzedReferenceLayer.StringValues = new List<SerializableRasterData<string>>
            {
                new SerializableRasterData<string> { Representation = stringRepresentation1 },
                new SerializableRasterData<string> { Representation = stringRepresentation2}
            };
            serialzedReferenceLayer.ReferenceLayer = _referenceLayer;

            var referenceLayer = _converter.ConvertToReferenceLayer(serialzedReferenceLayer) as RasterReferenceLayer;

            for (int rasterDataIndex = 0;
                rasterDataIndex < serialzedReferenceLayer.StringValues.Count;
                rasterDataIndex++)
            {
                var serializableData = serialzedReferenceLayer.StringValues[rasterDataIndex];
                var referenceLayerData = referenceLayer.StringRasterValues[rasterDataIndex];

                Assert.AreSame(serializableData.Representation, referenceLayerData.Representation);
            }
        }

        [Test]
        public void GivenSerializedRasterLayesrWhenConvertToReferenceLayerThenNumericRepresentationsAreConverted()
        {
            var serialzedReferenceLayer = new SerializableReferenceLayer();
            var numericRepresentation1 = new NumericRepresentation
            {
                Description = "First One",
                Code = "Code1",
                CodeSource = RepresentationCodeSourceEnum.ISO11783_DDI,
                LongDescription = "Long Description 1"
            };

            var numericRepresentation2 = new NumericRepresentation
            {
                Description = "Second One",
                Code = "Code2",
                CodeSource = RepresentationCodeSourceEnum.ADAPT,
                LongDescription = "Long Description 2"
            };

            serialzedReferenceLayer.NumericValueValues = new List<SerializableRasterData<NumericValue>>
            {
                new SerializableRasterData<NumericValue> { Representation = numericRepresentation1 },
                new SerializableRasterData<NumericValue> { Representation = numericRepresentation2}
            };
            serialzedReferenceLayer.ReferenceLayer = _referenceLayer;

            var referenceLayer = _converter.ConvertToReferenceLayer(serialzedReferenceLayer) as RasterReferenceLayer;

            for (int rasterDataIndex = 0;
                rasterDataIndex < serialzedReferenceLayer.NumericValueValues.Count;
                rasterDataIndex++)
            {
                var serializableData = serialzedReferenceLayer.NumericValueValues[rasterDataIndex];
                var referenceLayerData = referenceLayer.NumericRasterValues[rasterDataIndex];

                Assert.AreSame(serializableData.Representation, referenceLayerData.Representation);
            }
        }

        [Test]
        public void GivenSerializedRasterLayesrWhenConvertToReferenceLayerThenEnumeratedRepresentationsAreConverted()
        {
            var serialzedReferenceLayer = new SerializableReferenceLayer();
            var numericRepresentation1 = new EnumeratedRepresentation
            {
                Description = "First One",
                Code = "Code1",
                CodeSource = RepresentationCodeSourceEnum.ISO11783_DDI,
                LongDescription = "Long Description 1"
            };

            var numericRepresentation2 = new EnumeratedRepresentation
            {
                Description = "Second One",
                Code = "Code2",
                CodeSource = RepresentationCodeSourceEnum.ADAPT,
                LongDescription = "Long Description 2"
            };

            serialzedReferenceLayer.EnumerationMemberValues = new List<SerializableRasterData<EnumerationMember>>
            {
                new SerializableRasterData<EnumerationMember> { Representation = numericRepresentation1 },
                new SerializableRasterData<EnumerationMember> { Representation = numericRepresentation2}
            };
            serialzedReferenceLayer.ReferenceLayer = _referenceLayer;

            var referenceLayer = _converter.ConvertToReferenceLayer(serialzedReferenceLayer) as RasterReferenceLayer;

            for (int rasterDataIndex = 0;
                rasterDataIndex < serialzedReferenceLayer.EnumerationMemberValues.Count;
                rasterDataIndex++)
            {
                var serializableData = serialzedReferenceLayer.EnumerationMemberValues[rasterDataIndex];
                var referenceLayerData = referenceLayer.EnumeratedRasterValues[rasterDataIndex];

                Assert.AreSame(serializableData.Representation, referenceLayerData.Representation);
            }
        }

    }
}
