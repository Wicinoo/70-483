using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Anothers.Crypto
{
    public class Certificates
    {
        public static void Run()
        {
            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            object seachValue = "cert";
            var certs = store.Certificates.Find(X509FindType.FindBySubjectDistinguishedName, seachValue, false);
        }
    }
}
