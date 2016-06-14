using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace ADMPlugin
{
    public class SerializableRasterData<TVal>
    {
        public List<TVal> values;
        public Representation Representation;
    }
}
