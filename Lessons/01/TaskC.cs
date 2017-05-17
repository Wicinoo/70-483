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
            //car service
            ServiceCar carService = Car.ChangeTyres;
            carService(new Car());
            carService(new Bus());

            //bus service
            ServiceBus busService = Bus.ChangeTyres;
            busService(new Bus());

            ServiceBus busService2 = Bus.CleanBus;
            busService2(new Bus());
        }
    }

    public class Car
    {
        public static void ChangeTyres(Car car)
        {
            Console.WriteLine($"{car.GetType().Name}'s changing tyres executed.");
        }        
    }

    public class Bus : Car
    {
        public static void CleanBus(Bus bus)
        {
            Console.WriteLine($"{bus.GetType().Name}'s cleaning executed.");
        }
    }
}