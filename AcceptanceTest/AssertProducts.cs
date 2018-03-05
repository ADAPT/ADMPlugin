using System;
using System.Collections.Generic;
using System.Linq;
using AgGateway.ADAPT.ApplicationDataModel.Products;
using AgGateway.ADAPT.Representation.RepresentationSystem;
using NUnit.Framework;

namespace AcceptanceTest
{
    public static class AssertProducts
    {
        public static void VerifyCropProtectionProduct(List<Product> catalogProducts, string expectedDescription, string expectedGuid, CategoryEnum expectedCategoryEnum)
        {
            VerifyProduct(catalogProducts, expectedDescription, expectedGuid, expectedCategoryEnum, typeof(CropProtectionProduct));
        }

        public static void VerifyCropNutrientProduct(List<Product> catalogProducts, string expectedDescription, string expectedGuid, CategoryEnum expectedCategoryEnum)
        {
            VerifyProduct(catalogProducts, expectedDescription, expectedGuid, expectedCategoryEnum, typeof(CropNutritionProduct));
        }

        public static void VerifyCropVariety(List<Product> catalogProducts, List<Crop> catalogCrops, string expectedDescription, 
            string expectedGuid, CategoryEnum expectedCategoryEnum, string expectedCrop)
        {
            var product = VerifyProduct(catalogProducts, expectedDescription, expectedGuid, expectedCategoryEnum, typeof(CropVarietyProduct));

            var crop = catalogCrops.Find(x => x.Name == expectedCrop);
            Assert.AreEqual(crop.Id.ReferenceId, ((CropVarietyProduct)product).CropId);
        }

        private static Product VerifyProduct(List<Product> catalogProducts, string expectedDescription, string expectedGuid,
            CategoryEnum expectedCategoryEnum, Type instanceType)
        {
            var product = catalogProducts.Find(x => x.Id.UniqueIds.Exists(id => id.Id == expectedGuid));

            Assert.IsNotNull(product);
            Assert.IsInstanceOf(instanceType, product);
            Assert.AreEqual(expectedDescription, product.Description);
            Assert.AreEqual(expectedCategoryEnum, product.Category);
            return product;
        }

        public static void VerifyCrop(List<Crop> catalogCrops, string expectedName, string expectedId, 
            double expectedCropWeight, string expectedCropWeightUnit, 
            int expectedStandardPayableMoisture, string expectedStandardPayableMoistureUnit)
        {
            var crop = catalogCrops.Find(x => x.Id.UniqueIds.First().Id == expectedId);

            Assert.IsNotNull(crop);
            Assert.AreEqual(expectedName, crop.Name);

            Assert.AreEqual(expectedCropWeight, crop.ReferenceWeight.Value.Value);
            Assert.AreEqual(expectedCropWeightUnit, crop.ReferenceWeight.Value.UnitOfMeasure.Code);
            Assert.AreEqual(RepresentationInstanceList.vrCropWeightVolume.DomainId, crop.ReferenceWeight.Representation.Code);

            Assert.AreEqual(expectedStandardPayableMoisture, crop.StandardPayableMoisture.Value.Value);
            Assert.AreEqual(expectedStandardPayableMoistureUnit, crop.StandardPayableMoisture.Value.UnitOfMeasure.Code);
            Assert.AreEqual(RepresentationInstanceList.vrStandardPayableMoisture.DomainId, crop.StandardPayableMoisture.Representation.Code);
        }
    }
}