using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstQuestion")]
    public partial class lstQuestion
    {
        [Key]
        [Column(Order = 0)]
        public int QstnID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QstnairID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Seqno { get; set; }

        public int? PrevQstnID { get; set; }

        public int? NextQstnID { get; set; }

        public int? NextQstnIDYes { get; set; }

        public int? NextQstnIDNo { get; set; }

        public int? QstnairSectionID { get; set; }

        public int? QstnairSubSectionID { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(250)]
        public string QstnText { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AnswerTypeID { get; set; }

        public bool? NoteAllowed { get; set; }

        public bool? NoteAllowedYes { get; set; }

        public bool? NoteAllowedNo { get; set; }

        public bool? NoteRequired { get; set; }

        [StringLength(50)]
        public string LookupTableName { get; set; }

        [StringLength(50)]
        public string LookupIDFieldName { get; set; }

        [StringLength(150)]
        public string LookupValueFieldName { get; set; }

        public bool? AllowMultiSelect { get; set; }

        public string HintText { get; set; }

        public bool? AllowYNAndNeither { get; set; }

        [StringLength(150)]
        public string YesText { get; set; }

        [StringLength(150)]
        public string NoText { get; set; }

        public int? EventIDOnAnswer { get; set; }

        public int? EventIDOnYes { get; set; }

        public int? EventIDOnNo { get; set; }

        public bool? AllowMultipleEventsOnAnswer { get; set; }

        [StringLength(150)]
        public string RefTable { get; set; }

        [StringLength(150)]
        public string RefColumn { get; set; }

        [StringLength(150)]
        public string NeitherText { get; set; }

        public bool? NoteAllowedNeither { get; set; }

        public bool? ListOther { get; set; }

        public bool? ListDTA { get; set; }

        public bool? ListOtherNoteAllowed { get; set; }

        public bool? ListDTANoteAllowed { get; set; }

        [StringLength(50)]
        public string NextForm { get; set; }

        [StringLength(50)]
        public string NextFormYes { get; set; }

        [StringLength(50)]
        public string NextFormNo { get; set; }

        [StringLength(50)]
        public string NextFormNeither { get; set; }

        public bool? ConfirmAdviceDelivered { get; set; }

        public int? RelatedRAQstnairID { get; set; }

        public int? RelatedRAQstnID { get; set; }
    }
}
