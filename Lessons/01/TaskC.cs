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
            ServiceCar sc1 = ChangeTyres;

            ServiceBus sb1 = ChangeTyres;
            ServiceBus sb2 = CleanUp;

            var car = new Car();
            var bus = new Bus();

            sc1(car);
            sc1(bus);

            sb1(bus);

            sb2(bus);
        }

        public static void ChangeTyres(Car car)
        {
            Console.Out.WriteLine($"Tyres of {car} changed.");
        }

        public static void CleanUp(Bus bus)
        {
            Console.Out.WriteLine($"Interier of {bus} cleaned.");
        }
    }

    public class Car
    {
        public override string ToString()
        {
            return "Car";
        }
    }

    public class Bus : Car
    {
        public override string ToString()
        {
            return "Bus";
        }
    }
}