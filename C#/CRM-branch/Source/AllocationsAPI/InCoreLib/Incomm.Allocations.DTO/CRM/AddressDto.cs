﻿namespace Incomm.Allocations.DTO.CRM
{
    public class AddressDto : BaseDto
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string PostCode { get; set; }
        public bool IsActive { get; set; }
    }
}
