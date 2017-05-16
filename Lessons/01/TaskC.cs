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
        delegate void ServiceCar(Car car);

        delegate void ServiceBus(Bus bus);

        public static void Run()
        {
            ServiceCar serviceCarChangeTyres = ChangeTyres;
            serviceCarChangeTyres(new Car());
            serviceCarChangeTyres(new Bus());

            ServiceBus serviceBusChangeTyres = ChangeTyres;
            serviceBusChangeTyres(new Bus());

            ServiceBus serviceBusCleanInterior = CleanInterior;
            serviceBusCleanInterior(new Bus());
        }

        private static void ChangeTyres(Car car)
        {
            Console.WriteLine($"Changing tyres of {car.GetType().Name}.");
        }

        private static void CleanInterior(Bus bus)
        {
            Console.WriteLine($"Cleaning interior of {bus.GetType().Name}.");
        }
    }

    public class Car { }

    public class Bus : Car { }
}