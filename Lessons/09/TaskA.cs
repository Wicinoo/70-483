
using System;
using System.Reflection;

namespace Lessons._09
{
    /// <summary>
    /// Create a new solution with a class library project MyCoolLibrary. 
    /// - Move the type TaskA.CoolMessagePrinter, see below, to the new assembly.
    /// - Implement populating assemblyName in PrintCoolMessage.
    /// - Make the assembly strongly-named.
    /// - Print information about the strong name by using "sn.exe", 
    /// see Output 1. => take a screenshot and put it into this folder as TaskAOutput1.png
    /// - Install the assembly into GAC.
    /// - Change version of the assembly to 2.0.0.0
    /// - Install it into GAC.
    /// - Check the content of GAC by "gacutil.exe", 
    /// see Output 2. => take a screenshot TaskAOutput2.png
    /// - Reference the assembly (not the project) from this Lessons solution 
    /// and invoke PrintCoolMessage. => take a screenshot TaskAOutput3.png.
    /// </summary>
    class TaskA
    {
        public static void Run()
        {
            Console.WriteLine(typeof(MyCoolLibrary.MyCoolLibrary).Assembly.FullName);
            Console.WriteLine(typeof(MyCoolLibrary.MyCoolLibrary).Assembly.Location);
            
            var asm = Assembly.GetAssembly(typeof(MyCoolLibrary.MyCoolLibrary));
            Console.WriteLine($"is in GAC {asm.GlobalAssemblyCache}");
            Console.WriteLine($"is signed {asm.GetName().GetPublicKeyToken().Length>0}");
        }
        public static class CoolMessagePrinter
        {
            public static void PrintCoolMessage()
            {
                var assemblyName = string.Empty; // Get assembly full name by reflection.
                Console.WriteLine($"This is a cool message from {assemblyName}.");
            }
        }
    }



    /*
Possible expected output 1:

Microsoft (R) .NET Framework Strong Name Utility  Version 4.0.30319.0
Copyright (c) Microsoft Corporation.  All rights reserved.

Public key (hash algorithm: sha1):
00240000048000009400000006020000002400005253413100040000010001001921759be81942
825044402f23513a188508f758b01ac300804a61eca6d425e406f125077ef21d9ec687e03261cf
cd242a776781edbd54083a02af950f9178988f5669cf73544976118c70662cf478a3fe13e39371
f685c24b623450f840d6c5038be5b0d5540cca0e52aae0b6e7ad95d259dd996208d9aaeae485cb
04f078d4

Public key token is 4e81c5041bf68520

Possible expected output 2:

MyCoolLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=4e81c5041bf68520, processorArchitecture=MSIL
MyCoolLibrary, Version=2.0.0.0, Culture=neutral, PublicKeyToken=4e81c5041bf68520, processorArchitecture=MSIL
     */

    //result - tools sn.exe
    //C:\Users\Nikola\Source\Repos\NewRepo\MyCoolLibrary\bin\Debug>sn -Tp MyCoolLibrary.dll

    //Microsoft(R) .NET Framework Strong Name Utility Version 3.5.30729.1
    //Copyright(c) Microsoft Corporation.All rights reserved.


    //Public key is
    //0024000004800000940000000602000000240000525341310004000001000100e189b1dda09441
    //90ba5417505b48218746a52ef9e09406891caf522bcf207a33cdd686a2a83db02f8057171e836e
    //9676537c4b4442a4417731c573c3654f06deac2a68d42b095729f0c8231c091d55827a11c1eb42
    //6b07ca0a55192204810c81ab8e3898d19630b6a750f1432312dd7b2f872aa2a3324121bcf09220
    //4368a5c8

    //Public key token is 03c23f749a3d3794

    //C:\Users\Nikola\Source\Repos\NewRepo\MyCoolLibrary\bin\Debug>



    //build
    /*
     * Tam kde se bude ukládat výstup je dán nastavení v csproj pro každou konfiguraci pod OutputPath
    <OutputPath>bin\Debug\</OutputPath>
     * Tento cíl můžeme přesměrovat pomocí parametru v msbuild 
     *  C:\Users\Nikola\Source\Repos\NewRepo\MyCoolLibrary>msbuild MyCoolLibrary.csproj
            /property:Configuration=Debug /property:OutDir=result
     * 




    instalation dll to GAC
    C:\Users\Nikola\Source\Repos\NewRepo\MyCoolLibrary\bin\Debug>gacutil -i MyCoolLibrary.dll
    Show information 



      */


}



