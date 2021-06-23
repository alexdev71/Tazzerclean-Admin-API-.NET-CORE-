using System;
using System.Collections.Generic;
using System.Text;

namespace DataContracts.Entities
{
    public class ServiceProviding
    {
        public Guid BusinessId { get; set; }

        public Guid CategoryId { get; set; }

        public string LicenseNumber { get; set; }

        public DateTime StartingFrom { get; set; }

        public string Description { get; set; }

        public BusinessInfo Business { get; set; }

        public Category Category { get; set; }
    }
}
