using System;
using System.Runtime.InteropServices;

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

            ServiceBus changeTyresOfABus = ChangeTyres;
            changeTyresOfABus(new Bus());

            ServiceBus cleanUpInterier = CleanUpInterier;
            cleanUpInterier(new Bus());
        }

        private static void ChangeTyres(Car car)
        {
            Console.WriteLine($"Changing tyres of a {car.GetType().Name}");
        }

        private static void CleanUpInterier(Bus bus)
        {
            Console.WriteLine($"Cleaning up an interier of a {bus.GetType().Name}");
        }
    }

    public class Car { }

    public class Bus : Car { }
}