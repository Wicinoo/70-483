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
        delegate void ServiceCar(Car car);
        delegate void ServiceBus(Bus bus);

        public static void Run()
        {
            var car1 = new Car { TyresType = TyresType.Summer };
            var bus1 = new Bus
            {
                TyresType = TyresType.Summer,
                InterierStatus = InterierStatus.Messy
            };


            PrintStatus(car1, bus1);

            ServiceCar changeTyresDel = ChangeTyres;
            ChangeTyres(car1);
            ChangeTyres(bus1);

            PrintStatus(car1, bus1);

            ServiceBus cleanDel = CleanInterier;
            cleanDel(bus1);

            PrintStatus(car1, bus1);

            ServiceBus changeTyresOnBusDel = ChangeTyres;
            changeTyresOnBusDel(bus1);

            PrintStatus(car1, bus1);
        }

        public static void ChangeTyres(Car car)
        {
            car.TyresType = car.TyresType == TyresType.Summer ? TyresType.Winter : TyresType.Summer;
        }

        public static void CleanInterier(Bus bus)
        {
            if (bus.InterierStatus == InterierStatus.Messy)
            {
                bus.InterierStatus = InterierStatus.Clean;
            }
        }

        private static void PrintStatus(Car car, Bus bus)
        {
            System.Console.WriteLine("==================================");
            System.Console.WriteLine($"Car1 Tyres: {car.TyresType}");
            System.Console.WriteLine($"Bus1 Tyres: {bus.TyresType}");
            System.Console.WriteLine($"Bus1 Interier: {bus.InterierStatus}");
        }
    }

    public class Car
    {
        public TyresType TyresType { get; set; }
    }

    public class Bus : Car
    {
        public InterierStatus InterierStatus { get; set; }
    }

    public enum TyresType
    {
        Summer,
        Winter
    }

    public enum InterierStatus
    {
        Messy,
        Clean
    }
}