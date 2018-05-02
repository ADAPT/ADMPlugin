using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;
using NUnit.Framework;

namespace AgGateway.ADAPT.AcceptanceTest
{
    public static class AssertReferenceLayers
    {
        public static void VerifyReferenceLayers(List<ReferenceLayer> expectedReferenceLayers, List<ReferenceLayer> actualReferenceLayers)
        {
            for (var i = 0; i < expectedReferenceLayers.Count(); i++)
            {
                ReferenceLayerAreEqual(expectedReferenceLayers[i] as ShapeReferenceLayer, actualReferenceLayers[i] as ShapeReferenceLayer);
            }
        }

        private static void ReferenceLayerAreEqual(ShapeReferenceLayer expectedReferenceLayer, ShapeReferenceLayer actualReferenceLayer)
        {
            for (var i = 0; i < expectedReferenceLayer.ShapeLookups.Count; i++)
            {
                ShapeLookupValuesAreEqual(expectedReferenceLayer.ShapeLookups[i], actualReferenceLayer.ShapeLookups[i]);
            }
        }

        private static void ShapeLookupValuesAreEqual(ShapeLookup expectedShapeLookup, ShapeLookup actualShapeLookup)
        {
            Assert.AreEqual(expectedShapeLookup.Shape.GetType(), actualShapeLookup.Shape.GetType());

            if (typeof(Polygon) == expectedShapeLookup.Shape.GetType())
            {
                PolygonAreEqual(expectedShapeLookup.Shape as Polygon, actualShapeLookup.Shape as Polygon);
            }
            if (typeof(MultiPolygon) == expectedShapeLookup.Shape.GetType())
            {
                MultiPolygonAreEqual(expectedShapeLookup.Shape as MultiPolygon, actualShapeLookup.Shape as MultiPolygon);
            }

            if (typeof(MultiPoint) == expectedShapeLookup.Shape.GetType())
            {
                MultiPointAreEqual(expectedShapeLookup.Shape as MultiPoint, actualShapeLookup.Shape as MultiPoint);
            }
        }

        private static void PolygonAreEqual(Polygon expected, Polygon actual)
        {
            Assert.AreEqual(expected.ExteriorRing.Points.Count, actual.ExteriorRing.Points.Count);
        }

        private static void MultiPolygonAreEqual(MultiPolygon expected, MultiPolygon actual)
        {
            for (var i = 0; i < expected.Polygons.Count; i++)
            {
                PolygonAreEqual(expected.Polygons[i], actual.Polygons[i]);
            }
        }

        private static void MultiPointAreEqual(MultiPoint expected, MultiPoint actual)
        {
            Assert.AreEqual(expected.Points.Count, actual.Points.Count);
        }

        public static void VerifyReferenceLayers(List<ReferenceLayer> referenceLayers)
        {
            foreach (var referenceLayer in referenceLayers)
            {
                var shapeReferenceLayer = referenceLayer as ShapeReferenceLayer;
                Assert.IsInstanceOf(typeof(ShapeReferenceLayer), shapeReferenceLayer);

                foreach (var shapeLookup in shapeReferenceLayer.ShapeLookups)
                {
                    if (typeof(Polygon) == shapeLookup.Shape.GetType())
                    {
                        var polygon = shapeLookup.Shape as Polygon;
                        Assert.IsTrue(polygon.ExteriorRing.Points.Count > 0);
                    }
                    if (typeof(MultiPolygon) == shapeLookup.Shape.GetType())
                    {
                        var multiPolygon = shapeLookup.Shape as MultiPolygon;
                        foreach (var polygon in multiPolygon.Polygons)
                        {
                            Assert.IsTrue(polygon.ExteriorRing.Points.Count > 0);
                        }
                    }
                    if (typeof(MultiPoint) == shapeLookup.Shape.GetType())
                    {
                        var multiPoint = shapeLookup.Shape as MultiPoint;
                        Assert.IsTrue(multiPoint.Points.Count > 0);
                    }
                }
            }

        }
    }
}
