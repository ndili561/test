using InCoreLib.Domain.Allocations.Database.VBL.Search;
using InCoreLib.Domain.Allocations.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
   [TrackChanges]
    public class VBLContact : BaseObject
    {
        public VBLContact()
        {
            IncomeDetails = new List<VBLIncomeDetail>();
            Addresses = new List<VBLAddress>();
            ContactByDetails = new List<VBLContactByDetails>();
            RequestedSupportDetails = new List<VBLRequestedSupportDetails>();
            ReceivingSupportDetails = new List<VBLReceivingSupportDetails>();
            DisabilityTypes = new List<VBLDisabilityType>();
            IncommunitiesRelationshipTypes = new List<VBLIncommunitiesRelationshipType>();
            VBLNotes = new List<VBLNote>();
        }

        [Key]
        public int ContactId { get; set; }

        public int ApplicationId { get; set; }
        public virtual VBLApplication Application { get; set; }
        public string Title => SearchContact?.Title;
        public string Forename => SearchContact?.Forename;
        public string Surname => SearchContact?.Surname;
        public int ContactTypeId { get; set; }
        public virtual ContactType ContactType { get; set; }
        public bool MainTenantOnTenancy { get; set; }
        public bool IsPregnant { get; set; }
        public DateTime? PregnancyDueDate { get; set; }
        public bool LivedInUKForFiveYears { get; set; }
        public string TenancyReference { get; set; }
        public bool Active { get; set; }
        public bool IsMovingIn { get; set; }
        public bool ImmigrationControl { get; set; }
        public bool PublicFunds { get; set; }
        public string PreferredContactTime { get; set; }
        public string NoIncomeReason { get; set; }
        public string DisabilityImpactOnHousingNeed { get; set; }
        public string OtherSupportDetails { get; set; }
        public int? RelationshipId { get; set; }
        public virtual Relationship Relationship { get; set; }
        public virtual ICollection<VBLIncomeDetail> IncomeDetails { get; set; }
        [NotMapped]
        public virtual ICollection<VBLAddress> Addresses { get; set; }
        [NotMapped]
        public virtual ICollection<VBLContactByDetails> ContactByDetails { get; set; }
        public virtual ICollection<VBLDisabilityDetails> DisabilityDetails { get; set; }
        public virtual ICollection<VBLReceivingSupportDetails> ReceivingSupportDetails { get; set; }
        public virtual ICollection<VBLRequestedSupportDetails> RequestedSupportDetails { get; set; }

        public virtual ICollection<VBLDisabilityType> DisabilityTypes { get; set; }

        public virtual ICollection<VBLIncommunitiesRelationshipType> IncommunitiesRelationshipTypes { get; set; }
        public virtual ICollection<VBLTenantDetail> TenantDetails { get; set; }

        public virtual ICollection<VBLNote> VBLNotes { get; set; }
        [NotMapped]
        public Person Person { get; set; }

        [NotMapped]
        public SearchContact SearchContact { get; set; }
        [NotMapped]
        public SaveContact SaveContact { get; set; }
        [NotMapped]
        public int[] SelectedRequiredSupportsIds { get; set; }
        [NotMapped]
        public int[] SelectedDisabilitiesIds { get; set; }
        public bool? ClaimHousingBenefitAtNewProperty { get; set; }
        public bool? ClaimingHousingBenefitAtCurrentProperty { get; set; }

        public Guid? GlobalIdentityKey { get; set; }
    }
}