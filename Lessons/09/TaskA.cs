
using System;
using MyCoolLibrary;

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
            CoolMessagePrinter.PrintCoolMessage();
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
}
