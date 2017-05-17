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
            // We can pass both a car and a bus
            ServiceCar ChangeCarTyres = ChangeTyres;
            ChangeCarTyres(new Car());
            ChangeCarTyres(new Bus());

            // delegate requires Car + method requires Bus
            // It is not possible to pass any car if we expect only buses.
            //ServiceCar CleanCarInterior = CleanInterior; 

            // delegate requires Bus and method requires Car
            // It is possible because of Contravariance - A bus can get its tyres changed.
            ServiceBus ChangeBusTyres = ChangeTyres;
            ChangeBusTyres(new Bus());

            // delegate requires Bus and method requires Bus
            ServiceBus CleanBusInterior = CleanInterior;
            CleanBusInterior(new Bus());
        }

        private static void ChangeTyres(Car car)
        {
            Console.WriteLine($"A {car.GetType().Name} is getting its tyres changed.");
        }

        private static void CleanInterior(Bus bus)
        {
            Console.WriteLine($"A {bus.GetType().Name} is getting its interior cleaned.");
        }

        class Car { }

        class Bus : Car { }
    }
}