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

    public delegate void ServiceCar(Car car);

    public delegate void ServiceBus(Bus bus);

    public class Car
    {
    }

    public class Bus : Car
    {
    }

    public class TaskC
    {
        public static void Run()
        {
            //basic
            ServiceCar changeCarTyres = ChangeTyres;
            changeCarTyres(new Car());

            //contra-variance, delegate param type is more derived than method param type
            ServiceBus changeBusTyres = ChangeTyres;
            changeBusTyres(new Bus());

        }

        public static void ChangeTyres(Car car)
        {
            Console.WriteLine($"{car.GetType().Name} changed tyres.");
        }

        public static void CleanInterior(Bus bus)
        {
            Console.WriteLine($"{bus.GetType().Name} cleaned.");
        }
    }
}