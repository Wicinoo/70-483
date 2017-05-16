using System;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    public class TaskD
    {
        public delegate Car GetCar();

        public delegate Bus GetBus();

        public static void Run()
        {
            GetCar chooseCar = ChooseCar;
            chooseCar();
            
            GetBus chooseBus = ChooseBus;
            chooseBus();

            // Delegate covariance: 
            //  delegate with less derived return type can accept method that returns a more derived type
            chooseCar = ChooseBus; 
            chooseCar();

            // chooseBus = ChooseCar; // delegate with more derived return type cannot accept method that returns a less derived type
        }

        public static void PrintVehicleChosen(Car car)
        {
            Console.WriteLine($"Vehicle chosen was: { car.Name }");
        }

        public static Car ChooseCar()
        {
            var vehicle = new Car();
            PrintVehicleChosen(vehicle);

            return vehicle;
        }

        public static Bus ChooseBus()
        {
            var vehicle = new Bus();
            PrintVehicleChosen(vehicle);

            return vehicle;
        }
    }

    public class Car
    {
        public string Name { get; set; }

        public Car(string name = "car")
        {
            Name = name;
        }
    }

    public class Bus : Car
    {
        public Bus(string name = "bus") : base(name) { }
    }
}