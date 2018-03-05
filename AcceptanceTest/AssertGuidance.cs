using System;
using System.Collections.Generic;
using System.Linq;
using AgGateway.ADAPT.ApplicationDataModel.Guidance;
using AgGateway.ADAPT.ApplicationDataModel.Logistics;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;
using AgGateway.ADAPT.Representation.RepresentationSystem;
using NUnit.Framework;

namespace AcceptanceTest
{
    public static class AssertGuidance
    {
        public static void VerifyAbLine(List<GuidancePattern> catalogGuidancePattern, List<Grower> catalogGrowers, List<Farm> catalogFarms, List<Field> catalogFields,
            string expectedDescription, string expectedGuid, 
            string expectedGrowerName, string expectedGrowerGuid, string expectedFarmDescription, string expectedFarmGuid, 
            string expectedFieldDescription, string expectedFieldGuid, double expectedFieldArea, string expectedFieldAreaUnit, 
            double expectedHeading, double expectedEastShiftComponent, double expectedNorthShiftComponent,
            Point aPoint, Point bPoint)
        {
            var guidancePattern = VerifyGuidancePattern(catalogGuidancePattern, catalogGrowers, catalogFarms, catalogFields, expectedDescription, expectedGuid, 
                expectedGrowerName, expectedGrowerGuid, expectedFarmDescription, expectedFarmGuid, 
                expectedFieldDescription, expectedFieldGuid, expectedFieldArea, expectedFieldAreaUnit);

            Assert.IsInstanceOf<AbLine>(guidancePattern);
            var abLine = (AbLine) guidancePattern;

            Assert.AreEqual(GuidancePatternTypeEnum.AbLine, abLine.GuidancePatternType);
            Assert.AreEqual(expectedHeading, abLine.Heading);
            Assert.AreEqual(expectedEastShiftComponent, abLine.EastShiftComponent);
            Assert.AreEqual(expectedNorthShiftComponent, abLine.NorthShiftComponent);
            Assert.AreEqual(aPoint.X, abLine.A.X);
            Assert.AreEqual(aPoint.Y, abLine.A.Y);
            Assert.AreEqual(bPoint.X, abLine.B.X);
            Assert.AreEqual(bPoint.Y, abLine.B.Y);
        }

        public static void VerifyPivotGuidance(List<GuidancePattern> catalogGuidancePattern, List<Grower> catalogGrowers, List<Farm> catalogFarms, List<Field> catalogFields,
            string expectedDescription, string expectedGuid,
            string expectedGrowerName, string expectedGrowerGuid, string expectedFarmDescription, string expectedFarmGuid,
            string expectedFieldDescription, string expectedFieldGuid, double expectedFieldArea, string expectedFieldAreaUnit,
            Point expectedStartPoint, Point expectedEndPoint, Point expectedCenter,
            double swathWidthValue, string swathWidthUnitOfMeasure, PropagationDirectionEnum expectedPropagationDirection, GuidanceExtensionEnum expectedExtension)
        {
            var guidancePattern = VerifyGuidancePattern(catalogGuidancePattern, catalogGrowers, catalogFarms, catalogFields, expectedDescription, expectedGuid, 
                expectedGrowerName, expectedGrowerGuid, expectedFarmDescription, expectedFarmGuid, expectedFieldDescription, expectedFieldGuid, expectedFieldArea, 
                expectedFieldAreaUnit);

            Assert.IsInstanceOf<PivotGuidancePattern>(guidancePattern);
            var pivotGuidance = (PivotGuidancePattern)guidancePattern;

            Assert.AreEqual(GuidancePatternTypeEnum.CenterPivot, pivotGuidance.GuidancePatternType);
            Assert.AreEqual(expectedStartPoint.X, pivotGuidance.StartPoint.X);
            Assert.AreEqual(expectedStartPoint.Y, pivotGuidance.StartPoint.Y);
            Assert.AreEqual(expectedEndPoint.X, pivotGuidance.EndPoint.X);
            Assert.AreEqual(expectedEndPoint.Y, pivotGuidance.EndPoint.Y);
            Assert.AreEqual(expectedCenter.X, pivotGuidance.Center.X);
            Assert.AreEqual(expectedCenter.Y, pivotGuidance.Center.Y);
            Assert.AreEqual(swathWidthValue, pivotGuidance.SwathWidth.Value.Value);
            Assert.AreEqual(swathWidthUnitOfMeasure, pivotGuidance.SwathWidth.Value.UnitOfMeasure.Code);
            Assert.AreEqual(RepresentationInstanceList.vrRadiusShift.DomainId, pivotGuidance.SwathWidth.Representation.Code);
            Assert.AreEqual(expectedPropagationDirection, pivotGuidance.PropagationDirection);
            Assert.AreEqual(expectedExtension, pivotGuidance.Extension);
        }

