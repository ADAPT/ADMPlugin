using System;
using System.Collections.Generic;
using System.Linq;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.Representation.RepresentationSystem;
using NUnit.Framework;

namespace AgGateway.ADAPT.AcceptanceTest
{
    public class AssertDevices
    {
        public static void VerifyDeviceElement(List<DeviceElement> catalogDeviceElements, string expectedDescription, 
            string expectedSerialNumber, string expectedGuid, string expectedDeviceClassification, DeviceElementTypeEnum expectedType)
        {
            var deviceElement = catalogDeviceElements.Find(x => x.Id.UniqueIds.Exists(id => id.Id == expectedGuid));
            Assert.IsNotNull(deviceElement);

            Assert.AreEqual(expectedDescription, deviceElement.Description);
            Assert.AreEqual(expectedSerialNumber, deviceElement.SerialNumber);
            Assert.AreEqual(expectedDeviceClassification, deviceElement.DeviceClassification.Value.Value);
            Assert.AreEqual(expectedType, deviceElement.DeviceElementType);
        }

        public static void VerifyDeviceModel(List<DeviceModel> catalogDeviceModels, string expectedDescription, string expectedGuid)
        {
            var model = catalogDeviceModels.Find(x => x.Id.UniqueIds.Exists(id => id.Id == expectedGuid));
            Assert.IsNotNull(model);

            Assert.AreEqual(expectedDescription, model.Description);
        }

        public static void VerifyMachineConfiguration(List<Connector> catalogConnectors, List<DeviceElement> catalogDeviceElements, 
            List<DeviceElementConfiguration> catalogDeviceElementConfigurations, List<HitchPoint> catalogHitchPoints, string deviceElementDescription, 
            HitchTypeEnum expectedHitchTypeEnum, OriginAxleLocationEnum expectedOriginAxleLocationEnum, Dictionary<string, Tuple<double, string>> expectedOffsets)
        {
            var configuration = VerifyDeviceElementConfiguration(catalogConnectors, catalogDeviceElements, catalogHitchPoints,
                catalogDeviceElementConfigurations, deviceElementDescription, expectedHitchTypeEnum);

            Assert.IsInstanceOf<MachineConfiguration>(configuration);

            var machineConfiguration = (MachineConfiguration) configuration;

            Assert.AreEqual(expectedOriginAxleLocationEnum, machineConfiguration.OriginAxleLocation);

            var gpsReceiverXOffset = RepresentationInstanceList.vrGPSToNonSteeringAxleOffset.DomainId;
            if (expectedOffsets.ContainsKey(gpsReceiverXOffset))
            {
                var expectedOffset = expectedOffsets[gpsReceiverXOffset];
                var actualOffset = machineConfiguration.GpsReceiverXOffset;

                Assert.AreEqual(expectedOffset.Item1, actualOffset.Value.Value);
                Assert.AreEqual(expectedOffset.Item2, actualOffset.Value.UnitOfMeasure.Code);
                Assert.AreEqual(gpsReceiverXOffset, actualOffset.Representation.Code);
            }

            var gpsReceiverYOffset = RepresentationInstanceList.vrReceiverOffset.DomainId;
            if (expectedOffsets.ContainsKey(gpsReceiverYOffset))
            {
                var expectedOffset = expectedOffsets[gpsReceiverYOffset];
                var actualOffset = machineConfiguration.GpsReceiverYOffset;

                Assert.AreEqual(expectedOffset.Item1, actualOffset.Value.Value);
                Assert.AreEqual(expectedOffset.Item2, actualOffset.Value.UnitOfMeasure.Code);
                Assert.AreEqual(gpsReceiverYOffset, actualOffset.Representation.Code);
            }
        }

