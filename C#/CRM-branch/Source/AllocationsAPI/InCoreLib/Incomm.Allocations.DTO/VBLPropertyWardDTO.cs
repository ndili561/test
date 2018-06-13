using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Incomm.Allocations.BLL.DTOs;

namespace Incomm.Allocations.DTO
{
    [TrackChanges]
    public class VBLPropertyWardDTO : BaseObjectDto
    {
        public VBLPropertyWardDTO()
        {
            PropertyNeighbourhoods = new List<VBLPropertyNeighbourhoodDTO>();
        }

        [Key]
        public int WardId { get; set; }
       [StringLength(250)]
        public string Name { get; set; }
        public List<VBLPropertyNeighbourhoodDTO> PropertyNeighbourhoods { get; set; }
        public bool IsActive { get; set; }
    }
}
