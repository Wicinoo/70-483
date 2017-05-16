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
            var car = new Car("Car");
            var bus = new Bus("Bus");

            ServiceCar changingTyresOfServiceCar = ChangeTyres;

            changingTyresOfServiceCar(car);
            changingTyresOfServiceCar(bus);

            ServiceBus changingTyresOfServiceBus = ChangeTyres;

            // changingTyresOfServiceBus(car); // delegate expects method parameter to be of more derived type

            // delegate Contravariance example: 
            // delegate is expecting a more derived type and method is expecting a less derived type for parameter.
            // the method will accept a more derived type.
            changingTyresOfServiceBus(bus); 
            
            ServiceBus cleaningInteriorOfServiceBus = CleanInterior;
            cleaningInteriorOfServiceBus(bus);
            // cleaningInteriorOfServiceBus(car); // method parameter expects more derived type

            // ServiceCar cleaningInteriorOfServiceCar = CleanInterior; 
            // throws compiler error, parameter type of function passed to delegate is of a more derived class
        }

        public static void ChangeTyres(Car car)
        {
            Console.WriteLine($"Changing tyres of { car.Name }");
        }

        public static void CleanInterior(Bus bus)
        {
            Console.WriteLine($"Cleaning interior of { bus.Name }");
        }

        public class Car
        {
            public string Name { get; set; }

            public Car(string name)
            {
                Name = name;
            }
        }

        public class Bus : Car
        {
            public Bus(string name) : base(name) { }
        }
    }
}