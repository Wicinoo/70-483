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

            CreateBus createBus = () => new Bus();
            Bus busIsBus = createBus();
            Car busIsAlsoCar = createBus();
        }
    }

    internal delegate Car CreateCar();

    internal delegate Bus CreateBus();
}