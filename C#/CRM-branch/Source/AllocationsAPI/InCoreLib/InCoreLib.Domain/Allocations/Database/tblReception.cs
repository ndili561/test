using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tblReception")]
    public partial class tblReception
    {
        [Key]
        public int ReceptionIndex { get; set; }

        [StringLength(50)]
        public string ReceptionUserID { get; set; }

        public DateTime? ReceptionDateTime { get; set; }

        [StringLength(50)]
        public string ReceptionTitle { get; set; }

        [StringLength(50)]
        public string ReceptionFirstName { get; set; }

        [StringLength(50)]
        public string ReceptionLastName { get; set; }

        public DateTime? ReceptionDOB { get; set; }

        [StringLength(255)]
        public string ReceptionAddressLine1 { get; set; }

        [StringLength(50)]
        public string ReceptionApproachReason { get; set; }

        [StringLength(50)]
        public string ReceptionContactType { get; set; }

        [Column(TypeName = "ntext")]
        public string ReceptionContactDetails { get; set; }

        [Column(TypeName = "ntext")]
        public string ReceptionNotes { get; set; }

        public bool? ReceptionAllocatedToHOA { get; set; }

        public int? CaseRefNumber { get; set; }

        public bool? WarningFlag { get; set; }

        [StringLength(50)]
        public string LeftReceptionUserID { get; set; }

        public DateTime? LeftReceptionDateTime { get; set; }

        [Column(TypeName = "ntext")]
        public string LeftReceptionNotes { get; set; }

        [StringLength(3)]
        public string ReceptionUserLocation { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }

        [StringLength(5)]
        public string Application_VBL { get; set; }

        public string WarningNote { get; set; }
    }
}
