using System;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    public class TaskD
    {
        public delegate Vehicle DriveVehicle();
        public delegate Bus DriveBus();

        public static void Run()
        {
            DriveVehicle vehicle = GetVehicleLicence;
            DriveBus bus = GetBusLicence;
            DriveVehicle caravan = GetBusLicence;

            var drivingLicence = new[]
            {
                vehicle(),
                bus(),
                caravan()
            };
        }

        private static Vehicle GetVehicleLicence()
        {
            Console.WriteLine("Able to drive a Vehicle.");
            return new Vehicle();
        }

        private static Bus GetBusLicence()
        {
            Console.WriteLine("Able to drive a Bus.");
            return new Bus();
        }
    }

    public class Vehicle { }

    public class Car : Vehicle { }

    public class Bus : Vehicle { }
}