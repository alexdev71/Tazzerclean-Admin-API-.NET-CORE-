using System;
using System.Collections.Generic;
using System.Text;

namespace DataContracts.Entities
{
    public class Address
    {
        public string HouseNumber { get; set; }

        public string FormattedAddress { get; set; }

        public string Suburb { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Unit { get; set; }

        public StreetType StreetType { get; set; }

        public string StreetName { get; set; }

        public bool IsVerified { get; set; }

        public Guid PostalAddressId { get; set; }

        public PostalLookup PostalAddress { get; set; }
        public string ZipCode { get; set; }
    }
}
