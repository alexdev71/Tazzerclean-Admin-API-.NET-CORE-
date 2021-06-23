using System;
using System.Collections.Generic;
using System.Text;

namespace DataContracts.Entities
{
    public class ForgotPasswordRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string PasswordComfirm { get; set; }

        public string Code { get; set; }
        public string RequestFrom { get; set; }
    }
}
