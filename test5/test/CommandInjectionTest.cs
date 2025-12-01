using System;
using System.Diagnostics;

namespace test_project5
{
    public class CommandInjectionTest
    {
        public void ExecuteCommand(string userInput)
        {
            // Command injection vulnerability
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "/bin/bash";
            startInfo.Arguments = "-c " + userInput;
            Process.Start(startInfo);
        }
    }
}
