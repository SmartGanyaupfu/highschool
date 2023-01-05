using System;
namespace HighSchool.Entities.Models
{
    public class PhysicalAddress
    {
        public int PhysicalAddressID { get; set; }
        //////public PhysicalAddress PhysicalAddress { get; set; }
        public int UnitNumber { get; set; }
        public string? UnitName { get; set; }
        public string? StreetAddress { get; set; }
        public string? AddressLineTwo { get; set; }
        public string? PostalCode { get; set; }

        public string? Suburb { get; set; }

        public string? Province { get; set; }

        public string? Country { get; set; }

    }
}

