using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public class vOpenAssessment
    {
        public int? CaseRefNumber { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReceptionIndex { get; set; }

        [StringLength(3)]
        public string LocationId { get; set; }

        [StringLength(50)]
        public string AssessorUserID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReceptionDateTime { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CaseOpen { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CaseClosed { get; set; }
    }
}