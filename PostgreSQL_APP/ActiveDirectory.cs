using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.Protocols;

namespace PostgreSQL_APP
{
    class ActiveDirectory
    {
        DirectoryEntry de;
        public ActiveDirectory()
        {
            de = new DirectoryEntry("LDAP://server");
        }

        public bool CheckUser(string name, string password)
        {
            de.Username = name;
            de.Password = password;

            DirectorySearcher searcher = new DirectorySearcher(de);

            searcher.Filter = "(objectclass=user)";

            try
            {
                searcher.FindOne();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

