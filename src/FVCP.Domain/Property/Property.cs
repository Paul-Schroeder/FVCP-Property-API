using FVCP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.Domain
{
    public class Property : IProperty
    {
        public Property(IPropertyDTO data)
        {
            this.Data = data;
        }

        public IPropertyDTO Data { get; set; }

        IPropertyAddress _propertyAddress;
        public IPropertyAddress PropertyAddress
        {
            get
            {
                if (_propertyAddress == null && this.Data != null)
                {   // Initialize based upon our DTO data.
                    PropertyAddressFactory myFact = new PropertyAddressFactory();
                    _propertyAddress = myFact.Create(this.Data.PropertyAddressDTO);
                }

                return _propertyAddress;
            }

            set
            {
                _propertyAddress = value;
            }
        }

        IPropertyClass _propertyClass;
        public IPropertyClass PropertyClass
        {
            get
            {
                if (_propertyClass == null && this.Data != null)
                {   // Initialize based upon our DTO data.
                    PropertyClassFactory myFact = new PropertyClassFactory();
                    _propertyClass = myFact.Create(this.Data.PropertyClassDTO);
                }

                return _propertyClass;
            }

            set
            {
                _propertyClass = value;
            }
        }

        List<IPropertyTag> _propertyTags;
        public List<IPropertyTag> PropertyTags
        {
            get
            {
                if (_propertyTags == null && this.Data != null && this.Data.PropertyTagDTOs != null)
                {   // Initialize based upon our DTO data.
                    PropertyTagFactory myFact = new PropertyTagFactory();
                    _propertyTags = new List<IPropertyTag>();
                    foreach (var item in this.Data.PropertyTagDTOs)
                    {
                        _propertyTags.Add(myFact.Create(item));
                    }
                }

                return _propertyTags;
            }

            set
            {
                _propertyTags = value;
            }
        }

        ITownship _township;
        public ITownship Township
        {
            get
            {
                if (_township == null && this.Data != null)
                {   // Initialize based upon our DTO data.
                    TownshipFactory myFact = new TownshipFactory();
                    _township = myFact.Create(this.Data.TownshipDTO);
                }

                return _township;
            }

            set
            {
                _township = value;
            }
        }

        public void AddPropertyTag(string tag)
        {
            IPropertyTag myTag = this.PropertyTags.FirstOrDefault(x => x.Data.Name == tag);
            if (myTag == null)
            {
                PropertyTagFactory myFact = new PropertyTagFactory();
                myTag = myFact.Create(new PropertyTagDTO() {
                    Id = 0,
                    Name = tag,
                    Pin = this.Data.Pin
                });

                this.PropertyTags.Add(myTag);
            }
        }

    }
}
