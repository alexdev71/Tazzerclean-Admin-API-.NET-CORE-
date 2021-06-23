using System;
using System.Collections.Generic;
using System.Text;

namespace DataContracts.Entities
{
    public class Partner
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }
        public bool IsActive { get; set; }
        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public Guid? AddressId { get; set; }

        public Guid UserId { get; set; }

        public bool EmailConfirmed { get; set; }
        public bool MobileConfirmed { get; set; }
        public Guid Id { get; set; }
    }
}
