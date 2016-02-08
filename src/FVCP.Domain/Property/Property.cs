using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Property
{
    public class Property : IProperty
    {
        public Property()
        {
            this.Tags = new List<string>();
        }

        public string Pin { get; set; }
        public List<string> Tags { get; set; }

        public void AddTag(string tag)
        {
            Tags.Add(tag);
        }
    }
}
