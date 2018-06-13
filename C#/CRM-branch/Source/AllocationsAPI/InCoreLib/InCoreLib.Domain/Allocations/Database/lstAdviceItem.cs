using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstAdviceItem")]
    public partial class lstAdviceItem
    {
        [Key]
        public int AdviceItemID { get; set; }

        public int? AdviceItemTypeID { get; set; }

        public DateTime? AddDate { get; set; }

        public bool? Active { get; set; }

        [StringLength(50)]
        public string Heading { get; set; }

        public string AdviceSpoken { get; set; }

        public string AdvicePrinted { get; set; }

        public string Note { get; set; }

        public string DocLink { get; set; }

        public string DocURL { get; set; }

        public bool? EmbedDocInPrint { get; set; }

        public int? ThemeID { get; set; }

        public bool? PrintedIsSameAsSpoken { get; set; }

        [StringLength(50)]
        public string DefaultResponsibilityOwner { get; set; }

        public bool? ConfirmAdviceDelivered { get; set; }
    }
}
