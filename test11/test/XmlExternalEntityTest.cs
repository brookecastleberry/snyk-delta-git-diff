using System;
using System.Xml;

namespace test_project11
{
    public class XmlExternalEntityTest
    {
        public void ParseXml(string xmlContent)
        {
            // XXE vulnerability - XmlResolver not disabled
            XmlDocument doc = new XmlDocument();
            doc.XmlResolver = new XmlUrlResolver();
            doc.LoadXml(xmlContent);
        }
    }
}
