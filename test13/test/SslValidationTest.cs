using System;
using System.Net;

namespace test_project13
{
    public class SslValidationTest
    {
        public void DisableSslValidation()
        {
            // SSL/TLS validation bypass vulnerability
            ServicePointManager.ServerCertificateValidationCallback = 
                (sender, certificate, chain, sslPolicyErrors) => true;
            
            WebClient client = new WebClient();
            client.DownloadString("https://example.com/api/data");
        }
    }
}
