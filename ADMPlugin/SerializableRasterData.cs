using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace ADMPlugin
{
    public class SerializableRasterData<TVal>
    {
        public List<TVal> values;
        public Representation Representation;
    }
}
