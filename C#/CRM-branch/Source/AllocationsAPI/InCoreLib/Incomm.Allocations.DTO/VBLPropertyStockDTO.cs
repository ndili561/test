using System.ComponentModel.DataAnnotations;
using InCoreLib.Domain.Allocations.Database;

namespace Incomm.Allocations.BLL.DTOs
{
    public class VBLPropertyStockDTO : BaseObject
    {
        [Key]
        public int NeighbourhoodId { get; set; }

        [Display(Name = "Area")]
        public string NeighbourhoodName { get; set; }
        [Display(Name = "House")]
        public int HouseCount { get; set; }
        [Display(Name = "Flat")]
        public int FlatCount { get; set; }
        public int BunglowCount { get; set; }
        [Display(Name = "Bedsit")]
        public int BedsitCount { get; set; }
        [Display(Name = "Maison")]
        public int MaisonCount { get; set; }
      
    }
}
