using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AgGateway.ADAPT.ADMPlugin;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.ApplicationDataModel.Guidance;
using AgGateway.ADAPT.ApplicationDataModel.Logistics;
using AgGateway.ADAPT.ApplicationDataModel.Products;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;
using AgGateway.ADAPT.Representation.RepresentationSystem;
using NUnit.Framework;
using AgGateway.ADAPT.TestUtilities;

namespace AgGateway.ADAPT.AcceptanceTest
{
    [TestFixture]
    public class PluginAcceptanceTest
    {
        private string _cardPath;
        
        [Test]
        public void GivenOlderVersionSetupCardWhenImportedToVersionWithChangedPropertyAndTypeNamesThenImportsToTheNewerModel()
        {
            _cardPath = DatacardUtility.WriteDatacard("ADMSetupV1_0_8");

            var plugin = new Plugin();
            var applicationDataModel = plugin.Import(_cardPath);

            Assert.IsNotNull(applicationDataModel);

            var dataModel = applicationDataModel.First();
            var catalog = dataModel.Catalog;

            AssertLogistics.VerifyClient(catalog.Growers, "Client_1", "9309ad91-34a7-46d1-8fc4-2a8200bfd1fe");
            AssertLogistics.VerifyClient(catalog.Growers, "Client_2", "f012ab09-2bfa-4b43-bd84-0639fc964a37");
            AssertLogistics.VerifyClient(catalog.Growers, "Client_3", "c1453376-973a-4aae-afc7-e9cf124546b1");
            AssertLogistics.VerifyClient(catalog.Growers, "AccumulatedClient", "eef7e764-9b6e-490d-8650-c979ad0a6533");

            AssertLogistics.VerifyFarm(catalog.Farms, catalog.Growers, "Farm_1", "71695e14-c72a-4ad5-924e-6a8a93273b42", "Client_1");
            AssertLogistics.VerifyFarm(catalog.Farms, catalog.Growers, "Farm_2", "a9a27c6c-d535-49fe-9f7e-baa1be498dee", "Client_2");
            AssertLogistics.VerifyFarm(catalog.Farms, catalog.Growers, "Farm_3", "d084bb88-4df8-4fcb-a913-dd01b854cd78", "Client_3");
            AssertLogistics.VerifyFarm(catalog.Farms, catalog.Growers, "AccumulatedFarm", "46c3d57c-a87a-4324-a39d-d81a6547a1bc", "AccumulatedClient");

            AssertLogistics.VerifyField(catalog.Fields, catalog.Farms, "Field_1", "c5f76cad-2447-46bf-a291-64039bef531f", "Farm_1", 1000, "ac");
            AssertLogistics.VerifyField(catalog.Fields, catalog.Farms, "Field_2", "1dbfd5b6-5e93-4c3b-a823-74194046714d", "Farm_2", 2000, "ac");
            AssertLogistics.VerifyField(catalog.Fields, catalog.Farms, "Field_3", "1d427ee9-9530-48cd-bc09-610bc6aa0359", "Farm_3", 3000, "ac");
            AssertLogistics.VerifyField(catalog.Fields, catalog.Farms, "Field_4", "fe0ef60f-cdbe-420e-af38-39511e31d3cb", "Farm_1", 1000, "ac");
            AssertLogistics.VerifyField(catalog.Fields, catalog.Farms, "Field_5", "0bcbfbec-f064-42c2-a98a-57c434ba7be6", "Farm_1", 1000, "ac");
            AssertLogistics.VerifyField(catalog.Fields, catalog.Farms, "Field_6", "65c1eb62-0812-48ff-89ab-c422907e1fb8", "Farm_1", 1000, "ac");
            AssertLogistics.VerifyField(catalog.Fields, catalog.Farms, "AccumulatedField", "b23870b6-18de-4942-ac58-cf8671b87940", "AccumulatedFarm", 100, "ac");

            AssertLogistics.VerifyPerson(catalog.Persons, "Frank", "71661fa6-5cb8-4789-8e83-c9355a75aef6");
            AssertLogistics.VerifyPerson(catalog.Persons, "Lou", "d7802728-32ae-46e5-8ff4-ccf07fcd415d");
            AssertLogistics.VerifyPerson(catalog.Persons, "John", "8d5cb704-d41f-419f-abc0-ee7656ac2bf4");

            AssertProducts.VerifyCropProtectionProduct(catalog.Products, "Water", "ae248af1-d152-49c8-ab11-58ada63ec213", CategoryEnum.Unknown);

            // Defaults to additive when nothing is set. 
            AssertProducts.VerifyCropNutrientProduct(catalog.Products, "NH3", "93a50572-4b9a-4e17-8ea8-93883d544b6c", CategoryEnum.Additive); 
            AssertProducts.VerifyCropNutrientProduct(catalog.Products, "Manure", "7c548a23-66e8-40ae-a539-c571588a6b9c", CategoryEnum.Additive);

            AssertProducts.VerifyCropVariety(catalog.Products, catalog.Crops, "Variety1", "140c9c02-6dae-429d-be46-4b9739a53cdb", CategoryEnum.Variety, "Corn");
            AssertProducts.VerifyCropVariety(catalog.Products, catalog.Crops, "Variety2", "6b9e76ef-6c46-4086-9eda-51d80911da8c", CategoryEnum.Variety, "Corn");

            AssertProducts.VerifyCrop(catalog.Crops, "Barley", "2", 21.77, "kg1bu-1", 14, "prcnt");
            AssertProducts.VerifyCrop(catalog.Crops, "Canola", "5", 23.59, "kg1bu-1", 10, "prcnt");
            AssertProducts.VerifyCrop(catalog.Crops, "Corn", "173", 25.4, "kg1bu-1", 15, "prcnt");
            AssertProducts.VerifyCrop(catalog.Crops, "Cotton", "175", 480, "kg1bu-1", 6, "prcnt");
            AssertProducts.VerifyCrop(catalog.Crops, "Oats", "11", 14.51, "kg1bu-1", 14, "prcnt");
            AssertProducts.VerifyCrop(catalog.Crops, "Rape Seed", "16", 23.59, "kg1bu-1", 8, "prcnt");
            AssertProducts.VerifyCrop(catalog.Crops, "Rice", "17", 20.41, "kg1bu-1", 14, "prcnt");
            AssertProducts.VerifyCrop(catalog.Crops, "Sorghum (milo)", "21", 25.4, "kg1bu-1", 13, "prcnt");
            AssertProducts.VerifyCrop(catalog.Crops, "Soybeans", "174", 27.22, "kg1bu-1", 13, "prcnt");
            AssertProducts.VerifyCrop(catalog.Crops, "Sunflowers", "40", 11.33, "kg1bu-1", 9, "prcnt");
            AssertProducts.VerifyCrop(catalog.Crops, "Wheat", "24", 27.22, "kg1bu-1", 13, "prcnt");

            AssertDevices.VerifyDeviceModel(catalog.DeviceModels, "9x30T", "5c3cab35-9829-42fe-932f-5c8b3331a8e4");
            AssertDevices.VerifyDeviceModel(catalog.DeviceModels, "7x30", "80bc222d-4dee-4bb1-897f-0af6e9ae2e9e");
            AssertDevices.VerifyDeviceModel(catalog.DeviceModels, "2410 Chisel Plow", "90c0810f-f492-485b-8ce3-179a8be45fbe");
            AssertDevices.VerifyDeviceModel(catalog.DeviceModels, "1770NT", "d143fca4-bad0-4281-b53e-8f93becd1230");

            AssertDevices.VerifyDeviceElement(catalog.DeviceElements, "8430", "serial-1", "d3ea4736-0424-47fd-9c93-e531362a1f4f", "Tractor", DeviceElementTypeEnum.Machine);
            AssertDevices.VerifyDeviceElement(catalog.DeviceElements, "8320", "serial-2", "fc979391-7cd8-45fe-905b-1d26aa96f91d", "Tractor", DeviceElementTypeEnum.Machine);
            AssertDevices.VerifyDeviceElement(catalog.DeviceElements, "4730", "serial-3", "dc562db9-a2ea-4420-a003-00a9ccbc8153", "Sprayer", DeviceElementTypeEnum.Machine);
            AssertDevices.VerifyDeviceElement(catalog.DeviceElements, "9560 STS", "serial-4", "67907d7f-014b-4625-81f6-a5a65f3e788a", "Combine", DeviceElementTypeEnum.Machine);

            AssertDevices.VerifyDeviceElement(catalog.DeviceElements, "373", "serial-1", "b4def480-ee2a-4a28-a6a1-3898af96c385", "Tillage", DeviceElementTypeEnum.Implement);
            AssertDevices.VerifyDeviceElement(catalog.DeviceElements, "1770 NT", "serial-1", "4135b823-13cf-41a9-8286-9eb40119800c", "Planter", DeviceElementTypeEnum.Implement);
            AssertDevices.VerifyDeviceElement(catalog.DeviceElements, "714 Tiller", "serial-2", "b9a50513-b9cd-4065-9373-ab73e8bfa1b6", "Tillage", DeviceElementTypeEnum.Implement);
            AssertDevices.VerifyDeviceElement(catalog.DeviceElements, "1890", "serial-3", "e89b3ac3-57bf-4510-80cd-5b2135e1da88", "Air Cart", DeviceElementTypeEnum.Implement);

            var offsets8430 = new Dictionary<string, Tuple<double, string>>
            {
                {RepresentationInstanceList.vrGPSToNonSteeringAxleOffset.DomainId, new Tuple<double, string>(4.7, "in")},
                {RepresentationInstanceList.vrReceiverOffset.DomainId, new Tuple<double, string>(9.5, "in")},
            };

            AssertDevices.VerifyMachineConfiguration(catalog.Connectors, catalog.DeviceElements, catalog.DeviceElementConfigurations, catalog.HitchPoints,
                "8430", HitchTypeEnum.ISO730ThreePointHitchMounted, OriginAxleLocationEnum.Rear, offsets8430);
            AssertDevices.VerifyMachineConfiguration(catalog.Connectors, catalog.DeviceElements, catalog.DeviceElementConfigurations, catalog.HitchPoints,
                "8320", HitchTypeEnum.ISO730ThreePointHitchMounted, OriginAxleLocationEnum.Rear, new Dictionary<string, Tuple<double, string>>());
            AssertDevices.VerifyMachineConfiguration(catalog.Connectors, catalog.DeviceElements, catalog.DeviceElementConfigurations, catalog.HitchPoints,
                "4730", HitchTypeEnum.ISO730ThreePointHitchMounted, OriginAxleLocationEnum.Rear, new Dictionary<string, Tuple<double, string>>());
            AssertDevices.VerifyMachineConfiguration(catalog.Connectors, catalog.DeviceElements, catalog.DeviceElementConfigurations, catalog.HitchPoints,
                "9560 STS", HitchTypeEnum.ISO730ThreePointHitchMounted, OriginAxleLocationEnum.Rear, new Dictionary<string, Tuple<double, string>>());

            var offsets373 = new Dictionary<string, Tuple<double, string>>
            {
                {RepresentationInstanceList.vrEquipmentWidth.DomainId, new Tuple<double, string>(32.0, "ft")},
                {RepresentationInstanceList.vrTrackSpacing.DomainId, new Tuple<double, string>(32.0, "ft")},
                {RepresentationInstanceList.vrPhysicalImplementWidth.DomainId, new Tuple<double, string>(33.0, "ft")},
                {RepresentationInstanceList.vrImplementLength.DomainId, new Tuple<double, string>(5.3, "ft")},
                {RepresentationInstanceList.vrInlineControlPointToConnectionOffset.DomainId, new Tuple<double, string>(9.8, "ft")},
                {RepresentationInstanceList.vrLateralControlPointToConnectionOffset.DomainId, new Tuple<double, string>(6.7, "in")},
                {RepresentationInstanceList.vrImplementFrontOffset.DomainId, new Tuple<double, string>(6.8, "ft")},
                {RepresentationInstanceList.vrLateralConnectionPointToReceiverOffset.DomainId, new Tuple<double, string>(0, "in")},
                {RepresentationInstanceList.vrInlineConnectionPointToReceiverOffset.DomainId, new Tuple<double, string>(0, "ft")}
            };

            AssertDevices.VerifyImplementConfiguration(catalog.Connectors, catalog.DeviceElements, catalog.DeviceElementConfigurations, catalog.HitchPoints,
                "373", offsets373);
            AssertDevices.VerifyImplementConfiguration(catalog.Connectors, catalog.DeviceElements, catalog.DeviceElementConfigurations, catalog.HitchPoints,
                "1770 NT", new Dictionary<string, Tuple<double, string>>());
            AssertDevices.VerifyImplementConfiguration(catalog.Connectors, catalog.DeviceElements, catalog.DeviceElementConfigurations, catalog.HitchPoints,
                "714 Tiller", new Dictionary<string, Tuple<double, string>>());
            AssertDevices.VerifyImplementConfiguration(catalog.Connectors, catalog.DeviceElements, catalog.DeviceElementConfigurations, catalog.HitchPoints,
                "1890", new Dictionary<string, Tuple<double, string>>());

            //This bad boundary data card does not have any goemetry attached to it. Check other tests which verify boundary spatial data
            AssertBoundaries.VerifyBoundary(catalog.FieldBoundaries, catalog.Fields, catalog.Farms, catalog.Growers,
                "36293da7-19b0-47dd-b28c-f42d2464ed5a", "Client_1", "9309ad91-34a7-46d1-8fc4-2a8200bfd1fe", 
                "Farm_1", "71695e14-c72a-4ad5-924e-6a8a93273b42", "Field_1", "c5f76cad-2447-46bf-a291-64039bef531f", 1000, "ac",
                GpsSourceEnum.DeereRTK, new List<string>{"Pond"}, 0);

            AssertGuidance.VerifyAbLine(catalog.GuidancePatterns, catalog.Growers, catalog.Farms, catalog.Fields,
                "ABLine1", "d3bb7e96-6f48-4fc5-b955-f9adef634189", "Client_2", "f012ab09-2bfa-4b43-bd84-0639fc964a37",
                "Farm_2", "a9a27c6c-d535-49fe-9f7e-baa1be498dee", "Field_2", "1dbfd5b6-5e93-4c3b-a823-74194046714d", 2000, "ac", 100.1, 0.1, 0.1, 
                new Point {X = -90.74156051, Y = 40.61723241}, new Point {X = -90.74162551, Y = 40.61084801});

            AssertGuidance.VerifyPivotGuidance(catalog.GuidancePatterns, catalog.Growers, catalog.Farms, catalog.Fields,
                "CircleTrack1", "5c257ad5-bcea-4ede-905c-6f286154f1a9", "Client_3", "c1453376-973a-4aae-afc7-e9cf124546b1",
                "Farm_3", "d084bb88-4df8-4fcb-a913-dd01b854cd78", "Field_3", "1d427ee9-9530-48cd-bc09-610bc6aa0359", 3000, "ac", 
                new Point { X = -90.49236844, Y = 41.48970819}, new Point { X = -90.49233529657748, Y = 41.489707467589085 }, 
                new Point { X = -90.49236844, Y = 41.48970819}, 0, "cm", PropagationDirectionEnum.NoPropagation, GuidanceExtensionEnum.None);

            //This abcurve data card does not have any goemetry attached to it. Check other tests which verify ab curve spatial data
            AssertGuidance.VerifyAbCurve(catalog.GuidancePatterns, catalog.Growers, catalog.Farms, catalog.Fields,
                "ABCurve1", "862db2bc-e7d8-4476-8aa6-f80830c77f3a", "Client_1", "9309ad91-34a7-46d1-8fc4-2a8200bfd1fe",
                "Farm_1", "71695e14-c72a-4ad5-924e-6a8a93273b42", "Field_5", "0bcbfbec-f064-42c2-a98a-57c434ba7be6", 1000, "ac", 9, 36.71572876, 0.0, 0.0,
                GpsSourceEnum.DesktopGeneratedData, new Point { X = -90.49276618, Y = 41.4895797 }, new Point { X = -90.49227984, Y = 41.49007002 }, 0, 0, 
                new List<Point>
                {
                    new Point{X =  -90.49331356, Y = 41.49024408},
                    new Point{X = -90.49173246, Y = 41.49024408},
                    new Point{X = -90.49173246, Y = 41.48941734},
                    new Point{X = -90.49331356, Y = 41.48941734},
                    new Point{X = -90.49331356, Y = 41.49024408}
                });
        }

        [Test]
        public void GivenOlderVersionDocCardWhenImportedToVersionWithChangedPropertyAndTypeNamesThenImportsToTheNewerModel()
        {
            _cardPath = DatacardUtility.WriteDatacard("ADMDocV1_0_8");

            var plugin = new Plugin();
            var applicationDataModel = plugin.Import(_cardPath);

            var id = applicationDataModel.First().Catalog.Connectors.First().DeviceElementConfigurationId;

            Assert.AreNotEqual(0, id);
        }

        [TearDown]
        public void Teardown()
        {
            try
            {
                var directoryName = Path.GetDirectoryName(_cardPath);
                if (directoryName != null)
                {
                    Directory.Delete(directoryName, true);
                }
            }
            catch { }
        }
    }
}
