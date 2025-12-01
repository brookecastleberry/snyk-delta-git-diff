using System;

namespace test_project12
{
    public class InsecureRandomTest
    {
        public string GenerateToken()
        {
            // Insecure random number generation for security-sensitive context
            Random random = new Random();
            byte[] tokenBytes = new byte[32];
            random.NextBytes(tokenBytes);
            return Convert.ToBase64String(tokenBytes);
        }
    }
}
