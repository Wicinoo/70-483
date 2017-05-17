using System;

namespace Lessons._01
{
    /// <summary>
    /// Have a class Car and its descendant Bus. 
    /// Declare delegates "void ServiceCar(Car bus)" and "void ServiceBus(Bus bus)". 
    /// Define a method to change the tyres of a bus.
    /// Define a method to clean up an interier of a bus.
    /// Demonstrate all possible combinations of assigning the methods to the delegates. Apply "contravariance".
    /// </summary>
    public class TaskC
    {
        public delegate void ServiceCar(Car car);

        public delegate void ServiceBus(Bus bus);
        public static void Run()
        {

            var dirtyBus = new Bus() {Interier = InterierState.Waste, Tires = TiresState.Intermediate};
            var dirtyCar = new Car() { Interier = InterierState.Dirty, Tires =  TiresState.Low};
            var service = new Service();
            ServiceBus bigInterierService = service.CleanInterier;
            ServiceCar tierService = service.ChangeTyres;

            bigInterierService(dirtyBus);
            //bigInterierService(dirtyCar); //not possibe, because they have too big cleaner
            ShowVehicle(dirtyBus);

            tierService(dirtyCar); //possibility, because tier service has big Jack (zvedák) (Contravariance)
            tierService(dirtyBus);

            ShowVehicle(dirtyBus);
            ShowVehicle(dirtyCar);

            ServiceBus multiService = service.CleanInterier;
            multiService += service.ChangeTyres;

            multiService(dirtyBus);
            ShowVehicle(dirtyBus);

        }

        public static void ShowVehicle(Car car)
        {
            Console.WriteLine(car.ToString());
        }
    }

    public enum TiresState
    {
        New,
        Intermediate,
        Low
    }

    public enum InterierState
    {
        Clean,
        Dirty,
        Waste

    }

    public class Service
    {
        public void ChangeTyres(Car car)
        {
          car.Tires = TiresState.New;
        }

        public void CleanInterier(Bus bus)
        {
            if (bus.Interier > InterierState.Clean)
            {
                bus.Interier -= 1;
            }
        }
    }

    public class Car
    {
        public InterierState Interier { get; set; }

        public TiresState Tires { get; set; }

        public override string ToString()
        {
            return
                $"Type of vehicle: {this.GetType().Name}, Interier: {this.Interier.ToString()}, Tires: {this.Tires.ToString()}";
        }
    }
    public class Bus : Car { }
}