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
            // delegate requires Car and method requires Car
            ServiceCar changeTyres = ChangeTyres;
            changeTyres(new Car());
            changeTyres(new Bus());

            // delegate requires Car + method requires Bus
            // It is not possible to pass any car if we expect only buses.
            //ServiceCar cleanCarInterior = CleanBus;   

            // delegate requires Bus and method requires Car
            // It is possible because of Contravariance - A bus can have tyres changed
            ServiceBus changeBusTyres = ChangeTyres;
            changeBusTyres(new Bus());

            // delegate requires Bus and method requires Bus
            ServiceBus cleanBusInterior = CleanBus;
            cleanBusInterior(new Bus());
        }

        private static void ChangeTyres(Car car)
        {
            Console.WriteLine($"{car.GetType().Name} tyres changed.");
        }

        private static void CleanBus(Bus bus)
        {
            Console.WriteLine($"{bus.GetType().Name} interior cleaned.");
        }

        class Car { }

        class Bus : Car { }
    }
}