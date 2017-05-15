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
            ServiceCar serviceCar = ChangeTyres;
            serviceCar(new Car());
            serviceCar(new Bus());

            ServiceBus serviceBus = CleanInterier;
            serviceBus(new Bus());

            ServiceBus serviceBusTyres = ChangeTyres;
            serviceBusTyres(new Bus());            
        }

        public static void ChangeTyres(Car car)
        {
            Console.WriteLine("Tyres of a {0} has been changed", car.GetType().Name);
        }
        public static void CleanInterier(Bus bus)
        {
            Console.WriteLine("Interier of a {0} has been cleaned", bus.GetType().Name);
        }
    }

    public class Car
    {
    }

    public class Bus : Car
    {
    }
}