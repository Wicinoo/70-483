using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MyCoolLibrary
{
    public class MyCoolLibrary
    {
        public static void PrintCoolMessage()
        {
            var assemblyName = typeof(MyCoolLibrary).Assembly.GetName().Name; // Get assembly full name by reflection.
            Console.WriteLine($"This is a cool message from  {assemblyName}.");

        }
    }
}
