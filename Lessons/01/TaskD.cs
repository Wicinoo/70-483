using System;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    public class TaskD
    {
        public static void Run()
        {
            CreateCar createCar = () => new Car();
            Car carIsCar = createCar();

            CreateCar createBusAsCar = () => new Bus();
            Car busCreatedAsCar = createBusAsCar();
        }
    }

    internal delegate Car CreateCar();

}