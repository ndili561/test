using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("lstEvent")]
    public partial class lstEvent
    {
        [Key]
        [Column(Order = 0)]
        public int EventID { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool Active { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(250)]
        public string EventDesc { get; set; }

        public string EventDesc2 { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool IsADefault { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DefaultPriority { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool IsCheckpoint { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool SyncWithCalendar { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool ShowCompletionCheckbox { get; set; }

        public int? ParentID { get; set; }

        public bool? IsSystemGenerated { get; set; }

        public int? ExpectedDurnDays { get; set; }

        public int? ExpectedDurnMins { get; set; }

        public bool? PreventUnableToComplete { get; set; }

        public bool? PreventNotNeeded { get; set; }
    }
}
