using DataContracts.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ServiceContracts.Common
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 16; // 128 bit 
        private const int KeySize = 32; // 256 bit

        private readonly HashingOptions _option;
        public PasswordHasher(IOptions<HashingOptions> options)
        {
            _option = options.Value;
        }

        public (string salt, string hashed) Hash(string password)
        {
            using var algorithm = new Rfc2898DeriveBytes(
                password,
                SaltSize,
                _option.Iterations,
                HashAlgorithmName.SHA512);
            var key = Convert.ToBase64String(algorithm.GetBytes(KeySize));
            var salt = Convert.ToBase64String(algorithm.Salt);

            return (salt, key);
        }

        public bool Validate(string hashed, string password, string salt)
        {
            var data = Convert.FromBase64String(salt);
            var key = Convert.FromBase64String(hashed);

            using var algorithm = new Rfc2898DeriveBytes(
                password,
                data,
                _option.Iterations,
                HashAlgorithmName.SHA512);
            var keyToCheck = algorithm.GetBytes(KeySize);

            return keyToCheck.SequenceEqual(key);
        }
    }
}
