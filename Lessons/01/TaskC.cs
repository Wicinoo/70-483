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
    public class TaskC {
        private static delegate void ServiceCar(Car car);
        private static delegate void ServiceBus(Bus bus);

        public static void Run() {
            Bus bus = new Bus();
            Car car = new Car();
            
            ServiceCar changeTyres = ChangeTyres;
            changeTyres(car);
            changeTyres(bus); //Because a bus is technically a car

            ServiceBus cleanBusInterier = CleanBusInterier;
            cleanBusInterier(bus);
        }

        private static void ChangeTyres(Car car) {
            Console.WriteLine("The tires of the car has been changed.");
        }

        private static void CleanBusInterier(Bus bus) {
            Console.WriteLine("The interier of the bus has been cleant.");
        }
    }

    public class Car { 
    };

    public class Bus : Car { 
    };
}