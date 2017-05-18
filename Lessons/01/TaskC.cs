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
        public delegate void ServiceCar(Car car);

        public delegate void ServiceBus(Bus bus);

        public static void Run()
        {
            ServiceCar changeTyres = ChangeTyresOfCar;
            changeTyres(new Car());
            changeTyres(new Bus());

            Console.WriteLine();

            //contravariance
            ServiceBus changeTyresAgain = ChangeTyresOfCar;
            changeTyresAgain(new Bus());
            //changeTyresAgain(new Car()); //not possible
            
            Console.WriteLine();

            //not possible
            //ServiceCar cleanInterior = CleanInterierOfBus;

            ServiceBus cleanInteriorAgain = CleanInterierOfBus;
            //cleanInteriorAgain(new Car()); //not possible
            cleanInteriorAgain(new Bus());
        }

        private static void ChangeTyresOfCar(Car car)
        {
            Console.WriteLine($"Tires of *{car.GetType().Name}* has been changed");
        }

        private static void CleanInterierOfBus(Bus bus)
        {
            Console.WriteLine($"Interior of *{bus.GetType().Name}* has been cleaned up");
        }

        public class Car { };

        public class Bus : Car { };
    }
}