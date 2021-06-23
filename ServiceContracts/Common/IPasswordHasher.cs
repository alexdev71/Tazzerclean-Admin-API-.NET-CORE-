using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceContracts.Common
{
    public interface IPasswordHasher
    {
        (string salt, string hashed) Hash(string password);

        bool Validate(string hash, string password, string salt);
    }
}
