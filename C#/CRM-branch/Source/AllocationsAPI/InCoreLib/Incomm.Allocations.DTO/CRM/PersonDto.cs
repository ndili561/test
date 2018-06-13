using System;
using System.Collections.Generic;
using Incomm.Allocations.BLL.DTOs;

namespace Incomm.Allocations.DTO.CRM
{
    public class PersonDto : BaseObjectDto
    {
        public PersonDto()
        {
            PersonAddresses = new List<PersonAddressDto>();
            Applications = new List<PersonApplicationLinkDto>();
            PersonContactDetails = new List<PersonContactDetailDto>();
        }
        public int Id { get; set; }
        public Guid? GlobalIdentityKey { get; set; }
        public string NationalInsuranceNumber { get; set; }
        public string Forename { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Surname { get; set; }
        public int? TitleId { get; set; }
        public int? GenderId { get; set; }
        public int? EthnicityId { get; set; }
        public int? NationalityTypeId { get; set; }
        public int? PreferredLanguageId { get; set; }
        public int? RelationshipId { get; set; }
        public virtual List<PersonAddressDto> PersonAddresses { get; set; }
        public virtual ICollection<PersonApplicationLinkDto> Applications { get; set; }
        public virtual ICollection<PersonContactDetailDto> PersonContactDetails { get; set; }
    }
}
