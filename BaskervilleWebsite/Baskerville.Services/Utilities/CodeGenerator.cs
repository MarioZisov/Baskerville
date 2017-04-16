using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Services.Utilities
{
    public static class CodeGenerator
    {
        public static string GenerateVerificationCode(string key)
        {
            string date = DateTime.Now.ToString();
            string merge = key + date;

            byte[] bytes = Encoding.UTF8.GetBytes(merge);
            var sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(bytes);
            string verificationCode = Convert.ToBase64String(hashBytes);

            return verificationCode;
        }
    }
}
