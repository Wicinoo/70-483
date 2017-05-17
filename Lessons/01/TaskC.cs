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
        delegate void WorkOnCar(Car car);
        delegate void WorkOnBus(Bus bus);

        public static void Run()
        {
            WorkOnCar woc = ChangeTires;
            woc(new Car());
            woc(new Bus());

            WorkOnBus wob = ChangeTires;
            //wob(new Car()); //delegate is with param of type bus so can pass in a car, even tho the method ChangeTires requires only Car
            wob(new Bus());

            WorkOnBus wob2 = CleanupBus;
            //wob2(new Car()); //obvious
            wob2(new Bus());
        }


        private static void ChangeTires(Car car)
        {
            Console.WriteLine($"Changing tires of a {car.GetType().Name}.");
        }
        private static void CleanupBus(Bus bus)
        {
            Console.WriteLine($"Cleaning up {bus.GetType().Name}.");
        }
    }


    public class Car
    {
    }

    public class Bus : Car
    {
    }
}