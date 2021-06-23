using System;
using System.Collections.Generic;
using System.Text;

namespace DataContracts.Entities
{
    public class LoginRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string GoogleId { get; set; }
    }
}
