using InCoreLib.Domain.Allocations.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database.VBL
{
   [TrackChanges]
    public class VBLRequestedPropertymatchDetail : BaseObject
    {
        [Key]
        public int ApplicationId { get; set; }
        public virtual List<VBLRequestedPropertyPropertyType> PropertyTypes { get; set; }
        public virtual List<VBLRequestedPropertyAgeRestriction> AgeRestrictions { get; set; }
        public virtual List<VBLRequestedPropertyPropertySize> PropertySizes { get; set; }
        public virtual List<VBLRequestedPropertyPrefferedNeighbourhood> RequestedPropertyPrefferedNeighbourhoods { get; set; }
        public virtual List<VBLRequestedPropertyScheme> Schemes { get; set; }
        public virtual List<VBLRequestedPropertyHeatingType> HeatingTypes { get; set; }
        public virtual List<VBLRequestedPropertyAdaptationDetails> AdaptationDetails { get; set; }
        public bool IsNewVBLApplication { get; set; }
        //new questions
        public bool? CatOrDog { get; set; }// do you have a cat or dog 2
        public bool? RehousePet { get; set; }//will you consider rehoming your pet 3
        public bool? CommunalEntrance { get; set; }// will you consider a communal entrance 4
        public bool? HighRise { get; set; } //high rise block of flats 5
        public bool? AgeRestricted { get; set; }//require age related accom 7
        public bool? ManageSteps { get; set; }//can you manage steps 8
        public NumberOfSteps NumberOfSteps { get; set; }
        public bool? RequireAdaptations { get; set; }//do you require adaptations 9

        public int? FloorLevel { get; set; }
        public bool? LiftServed { get; set; }
        public bool? TrustCare { get; set; }
        public bool? Sheltered { get; set; }
        public bool? Garden { get; set; }
        public bool? WheelChairAdapted { get; set; }  // WheelChair adaption
        public bool? RampedAccess { get; set; }   // Ramped Access adaption
        public bool? LevelAccessProperty { get; set; }
        public bool? StairLift { get; set; }
        public bool? WalkInShower { get; set; }  // walk in Shower adaption
        public bool? StepInShower { get; set; }  // step in shower adaption.
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public virtual VBLApplication Application { get; set; }

    }
}
