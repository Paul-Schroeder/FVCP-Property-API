using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.DTO
{
    public class PropertyDTO : IPropertyDTO
    {
        public PropertyDTO()
        {
            this.PropertyTagDTOs = new List<IPropertyTagDTO>();
        }

        public string Pin { get; set; }
        public short ClassNum { get; set; }
        public int TownNum { get; set; }
        public Nullable<short> Volume { get; set; }
        public string LocationId { get; set; }
        public int TaxCode { get; set; }
        public int NeighborhoodId { get; set; }
        public Nullable<short> HomeImpYear { get; set; }
        public string ResType { get; set; }
        public string BuildingUse { get; set; }
        public string AptCount { get; set; }
        public string CommUnits { get; set; }
        public string ExtDesc { get; set; }
        public Nullable<byte> FullBath { get; set; }
        public Nullable<byte> HalfBath { get; set; }
        public string BasementDesc { get; set; }
        public string AtticDesc { get; set; }
        public Nullable<byte> AirCond { get; set; }
        public Nullable<byte> Fireplace { get; set; }
        public string GarageDesc { get; set; }
        public short Age { get; set; }
        public Nullable<int> BuildingSF { get; set; }
        public Nullable<int> LandSF { get; set; }
        public string TotalAllBuildingSF { get; set; }
        public string UnitsTotal { get; set; }
        public string SaleDate { get; set; }
        public Nullable<int> SaleAmount { get; set; }

        public virtual IPropertyClassDTO PropertyClassDTO { get; set; }
        public virtual ITownshipDTO TownshipDTO { get; set; }
        public virtual IPropertyAddressDTO PropertyAddressDTO { get; set; }
        public virtual List<IPropertyTagDTO> PropertyTagDTOs { get; set; }

    }
}
