using System;
using System.Collections.Generic;
using System.Text;

namespace DataContracts.Entities
{
    public class User
    {
        public Guid RoleId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

        public string Salt { get; set; }

        public bool IsVerified { get; set; }

        public string ExternalId { get; set; }

        public Role Role { get; set; }

        public string FullName =>
            Customer != null ? $"{Customer.Firstname} {Customer.Lastname}" : "";


        public Customer Customer { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        public bool ForgotPasswrodEnabled { get; set; }
        public Guid Id { get; set; }
        public UserSource Source { get; set; }
        public string ForgotPasswordCode { get; set; }
        public Address Address { get; set; }
        public Guid PrimaryService { get; set; }
        public string ProfileImage { get; set; }
        public string Middlename { get; set; }
    }
}
