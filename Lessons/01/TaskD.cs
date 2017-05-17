using System;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    public class TaskD
    {
        delegate Employee GetPersonToPaySalary();

        delegate Dev GetDeveloperToPaySalary();

        delegate Analyst GetAnalystToPaySalary();

        public static void Run()
        {
            GetPersonToPaySalary employee = GetEmployee;

            GetDeveloperToPaySalary developer = GetDeveloper;

            GetAnalystToPaySalary analyst = GetAnalyst;

            var employees = new[]
            {
                employee(), developer(), developer(), analyst(), employee()
            };

            foreach (var empl in employees)
            {
                Console.WriteLine($"We need to pay salary to: {empl.GetType().Name}");
            }
        }

        private static Employee GetEmployee()
        {
            Console.WriteLine("Getting employee to pay salary.");
            return new Employee();
        }

        private static Dev GetDeveloper()
        {
            Console.WriteLine("Getting developer to pay salary.");
            return new Dev();
        }

        private static Analyst GetAnalyst()
        {
            Console.WriteLine("Getting analyst to pay salary.");
            return new Analyst();
        }
    }

    class Employee { }
    
    class Dev : Employee { }

    class Analyst : Employee { }
}