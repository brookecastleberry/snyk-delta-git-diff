using System;
using System.IO;

namespace test_project4
{
    public class PathTraversalTest
    {
        public string ReadUserFile(string filename)
        {
            // Path traversal vulnerability - no validation of user input
            string filePath = "/var/www/files/" + filename;
            return File.ReadAllText(filePath);
        }
    }
}
