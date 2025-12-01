using System;
using System.Web;

namespace test_project7
{
    public class XssTest
    {
        public string RenderUserContent(string userContent)
        {
            // XSS vulnerability - no encoding of user input
            return "<div>" + userContent + "</div>";
        }
    }
}
