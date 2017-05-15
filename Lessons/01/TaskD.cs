using System;
using System.Collections.Generic;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    public class TaskD
    {
        class Animal
        {
            public string Name { get; set; }

            public virtual void SayHi()
            {
                Console.WriteLine($"I'm secret animal and my name is {Name}");
            }
        }

        class Cat : Animal
        {
            public override void SayHi()
            {
                Console.WriteLine($"I'm cat and my name is {Name}");
            }
        }

        public static void Run()
        {
            var cats = new List<Cat>
            {
                new Cat {Name = "Leopold"},
                new Cat {Name = "Basilio"}
            };

            SayAnimalsHi(cats);
        }

        private static void SayAnimalsHi(IEnumerable<Animal> animals)
        {
            foreach (var animal in animals)
            {
                animal.SayHi();
            }
        }
    }
}