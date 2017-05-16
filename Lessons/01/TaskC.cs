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
        public delegate void ServiceBus(Bus bus);
        public delegate void ServiceCar(Car bus);

        public static void Run()
        {
            ServiceCar ChangeTyres = delegate (Car car) { Console.WriteLine("Car Tyres Changed 1 : {0}", car.Model); };
            ServiceCar ChangeTyres2 = (Car car) => { Console.WriteLine("Car Tyres Changed 2 : {0}", car.Model); };
            ServiceCar ChangeTyres3 = (car) => { Console.WriteLine("Car Tyres Changed 3 : {0}", car.Model); };

            ServiceBus CleanBus1 = delegate (Bus bus) { Console.WriteLine("Bus Cleaned 2 : {0}", bus.Type); };
            ServiceBus CleanBus2 = (Bus bus) => { Console.WriteLine("Bus Cleaned 2 : {0}", bus.Type); };
            ServiceBus CleanBus3 = (bus) => { Console.WriteLine("Bus Cleaned 2 : {0}", bus.Type); };

            var car1 = new Car { Model = "Ford Mustang" };
            var bus1 = new Bus { Model = "Magirus", Type = "Public Transport" };

            ChangeTyres(car1);
            ChangeTyres(bus1);

            CleanBus1(bus1);
        }
    }

    public class Car { public string Model { get; set; } }

    public class Bus : Car { public string Type { get; set; } }
}