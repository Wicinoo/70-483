using System;
using System.Collections;

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
                var me = new Person();
                me.DateOfBirth = new DateTime(2020, 1, 1);
            }
            catch (DateIsInTheFuture exception)
            {
                foreach (DictionaryEntry dataItem in exception.Data)
                {
                    Console.WriteLine("{0} is in the future", dataItem.Value);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

    public class Person
    {
        private DateTime _dateOfBirth;

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                if (value < DateTime.Now)
                { _dateOfBirth = value; }
                else { throw new DateIsInTheFuture("BirthDate"); }
            }
        }

    }

    public class DateIsInTheFuture : Exception
    {
        public DateIsInTheFuture(string DateType)
        {
            this.Data.Add("DateType", DateType);
        }
    }
}