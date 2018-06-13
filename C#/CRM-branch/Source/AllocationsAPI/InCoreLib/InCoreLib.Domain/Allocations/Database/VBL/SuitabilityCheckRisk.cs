using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
    /// <summary>
    /// </summary>
    public class SuitabilityCheckRisk
    {
        /// <summary>
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// </summary>
        public string DisplayTabName { get; set; }

        /// <summary>
        /// </summary>
        public int ContactId { get; set; }

        /// <summary>
        /// </summary>
        public int RiskThemeId { get; set; }

        /// <summary>
        /// </summary>
        public int RiskCategoryId { get; set; }

        /// <summary>
        /// </summary>
        public DateTime? LoggedDate { get; set; }

        /// <summary>
        /// </summary>
        public string LoggedById { get; set; }

        /// <summary>
        /// </summary>
        public string RiskDetail { get; set; }

        /// <summary>
        /// </summary>
        public DateTime? LastReviewedDate { get; set; }

        /// <summary>
        /// </summary>
        [ConcurrencyCheck, Timestamp]
        public byte[] ConcurrencyCheck { get; set; }

        /// <summary>
        /// </summary>
        [StringLength(40)]
        public string LastModifiedById { get; set; }

        /// <summary>
        /// </summary>
        public DateTime ModifiedTimestamp { get; set; }

        /// <summary>
        /// </summary>
        [ForeignKey("RiskThemeId")]
        public virtual RiskTheme RiskTheme { get; set; }

        /// <summary>
        /// </summary>
        [ForeignKey("RiskCategoryId")]
        public virtual RiskCategory RiskCategory { get; set; }

    }
}
