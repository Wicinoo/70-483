using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._04
{
    public class ExceptionPrinter
    {
        public static void PrintExceptionDetails(Exception exception)
        {
            var ui = new UI();
            var properties = exception.GetType().GetProperties();
            ui.Print("=> Properties:");
            foreach (var propertyInfo in properties)
            {
                ui.Print($"{propertyInfo.Name}:{propertyInfo.GetValue(exception)}");
            }

            ui.Print("=> data:");
            if (exception.Data.Count > 0)
            {
                foreach (DictionaryEntry dictionaryEntry in exception.Data)
                {
                    ui.Print($"Data {dictionaryEntry.Key}:{dictionaryEntry.Value} ");
                }
            }

            ui.Print("=> Inner exception:");

            if (exception.InnerException != null)
            {
                PrintExceptionDetails(exception.InnerException);
            }
        }
    }
}
