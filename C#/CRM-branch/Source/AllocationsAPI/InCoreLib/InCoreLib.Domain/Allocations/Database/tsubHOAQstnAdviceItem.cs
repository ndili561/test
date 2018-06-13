using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("tsubHOAQstnAdviceItem")]
    public partial class tsubHOAQstnAdviceItem
    {
        [Key]
        [Column(Order = 0)]
        public int CaseQstnAdviceItemID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CaseRef { get; set; }

        public int? QstnairID { get; set; }

        public int? QstnID { get; set; }

        public int? QstnAltID { get; set; }

        public int? QstnAdviceItemID { get; set; }

        public int? AdviceItemID { get; set; }

        public DateTime? AddDate { get; set; }

        public bool? Completed { get; set; }

        public DateTime? CompletionDate { get; set; }

        [StringLength(50)]
        public string CompletedUserID { get; set; }

        [StringLength(50)]
        public string AssignedTo { get; set; }

        public bool? ShownToClient { get; set; }

        public DateTime? ShownToClientDate { get; set; }

        public bool? NotNeeded { get; set; }

        public DateTime? NotNeededDate { get; set; }

        [StringLength(50)]
        public string NotNeededUserID { get; set; }

        public bool? UnableToComplete { get; set; }

        public DateTime? UnableToCompleteDate { get; set; }

        [StringLength(50)]
        public string UnableToCompleteUserID { get; set; }

        public int? ClientResponseID { get; set; }

        public string ClientResponseText { get; set; }

        public bool? AdviceDocPrinted { get; set; }

        public DateTime? AdviceDocPrintDate { get; set; }
    }
}
