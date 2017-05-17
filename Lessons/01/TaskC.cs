using System;

namespace Lessons._01
{
    /// Have a class Car and its descendant Bus. 
    public class Car
    {

    }

    public class Bus : Car
    {

    }

    public static class TaskC
    {

        /// Declare delegates "void ServiceCar(Car car)" and "void ServiceBus(Bus bus)". 
        delegate void ServiceCar(Car car);
        delegate void ServiceBus(Bus bus);

        /// Define a method to change the tyres of a car.
        private static void ChangeTyres(Car car)
        {
            Console.WriteLine($"{car.GetType().Name} has changed tyres.");
        }

        /// Define a method to clean up an interier of a bus.
        private static void CleanUpBusInterier(Bus bus)
        {
            Console.WriteLine($"{bus.GetType().Name}'s interier is now clesn.");
        }

        /// Demonstrate all possible combinations of assigning the methods to the delegates. Apply "contravariance".

        public static void Run()
        {
            ServiceCar chng = ChangeTyres;
            chng(new Car());
            chng(new Bus());

            ServiceBus cln = ChangeTyres;
            cln(new Bus());

            ServiceBus cln1 = CleanUpBusInterier;
            cln1(new Bus());

        }
    }
}