using FVCP.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Persistence
{
    public class PropertyRepository : IPropertyRepository
    {
        public void AddTag(string tag)
        {
            throw new NotImplementedException();
        }

        public IProperty GetByPin(string pin)
        {
            PropertyFactory pFact = new PropertyFactory();
            IProperty retVal = pFact.Create();

            //TODO: Call DB.
            retVal.Pin = pin;

            return retVal;
        }

        public IProperty Save(IProperty property)
        {
            throw new NotImplementedException();
        }
    }
}
