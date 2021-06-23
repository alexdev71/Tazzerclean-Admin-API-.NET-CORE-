using System;
using System.Collections.Generic;
using System.Text;

namespace DataContracts.Entities
{
    public class PostalLookup
    {
        public Guid Id { get; set; }
        public string Suburb { get; set; }

        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string Route { get; set; }
        public string Locality { get; set; }
        public string PostalTown { get; set; }
        public string AdministrativeAreaLevel2 { get; set; }
        public string AdministrativeAreaLevel1 { get; set; }
        public string Country { get; set; }

        public string Postcode { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public string Type { get; set; }
    }
}
