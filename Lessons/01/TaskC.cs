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
            //change tyres
            ServiceCar changeTyres = ChangeTyres;
            changeTyres(new Car());
            changeTyres(new Bus());

            //change bus tyres
            ServiceBus changeBusTyres = ChangeTyres;
            changeBusTyres(new Bus());

            //clean bus interior
            ServiceBus cleanInterior = CleanInterior;
            cleanInterior(new Bus());
        }

        private static void ChangeTyres(Car car)
        {
            Console.WriteLine($"The {car.GetType().Name}'s tyres have been changed");
        }

        private static void CleanInterior(Bus bus)
        {
            Console.WriteLine($"The {bus.GetType().Name}'s interior has been cleaned");
        }
    }

    public class Car
    {
        
    }

    public class Bus : Car
    {
        
    }
}