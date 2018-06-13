using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class tblUserChangeRequest
    {
        [Key]
        public int ChangeRequestRef { get; set; }

        public DateTime? DateLogged { get; set; }

        [StringLength(50)]
        public string LoggedBy { get; set; }

        [StringLength(50)]
        public string RequestCategory { get; set; }

        [Column(TypeName = "ntext")]
        public string RequestDetails { get; set; }

        [StringLength(50)]
        public string ApprovedBy { get; set; }

        public DateTime? ApprovedDate { get; set; }

        [StringLength(50)]
        public string DeveloperName { get; set; }

        public DateTime? DeveloperDueDate { get; set; }

        [StringLength(50)]
        public string DeveloperStatus { get; set; }

        public DateTime? DeveloperDoneDate { get; set; }

        [Column(TypeName = "ntext")]
        public string DeveloperNotes { get; set; }

        public bool? Locked { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] upsize_ts { get; set; }
    }
}
