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
        private delegate void ServiceCar(Car car);
        private delegate void ServiceBus(Bus bus);

        public static void Run()
        {
            // Contravariance - permits use a method with less derived types in argument for a delegate.

            // delegate requires car and method requires car
            ServiceCar changeTyres = ChangeTyres;
            changeTyres(new Car());
            changeTyres(new Bus());

            // It is not possible to pass any car if we expect only bus.
            //ServiceCar cleanBus = CleanUpBus;      

            // delegate requires Bus and method requires Car
            // It is possible because of Contravariance - we can change tyres for bus
            ServiceBus changeTyresBus = ChangeTyres;
            changeTyresBus(new Bus());

            // delegate requires Bus and method requires Bus
            ServiceBus cleanUpBus = CleanUpBus;
            cleanUpBus(new Bus());
        }

        private static void ChangeTyres(Car car)
        {
            Console.WriteLine($"Tyres are changed for {car.GetType().Name}");
        }

        private static void CleanUpBus(Bus bus)
        {
            Console.WriteLine($"Interior of {bus.GetType().Name} is cleaned up");
        }
    }


    class Car
    {
         
    }

    class Bus : Car
    {
         
    }
}