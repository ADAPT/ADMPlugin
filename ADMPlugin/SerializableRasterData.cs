using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ADMPlugin
{
    public class SerializableRasterData<TVal>
    {
        public List<TVal> values;
        public ApplicationDataModel.Representations.Representation Representation;
    }
}
