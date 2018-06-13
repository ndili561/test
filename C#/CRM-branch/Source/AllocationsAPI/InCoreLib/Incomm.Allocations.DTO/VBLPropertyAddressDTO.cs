using System.ComponentModel.DataAnnotations;
using Incomm.Allocations.BLL.DTOs;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace Incomm.Allocations.DTO
{
    public class VBLPropertyAddressDTO : BaseObjectDto
    {
        [Key]
        public int PropertyAddressId { get; set; }
        public string PropertyAddress { get; set; }
        public string PropertyReference { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public int PostcodeId { get; set; }
        public VBLPropertyPostcodeDTO PropertyPostcodeDto { get; set; }
        public bool IsActive { get; set; }
        public int? AgeRestrictionId { get; set; }
        public AgeRestriction AgeRestriction { get; set; }
        public int? PropertyTypeId { get; set; }
        public PropertyType PropertyType { get; set; }
        public int? PropertySizeId { get; set; }
        public PropertySize PropertySize { get; set; }
        public bool Highrise { get; set; }
        public bool CommunalEntrance { get; set; }
        public decimal? WaitingTimeInMonth { get; set; }
    }
}
