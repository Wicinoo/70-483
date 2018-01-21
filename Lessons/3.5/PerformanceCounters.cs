using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._3._5
{
    public class PerformanceCounters
    {
        private const string CategoryName = "MySpecialCategory";
        private const string CounterNameOperationsExecuted = "# operation executed";
        private const string CounterNameOperationsSec = "# operations / sec";

        public static void Run()
        {
            ShowAvaliableCategories();

            MemoryAvailableBytes();

            if (CreatePerformanceCounters())
            {
                Console.WriteLine("Specific performance counters was created");
                Console.WriteLine("You can see it in Perfmon.exe. Category name = " + CategoryName);
                Console.WriteLine("Please restart your application");
                return;
            }
            var totalOperationCounter = new PerformanceCounter(CategoryName, CounterNameOperationsExecuted, false);
            var operationsPerSecondCounter = new PerformanceCounter(CategoryName, CounterNameOperationsSec, false);
            totalOperationCounter.Increment();
            operationsPerSecondCounter.Increment();

        }

        private static bool CreatePerformanceCounters()
        {
            if (!PerformanceCounterCategory.Exists(CategoryName))
            {
                CounterCreationDataCollection counters = new CounterCreationDataCollection()
                {
                    new CounterCreationData(CounterNameOperationsExecuted, "Total number of operations executed", PerformanceCounterType.NumberOfItems32),
                    new CounterCreationData(CounterNameOperationsSec,"Number of operations executed per second", PerformanceCounterType.RateOfCountsPerSecond32)
                };
                PerformanceCounterCategory.Create(CategoryName, "Sample category for Codeproject", PerformanceCounterCategoryType.Unknown, counters);
                return true;
            };
            return false;
        }

        private static void MemoryAvailableBytes()
        {
            using (System.Diagnostics.PerformanceCounter counter = new System.Diagnostics.PerformanceCounter("Memory", "Available Bytes"))
            {
                Console.WriteLine(counter.RawValue);
            }
            var neco = new PerformanceCounter();
        }

        private static void ShowAvaliableCategories()
        {
            var categories = System.Diagnostics.PerformanceCounterCategory.GetCategories();
            foreach (var item in categories)
            {
                Console.WriteLine("CategoryName: " + item.CategoryName);
                Console.WriteLine("CategoryType: " + item.CategoryType);
                var instances = item.GetInstanceNames();
                foreach (var instance in instances)
                {
                    try
                    {
                        PerformanceCounter[] counters = item.GetCounters(instance);
                        foreach (var counter in counters)
                        {

                            Console.WriteLine($"Instance: {instance}, counterType: {counter.CounterType}");


                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("EXCEPTION!!!!");
                    }
                }


                Console.WriteLine("MachineName:  " + item.MachineName);
                Console.WriteLine("CategoryHelp: " + item.CategoryHelp);
                Console.WriteLine();
            }
        }
    }
}
