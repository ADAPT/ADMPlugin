using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.ADM
{
  public static class CatalogType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog), Constants.UseDefaults);
      type.AddField(183, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.Brands));
      type.AddField(692, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.Companies));
      type.AddField(184, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.Connectors));
      type.AddField(185, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.ContactInfo));
      type.AddField(187, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.Crops));
      type.AddField(190, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.CropZones));
      type.AddField(191, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.Description));
      type.AddField(505, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.DeviceElements));
      type.AddField(506, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.DeviceModels));
      type.AddField(507, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.DeviceElementConfigurations));
      type.AddField(599, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.EquipmentConfigurations));
      type.AddField(600, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.EquipmentConfigurationGroups));
      type.AddField(193, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.Farms));
      type.AddField(195, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.Fields));
      type.AddField(196, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.FieldBoundaries));
      type.AddField(197, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.Growers));
      type.AddField(198, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.GuidancePatterns));
      type.AddField(199, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.GuidanceGroups));
      type.AddField(508, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.HitchPoints));
      type.AddField(204, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.Ingredients));
      type.AddField(210, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.Manufacturers));
      type.AddField(211, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.Persons));
      type.AddField(212, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.PersonRoles));
      type.AddField(213, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.Prescriptions));
      type.AddField(693, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.Products));
      type.AddField(215, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.Catalog.TimeScopes));
    }
  }
}
