using System;
using System.Collections.Generic;
using System.Linq;

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
            Console.WriteLine("TaskC:");
            Console.WriteLine("---------------------------------------");
            ServiceCar serviceChangeTyres = ChangeTyres;
            serviceChangeTyres(new Car());
            serviceChangeTyres(new Bus());

            ServiceBus serviceChangeTyres2 = ChangeTyres;
            serviceChangeTyres2(new Bus());

            ServiceBus serviceCleanUp = CleanUpInterier;
            serviceCleanUp(new Bus());
            Console.WriteLine("---------------------------------------");
        }

        static void ChangeTyres(Car car)
        {
            for(int i = 0;i<car.Tyres.Length;i++)
            {
                car.Tyres[i] = new Tyre("new " + car.Tyres[i]);
                Console.WriteLine("Changing " + (car.GetType() == typeof(Car) ? "Car" : "Bus") + " tyre to " + car.Tyres[i].Desc);
            }
        }

        static void CleanUpInterier(Bus bus)
        {
            for(int i = 0;i<bus.Seats.Length;i++)
            {
                bus.Seats[i].LastCleaned = DateTime.Now;
                Console.WriteLine("Cleaing seat " + bus.Seats[i].Desc);
            }
        }

        delegate void ServiceCar(Car car);
        delegate void ServiceBus(Bus bus);
    }

    public class Car
    {
        protected Tyre[] _tyres;
        public Tyre[] Tyres { get { return _tyres; } }

        public Car()
        {
            _tyres = TyreFactory.CreateTyres(4).ToArray();
        }
    }

    public class Bus : Car
    {
        protected Seat[] _seats;
        public Seat[] Seats { get { return _seats; } }

        public Bus()
        {
            _tyres = TyreFactory.CreateTyres(8).ToArray();
            _seats = SeatFactory.CreateSeats(64).ToArray();
        }
    }

    public class Tyre
    {
        public Tyre(string desc = "tyre")
        {
            Desc = desc;
        }
        public string Desc { get; set; }
    }

    public class Seat
    {
        public Seat(string desc = "seat")
        {
            Desc = desc;
            LastCleaned = DateTime.Now;
        }
        public string Desc { get; set; }
        public DateTime LastCleaned { get; set; }
    }

    public static class SeatFactory
    {
        public static IEnumerable<Seat> CreateSeats(int count)
        {
            for (int i = 1; i < count + 1; i++)
            {
                yield return new Seat("seat " + i);
            }
        }
    }

    public static class TyreFactory
    {
        public static IEnumerable<Tyre> CreateTyres(int count)
        {
            for (int i = 1; i < count + 1; i++)
            {
                yield return new Tyre("tyre " + i);
            }
        }
    }
}
