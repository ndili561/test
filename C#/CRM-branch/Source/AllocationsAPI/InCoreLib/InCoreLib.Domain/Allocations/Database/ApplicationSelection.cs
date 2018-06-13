using System;
using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class ApplicationSelection
    {
        public int SelectionID { get; set; }

        [Key]
        [StringLength(255)]
        public string SessionID { get; set; }

        [Required]
        [StringLength(255)]
        public string SelectedLocations { get; set; }

        public DateTime Created { get; set; }
    }
}
