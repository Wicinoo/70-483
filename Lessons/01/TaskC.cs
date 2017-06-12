using System;

namespace Lessons._01
{
    delegate void ServiceCar(Car car);

    delegate void ServiceBus(Bus bus);

    /// <summary>
    /// Have a class Car and its descendant Bus. 
    /// Declare delegates "void ServiceCar(Car car)" and "void ServiceBus(Bus bus)". 
    /// Define a method to change the tyres of a car.
    /// Define a method to clean up an interier of a bus.
    /// Demonstrate all possible combinations of assigning the methods to the delegates. Apply "contravariance".
    /// </summary>
    public class TaskC
    {
        public static void Run()
        {
            ServiceCar changeCarTyre = ChangeTyre;
            changeCarTyre(new Car());
            changeCarTyre(new Bus());

            ServiceBus changeBusTyre = ChangeTyre;
            changeBusTyre(new Bus());

            ServiceBus cleanBusInterior = CleanInterior;
            cleanBusInterior(new Bus());
        }

        private static void ChangeTyre(Car car)
        {
        }

        private static void CleanInterior(Bus bus)
        {
        }
    }

    class Car { }

    class Bus : Car { }
}