using AgGateway.ADAPT.ADMPlugin;
using NUnit.Framework;

namespace AgGateway.ADAPT.PluginTest
{
    [TestFixture]
    public class InternalSerializationBinderTest
    {
        private InternalSerializationBinder _internalSerializationBinder;

        [SetUp]
        public void SetUp()
        {
            _internalSerializationBinder = new InternalSerializationBinder();    
        }

        [Test]
        public void GivenOlderTypeWhenBindReturnsNewUpdatedType()
        {
            var actualType = _internalSerializationBinder.BindToType("AgGateway.ADAPT.ApplicationDataModel", "AgGateway.ADAPT.ApplicationDataModel.Products.FertilizerProduct");
            var expectedType = typeof(AgGateway.ADAPT.ApplicationDataModel.Products.CropNutritionProduct);

            Assert.AreEqual(expectedType, actualType);
        }

        [Test]
        public void GivenTypeNotChangedWhenBindReturnsCorrectType()
        {
            var actualType = _internalSerializationBinder.BindToType("AgGateway.ADAPT.ApplicationDataModel", "AgGateway.ADAPT.ApplicationDataModel.Products.Crop");
            var expectedType = typeof(AgGateway.ADAPT.ApplicationDataModel.Products.Crop);

            Assert.AreEqual(expectedType, actualType);
        }
    }
}
