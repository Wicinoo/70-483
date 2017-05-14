using System;
using System.Collections.Generic;

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
            var car = new Car();
            var bus = new Bus();

            ServiceCar changeTyresCar = c => c.ChangeTyres();
            ServiceBus changeTyresBus = b => b.ChangeTyres();
            ServiceBus cleanBus = b => b.CleanInterier();

            changeTyresCar.Invoke(car);
            changeTyresCar.Invoke(bus);

            changeTyresBus.Invoke(bus);

            cleanBus.Invoke(bus);
        }


        private class Car
        {
            public void ChangeTyres()
            {
                Console.WriteLine("Car tyres changed!");
            }
        }

        private class Bus : Car
        {
            public void CleanInterier()
            {
                Console.WriteLine("Bus interier cleaned!");
            } 
        }
    }
}