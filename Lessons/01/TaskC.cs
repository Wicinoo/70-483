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
        static void ChangeTyres(Car car)
        {
        }

        static void CleanUpInterier(Bus bus)
        {
        }


        public static void Run()
        {
            ServiceCar carDelegate = ChangeTyres;
            ServiceBus busDelegate = CleanUpInterier;
            ServiceBus busDalegateCarMethod = ChangeTyres;
        }
    }

    internal delegate void ServiceCar(Car car);

    internal delegate void ServiceBus(Bus bus);
}