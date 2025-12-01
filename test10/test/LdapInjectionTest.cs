using System;
using System.DirectoryServices;

namespace test_project10
{
    public class LdapInjectionTest
    {
        public void SearchUser(string username)
        {
            // LDAP injection vulnerability
            string ldapPath = "LDAP://dc=example,dc=com";
            DirectoryEntry entry = new DirectoryEntry(ldapPath);
            DirectorySearcher searcher = new DirectorySearcher(entry);
            searcher.Filter = "(uid=" + username + ")";
            searcher.FindOne();
        }
    }
}