        public static void VerifyImplementConfiguration(List<Connector> catalogConnectors, List<DeviceElement> catalogDeviceElements, 
            List<DeviceElementConfiguration> catalogDeviceElementConfigurations, List<HitchPoint> catalogHitchPoints, string deviceElementDescription, 
            Dictionary<string, Tuple<double, string>> expectedOffsets)
        {
            var configuration = VerifyDeviceElementConfiguration(catalogConnectors, catalogDeviceElements, catalogHitchPoints,
                catalogDeviceElementConfigurations, deviceElementDescription, null);
            
            Assert.IsInstanceOf<ImplementConfiguration>(configuration);

            var implementConfiguration = (ImplementConfiguration)configuration;

            var equipmentWidthDomainId = RepresentationInstanceList.vrEquipmentWidth.DomainId;
            if (expectedOffsets.ContainsKey(equipmentWidthDomainId))
            {
                var expectedWidth = expectedOffsets[equipmentWidthDomainId];
                var actualWidth = implementConfiguration.Width;

                Assert.AreEqual(expectedWidth.Item1, actualWidth.Value.Value);
                Assert.AreEqual(expectedWidth.Item2, actualWidth.Value.UnitOfMeasure.Code);
                Assert.AreEqual(equipmentWidthDomainId, actualWidth.Representation.Code);
            }

            var trackSpacingDomainId = RepresentationInstanceList.vrTrackSpacing.DomainId;
            if (expectedOffsets.ContainsKey(trackSpacingDomainId))
            {
                var expectedTrackSpacing = expectedOffsets[trackSpacingDomainId];
                var actualTrackSpacing = implementConfiguration.TrackSpacing;

                Assert.AreEqual(expectedTrackSpacing.Item1, actualTrackSpacing.Value.Value);
                Assert.AreEqual(expectedTrackSpacing.Item2, actualTrackSpacing.Value.UnitOfMeasure.Code);
                Assert.AreEqual(trackSpacingDomainId, actualTrackSpacing.Representation.Code);
            }

            var physicalImplementWidthDomainId = RepresentationInstanceList.vrPhysicalImplementWidth.DomainId;
            if (expectedOffsets.ContainsKey(physicalImplementWidthDomainId))
            {
                var expectedPhysialWidth = expectedOffsets[physicalImplementWidthDomainId];
                var actualPhysicalWidth = implementConfiguration.PhysicalWidth;

                Assert.AreEqual(expectedPhysialWidth.Item1, actualPhysicalWidth.Value.Value);
                Assert.AreEqual(expectedPhysialWidth.Item2, actualPhysicalWidth.Value.UnitOfMeasure.Code);
                Assert.AreEqual(physicalImplementWidthDomainId, actualPhysicalWidth.Representation.Code);
            }

            var implementLengthDomainId = RepresentationInstanceList.vrImplementLength.DomainId;
            if (expectedOffsets.ContainsKey(implementLengthDomainId))
            {
                var expectedImplementLength = expectedOffsets[implementLengthDomainId];
                var actualImplementLength = implementConfiguration.ImplementLength;

                Assert.AreEqual(expectedImplementLength.Item1, actualImplementLength.Value.Value);
                Assert.AreEqual(expectedImplementLength.Item2, actualImplementLength.Value.UnitOfMeasure.Code);
                Assert.AreEqual(implementLengthDomainId, actualImplementLength.Representation.Code);
            }

            var controlPointXOffsetDomainId = RepresentationInstanceList.vrInlineControlPointToConnectionOffset.DomainId;
            if (expectedOffsets.ContainsKey(controlPointXOffsetDomainId))
            {
                var expectedXOffset = expectedOffsets[controlPointXOffsetDomainId];
                var actualYOffset = implementConfiguration.ControlPoint.XOffset;

                Assert.AreEqual(expectedXOffset.Item1, actualYOffset.Value.Value);
                Assert.AreEqual(expectedXOffset.Item2, actualYOffset.Value.UnitOfMeasure.Code);
                Assert.AreEqual(controlPointXOffsetDomainId, actualYOffset.Representation.Code);
            }

            var controlPointYOffsetDomainId = RepresentationInstanceList.vrLateralControlPointToConnectionOffset.DomainId;
            if (expectedOffsets.ContainsKey(controlPointYOffsetDomainId))
            {
                var expectedYOffset = expectedOffsets[controlPointYOffsetDomainId];
                var acualYOffset = implementConfiguration.ControlPoint.YOffset;

                Assert.AreEqual(expectedYOffset.Item1, acualYOffset.Value.Value);
                Assert.AreEqual(expectedYOffset.Item2, acualYOffset.Value.UnitOfMeasure.Code);
                Assert.AreEqual(controlPointYOffsetDomainId, acualYOffset.Representation.Code);
            }

            var implementFrontOffsetDomainId = RepresentationInstanceList.vrImplementFrontOffset.DomainId;
            if (expectedOffsets.ContainsKey(implementFrontOffsetDomainId))
            {
                var expectedFrontOffset = expectedOffsets[implementFrontOffsetDomainId];
                var actualFrontOffset = implementConfiguration.Offsets.First(x=>x.Representation.Code == implementFrontOffsetDomainId);

                Assert.AreEqual(expectedFrontOffset.Item1, actualFrontOffset.Value.Value);
                Assert.AreEqual(expectedFrontOffset.Item2, actualFrontOffset.Value.UnitOfMeasure.Code);
                Assert.AreEqual(implementFrontOffsetDomainId, actualFrontOffset.Representation.Code);
            }

            var lateralConnectionPointToRecieverOffset = RepresentationInstanceList.vrLateralConnectionPointToReceiverOffset.DomainId;
            if (expectedOffsets.ContainsKey(lateralConnectionPointToRecieverOffset))
            {
                var expectedOffset = expectedOffsets[lateralConnectionPointToRecieverOffset];
                var actualOffset = implementConfiguration.Offsets.First(x => x.Representation.Code == lateralConnectionPointToRecieverOffset);

                Assert.AreEqual(expectedOffset.Item1, actualOffset.Value.Value);
                Assert.AreEqual(expectedOffset.Item2, actualOffset.Value.UnitOfMeasure.Code);
                Assert.AreEqual(lateralConnectionPointToRecieverOffset, actualOffset.Representation.Code);
            }

            var inlineConnectionPointToRecieverOffset = RepresentationInstanceList.vrInlineConnectionPointToReceiverOffset.DomainId;
            if (expectedOffsets.ContainsKey(inlineConnectionPointToRecieverOffset))
            {
                var expectedOffset = expectedOffsets[inlineConnectionPointToRecieverOffset];
                var actualOffset = implementConfiguration.Offsets.First(x => x.Representation.Code == inlineConnectionPointToRecieverOffset);

                Assert.AreEqual(expectedOffset.Item1, actualOffset.Value.Value);
                Assert.AreEqual(expectedOffset.Item2, actualOffset.Value.UnitOfMeasure.Code);
                Assert.AreEqual(inlineConnectionPointToRecieverOffset, actualOffset.Representation.Code);
            }
        }

