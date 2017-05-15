using System;
using System.Text;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>

    delegate Weapon StoreWeapon();

    delegate Sword StoreSword();

    delegate Bow StorwBow();

    delegate Mace StoreBow();

    public class TaskD
    {
        public static void Run()
        {
            StoreWeapon hideYourSword = StoreSword;
            StoreWeapon hideYourBow = StoreBow;
            StoreWeapon hideYourMace = StoreMace;
            StoreWeapon hideYourWeapon = StoreWeapon;

            var armory = new[]
            {
                hideYourSword(),
                hideYourBow(),
                hideYourMace(),
                hideYourWeapon()
            };

            Console.WriteLine();
            StringBuilder message = new StringBuilder("Your armory contains ");
            foreach (Weapon weapon in armory)
            {
                message.Append(weapon.GetType().Name + " ");
            }

            Console.WriteLine(message.ToString());
        }

        static Weapon StoreWeapon()
        {
            Console.WriteLine("Weapon has been stored in the armory");
            return new Weapon();
        }

        static Sword StoreSword()
        {
            Console.WriteLine("Sword has been put on an armor rack");
            return new Sword();
        }

        static Bow StoreBow()
        {
            Console.WriteLine("Bow has been hung on a wall");
            return new Bow();
        }

        static Mace StoreMace()
        {
            Console.WriteLine("Mace has been left on the table");
            return new Mace();
        }
    }

    class Weapon { }

    class Sword : Weapon { }

    class Bow : Weapon { }

    class Mace : Weapon { }
}