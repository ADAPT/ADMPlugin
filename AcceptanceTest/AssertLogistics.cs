using System;
using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Logistics;
using AgGateway.ADAPT.Representation.RepresentationSystem;
using NUnit.Framework;

namespace AcceptanceTest
{
    public static class AssertLogistics
    {
        public static void VerifyClient(List<Grower> catalogGrowers, string expectedName, string expectedGuid)
        {
            var grower = catalogGrowers.Find(x=> x.Id.UniqueIds.Exists(id => id.Id == expectedGuid));

            Assert.IsNotNull(grower);
            Assert.AreEqual(expectedName, grower.Name);
        }

        public static void VerifyFarm(List<Farm> catalogFarms, List<Grower> catalogGrowers, string expectedDescription, string expectedGuid, string expectedGrowerName)
        {
            var grower = catalogGrowers.Find(x => x.Name == expectedGrowerName);
            Assert.IsNotNull(grower);

            var farm = catalogFarms.Find(x => x.Id.UniqueIds.Exists(id => id.Id == expectedGuid));

            Assert.IsNotNull(farm);
            Assert.AreEqual(expectedDescription, farm.Description);
            Assert.AreEqual(grower.Id.ReferenceId,farm.GrowerId);
        }

        public static void VerifyField(List<Field> catalogFields, List<Farm> catalogFarms, string expectedDescription,
            string expectedGuid, string expectedFarmDescription, double expectedArea, string expectedAreaUnit)
        {
            var farm = catalogFarms.Find(x => x.Description == expectedFarmDescription);
            Assert.IsNotNull(farm);

            var field = catalogFields.Find(x => x.Id.UniqueIds.Exists(id => id.Id == expectedGuid));

            Assert.IsNotNull(field);
            Assert.AreEqual(expectedDescription, field.Description);
            Assert.AreEqual(farm.Id.ReferenceId, field.FarmId);
            Assert.AreEqual(expectedArea, field.Area.Value.Value);
            Assert.AreEqual(expectedAreaUnit, field.Area.Value.UnitOfMeasure.Code);
            Assert.AreEqual(RepresentationInstanceList.vrReportedFieldArea.DomainId, field.Area.Representation.Code);
        }

        public static void VerifyPerson(List<Person> catalogPersons, string expectedName, string expectedGuid)
        {
            var person = catalogPersons.Find(x => x.Id.UniqueIds.Exists(id => id.Id == expectedGuid));

            Assert.IsNotNull(person);
            Assert.AreEqual(expectedName, person.CombinedName);
        }
    }
}
