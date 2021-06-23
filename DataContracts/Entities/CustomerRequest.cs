using System;
using System.Collections.Generic;
using System.Text;

namespace DataContracts.Entities
{
    public class CustomerRequest
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string Role { get; set; }
        public Guid PrimaryService { get; set; }

        public List<Guid> Services { get; set; }

        public int ProfessionalType { get; set; }

        public bool OwnMaterialTools { get; set; }

        public int AreasAroundPostcode { get; set; }

        public bool OwnTransport { get; set; }

        public bool OtherEmployment { get; set; }

        public bool WillingToTrain { get; set; }

        public bool Uniform { get; set; }

        public bool RightToWorkInTheCountry { get; set; }
    }
}
