using System;
using System.Runtime.CompilerServices;
using Rhino.Mocks.Constraints;

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
            ServiceCar changeTyres = ChangeTyres;
            changeTyres(new Car());
            changeTyres(new Bus());

            ServiceBus changeTyresOnBus = ChangeTyres;
            changeTyresOnBus(new Bus());

            ServiceBus cleanInterior = CleanInteriorOfBus;
            cleanInterior(new Bus());
        }

        private static void ChangeTyres(Car car)
        {
            Console.Write($"Changing tyres on {car.GetType().Name}.........");
            Console.WriteLine("Tyres changed");
        }

        private static void CleanInteriorOfBus(Bus bus)
        {
            Console.Write($"Cleaning of {bus.GetType().Name} in progress.........");
            Console.WriteLine("Cleaning finished");
        }
    }

    public class Car { }

    public class Bus: Car { }
}