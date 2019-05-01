using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1
{
  public static class AdaptTypeModelV1
  {
    public static RuntimeTypeModel CreateTypeModel()
    {
      var typeModel = RuntimeTypeModel.Create();

      // Common
      Common.ContextItemDefinitionType.Configure(typeModel);
      Common.ContextItemEnumItemType.Configure(typeModel);
      Common.GeoPoliticalContextType.Configure(typeModel);
      Common.LanguageType.Configure(typeModel);
      Common.LexicalizationType.Configure(typeModel);
      Common.ModelScopeType.Configure(typeModel);
      Common.PresentationType.Configure(typeModel);
      Common.CompoundIdentifierType.Configure(typeModel);
      Common.ContextItemType.Configure(typeModel);
      Common.TimeScopeType.Configure(typeModel);
      Common.UniqueIdType.Configure(typeModel);
      Common.UnitOfMeasureType.Configure(typeModel);

      // Documents
      Documents.MeteredValueType.Configure(typeModel);
      Documents.OperationSummaryType.Configure(typeModel);
      Documents.StampedMeteredValuesType.Configure(typeModel);
      Documents.SummaryType.Configure(typeModel);
      Documents.DocumentType.Configure(typeModel);
      Documents.DocumentCorrelationType.Configure(typeModel);
      Documents.PlanType.Configure(typeModel);
      Documents.RecommendationType.Configure(typeModel);
      Documents.StatusUpdateType.Configure(typeModel);
      Documents.WorkItemType.Configure(typeModel);
      Documents.WorkItemOperationType.Configure(typeModel);
      Documents.WorkOrderType.Configure(typeModel);
      Documents.WorkRecordType.Configure(typeModel);

      // Equipment
      Equipment.DeviceElementType.Configure(typeModel);
      Equipment.DeviceElementConfigurationType.Configure(typeModel);
      Equipment.DeviceModelType.Configure(typeModel);
      Equipment.EquipmentConfigurationGroupType.Configure(typeModel);
      Equipment.HitchPointType.Configure(typeModel);
      Equipment.ImplementConfigurationType.Configure(typeModel);
      Equipment.MachineConfigurationType.Configure(typeModel);
      Equipment.SectionConfigurationType.Configure(typeModel);
      Equipment.ConnectorType.Configure(typeModel);
      Equipment.EquipmentConfigurationType.Configure(typeModel);
      Equipment.ReferencePointType.Configure(typeModel);
      Equipment.DeviceElementUseType.Configure(typeModel);

      // Guidance
      Guidance.GuidancePatternType.Configure(typeModel);
      Guidance.AbCurveType.Configure(typeModel);
      Guidance.AbLineType.Configure(typeModel);
      Guidance.MultiAbLineType.Configure(typeModel);
      Guidance.APlusType.Configure(typeModel);
      Guidance.PivotGuidancePatternType.Configure(typeModel);
      Guidance.GuidanceAllocationType.Configure(typeModel);
      Guidance.GuidanceGroupType.Configure(typeModel);
      Guidance.GuidanceShiftType.Configure(typeModel);
      Guidance.SpiralType.Configure(typeModel);

      // Logistics
      Logistics.CropZoneType.Configure(typeModel);
      Logistics.BrandType.Configure(typeModel);
      Logistics.CompanyType.Configure(typeModel);
      Logistics.ContactType.Configure(typeModel);
      Logistics.ContactInfoType.Configure(typeModel);
      Logistics.FacilityType.Configure(typeModel);
      Logistics.FarmType.Configure(typeModel);
      Logistics.FieldType.Configure(typeModel);
      Logistics.GpsSourceType.Configure(typeModel);
      Logistics.GrowerType.Configure(typeModel);
      Logistics.LocationType.Configure(typeModel);
      Logistics.DestinationType.Configure(typeModel);
      Logistics.ManufacturerType.Configure(typeModel);
      Logistics.PermittedProductType.Configure(typeModel);
      Logistics.PersonType.Configure(typeModel);
      Logistics.PersonRoleType.Configure(typeModel);

      // Prescriptions
      Prescriptions.RxProductLookupType.Configure(typeModel);
      Prescriptions.PrescriptionType.Configure(typeModel);
      Prescriptions.ManualPrescriptionType.Configure(typeModel);
      Prescriptions.SpatialPrescriptionType.Configure(typeModel);
      Prescriptions.RasterGridPrescriptionType.Configure(typeModel);
      Prescriptions.RxRateType.Configure(typeModel);
      Prescriptions.RxCellLookupType.Configure(typeModel);
      Prescriptions.RxShapeLookupType.Configure(typeModel);
      Prescriptions.VectorPrescriptionType.Configure(typeModel);

      // Products
      Products.IngredientType.Configure(typeModel);
      Products.AvailableProductType.Configure(typeModel);
      Products.ProductType.Configure(typeModel);
      Products.HarvestedCommodityProductType.Configure(typeModel);
      Products.CropType.Configure(typeModel);
      Products.CropNutritionIngredientType.Configure(typeModel);
      Products.CropProtectionProductType.Configure(typeModel);
      Products.CropVarietyProductType.Configure(typeModel);
      Products.DensityFactorType.Configure(typeModel);
      Products.CropNutritionProductType.Configure(typeModel);
      Products.IngredientUseType.Configure(typeModel);
      Products.ProductComponentType.Configure(typeModel);
      Products.MixProductType.Configure(typeModel);
      Products.ProductUseType.Configure(typeModel);
      Products.TraitType.Configure(typeModel);

      // ADM
      ADM.ProprietaryValueType.Configure(typeModel);
      ADM.CatalogType.Configure(typeModel);

      // Shapes
      Shapes.BoundingBoxType.Configure(typeModel);
      Shapes.ShapeType.Configure(typeModel);
      Shapes.LinearRingType.Configure(typeModel);
      Shapes.LineStringType.Configure(typeModel);
      Shapes.MultiLineStringType.Configure(typeModel);
      Shapes.MultiPointType.Configure(typeModel);
      Shapes.MultiPolygonType.Configure(typeModel);
      Shapes.PointType.Configure(typeModel);
      Shapes.PolygonType.Configure(typeModel);

      // LoggedData
      LoggedData.CalibrationFactorType.Configure(typeModel);
      LoggedData.DataLogTriggerType.Configure(typeModel);
      LoggedData.WorkingDataType.Configure(typeModel);
      LoggedData.EnumeratedWorkingDataType.Configure(typeModel);
      LoggedData.LoadType.Configure(typeModel);
      LoggedData.LoggedDataType.Configure(typeModel);
      LoggedData.NumericWorkingDataType.Configure(typeModel);
      LoggedData.OperationDataType.Configure(typeModel);
      LoggedData.SectionSummaryType.Configure(typeModel);
      LoggedData.SpatialRecordType.Configure(typeModel);

      // FieldBoundaries
      FieldBoundaries.HeadlandType.Configure(typeModel);
      FieldBoundaries.ConstantOffsetHeadlandType.Configure(typeModel);
      FieldBoundaries.DrivenHeadlandType.Configure(typeModel);
      FieldBoundaries.FieldBoundaryType.Configure(typeModel);
      FieldBoundaries.InteriorBoundaryAttributeType.Configure(typeModel);

      // Representations
      Representations.EnumerationMemberType.Configure(typeModel);
      Representations.RepresentationType.Configure(typeModel);
      Representations.EnumeratedRepresentationType.Configure(typeModel);
      Representations.EnumeratedRepresentationGroupType.Configure(typeModel);
      Representations.RepresentationValueType.Configure(typeModel);
      Representations.EnumeratedValueType.Configure(typeModel);
      Representations.NumericValueType.Configure(typeModel);
      Representations.NumericRepresentationType.Configure(typeModel);
      Representations.NumericRepresentationValueType.Configure(typeModel);
      Representations.StringRepresentationType.Configure(typeModel);
      Representations.StringValueType.Configure(typeModel);

      // Notes
      Notes.NoteType.Configure(typeModel);

      // ReferenceLayers
      ReferenceLayers.ReferenceLayerType.Configure(typeModel);
      ReferenceLayers.RasterReferenceLayerType.Configure(typeModel);
      ReferenceLayers.ShapeLookupType.Configure(typeModel);
      ReferenceLayers.ShapeReferenceLayerType.Configure(typeModel);
      ReferenceLayers.SpatialAttributeType.Configure(typeModel);
      ReferenceLayers.RasterDataEnumeratedRepresentationType.Configure(typeModel);
      ReferenceLayers.RasterDataStringRepresentationType.Configure(typeModel);
      ReferenceLayers.RasterDataNumericRepresentationType.Configure(typeModel);
      ReferenceLayers.SerializableRasterDataEnumerationMemberType.Configure(typeModel);
      ReferenceLayers.SerializableRasterDataStringType.Configure(typeModel);
      ReferenceLayers.SerializableRasterDataNumericValueType.Configure(typeModel);
      ReferenceLayers.SerializableShapeDataType.Configure(typeModel);
      ReferenceLayers.SerializableReferenceLayerType.Configure(typeModel);

      return typeModel;
    }
  }
}
