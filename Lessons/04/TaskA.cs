using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
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
            _ui.Print("------ Standard exception----------------------------");
            try
            {
                throw new ArgumentException("test");
            }
            catch (Exception ex)
            {
                PrintExceptionDetails(ex);
            }

            _ui.Print("------ Inner exception -------------------------------");

            var task = Task.Run(() =>
            {
                throw  new ArgumentNullException("Argument is empty");
            });

            try
            {
                task.Wait();
            }
            catch (Exception ex)
            {
                PrintExceptionDetails(ex);
            }
            _ui.Print("------- Data --------------------------------");

            try
            {
                var exeption = new ArgumentNullException(); 
                exeption.Data.Add("Important", "This is important information");
                throw exeption;
            }
            catch (Exception ex)
            {
                PrintExceptionDetails(ex);
            }

        }

        private void PrintExceptionDetails(Exception exception)
        {
            var properties = exception.GetType().GetProperties();
            _ui.Print("=> Properties:");
            foreach (var propertyInfo in properties)
            {
                _ui.Print($"{propertyInfo.Name}:{propertyInfo.GetValue(exception)}");
            }

            _ui.Print("=> data:");
            if (exception.Data.Count > 0)
            {
                foreach (DictionaryEntry dictionaryEntry in exception.Data)
                {
                    _ui.Print($"Data {dictionaryEntry.Key}:{dictionaryEntry.Value} ");
                }
            }

            _ui.Print("=> Inner exception:");

            if (exception.InnerException != null)
            {
                PrintExceptionDetails(exception.InnerException);
            }
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