        public static void VerifyAbCurve(List<GuidancePattern> catalogGuidancePattern, List<Grower> catalogGrowers, List<Farm> catalogFarms, List<Field> catalogFields,
            string expectedDescription, string expectedGuid,
            string expectedGrowerName, string expectedGrowerGuid, string expectedFarmDescription, string expectedFarmGuid,
            string expectedFieldDescription, string expectedFieldGuid, double expectedFieldArea, string expectedFieldAreaUnit,
            int expectedSegments, double expectedHeading, double expectedEastShiftComponent, double expectedNorthShiftComponent, GpsSourceEnum expectedGpsSourceEnum, 
            Point point1, Point point2, int expectedSwathsLeft, int expectedSwathsRight, List<Point> expectedBoundingPolygon)
        {
            var guidancePattern = VerifyGuidancePattern(catalogGuidancePattern, catalogGrowers, catalogFarms, catalogFields, expectedDescription, expectedGuid,
                expectedGrowerName, expectedGrowerGuid, expectedFarmDescription, expectedFarmGuid,
                expectedFieldDescription, expectedFieldGuid, expectedFieldArea, expectedFieldAreaUnit);

            Assert.IsInstanceOf<AbCurve>(guidancePattern);
            var abCurve = (AbCurve)guidancePattern;

            Assert.AreEqual(GuidancePatternTypeEnum.AbCurve, abCurve.GuidancePatternType);
            Assert.AreEqual(expectedSegments, abCurve.NumberOfSegments);
            Assert.AreEqual(expectedHeading, abCurve.Heading);
            Assert.AreEqual(expectedEastShiftComponent, abCurve.EastShiftComponent);
            Assert.AreEqual(expectedNorthShiftComponent, abCurve.NorthShiftComponent);
            Assert.AreEqual(point1.X, abCurve.Shape[0].Points[0].X);
            Assert.AreEqual(point1.Y, abCurve.Shape[0].Points[0].Y);
            Assert.AreEqual(point2.X, abCurve.Shape[0].Points[1].X);
            Assert.AreEqual(point2.Y, abCurve.Shape[0].Points[1].Y);
            Assert.AreEqual(expectedGpsSourceEnum, abCurve.GpsSource.SourceType);
            Assert.AreEqual(expectedSwathsLeft, abCurve.NumbersOfSwathsLeft);
            Assert.AreEqual(expectedSwathsRight, abCurve.NumbersOfSwathsRight);

            var exteriorRingPoints = abCurve.BoundingPolygon.Polygons.First().ExteriorRing.Points;
            foreach (var point in expectedBoundingPolygon)
            {
                Assert.IsTrue(exteriorRingPoints.Exists(x=>Math.Abs(x.X - point.X) < 0.01 && Math.Abs(x.Y - point.Y) < 0.01));
            }
        }

        private static GuidancePattern VerifyGuidancePattern(List<GuidancePattern> catalogGuidancePattern, List<Grower> catalogGrowers, List<Farm> catalogFarms,
            List<Field> catalogFields, string expectedDescription, string expectedGuid, string expectedGrowerName,
            string expectedGrowerGuid, string expectedFarmDescription, string expectedFarmGuid, string expectedFieldDescription,
            string expectedFieldGuid, double expectedFieldArea, string expectedFieldAreaUnit)
        {
            var guidancePattern = catalogGuidancePattern.Find(x => x.Id.UniqueIds.Exists(id => id.Id == expectedGuid));
            Assert.IsNotNull(guidancePattern);

            Assert.AreEqual(expectedDescription, guidancePattern.Description);

            AssertLogistics.VerifyClient(catalogGrowers, expectedGrowerName, expectedGrowerGuid);
            AssertLogistics.VerifyFarm(catalogFarms, catalogGrowers, expectedFarmDescription, expectedFarmGuid,
                expectedGrowerName);
            AssertLogistics.VerifyField(catalogFields, catalogFarms, expectedFieldDescription, expectedFieldGuid,
                expectedFarmDescription, expectedFieldArea, expectedFieldAreaUnit);
            return guidancePattern;
        }
    }
}