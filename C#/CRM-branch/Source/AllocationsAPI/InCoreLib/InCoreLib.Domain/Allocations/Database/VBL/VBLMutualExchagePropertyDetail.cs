using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
   [TrackChanges]
    public class VBLMutualExchagePropertyDetail : BaseObject
    {
        [Key]
        public int ApplicationId { get; set; }
        public string PropertyCode { get; set; }
        public bool PropertyIsTerminating { get; set; }
        public decimal Rent { get; set; }
        public decimal ServiceCharges { get; set; }
        public decimal OtherCharges { get; set; }
        public int PropertyNumberOfBedrooms { get; set; }
        public int AgeCritera { get; set; }
        public int HeatingTypeId { get; set; }
        public virtual HeatingType HeatingType { get; set; }
        public int FlatFloorLevel { get; set; }
        public bool HasStepsToAccess { get; set; }
        public int NumberOfStepsToAccess { get; set; }
        public bool HasGarden { get; set; }
        public bool HasLift { get; set; }
        public bool HasTrustcare { get; set; }
        public bool IsWheelChairAdapted { get; set; }
        public bool HasRampledAccess { get; set; }
        public bool IsLevelAccessProperty { get; set; }
        public bool HasStairLift { get; set; }
        public bool HasWalkInShower { get; set; }
        public bool HasStepInShower { get; set; }
        public virtual int? PropertyTypeId { get; set; }
        public PropertyType PropertyType { get; set; }
        public int? PropertySizeId { get; set; }
        public virtual PropertySize PropertySize{ get; set; }
        public virtual int? PropertyEntranceTypeId { get; set; }
        public virtual PropertyEntranceType PropertyEntranceType { get; set; }
        public virtual int? PropertyBlockTypeId { get; set; }
        public virtual PropertyBlockType PropertyBlockType { get; set; }
        public int? AgeRestrictionId { get; set; }
        public virtual AgeRestriction AgeRestriction { get; set; }
        public virtual ICollection<VBLMutualExchangeAdaptationDetails> AdaptationDetails { get; set; }
        public virtual VBLApplication Application { get; set; }
        [NotMapped]
        public int[] SelectedAdaptationDetails { get; set; }
    }
}
