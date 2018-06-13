using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tsubTAPlacementPerson")]
    public partial class tsubTAPlacementPerson
    {
        [Key]
        [Column(Order = 0)]
        public int TAPlacementPersonID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TAPlacementID { get; set; }

        [StringLength(150)]
        public string Forename { get; set; }

        [StringLength(150)]
        public string Surname { get; set; }

        [StringLength(150)]
        public string Relationship { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DoB { get; set; }

        public string Note { get; set; }
    }
}
