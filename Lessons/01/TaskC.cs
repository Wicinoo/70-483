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
        public static void Run()
        {
            ServiceCar serviceCarDelegate = ChangeTyres;
            //serviceCarDelegate += CleanUpBus;
            ServiceBus serviceBusDelegate = CleanUpBus;
            serviceBusDelegate += ChangeTyres;

            serviceCarDelegate(new Car());
            serviceCarDelegate(new Bus());
            serviceBusDelegate(new Bus());
        }

        public static void ChangeTyres(Car car)
        {
            Console.WriteLine("Tyres changed for " + car.GetType().Name);
        }

        public static void CleanUpBus(Bus bus)
        {
            Console.WriteLine($"{bus.GetType().Name} cleaned up.");
        }
    }

    public class Car { }

    public class Bus : Car { }

    public delegate void ServiceCar(Car car);

    public delegate void ServiceBus(Bus bus);
}