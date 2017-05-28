using System;

namespace Lessons._01
{
    /// <summary>
    /// Have a class Car and its descendant Bus. 
    /// Declare delegates "void ServiceCar(Car car)" and "void ServiceBus(Bus bus)". 
    /// Define a method to change the tyres of a car.
    /// Define a method to clean up an interier of a bus.
    /// Demonstrate all possible combinations of assigning the methods to the delegates. Apply "contravariance".
    /// </summary>
    public class TaskC
    {
        public delegate void ServiceCar(Car car);

        public delegate void ServiceBus(Bus bus);

        public static void Run()
        {
            ServiceCar service = ChangeTyres;
            service(new Car());
            service(new Bus());

            ServiceBus service2 = CleanInterier;
            service2(new Bus());

            ServiceBus service3 = ChangeTyres;
            service3(new Bus());
        }

        public static void ChangeTyres(Car car)
        {
            Console.WriteLine($"{car.GetType().Name} had tyres changed.");
        }

        public static void CleanInterier(Bus bus)
        {
            Console.WriteLine($"{bus.GetType().Name} had interier cleaned.");
        }

        public class Car { }

        public class Bus : Car { }
    }
}