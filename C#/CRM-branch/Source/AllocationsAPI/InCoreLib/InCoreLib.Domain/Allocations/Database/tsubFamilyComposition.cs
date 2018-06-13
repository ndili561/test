using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tsubFamilyComposition")]
    public partial class tsubFamilyComposition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CaseRefNumber { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SystemFCIndex { get; set; }

        public DateTime? SystemFCDate { get; set; }

        [StringLength(50)]
        public string SystemFCUserID { get; set; }

        [StringLength(50)]
        public string FC_Title { get; set; }

        [StringLength(50)]
        public string FC_Forename { get; set; }

        [StringLength(50)]
        public string FC_Surname { get; set; }

        public DateTime? FC_DOB { get; set; }

        [Column("FC_ Relationship")]
        [StringLength(50)]
        public string FC__Relationship { get; set; }

        [StringLength(1)]
        public string FC_Gender { get; set; }

        public bool? FC_HasDisability { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }
    }
}
