using System;
using System.Data.SqlClient;

namespace test_project3
{
    public class SqlInjectionTest
    {
        public void VulnerableQuery(string userInput)
        {
            string connectionString = "Server=localhost;Database=TestDB;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // SQL Injection vulnerability - user input directly concatenated
                string query = "SELECT * FROM Users WHERE Username = '" + userInput + "'";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteReader();
            }
        }
    }
}
