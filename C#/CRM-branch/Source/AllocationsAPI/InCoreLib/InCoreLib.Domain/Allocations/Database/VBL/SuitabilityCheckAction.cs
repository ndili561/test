using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
    /// <summary>
    /// </summary>
    public class SuitabilityCheckAction
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
        public int ActionCategoryId { get; set; }

        /// <summary>
        /// </summary>
        public int ActionTypeId { get; set; }

        /// <summary>
        /// </summary>
        public DateTime? DateToComplete { get; set; }

        /// <summary>
        /// </summary>
        public int ActionResponsibilityId { get; set; }

        /// <summary>
        /// </summary>
        public DateTime? ActionLoggedDate { get; set; }

        /// <summary>
        /// </summary>
        [StringLength(40)]
        public string ActionLoggedById { get; set; }

        /// <summary>
        /// </summary>
        public DateTime? ActionCompletedDate { get; set; }

        /// <summary>
        /// </summary>
        public string Notes { get; set; }

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
        [ForeignKey("ActionCategoryId")]
        public virtual ActionCategory ActionCategory { get; set; }

        /// <summary>
        /// </summary>
        [ForeignKey("ActionTypeId")]
        public virtual ActionType ActionType { get; set; }

        /// <summary>
        /// </summary>
        [ForeignKey("ActionResponsibilityId")]
        public virtual ActionResponsibility Responsibility { get; set; }


    }
}
