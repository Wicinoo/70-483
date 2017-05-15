using System;
using System.Collections.Generic;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    public class TaskD
    {
        delegate Animal GetAnimal();

        delegate Parrot GetFlyingAnimal();

        public static void Run()
        {
            GetAnimal getAnimalDog = GetDog;
            GetFlyingAnimal getFlyingAnimal = GetParrot;

            var petStore = new List<Animal>();
            petStore.Add(getFlyingAnimal());
            petStore.Add(getAnimalDog());

            petStore.ForEach(animal => animal.MakeSound());
        }

        private static Animal GetSomeAnimal()
        {
            Console.WriteLine("Getting an animal");
            return new Animal();
        }

        private static Parrot GetParrot()
        {
            Console.WriteLine("Getting a parrot.");
            return new Parrot();
        }

        private static Dog GetDog()
        {
            Console.WriteLine("Getting a dog.");
            return new Dog();
        }

        public class Animal
        {
            virtual public void MakeSound() { }

        }
        public class Dog : Animal
        {
            public override void MakeSound()
            {
                Console.WriteLine("I'm a dog");
            }
        }

        public class Parrot : Animal
        {
            public override void MakeSound()
            {
                Console.WriteLine("I'm a parrot");
            }
        }
    }
}