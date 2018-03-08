using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries;
using AgGateway.ADAPT.ApplicationDataModel.Logistics;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;
using NUnit.Framework;

namespace AgGateway.ADAPT.AcceptanceTest
{
    public static class AssertBoundaries
    {
        public static void VerifyBoundary(List<FieldBoundary> catalogFieldBoundaries, List<Field> catalogFields, List<Farm> catalogFarms, List<Grower> catalogGrowers, 
            string expectedGuid, string expectedGrowerName, string expectedGrowerGuid, string expectedFarmDescription, string expectedFarmGuid,
            string expectedFieldDescription, string expectedFieldGuid, double expectedFieldArea, string expectedFieldAreaUnit,
            GpsSourceEnum expectedGpsSourceEnum, List<string> expectedInteriorBoundaries, int expectedPolygonCount)
        {
            var boundary = catalogFieldBoundaries.Find(x => x.Id.UniqueIds.Exists(id => id.Id == expectedGuid));
            Assert.IsNotNull(boundary);

            AssertLogistics.VerifyClient(catalogGrowers, expectedGrowerName, expectedGrowerGuid);
            AssertLogistics.VerifyFarm(catalogFarms, catalogGrowers, expectedFarmDescription, expectedFarmGuid, expectedGrowerName);
            AssertLogistics.VerifyField(catalogFields, catalogFarms, expectedFieldDescription, expectedFieldGuid, expectedFarmDescription, expectedFieldArea, expectedFieldAreaUnit);

            Assert.AreEqual(expectedGpsSourceEnum, boundary.GpsSource.SourceType);

            var interiorBoundaryVerified = true;
            foreach (var expectedInteriorBoundary in expectedInteriorBoundaries)
            {
                 interiorBoundaryVerified &= boundary.InteriorBoundaryAttributes.Exists(x => x.Description == expectedInteriorBoundary);
            }
            
            Assert.IsTrue(interiorBoundaryVerified);
            
            Assert.IsNotNull(boundary.SpatialData);
            Assert.AreEqual(ShapeTypeEnum.MultiPolygon, boundary.SpatialData.Type);
            Assert.IsNotNull(boundary.SpatialData.Polygons);
            Assert.AreEqual(boundary.SpatialData.Polygons.Count, expectedPolygonCount);
        }
    }
}
