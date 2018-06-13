using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InCoreLib.Domain.Allocations.Database.VBL.Search
{
    [NotMapped]
    public class Person : BaseObject
    {
        public Person()
        {
            Applications = new List<PersonApplicationLink>();
            PersonContactDetails = new List<PersonContactDetail>();
            PersonAddresses = new List<PersonAddress>();
        }
        public ICollection<PersonContactDetail> PersonContactDetails { get; set; }
        public ICollection<PersonAddress> PersonAddresses { get; set; }
        public ICollection<PersonApplicationLink> Applications { get; set; }
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
    }
}
