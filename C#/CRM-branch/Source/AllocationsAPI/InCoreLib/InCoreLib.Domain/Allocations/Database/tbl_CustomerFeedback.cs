using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class tbl_CustomerFeedback
    {
        [Key]
        public int CustomerFeedbackID { get; set; }

        public int CustomerApplicationID { get; set; }

        public bool MarketingInitiative { get; set; }

        public bool Banner { get; set; }

        [StringLength(1000)]
        public string BannerLocation { get; set; }

        public bool Rightmove { get; set; }

        public bool IsVanAdvert { get; set; }

        public bool Other { get; set; }

        [StringLength(1000)]
        public string OtherText { get; set; }
    }
}
