using System;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    public class TaskD
    {
        private delegate Weapon GetWeapon();

        private delegate Frostmourne GetFrostmourne();

        private delegate Doomhammer GetDoomhammer();

        public static void Run()
        {
            GetWeapon wpn = PickUpWeapon;
            wpn();
            wpn = PickUpFrostmourne;
            wpn();
            wpn = PickUpDoomhammer;
            wpn();

            GetDoomhammer doomh = PickUpDoomhammer;
            //doomh = PickUpWeapon;
            doomh();





        }

        private static Weapon PickUpWeapon()
        {
            Console.WriteLine("What a shitty weapon you found. LAME! :D");
            return new Weapon();
        }

        private static Frostmourne PickUpFrostmourne()
        {
            Console.WriteLine("Frostmourne hungers...");
            return new Frostmourne();
        }

        private static Doomhammer PickUpDoomhammer()
        {
            Console.WriteLine("You are Durotan, son of Garad and warchief of the Horde!");
            return new Doomhammer();
        }


    }


    internal class Weapon
    {
    }

    internal class Frostmourne : Weapon
    {
    }

    internal class Doomhammer : Weapon
    {
    }



}