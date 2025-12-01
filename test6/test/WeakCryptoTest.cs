using System;
using System.Security.Cryptography;
using System.Text;

namespace test_project6
{
    public class WeakCryptoTest
    {
        public string HashPassword(string password)
        {
            // Weak cryptography - using MD5
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return Convert.ToHexString(hashBytes);
            }
        }
    }
}
