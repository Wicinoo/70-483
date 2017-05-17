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
    public class TaskC
    {
        public static void Run()
        {
            ServiceCar servicesCar = ChangeTypeOfCar;
            servicesCar(new Bus());
            servicesCar(new Car());

            ServiceBus servicesBus = CleanUpInterierOfBus;
            servicesBus += ChangeTypeOfCar;
            servicesBus(new Bus());

        }

        private static void ChangeTypeOfCar(Car car)
        {
            Console.WriteLine($"{car.GetType().Name} is changing type");
        }
        private static void CleanUpInterierOfBus(Bus bus)
        {
            Console.WriteLine($"{bus.GetType().Name} is cleaning up an interier");
        }
    }

    public class Car
    {
        
    }

    public class Bus : Car
    {
        
    }
}