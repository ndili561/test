using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    [Table("Contact")]
    public partial class Contact
    {
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

        [StringLength(100)]
        public string LastUpdatedUserName { get; set; }

        public bool? MainTenant { get; set; }

        [StringLength(20)]
        public string TitleName { get; set; }

        [StringLength(20)]
        public string GenderName { get; set; }

        [StringLength(20)]
        public string RelationshipName { get; set; }

        [StringLength(50)]
        public string NationalityTypeName { get; set; }

        [StringLength(50)]
        public string EthnicityCode { get; set; }

        public bool? IsIncommunitiesTenant { get; set; }
    }
}
