using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._3._2
{
    public class Securities
    {
        public static void Run()
        {
            //https://www.codeproject.com/Articles/5724/Understanding-NET-Code-Access-Security
            DeclarativeCAS();
            ImperativeCas();
            StorePasswordToSecureString();

        }

        private static string GetPasswordFromSecureString(SecureString secureString)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        private static void StorePasswordToSecureString()
        {
            Console.WriteLine("Secure string...");
            Console.WriteLine("Enter password follow enter");


            using (SecureString ss = new SecureString())
            {
                while (true)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Enter) break;
                    ss.AppendChar(cki.KeyChar);
                    Console.Write(".");
                }

                ss.MakeReadOnly();

                Console.WriteLine(GetPasswordFromSecureString(ss));
            }
        }

        private static void ImperativeCas()
        {
            FileIOPermission f = new FileIOPermission(PermissionState.None);
            f.AllFiles = FileIOPermissionAccess.Read;
            try
            {
                f.Demand();
            }
            catch (SecurityException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [System.Security.Permissions.FileIOPermission(System.Security.Permissions.SecurityAction.Demand, AllLocalFiles = System.Security.Permissions.FileIOPermissionAccess.Read)]
        public static void DeclarativeCAS()
        {


        }


    }
}
