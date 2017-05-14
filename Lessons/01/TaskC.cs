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
        class Car
        {
            public bool TyresAreChanged { get; private set; }

            public static void ChangeTyres(Car car)
            {
                car.TyresAreChanged = true;
            }
        }

        class Bus: Car
        {
            public bool InterierIsCleanedUp { get; private set; }

            public static void CleanUpInterier(Bus bus)
            {
                bus.InterierIsCleanedUp = true;
            }
        }

        private delegate void ServiceCar(Car car);

        private delegate void ServiceBus(Bus bus);

        public static void Run()
        {
            ServiceCar svcCarCarChangeTyres = Car.ChangeTyres;

            ServiceCar svcCarBusChangeTyres = Bus.ChangeTyres;


            ServiceBus svcBusBusChangeTyres = Bus.ChangeTyres;

            ServiceBus svcBusCarChangeTyres = Car.ChangeTyres;

            ServiceBus svcBusCleanUpInterier = Bus.CleanUpInterier;
        }
    }
}