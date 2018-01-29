using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Anothers.Reflection
{
    public class AssemblyLoad
    {
        public static void Run()
        {
            var bytes = File.ReadAllBytes("MyCoolLibrary.dll");

            //Loads an assembly into the reflection-only context, given its display name.
            Assembly.ReflectionOnlyLoad(bytes);
            Assembly.ReflectionOnlyLoad("MyCoolLibrary"); //uses string like assembly display name

            Assembly.Load
            string assemblyFilePath = "MyCoolLibrary.dll";
            
            //Loads an assembly into the reflection - only context, given its path.
            Assembly.ReflectionOnlyLoadFrom(assemblyFilePath);
        }
    }
}
