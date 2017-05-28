using System;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    /// 
    public class TaskD
    {
        public delegate Car GetCar();

        public delegate SuperCar GetSuperCar();

        public static void Run()
        {
            GetCar getCar = GetOrdinaryCar;
            GetCar superCar = GetSuperCarFromShop;

            var cars = new[]
            {
                getCar(),
                superCar()
            };

            Console.WriteLine($"We bought these cars: {cars[0].GetType().Name} and {cars[1].GetType().Name}");
            
            GetSuperCar getsuperCar = GetSuperCarFromShop;

            var frontendDeveloper = getsuperCar();
        }

        private static Car GetOrdinaryCar()
        {
            Console.WriteLine("Getting an ordinary car.");
            return new Car();
        }

        private static SuperCar GetSuperCarFromShop()
        {
            Console.WriteLine("Getting a super car from the shop.");
            return new SuperCar();
        }

        private static FlyingCar GetFlyingCarFromShop()
        {
            Console.WriteLine("Getting a flying car from the shop.");
            return new FlyingCar();
        }
    }

    public class Car { }

    public class SuperCar : Car { }

    public class FlyingCar : Car { }
}