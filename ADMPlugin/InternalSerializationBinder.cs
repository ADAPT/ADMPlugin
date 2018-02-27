using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json.Serialization;

namespace ADMPlugin
{
    public class InternalSerializationBinder : ISerializationBinder
    {
        private readonly Dictionary<string, string> _version108To110ChangedTypes = new Dictionary<string, string>
        {
            {"AgGateway.ADAPT.ApplicationDataModel.Products.FertilizerProduct", "AgGateway.ADAPT.ApplicationDataModel.Products.CropNutritionProduct"},
            {"AgGateway.ADAPT.ApplicationDataModel.Products.CropVariety", "AgGateway.ADAPT.ApplicationDataModel.Products.CropVarietyProduct"},
            {"AgGateway.ADAPT.ApplicationDataModel.Products.ProductMix", "AgGateway.ADAPT.ApplicationDataModel.Products.MixProduct"},
            {"AgGateway.ADAPT.ApplicationDataModel.Guidance.CenterPivot", "AgGateway.ADAPT.ApplicationDataModel.Guidance.PivotGuidancePattern"}
        };

        private readonly SerializationBinder _serializationBinder = new DefaultSerializationBinder();

        public Type BindToType(string assemblyName, string typeName)
        {
            if (_version108To110ChangedTypes.ContainsKey(typeName))
            {
                typeName = _version108To110ChangedTypes[typeName];
            }

            return _serializationBinder.BindToType(assemblyName, typeName);
        }

        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            _serializationBinder.BindToName(serializedType, out assemblyName, out typeName);
        }
    }
}