        private static DeviceElementConfiguration VerifyDeviceElementConfiguration(List<Connector> catalogConnectors, List<DeviceElement> catalogDeviceElements,
            List<HitchPoint> catalogHitchPoints, List<DeviceElementConfiguration> catalogDeviceElementConfigurations, 
            string deviceElementDescription, HitchTypeEnum? expectedHitchTypeEnum)
        {
            var deviceElement = catalogDeviceElements.Find(x => x.Description == deviceElementDescription);
            Assert.IsNotNull(deviceElement);

            var deviceElementConfiguration = catalogDeviceElementConfigurations.Find(x => x.DeviceElementId == deviceElement.Id.ReferenceId);
            Assert.IsNotNull(deviceElementConfiguration);

            var connector = catalogConnectors.Find(x => x.DeviceElementConfigurationId == deviceElementConfiguration.Id.ReferenceId);
            Assert.IsNotNull(connector);

            if (connector.HitchPointId != 0 && expectedHitchTypeEnum != null)
            {
                var hitchPoint = catalogHitchPoints.Find(x => x.Id.ReferenceId == connector.HitchPointId);
                Assert.IsNotNull(hitchPoint);

                Assert.AreEqual(expectedHitchTypeEnum, hitchPoint.HitchTypeEnum);
            }

            return deviceElementConfiguration;
        }
    }
}
