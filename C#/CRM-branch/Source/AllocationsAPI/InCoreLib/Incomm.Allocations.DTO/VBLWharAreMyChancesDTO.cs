using System.ComponentModel.DataAnnotations;

namespace Incomm.Allocations.BLL.DTOs
{
    public class VBLWhatAreMyChancesDTO
    {
        [Key]
        public int NeighbourhoodId { get; set; }
        public int ApplicationId { get; set; }
        [Display(Name = "Area")]
        public string NeighbourhoodName { get; set; }
        [Display(Name = "Type")]
        public string TypeName { get; set; }
        public int TypeCount { get; set; }
        [Display(Name = "Size")]
        public string SizeName { get; set; }
        public int SizeCount { get; set; }
        public bool AgeRestriction { get; set; }
        [Display(Name = "Age Restriction")]
        public string AgeRestrictionName { get; set; }
        public int AgeRestrictionCount { get; set; }
        [Display(Name = "Highrise")]
        public bool Highrise { get; set; }
        public int HighriseCount { get; set; }
        [Display(Name = "Communal Entrance")]
        public bool CommunalEntrance { get; set; }
        public int CommunalEntranceCount { get; set; }

        [Display(Name = "Average Wait Time")]
        public decimal? AverageWaitingTime { get; set; }

        public int PropertyCount { get; set; }

    }
}
