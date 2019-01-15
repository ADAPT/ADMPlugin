using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.ADM
{
  public static class CatalogType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.Brands));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.Companies));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.Connectors));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.ContactInfo));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.Crops));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.CropZones));
      type.AddField(7, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.Description));
      type.AddField(8, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.DeviceElements));
      type.AddField(9, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.DeviceModels));
      type.AddField(10, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.DeviceElementConfigurations));
      type.AddField(11, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.EquipmentConfigurations));
      type.AddField(12, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.EquipmentConfigurationGroups));
      type.AddField(13, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.Farms));
      type.AddField(14, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.Fields));
      type.AddField(15, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.FieldBoundaries));
      type.AddField(16, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.Growers));
      type.AddField(17, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.GuidancePatterns));
      type.AddField(18, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.GuidanceGroups));
      type.AddField(19, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.HitchPoints));
      type.AddField(20, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.Ingredients));
      type.AddField(21, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.Manufacturers));
      type.AddField(22, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.Persons));
      type.AddField(23, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.PersonRoles));
      type.AddField(24, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.Prescriptions));
      type.AddField(25, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.Products));
      type.AddField(26, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.TimeScopes));
    }
  }
}
