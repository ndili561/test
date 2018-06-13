using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Incomm.Allocations.BLL.DTOs;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace Incomm.Allocations.DTO
{
    [TrackChanges]
    public class VBLPropertyNeighbourhoodDTO : BaseObjectDto
    {
        public VBLPropertyNeighbourhoodDTO()
        {
            PropertyPostcodes = new List<VBLPropertyPostcodeDTO>();
        }

        [Key]
        public int NeighbourhoodId { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        public int WardId { get; set; }
        public VBLPropertyWardDTO PropertyWardDto { get; set; }
        public List<VBLPropertyPostcodeDTO> PropertyPostcodes { get; set; }
        public bool IsActive { get; set; }
    }
}
