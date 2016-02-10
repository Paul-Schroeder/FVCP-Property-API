using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVCP.DTO
{
    public interface IPropertyDTO
    {
        string Pin { get; set; }
        short ClassNum { get; set; }
        int TownNum { get; set; }
        Nullable<short> Volume { get; set; }
        string LocationId { get; set; }
        int TaxCode { get; set; }
        int NeighborhoodId { get; set; }
        Nullable<short> HomeImpYear { get; set; }
        string ResType { get; set; }
        string BuildingUse { get; set; }
        string AptCount { get; set; }
        string CommUnits { get; set; }
        string ExtDesc { get; set; }
        Nullable<byte> FullBath { get; set; }
        Nullable<byte> HalfBath { get; set; }
        string BasementDesc { get; set; }
        string AtticDesc { get; set; }
        Nullable<byte> AirCond { get; set; }
        Nullable<byte> Fireplace { get; set; }
        string GarageDesc { get; set; }
        short Age { get; set; }
        Nullable<int> BuildingSF { get; set; }
        Nullable<int> LandSF { get; set; }
        string TotalAllBuildingSF { get; set; }
        string UnitsTotal { get; set; }
        string SaleDate { get; set; }
        Nullable<int> SaleAmount { get; set; }

        IPropertyClassDTO PropertyClassDTO { get; set; }
        ITownshipDTO TownshipDTO { get; set; }
        IPropertyAddressDTO PropertyAddressDTO { get; set; }
        List<IPropertyTagDTO> PropertyTagDTOs { get; set; }

    }
}
