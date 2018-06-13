using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database
{
    public partial class v_HOAInterfaceContacts
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerApplicationId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ApplicationStatusID { get; set; }

        [StringLength(1000)]
        public string ApplicationStatusReason { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime ApplicationDate { get; set; }

        public bool? ApplicationEligible { get; set; }

        public DateTime? HOALevelOfNeedDate { get; set; }

        public int? ApplicationLevelOfNeedID { get; set; }

        public int? HOACaseRef { get; set; }

        [StringLength(1000)]
        public string HOAOutcome { get; set; }

        public DateTime? HOAOutcomeDate { get; set; }

        public bool? HOACaseIsOpen { get; set; }

        public bool? HOAEligabilitySet { get; set; }

        public DateTime? ApplicationClosedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LatestMoveDate { get; set; }

        public bool? HOAEligible { get; set; }

        public int? HOALevelOfNeedID { get; set; }

        [StringLength(255)]
        public string MoveReason { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ActivityID { get; set; }

        public DateTime? AppointmentDate { get; set; }

        public int? ActivityStatusID { get; set; }

        [StringLength(20)]
        public string NAME { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string Forename { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string Surname { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [StringLength(20)]
        public string Gender { get; set; }

        [StringLength(255)]
        public string Address1 { get; set; }

        [StringLength(255)]
        public string Address2 { get; set; }

        [StringLength(255)]
        public string Address3 { get; set; }

        [StringLength(255)]
        public string Address4 { get; set; }

        [StringLength(16)]
        public string PostCode { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NationalityID { get; set; }

        [StringLength(20)]
        public string Relationship { get; set; }

        [StringLength(50)]
        public string Nationality { get; set; }

        [StringLength(50)]
        public string Ethnicity { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ContactTypeID { get; set; }

        [StringLength(25)]
        public string TelNum { get; set; }

        [StringLength(25)]
        public string MobileNum { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [Key]
        [Column(Order = 9)]
        public bool IsPregnant { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PregnancyDueDate { get; set; }

        public int? ActivityLocationID { get; set; }
    }
}
