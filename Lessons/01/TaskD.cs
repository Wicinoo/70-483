using System;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    public delegate Car ServiceCar2();

    public delegate Bus ServiceBus2();

    public class TaskD
    {
        public static void Run()
        {
            ServiceCar2 serviceCar = ChangeTypeOfCar;
            serviceCar += CleanUpInterierOfBus;
            serviceCar();

            ServiceBus2 serviceBus = CleanUpInterierOfBus;
            serviceBus();
        }

        private static Car ChangeTypeOfCar()
        {
            Console.WriteLine($"Car is changing type");
            return new Car();
        }
        private static Bus CleanUpInterierOfBus()
        {
            Console.WriteLine($"Bus is cleaning up an interier");
            return new Bus();
        }
    }
}