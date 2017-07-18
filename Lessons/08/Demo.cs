using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using FluentAssertions.Common;

namespace Lessons._08
{
    public class Demo
    {
        // Attributes

        [Customer(CustomerType.Microsoft)]
        class FooForMicrosoft : ICustomerFoo
        {
            public string Exclamation
            {
                get { return "We love Microsoft!"; }
            }
        }

        [Customer(CustomerType.Google)]
        class FooForGoogle : ICustomerFoo
        {
            [class: Customer(CustomerType.IBM)]
            public string Exclamation
            {
                get { return "Google is the best at searching!"; }
            }
        }

        interface ICustomerFoo
        {
            string Exclamation { get; }
        }

        // Using attributes to decorate enums

        enum CustomerType
        {
            [GoldPartner]
            Microsoft,
            [GoldPartner]
            Google,
            IBM
        }

        [AttributeUsage(AttributeTargets.Field)]
        sealed class GoldPartnerAttribute : Attribute
        {
        }

        // Reflection scopes:
        // * Type: typeof(), instance.GetType()
        // * Assembly: Assembly.GetExecutingAssembly().GetTypes() ...

        // To understand why sealed: 
        // https://stackoverflow.com/questions/7868218/why-is-net-best-practice-to-design-custom-attributes-as-sealed

        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
        sealed class CustomerAttribute : Attribute
        {
            public CustomerType Type { get; private set; }

            public CustomerAttribute(CustomerType type)
            {
                Type = type;
            }
        }

        // CodeDom - generators for C#, VB, C++, J#, JScript

        // Lambda expressions - dynamically created anonymous functions

        public static void Run()
        {
            var configuredCustomer = CustomerType.Google;

            // 1. Get ICustomerFoo implementation for configuredCustomer 

            var customerFooType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .First(type => 
                    type.Implements(typeof(ICustomerFoo)) && 
                    HasCustomerAttribute(type, configuredCustomer));

            // 2. Create an instance of the implementation

            ICustomerFoo customerFoo = Activator.CreateInstance(customerFooType) as ICustomerFoo;

            // 3. Ask for Exclamation.

            Console.WriteLine(customerFoo.Exclamation);

            // Another way to read an attribute
            var customerAttribute = Attribute.GetCustomAttribute(typeof(FooForGoogle), typeof(CustomerAttribute)) as CustomerAttribute;
            
            // List all gold partners

            var goldPartners =
                typeof(CustomerType)
                    .GetFields()
                    .Where(field => field.HasAttribute<GoldPartnerAttribute>())
                    //.Where(field => Attribute.IsDefined(field, typeof(GoldPartnerAttribute)))
                    .Select(field => field.GetValue(null))
                    //.Select(field => Enum.Parse(typeof(CustomerType), field.Name));
                    .Cast<CustomerType>();
            
            Console.WriteLine(string.Join(",", goldPartners));

            // Read a private field

            var foo = new FooWithPrivateField();
            var privateFieldInfo = foo
                .GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance) // Instance x Static
                .First();

            Console.WriteLine(privateFieldInfo.GetValue(foo));

            // Lambda expression - Console.WriteLine(DateTime.Now)

            var expression = Expression.Call(
                null,
                typeof(Console).GetMethod("WriteLine", new Type[] {typeof(object)}),
                Expression.Convert(
                    Expression.Property(null, typeof(DateTime).GetProperty("Now")), 
                    typeof(object))
                );

            var compiledExpression = Expression.Lambda<Action>(expression).Compile();
            compiledExpression();
            Thread.Sleep(1000);
            compiledExpression();
        }

        class FooWithPrivateField
        {
            private Guid _secretValue = Guid.NewGuid();
        }

        private static bool HasCustomerAttribute(Type type, CustomerType customerType)
        {
            var customerAttribute = type.GetCustomAttribute<CustomerAttribute>();
            var hasCustomerAttribute = customerAttribute != null && customerAttribute.Type == customerType;
            return hasCustomerAttribute;
        }
    }

    
}
