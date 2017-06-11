using System;

namespace Lessons._04
{
    /// <summary>
    /// Create your own custom exception.
    /// Use it in a reasonable context and simulate throwing and catching.
    /// </summary>
    public class TaskD
    {
        public static void Run()
        {
            try
            {
                var customer = LoadCustomer(15);
                Console.WriteLine(customer);
            }
            catch (NonExistingCustomerException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Load Customer from database
        /// </summary>
        /// <param name="id">Unique id number</param>
        /// <returns>Customer object with all customer's details</returns>
        /// <exception cref="NonExistingCustomer">When Customer's id is not found</exception>
        public static Customer LoadCustomer(int id)
        {
            throw new NonExistingCustomerException($"Customer with id {id} wasn't found");
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }

    public class NonExistingCustomerException : Exception
    {
        public NonExistingCustomerException()
        {
            
        }

        public NonExistingCustomerException(string message) : base(message)
        {
            
        }

        public NonExistingCustomerException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}