using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incomm.Allocations.DTO
{
    public class VBLApplicationSummaryDTO
    {
        public VBLApplicationSummaryDTO()
        {
            NumberOfBedrooms = new List<int>();
            PropertyTypes = new List<string>();
            PreferredNeighbourhoodIds = new List<int>();
        }
        public int ApplicationId { get; set; }

        //mutex details

        public bool IsSuitableForMutex { get; set; }//for easy checking
        public string PropertyCode { get; set; }
        public string MutexPropertyType { get; set; }
        public int? MutexNumberOfBeds { get; set; }
        public int? MutexAgeRestriction { get; set; }
        public int? MutexNumberSteps { get; set; }
        public bool? MutexWheelchairAdapted { get; set; }
        public bool? MutexRampedAccess { get; set; }
        public bool? MutexStairLift { get; set; }
        public bool? MutexWalkInShower { get; set; }
        public bool? MutexStepInShower { get; set; }

        //void matchingdetails

        public bool? HasPet { get; set; }//if catdog && !rehousePet)
        public bool? CommunalEntrance { get; set; }
        public bool? HighRise { get; set; }
        public bool? LiftServed { get; set; }
        public bool EighteenPlus { get; set; }
        public bool FiftyFivePlus { get; set; }
        public bool SixtyFivePlus { get; set; }
        public bool WheelchairAdapted { get; set; }
        public bool RampedAccess { get; set; }
        public bool StairLift { get; set; }
        public bool WalkInShower { get; set; }
        public bool StepInShower { get; set; }

        public int? MaxNumberSteps { get; set; }//if null, no max, else 0, 2, 10 or 20
        public List<int> NumberOfBedrooms { get; set; }
        public List<string> PropertyTypes { get; set; }
        public List<int> PreferredNeighbourhoodIds { get; set; }

    }
}
