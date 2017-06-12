using System;
using Lessons._03;
using Rhino.Mocks.Constraints;

namespace Lessons._04
{
    /// <summary>
    /// Write a method to print a structured listing of all properties of an exception. 
    /// Keep format [property_name]: [value]\n.
    /// Let your code throw an exception, handle it and use the method for printing.
    /// Simulate a situation with valid InnerException.
    /// Simulate a situation with non-empty Data dictionary.
    /// </summary>
    public class TaskA
    {
        private IUI _ui;

        public TaskA()
        {
            _ui = new UI();
        }
        public void Run()
        {
            try
            {
                throw new ArgumentException("test");
            }
            catch (Exception ex)
            {
                PrintExceptionDetails(ex);
            }
        }

        private void PrintExceptionDetails(Exception exception)
        {
            var properties = exception.GetType().GetProperties();
            foreach (var propertyInfo in properties)
            {
                _ui.Print($"{propertyInfo.Name}:{propertyInfo.GetValue(exception)}");

            }
            //_ui.Print($"{nameof(exception.HResult)}:{exception.HResult}");

            //_ui.Print($"{nameof(exception.Data)}:{exception.Data}");
            //_ui.Print($"{nameof(exception.HResult)}:{exception.HResult}");
            //_ui.Print($"{nameof(exception.HResult)}:{exception.HResult}");
            //throw new NotImplementedException();
        }
    }

    public class UI : IUI
    {
        public void Print(string value)
        {
            Console.WriteLine(value);
        }
    }

    public interface IUI
    {
        void Print(string value);
    }
}

