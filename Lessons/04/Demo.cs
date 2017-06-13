using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using Xunit;

namespace Lessons._04
{
    public class Demo
    {
        private static IExchangeRateProvider _exchangeRateProvider = new ExchangeRateProvider();

        // #1 Throwing exceptions

        // Writing robust code, checks for nulls and invalid arguments, garbage-in-garbage-out

        public IEnumerable<string> GetPeopleInDepartment(string departmentId, string namesSubstring)
        {
            return GetPeopleInDepartment(departmentId)
                .Where(personName => personName.Contains(namesSubstring))
                .ToList();
        }

        private IEnumerable<string> GetPeopleInDepartment(string departmentId)
        {
            throw new NotImplementedException();
        }

        // Good practice: Throw the most specific exception. ArgumentException() <=> ArgumentNullException

        public void DoSomethingCheckArguments(string input)
        {
            // Is this correct?
            if (input == null) throw new ArgumentException("Input has to be a valid string.");
        }

        // Documenting expected exception for public members

        /// <summary>
        /// Provides exchange rates for currencies.
        /// </summary>
        public interface IExchangeRateProvider
        {
            /// <summary>
            /// It returns current exchange rate between currencies.
            /// </summary>
            /// <param name="currencyFromIso4217">Source currency code according to ISO 4217, see https://en.wikipedia.org/wiki/ISO_4217.</param>
            /// <param name="currencyToIso4217">Target currency code according to ISO 4217, see https://en.wikipedia.org/wiki/ISO_4217.</param>
            /// <returns>Current rate with a precision of 6.</returns>
            decimal GetRate(string currencyFromIso4217, string currencyToIso4217);
        }

        // Smell: Don't throw generic exception.

        public void DoSomethingThrowGenericException()
        {
            throw new Exception("Problem during communication with the server.");
        }

        // Smell: Controling throwing exception from outside a method.

        public void DoSomething(bool canIThrowException)
        {
            var isError = true;

            if (isError && canIThrowException)
            {
                // Throw exception
            }
        }

        // Smell: Returning an exception as a return value.

        public Exception DoSomethingAndReturnException()
        {
            var isError = false;

            return isError ? new InvalidOperationException() : null;
        }

        // Understanding addressees of exceptions - developer, system administrator, user

        private class ExchangeRateProvider : IExchangeRateProvider
        {
            public decimal GetRate(string currencyFromIso4217, string currencyToIso4217)
            {
                throw new NotImplementedException();
            }
        }

        // Rules for exception messages

        // "Your message has not been delivered!"
        // "Hey man, it doesn't work."
        // "Problem with connecting to the database. Connection string = Source=dbblabla;User=user;Password=1234"
        // "Wrong configuration of your application."
        // "Order has not been created: Duplicate primary key in table xyz."

        // #2 Custom exceptions

        // When and how create a custom exception.

        public class MyException : Exception
        {
            public MyException(string message) : base(message)
            {
            }

            public MyException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected MyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }

        // Smell: Using custom exceptions for cases that should be covered by standard exception.

        public void DoSomethingThrowCustomExceptionForInvalidArgument(Foo foo)
        {
            if (foo == null || string.IsNullOrEmpty(foo.MandatoryProperty))
            {
                throw new MyException("Invalid arguments");
            }

            // Do something
        }

        public class Foo
        {
            public string MandatoryProperty { get; set; }
        }

        // When throw these exceptions?
        
        // ArithmeticException
        // ArrayTypeMismatchException
        // DivideByZeroException
        // IndexOutOfRangeException
        // InvalidCastException
        // NullReferenceException
        // OutOfMemoryException
        // OverflowException
        // StackOverflowException
        // TypeInitializationException

        // ArgumentException
        // ArgumentNullException
        // ArgumentOutOfRangeException

        // NotImplementedException


        // Smell: Creating a custom exception for your team.

        // Good vs. Bad names of custom exceptions.

        // TaskException
        // FileNotFoundException
        // BusinessException

        // #3 Catching exceptions

        // Smell: Catching generic Exception. 

        public void DoSomethingCatchGenericException()
        {
            try
            {
                // Do something
                _exchangeRateProvider.GetRate("USD", "XXL");
            }
            catch (Exception exception)
            {
                // Handle generic exception
            }
        }

        // Good practice: Catch Exception Where You Can React Meaningful

        public void ProcessExchange()
        {
            var targetCurrency = "USD"; // GetTargetCurrency()
            var amountInGbp = 1234; // GetAmountInGbp()

            var rate = _exchangeRateProvider.GetRate("GBP", targetCurrency);

            var amountInTargetCurrency = amountInGbp * rate;
            // ProcessAmountInTargetCurrency(amountInTargetCurrency)
        }

        // Smell: Using Exceptions For Control Flow.

        public void DoSomethingForAllItems(int[] numbers)
        {
            try
            {
                for (int i = 0; /* no test for termination */; i++)
                {
                    var number = numbers[i];
                    // Do something for number
                }
            }
            catch (IndexOutOfRangeException exception)
            {
                // All numbers have been processed.
            }
        }

        // Smell: Swallowing exceptions

        public void DoSomethingSwallowException()
        {
            try
            {
                // Do something
            }
            catch
            {
                // Do nothing
            }
        }
        // Smell: Throwing an exception in finally block

        public void DoSomethingAndThrowExceptionInFinallyBlock()
        {
            Exception exception = null;

            try
            {
                // Do something
            }
            catch (InvalidOperationException e)
            {
                exception = e;
            }
            finally
            {
                // Close or release resources

                if (exception != null) throw exception;
            }
        }

        // Good practice: Prefer try-finally to try-catch for clean-up code.

        public void DoSomethingCleanUpInCatch()
        {
            try
            {
                // Do something that can throw an exception

                // Clean up
            }
            catch (Exception exception)
            {
                // Clean up

                throw;
            }
        }


        // Smell: Using throw exception; to rethrow the exception in the catch block.

        public void DoSomethingRethrowingException()
        {
            try
            {
                // Do something
            }
            catch (Exception exception)
            {
                // What is better
                throw exception;
                throw;
            }
        }

        // Wrapping exceptions, mapping exceptions from lower layer to an exception from higher layer.
        // Setting InnerException property.

        public void DoSomethingWrapSpecificExceptions()
        {
            try
            {
                // Do something 
            }
            catch (NetworkInformationException exception)
            {
                throw new MyException("There are problems with retrieving network information: " + exception.Message,
                    exception);
            }
            catch (InvalidOperationException exception)
            {
                throw new MyException("Requested operation is not possible: " + exception.Message, exception);
            }
        }

        // Handle an unhandled exception on global level

        public void HandleUnhandledExcpetion()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                var exception = args.ExceptionObject as Exception;
                Console.WriteLine("Unhandled exception: {0}", exception);
            };
        }

        // How to handle exceptions on threads?

        // #4 Unit testing exceptions

        [Fact]
        private void GetRate_ForInvalidCurrencyCode_ShouldThrowArgumentOutOfRangeException()
        {
            var exchangeRateProvider = new ExchangeRateProvider();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                exchangeRateProvider.GetRate("USD", "RRR");
            });
        }
    }
}