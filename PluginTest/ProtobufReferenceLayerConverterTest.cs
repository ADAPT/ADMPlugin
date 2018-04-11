using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AgGateway.ADAPT.ADMPlugin;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers;
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;
using Castle.Components.DictionaryAdapter;
using NUnit.Framework;

namespace AgGateway.ADAPT.PluginTest
{
    [TestFixture]
    public class ProtobufReferenceLayerConverterTest
    {
        private RasterReferenceLayer _referenceLayer;
        private ProtobufReferenceLayerConverter _converter;
        private ShapeReferenceLayer _shapeReferenceLayer;

        [SetUp]
        public void Setup()
        {
            _referenceLayer = new RasterReferenceLayer();

            _converter = new ProtobufReferenceLayerConverter();
            _shapeReferenceLayer=new ShapeReferenceLayer();
        }

        [Test]
        public void GivenRasterLayerWhenConvertToSerialThenIsConverted()
        {
            var rasterData = new RasterData<StringRepresentation, string>();
            var array2Db = new[,] { { "one", "two" }, { "three", "four" },
                                        { "five", "six" } };
            rasterData.Values = array2Db;
            var rasterDatas = new List<RasterData<StringRepresentation, string>> { rasterData };

            _referenceLayer.StringRasterValues = rasterDatas;
            _referenceLayer.ColumnCount = 3;
            _referenceLayer.RowCount = 2;

            var serializable = _converter.ConvertToSerializableReferenceLayer(_referenceLayer);

            Assert.AreEqual(3, serializable.RasterReferenceLayer.ColumnCount);
            Assert.AreEqual(2, serializable.RasterReferenceLayer.RowCount);

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
            var array2Db = new[,] {{"one", "two"}, {"three", "four"}, {"five", "six"}};
            rasterData.Values = array2Db;

            var rasterData2 = new RasterData<StringRepresentation, string>();
            var array2Db2 = new[,] {{"11", "12"}, {"13", "14"}, {"15", "16"}};
            rasterData2.Values = array2Db2;

            var rasterDatas = new List<RasterData<StringRepresentation, string>> {rasterData, rasterData2};
            _referenceLayer.StringRasterValues = rasterDatas;
            _referenceLayer.ColumnCount = 3;
            _referenceLayer.RowCount = 2;

            var serializable = _converter.ConvertToSerializableReferenceLayer(_referenceLayer);

            Assert.AreEqual(3, serializable.RasterReferenceLayer.ColumnCount);
            Assert.AreEqual(2, serializable.RasterReferenceLayer.RowCount);

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
            var array2Db = new[,] { { new EnumerationMember{Value = "1"}, new EnumerationMember{Value = "2"} }, { new EnumerationMember{Value = "3"}, new EnumerationMember{Value = "4"} },
                                        { new EnumerationMember{Value = "5"}, new EnumerationMember{Value = "6"} } };
            rasterData.Values = array2Db;
            var rasterDatas = new List<RasterData<EnumeratedRepresentation, EnumerationMember>> { rasterData };

            _referenceLayer.EnumeratedRasterValues = rasterDatas;
            _referenceLayer.ColumnCount = 3;
            _referenceLayer.RowCount = 2;

            var serializable = _converter.ConvertToSerializableReferenceLayer(_referenceLayer);

            Assert.AreEqual(3, serializable.RasterReferenceLayer.ColumnCount);
            Assert.AreEqual(2, serializable.RasterReferenceLayer.RowCount);

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
            var array2Db = new[,] { { new EnumerationMember{Value = "1"}, new EnumerationMember{Value = "2"} }, { new EnumerationMember{Value = "3"}, new EnumerationMember{Value = "4"} },
                                        { new EnumerationMember{Value = "5"}, new EnumerationMember{Value = "6"} } };
            rasterData.Values = array2Db;

            var rasterData2 = new RasterData<EnumeratedRepresentation, EnumerationMember>();
            var array2Db2 = new[,] { { new EnumerationMember{Value = "7"}, new EnumerationMember{Value = "8"} }, { new EnumerationMember{Value = "9"}, new EnumerationMember{Value = "10"} },
                                        { new EnumerationMember{Value = "11"}, new EnumerationMember{Value = "13"} } };
            rasterData2.Values = array2Db2;

            var rasterDatas = new List<RasterData<EnumeratedRepresentation, EnumerationMember>> { rasterData, rasterData2 };
            _referenceLayer.EnumeratedRasterValues = rasterDatas;
            _referenceLayer.ColumnCount = 3;
            _referenceLayer.RowCount = 2;

            var serializable = _converter.ConvertToSerializableReferenceLayer(_referenceLayer);

            Assert.AreEqual(3, serializable.RasterReferenceLayer.ColumnCount);
            Assert.AreEqual(2, serializable.RasterReferenceLayer.RowCount);

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
            var array2Db = new[,] { { new NumericValue(new UnitOfMeasure(), 1), new NumericValue(new UnitOfMeasure(), 2) },
                                                    { new NumericValue(new UnitOfMeasure(), 3), new NumericValue(new UnitOfMeasure(), 4) },
                                                    { new NumericValue(new UnitOfMeasure(), 5), new NumericValue(new UnitOfMeasure(), 6) }};

            rasterData.Values = array2Db;
            var rasterDatas = new List<RasterData<NumericRepresentation, NumericValue>> { rasterData };

            _referenceLayer.NumericRasterValues = rasterDatas;
            _referenceLayer.ColumnCount = 3;
            _referenceLayer.RowCount = 2;

            var serializable = _converter.ConvertToSerializableReferenceLayer(_referenceLayer);

            Assert.AreEqual(3, serializable.RasterReferenceLayer.ColumnCount);
            Assert.AreEqual(2, serializable.RasterReferenceLayer.RowCount);

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
            var array2Db = new[,] { { new NumericValue(new UnitOfMeasure(), 1), new NumericValue(new UnitOfMeasure(), 2) },
                                                    { new NumericValue(new UnitOfMeasure(), 3), new NumericValue(new UnitOfMeasure(), 4) },
                                                    { new NumericValue(new UnitOfMeasure(), 5), new NumericValue(new UnitOfMeasure(), 6) }};
            rasterData.Values = array2Db;

            var rasterData2 = new RasterData<NumericRepresentation, NumericValue>();
            var array2Db2 = new[,] { { new NumericValue(new UnitOfMeasure(), 7), new NumericValue(new UnitOfMeasure(), 8) },
                                                    { new NumericValue(new UnitOfMeasure(), 9), new NumericValue(new UnitOfMeasure(), 11) },
                                                    { new NumericValue(new UnitOfMeasure(), 12), new NumericValue(new UnitOfMeasure(), 13) }};
            rasterData2.Values = array2Db2;

            var rasterDatas = new List<RasterData<NumericRepresentation, NumericValue>> { rasterData, rasterData2 };
            _referenceLayer.NumericRasterValues = rasterDatas;
            _referenceLayer.ColumnCount = 3;
            _referenceLayer.RowCount = 2;

            var serializable = _converter.ConvertToSerializableReferenceLayer(_referenceLayer);

            Assert.AreEqual(3, serializable.RasterReferenceLayer.ColumnCount);
            Assert.AreEqual(2, serializable.RasterReferenceLayer.RowCount);

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
            serialzedReferenceLayer.RasterReferenceLayer = _referenceLayer;

            _referenceLayer.StringRasterValues = null;
            _referenceLayer.ColumnCount = 3;
            _referenceLayer.RowCount = 2;

            var referenceLayer = _converter.ConvertToReferenceLayer(serialzedReferenceLayer) as RasterReferenceLayer;

            var expected = new[,] { { "one", "two" }, { "three", "four" },
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
            var serialzedReferenceLayer = new SerializableReferenceLayer
            {
                StringValues = new List<SerializableRasterData<string>>
                {
                    new SerializableRasterData<string>
                    {
                        values = new List<string> {"one", "two", "three", "four", "five", "six"}
                    },
                    new SerializableRasterData<string> {values = new List<string> {"11", "12", "13", "14", "15", "16"}}
                },
                RasterReferenceLayer = _referenceLayer
            };

            _referenceLayer.StringRasterValues = null;
            _referenceLayer.ColumnCount = 3;
            _referenceLayer.RowCount = 2;

            var referenceLayer = _converter.ConvertToReferenceLayer(serialzedReferenceLayer) as RasterReferenceLayer;

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
            serialzedReferenceLayer.RasterReferenceLayer = _referenceLayer;

            _referenceLayer.EnumeratedRasterValues = null;
            _referenceLayer.ColumnCount = 3;
            _referenceLayer.RowCount = 2;

            var referenceLayer = _converter.ConvertToReferenceLayer(serialzedReferenceLayer) as RasterReferenceLayer;

            var expected = new[,]{ { "one", "two" }, { "three", "four" },
                                        { "five", "six" } };

            for (var i = 0; i < _referenceLayer.ColumnCount; i++)
            {
                for (var j = 0; j < _referenceLayer.RowCount; j++)
                {
                    Assert.AreEqual(expected[i, j], referenceLayer.EnumeratedRasterValues.First().Values[i, j].Value);
                }
            }
        }

        [Test]
        public void GivenSerializedRasterLayersWhenConvertToReferenceLayerThenEnumeratedValuesAreConverted()
        {
            var serialzedReferenceLayer = new SerializableReferenceLayer
            {
                EnumerationMemberValues = new List<SerializableRasterData<EnumerationMember>>
                {
                    new SerializableRasterData<EnumerationMember>
                    {
                        values = new List<EnumerationMember>
                        {
                            new EnumerationMember {Value = "one"},
                            new EnumerationMember {Value = "two"},
                            new EnumerationMember {Value = "three"},
                            new EnumerationMember {Value = "four"},
                            new EnumerationMember {Value = "five"},
                            new EnumerationMember {Value = "six"}
                        }
                    },

                    new SerializableRasterData<EnumerationMember>
                    {
                        values = new List<EnumerationMember>
                        {
                            new EnumerationMember {Value = "1"},
                            new EnumerationMember {Value = "2"},
                            new EnumerationMember {Value = "3"},
                            new EnumerationMember {Value = "4"},
                            new EnumerationMember {Value = "5"},
                            new EnumerationMember {Value = "6"}
                        }
                    }
                },
                RasterReferenceLayer = _referenceLayer
            };

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
            var serialzedReferenceLayer = new SerializableReferenceLayer
            {
                NumericValueValues = new List<SerializableRasterData<NumericValue>>
                {
                    new SerializableRasterData<NumericValue>
                    {
                        values = new List<NumericValue>
                        {
                            new NumericValue(new UnitOfMeasure(), 1),
                            new NumericValue(new UnitOfMeasure(), 2),
                            new NumericValue(new UnitOfMeasure(), 3),
                            new NumericValue(new UnitOfMeasure(), 4),
                            new NumericValue(new UnitOfMeasure(), 5),
                            new NumericValue(new UnitOfMeasure(), 6)
                        }
                    }
                },
                RasterReferenceLayer = _referenceLayer
            };

            _referenceLayer.ColumnCount = 3;
            _referenceLayer.RowCount = 2;

            var referenceLayer = _converter.ConvertToReferenceLayer(serialzedReferenceLayer) as RasterReferenceLayer;

            var expected = new[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };

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
            var serialzedReferenceLayer = new SerializableReferenceLayer
            {
                NumericValueValues = new List<SerializableRasterData<NumericValue>>
                {
                    new SerializableRasterData<NumericValue>
                    {
                        values = new List<NumericValue>
                        {
                            new NumericValue(new UnitOfMeasure(), 1),
                            new NumericValue(new UnitOfMeasure(), 2),
                            new NumericValue(new UnitOfMeasure(), 3),
                            new NumericValue(new UnitOfMeasure(), 4),
                            new NumericValue(new UnitOfMeasure(), 5),
                            new NumericValue(new UnitOfMeasure(), 6)
                        }
                    },
                    new SerializableRasterData<NumericValue>
                    {
                        values = new List<NumericValue>
                        {
                            new NumericValue(new UnitOfMeasure(), 7),
                            new NumericValue(new UnitOfMeasure(), 8),
                            new NumericValue(new UnitOfMeasure(), 9),
                            new NumericValue(new UnitOfMeasure(), 10),
                            new NumericValue(new UnitOfMeasure(), 11),
                            new NumericValue(new UnitOfMeasure(), 14)
                        }
                    },
                },
                RasterReferenceLayer = _referenceLayer
            };

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
            var rasterData = new RasterData<StringRepresentation, string>
            {
                Representation = new StringRepresentation
                {
                    Description = "First One",
                    Code = "Code1",
                    CodeSource = RepresentationCodeSourceEnum.ISO11783_DDI,
                    LongDescription = "Long Description 1"
                }
            };

            var rasterData2 = new RasterData<StringRepresentation, string>
            {
                Representation = new StringRepresentation
                {
                    Description = "Second One",
                    Code = "Code2",
                    CodeSource = RepresentationCodeSourceEnum.ADAPT,
                    LongDescription = "Long Description"
                }
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
            var rasterData = new RasterData<NumericRepresentation, NumericValue>
            {
                Representation = new NumericRepresentation
                {
                    Description = "First One",
                    Code = "Code1",
                    CodeSource = RepresentationCodeSourceEnum.ISO11783_DDI,
                    LongDescription = "Long Description 1"
                }
            };

            var rasterData2 = new RasterData<NumericRepresentation, NumericValue>
            {
                Representation = new NumericRepresentation
                {
                    Description = "Second One",
                    Code = "Code2",
                    CodeSource = RepresentationCodeSourceEnum.ADAPT,
                    LongDescription = "Long Description"
                }
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
            var rasterData = new RasterData<EnumeratedRepresentation, EnumerationMember>
            {
                Representation = new EnumeratedRepresentation
                {
                    Description = "First One",
                    Code = "Code1",
                    CodeSource = RepresentationCodeSourceEnum.ISO11783_DDI,
                    LongDescription = "Long Description 1"
                }
            };

            var rasterData2 = new RasterData<EnumeratedRepresentation, EnumerationMember>
            {
                Representation = new EnumeratedRepresentation
                {
                    Description = "Second One",
                    Code = "Code2",
                    CodeSource = RepresentationCodeSourceEnum.ADAPT,
                    LongDescription = "Long Description"
                }
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
            serialzedReferenceLayer.RasterReferenceLayer = _referenceLayer;

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
            serialzedReferenceLayer.RasterReferenceLayer = _referenceLayer;

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
            serialzedReferenceLayer.RasterReferenceLayer = _referenceLayer;

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

        [Test]
        public void GivenShapeReferenceLayerWithMultiPointWhenConvertToSerializableThenIsConverted()
        {
            var point1 = new Point{X = 5, Y = 5, Z = 5};
            var point2 = new Point { X = 10, Y = 10, Z = 10 };
            _shapeReferenceLayer.ShapeLookups = new List<ShapeLookup>{new ShapeLookup{Shape = new MultiPoint{Id = 1, Points = new List<Point>{point1, point2}}}};

            var result = _converter.ConvertToSerializableReferenceLayer(_shapeReferenceLayer);

            Assert.IsInstanceOf(typeof(MultiPoint), result.ShapeLookupValues.First().shapeLookups.FirstOrDefault().Shape);
            Assert.IsInstanceOf(typeof(ShapeReferenceLayer), result.ShapeReferenceLayer);
        }

        [Test]
        public void GivenShapeReferenceLayerWithPolygonWhenConvertToSerializableThenIsConverted()
        {
            var point1 = new Point { X = 5, Y = 5, Z = 5 };
            var point2 = new Point { X = 10, Y = 10, Z = 10 };
            var polygon = new Polygon
            {
                ExteriorRing = new LinearRing { Id = 1, Points = new List<Point>{ point1, point2} }
            };

            _shapeReferenceLayer.ShapeLookups = new List<ShapeLookup> { new ShapeLookup { Shape = polygon }};

            var result = _converter.ConvertToSerializableReferenceLayer(_shapeReferenceLayer);

            Assert.IsInstanceOf(typeof(Polygon), result.ShapeLookupValues.First().shapeLookups.FirstOrDefault().Shape);
            Assert.IsInstanceOf(typeof(ShapeReferenceLayer), result.ShapeReferenceLayer);
        }

        [Test]
        public void GivenShapeReferenceLayerWithNullShapeLookUpsWhenConvertToSerializableThenIsNotConverted()
        {
            _shapeReferenceLayer.ShapeLookups = null;
            var result = _converter.ConvertToSerializableReferenceLayer(_shapeReferenceLayer);

            Assert.IsNull(result.ShapeLookupValues);
            Assert.IsInstanceOf(typeof(ShapeReferenceLayer), result.ShapeReferenceLayer);
        }

        [Test]
        public void GivenShapeReferenceLayerWithEmptyShapeLookUpsWhenConvertToSerializableThenIsNotConverted()
        {
            _shapeReferenceLayer.ShapeLookups = new List<ShapeLookup>();
            var result = _converter.ConvertToSerializableReferenceLayer(_shapeReferenceLayer);

            Assert.IsNull(result.ShapeLookupValues);
            Assert.IsInstanceOf(typeof(ShapeReferenceLayer), result.ShapeReferenceLayer);
        }

        [Test]
        public void GivenShapeReferenceLayerWithNullShapeWhenConvertoSerializableThenIsNotConverted()
        {
            _shapeReferenceLayer.ShapeLookups = new List<ShapeLookup>{new ShapeLookup()};
            var result = _converter.ConvertToSerializableReferenceLayer(_shapeReferenceLayer);

            Assert.IsNull(result.ShapeLookupValues.First().shapeLookups.First().Shape);
            Assert.IsInstanceOf(typeof(ShapeReferenceLayer), result.ShapeReferenceLayer);
        }
        
        [Test]
        public void GivenSerializableReferenceLayerWithMultiPointWhenConvertoReferenceLayerThenIsConverted()
        {
            var serializedReferenceLayer = new SerializableReferenceLayer();
            var point1 = new Point { X = 5, Y = 5, Z = 5 };
            var point2 = new Point { X = 10, Y = 10, Z = 10 };
            serializedReferenceLayer.ShapeLookupValues=new List<SerializableShapeData>
            {
                new SerializableShapeData{shapeLookups = new List<ShapeLookup>{new ShapeLookup{Shape = new MultiPoint{Id = 1, Points = new List<Point>{point1, point2}}}}}
            };
            serializedReferenceLayer.ShapeReferenceLayer = _shapeReferenceLayer;

            var result = _converter.ConvertToReferenceLayer(serializedReferenceLayer) as ShapeReferenceLayer;
            var multiPoint = result.ShapeLookups.First().Shape;

            Assert.IsInstanceOf(typeof(MultiPoint), multiPoint);
            Assert.IsInstanceOf(typeof(ShapeReferenceLayer), result);
        }

        [Test]
        public void GivenSerializableReferenceLayerWithPolygonWhenConvertoReferenceLayerThenIsConverted()
        {
            var serializedReferenceLayer = new SerializableReferenceLayer();
            var point1 = new Point { X = 5, Y = 5, Z = 5 };
            var point2 = new Point { X = 10, Y = 10, Z = 10 };
            var polygon = new Polygon
            {
                ExteriorRing = new LinearRing { Id = 1, Points = new List<Point> { point1, point2 } }
            };
            serializedReferenceLayer.ShapeLookupValues = new List<SerializableShapeData>
            {
                new SerializableShapeData{shapeLookups = new List<ShapeLookup>{new ShapeLookup{Shape = polygon }}}
            };
            serializedReferenceLayer.ShapeReferenceLayer = _shapeReferenceLayer;

            var result = _converter.ConvertToReferenceLayer(serializedReferenceLayer) as ShapeReferenceLayer;
            var actualPolygon = result.ShapeLookups.First().Shape;

            Assert.IsInstanceOf(typeof(Polygon), actualPolygon);
            Assert.IsInstanceOf(typeof(ShapeReferenceLayer), result);
        }

        [Test]
        public void GivenSerializableReferenceLayerWithNullShapeLookUpsValuesWhenConvertoReferenceLayerThenIsNotConverted()
        {
            var serializedReferenceLayer = new SerializableReferenceLayer
            {
                ShapeReferenceLayer = _shapeReferenceLayer,
                ShapeLookupValues = null
            };

            var result = _converter.ConvertToReferenceLayer(serializedReferenceLayer) as ShapeReferenceLayer;

            Assert.IsEmpty(result.ShapeLookups);
        }

        [Test]
        public void GivenSerializableReferenceLayerWithEmptyShapeLookUpsValuesWhenConvertoReferenceLayerThenIsNotConverted()
        {
            var serializedReferenceLayer = new SerializableReferenceLayer
            {
                ShapeReferenceLayer = _shapeReferenceLayer,
                ShapeLookupValues = new List<SerializableShapeData>()
            };

            var result = _converter.ConvertToReferenceLayer(serializedReferenceLayer) as ShapeReferenceLayer;

            Assert.IsEmpty(result.ShapeLookups);
        }

        [Test]
        public void GivenSerializableReferenceLayerWithNullShapeLookUpsWhenConvertoReferenceLayerThenIsNotConverted()
        {
            var serializedReferenceLayer = new SerializableReferenceLayer
            {
                ShapeReferenceLayer = _shapeReferenceLayer,
                ShapeLookupValues = new List<SerializableShapeData> { new SerializableShapeData()}
            };

            var result = _converter.ConvertToReferenceLayer(serializedReferenceLayer) as ShapeReferenceLayer;

            Assert.IsEmpty(result.ShapeLookups);
        }
    }
}
