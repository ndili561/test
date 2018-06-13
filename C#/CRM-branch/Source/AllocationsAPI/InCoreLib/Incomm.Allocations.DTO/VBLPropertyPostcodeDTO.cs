using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Incomm.Allocations.BLL.DTOs;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace Incomm.Allocations.DTO
{
    [TrackChanges]
    public class VBLPropertyPostcodeDTO : BaseObjectDto
    {
        public VBLPropertyPostcodeDTO()
        {
            PropertyAddresses= new List<VBLPropertyAddressDTO>();
        }

        [Key]
        public int PostcodeId { get; set; }
        [StringLength(8)]
        public string Postcode { get; set; }
        public int NeighbourhoodId { get; set; }
        public VBLPropertyNeighbourhoodDTO PropertyNeighbourhoodDto { get; set; }
        public List<VBLPropertyAddressDTO> PropertyAddresses { get; set; }
        public bool IsActive { get; set; }
    }
}
