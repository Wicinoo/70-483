using System;
using System.Reflection;
using Castle.DynamicProxy.Generators.Emitters;

namespace Lessons._09
{
    public class Demo
    {
        // Create a project MyCoolProject with MyCoolClass
        // Build the project:
        // > msbuild /p:OutDir=.;debug=none
        // Reference the assembly dll from the main project. (use Browse)
        // Call MyCoolLibrary.MyCoolClass.Run()
        // Run the main project.
        // Print out FullName, Location, GlobalAssemblyCache properties of the assembly.
        // Print out IsAssemblySigned() result.


        // Signing the assembly ...
        // Create a module file for the class:
        // > csc /target:module MyCoolClass.cs
        // Create a key pair file:
        // > sn -k MyKey.snk
        // Create .netmodule file:
        // > csc /out:MyCoolLibrary.netmodule /target:module Properties/AssemblyInfo.cs MyCoolClass.cs
        // Sign the module file:
        // > al /out:MyCoolLibrary.dll MyCoolLibrary.netmodule /keyfile:MyKey.snk
        // Print out information about the assembly:
        // > sn -Tp MyCoolLibrary.dll

        // Change CopyLocal of the referenced assembly to False.
        // Run the main project. => exception

        // Working with GAC ...
        // List all MyCoolLibrary assemblies installed into GAC
        // > gacutil -l MyCoolLibrary
        // Install MyCoolLibrary.dll into GAC:
        // > gacutil -i MyCoolLibrary.dll 
        // > gacutil -l MyCoolLibrary

        // Run the main project.

        // New version of the assembly 1.0.0.0 => 2.0.0.0 ...
        // Change version of the assembly 2.0.0.0
        // > csc /out:MyCoolLibrary.netmodule /target:module Properties/AssemblyInfo.cs MyCoolClass.cs
        // > al /out:MyCoolLibrary.dll MyCoolLibrary.netmodule /keyfile:MyKey.snk

        // Assembly binding
        // Create a folder, copy all assemblies for Lesson.exe
        // Remove private assembly MyCoolLibrary.dll from the folder
        // Copy MyCoolLibrary version 2.0.0.0 into the folder
        // Run the app from command line => exception
        // Put redirection configuration from Redirection.xml to Lessons.exe.config
        // Run the app from command line => ok

        // Generating PDB file
        // > msbuild /p:OutDir=.;debug=pdbonly
        // > msbuild /p:OutDir=.;debug=full
        // > msbuild /p:OutDir=.;debug=none

        // Debug > Windows > Modules
        // Tools > Options > Debugging > Symbols

        public static void Run()
        {
            MyCoolLibrary.MyCoolClass.Run();
            var assembly = Assembly.GetAssembly(typeof(MyCoolLibrary.MyCoolClass));
            Console.WriteLine(assembly.FullName);
            Console.WriteLine(assembly.Location);
            Console.WriteLine("Signed: " + assembly.IsAssemblySigned());
            Console.WriteLine("In GAC: " + assembly.GlobalAssemblyCache);
        }
    }
}