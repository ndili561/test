using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;

namespace Incomm.Allocations.BLL.DTOs
{

    public class VBLTenancySearchDTO
    {
        public string PropertyCode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public MvcHtmlString AddressHtml { get { return ToHtmlString(); } }
        [Display(Name = "Postcode")]
        public string Postcode { get; set; }
        public string IBSPropertyType { get; set; }
        public decimal AgeCriteria { get; set; }
        public string PetsAllowed { get; set; }
        public int PropertyNumBedrooms { get; set; }
        public int SchemeID { get; set; }
        public int SubNeighbourhoodId { get; set; }
        public string SubNeighbourhoodCode { get; set; }
        public string SubNeighbourhoodName { get; set; }
        public string NeighbourhoodCode { get; set; }
        public string NeighbourhoodName { get; set; }
        public int FlatFloorLevel { get; set; }
        public int LiftAccess { get; set; }
        public int Careline { get; set; }
        public int HeatingTypeID { get; set; }
        public int Garden { get; set; }
        public int StepsToAccess { get; set; }
        public int IsWheelChairAdapted { get; set; }
        public int HasRampedAccess { get; set; }
        public int IsLevelAccessProperty { get; set; }
        public int HasStairlift { get; set; }
        public int HasWalkInShower { get; set; }
        public int HasStepInShower { get; set; }
        public int BlockID { get; set; }
        public string IBSTypeCode { get; set; }
        public string IBSCatCode { get; set; }
        public DateTime TenancyStart { get; set; }
        public DateTime TenancyEnd { get; set; }
        [Display(Name = "Forename")]
        public string Forename { get; set; }
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        [Display(Name = "DateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        public string DateOfBirthString { get { return DateOfBirth.ToShortDateString(); } }
        public string TenancyRef { get; set; }
        public string TenantCode { get; set; }
        public int VoidId { get; set; }
        public int TerminationTypeID { get; set; }
        public int IBSTerminating { get; set; }
        [Display(Name = "Tenancy Type")]
        public int TenancyTypeId { get; set; }
        public string TenancyType { get; set; }
        public string TenancyTypeName { get; set; }
        public int CustomerApplicationID { get; set; }
        [Display(Name = "House Number")]
        public string HouseNumber { get; set; }
        [Display(Name = "Street")]
        public string Street { get; set; }
        public MvcHtmlString ToHtmlString()
        {
            const string linebreak = "<br/>";
            var sb = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(Address1))
            {
                sb.Append(Address1).Append(linebreak);
            }
            if (!string.IsNullOrWhiteSpace(Address2))
            {
                sb.Append(Address2).Append(linebreak);
            }
            if (!string.IsNullOrWhiteSpace(Address3))
            {
                sb.Append(Address3).Append(linebreak);
            }
            if (!string.IsNullOrWhiteSpace(Address4))
            {
                sb.Append(Address4).Append(linebreak);
            }
            return new MvcHtmlString(sb.ToString());
        }

        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }

    }
}

