using System;

namespace test_project9
{
    public class HardcodedCredentialsTest
    {
        public void ConnectToDatabase()
        {
            // Hardcoded credentials vulnerability
            string username = "admin";
            string password = "P@ssw0rd123!";
            string connectionString = $"Server=localhost;Database=MyDB;User Id={username};Password={password};";
            
            Console.WriteLine("Connecting with: " + connectionString);
        }
    }
}
