using System;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    public class TaskD
    {
        delegate Person GetPerson();

        delegate Man GetSomeMan();

        delegate Woman GetSomeWomen();

        public static void Run()
        {
            //The method return a new person
            GetPerson getBaby = GetBorn;
            GetPerson getFather = GetMan;
            GetPerson getMother = GetWoman;
            var family = new[]
            {
                getMother(),
                getFather(),
                getBaby()
            };
            Console.WriteLine($"Our family contains: {family[0].Description} and {family[1].Description} and {family[2].Description}");

            GetSomeWomen getGranny = GetWoman;

            //Thes variantes are not possible because of wrong return type
            //GetSomeWomen getGrandpa = GetMan;
            //GetSomeWomen getGrandpa = GetBorn;

        }

        private static Person GetBorn()
        {
            Console.WriteLine("Getting a new born person.");
            return new Person() {Description = "Baby"};
        }

        private static Man GetMan()
        {
            Console.WriteLine("Getting a man.");
            return new Man() { Description = "Strong and clever man" }; ;
        }

        private static Woman GetWoman()
        {
            Console.WriteLine("Getting a women.");
            return new Woman() { Description = "Nice pritty women" }; ;
        }

    }

    class Person {
        public string Description { get; set; }
    }
    class Man : Person { }
    class Woman : Person { }
}