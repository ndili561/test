using System;
using System.ComponentModel.DataAnnotations;

namespace InCoreLib.Domain.Allocations.Database.VBL.Search
{
    public class SearchContact 
    {

        [Key]
        public int ContactId { get; set; }
        public Guid? GlobalIdentityKey { get; set; }
        public string NationalInsuranceNumber { get; set; }
        [Display(Name = "Status")]
        public string ApplicationStatus { get; set; }
        public int ApplicationId { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        public int? AddressId { get; set; }
        public string Address { get; set; }
        [Display(Name = "Role")]
        public string ContactTypeName { get; set; }
        public string Gender { get; set; }
        public string Ethnicity { get; set; }
        public string Language { get; set; }
        public string Nationality { get; set; }
        public string Title { get; set; }
    }
}