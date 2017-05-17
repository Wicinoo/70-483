using System;
using System.IO;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>

    //Covariance makes it possible that a method has a return type that is more derived than that defined in the delegate.

    public class PublicCompany {}
    public class BigPublicCompany : PublicCompany {}
    
    public class TaskD
    {
        public delegate PublicCompany covarDel(BigPublicCompany bg);

        public static void Run()
        {
            covarDel del = Method1;

            PublicCompany pbl = del(new BigPublicCompany());
        }

        static BigPublicCompany Method1(BigPublicCompany bg)
        {
            Console.WriteLine("This method has a return type (BigPublicCompany) that is more derived than that " +
                "defined in the delegate (PublicCompany)");

            return new BigPublicCompany();
        }

        static PublicCompany Method2(BigPublicCompany bg)
        {
            Console.WriteLine("Method2");

            return new PublicCompany();
        }
    }
}