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
        public static void Run()
        {
            ServiceCar changeVehicleTyres = ChangeTyres;

            //All vehicles can have their tyres changed
            changeVehicleTyres(new Car());
            changeVehicleTyres(new Bus());

            ServiceBus cleanVehicleInterior = CleanInterior;

            //Only Buses can have their interior cleaned
            cleanVehicleInterior(new Bus());
            //cleanVehicleInterior(new Car()); 
        }

        private static void ChangeTyres(Car car)
        {
            car.TyresChanged = true;
            Console.WriteLine($"Changed {car.GetType().Name} tyres");
        }

        private static void CleanInterior(Bus bus)
        {
            bus.InteriorCleaned = true;
            Console.WriteLine($"Cleaned {bus.GetType().Name} interior");
        }
    }

    delegate void ServiceCar(Car car);

    class Car
    {
        public bool TyresChanged = false;
    }

    delegate void ServiceBus(Bus bus);

    class Bus : Car
    {
        public bool InteriorCleaned = false;
    }



}