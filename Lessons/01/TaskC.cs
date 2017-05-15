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
            ServiceCar changeTyres = ChangeTyres;
            changeTyres(new Car());
            changeTyres(new Bus());

            ServiceBus changeBusTyres = ChangeTyres;

            changeBusTyres(new Bus());

            ServiceBus cleanBusInterier = CleanBusInterier;

            cleanBusInterier(new Bus());
        }

        private static void ChangeTyres(Car car)
        {
            Console.WriteLine($"{car.GetType().Name} has new tyres.");
        }

        private static void CleanBusInterier(Bus bus)
        {
            Console.WriteLine($"Interior of {bus.GetType().Name} is being cleaned.");
        }

    }

    class Car { };

    class Bus : Car { };
}