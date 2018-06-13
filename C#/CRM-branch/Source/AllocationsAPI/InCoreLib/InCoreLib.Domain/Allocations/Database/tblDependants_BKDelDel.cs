using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class tblDependants_BKDelDel
    {
        public int? CaseRefNumber { get; set; }

        [Key]
        public int DependantsIndex { get; set; }

        [StringLength(50)]
        public string DependantsForename { get; set; }

        [StringLength(50)]
        public string DependantsSurname { get; set; }

        public DateTime? DependantsDOB { get; set; }

        [StringLength(50)]
        public string DependantsRelationship { get; set; }

        [StringLength(50)]
        public string DependantsGender { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        public bool? Active { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AddDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DeletedDate { get; set; }

        public string Note { get; set; }

        public bool? Pregnancy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DueDate { get; set; }

        [StringLength(50)]
        public string Ethnicity { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string EMail { get; set; }
    }
}
