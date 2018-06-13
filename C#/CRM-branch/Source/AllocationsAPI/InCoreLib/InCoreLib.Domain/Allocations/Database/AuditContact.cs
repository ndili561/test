using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("AuditContact")]
    public partial class AuditContact
    {
        [Key]
        [Column(Order = 0)]
        public int AuditID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ContactID { get; set; }

        public int CustomerApplicationID { get; set; }

        public int ContactTypeID { get; set; }

        public int TitleId { get; set; }

        [Required]
        [StringLength(50)]
        public string Forename { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        public bool LivedInUkForFiveYears { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        public int NationalityID { get; set; }

        public bool IsMovingIn { get; set; }

        public int GenderID { get; set; }

        public int RelationshipID { get; set; }

        public bool IsPregnant { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PregnancyDueDate { get; set; }

        public bool Active { get; set; }

        public bool IsDisabled { get; set; }

        [Required]
        public string DisabledDetails { get; set; }

        public bool IsWheelChairUser { get; set; }

        public bool UsesWheelChairInside { get; set; }

        public bool HasIncommunitiesRelationship { get; set; }

        [Required]
        [StringLength(1000)]
        public string IncommunitiesRelationshipDescription { get; set; }

        public int EthnicityId { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        public DateTime ChangeDate { get; set; }

        [StringLength(100)]
        public string ChangeType { get; set; }
    }
}
