using System;
using System.ComponentModel;

namespace Lessons._04
{
    public class MyAwesomeException : Exception { };

    public class TotallyUsefullHandlingRequirer : Exception { };

    public class AndOneMoreException : Exception { };
    /// <summary>
    /// Write a code that demonstrates differences between 
    /// "throw;" and "throw exception;" in catch block.
    /// </summary>
    public class TaskC
    {
        public static void Run() {
            try {
                TotallySafePieceOfCode();
            } catch(Exception ex) {
                PrintExceptionDetails(ex);
            }

            try {
                EvenSaferPieceOfCodeWithSomeAdditionalExceptionStuffRightHere();
            } catch (Exception ex) {
                PrintExceptionDetails(ex);
            }
        }

        public static void TotallySafePieceOfCode()
        {
            try {
                throw new MyAwesomeException();
            } catch (Exception ex) {
                throw; //Oh, I am so redundant
            }
        }

        public static void EvenSaferPieceOfCodeWithSomeAdditionalExceptionStuffRightHere() {
            try {
                throw new AndOneMoreException();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private static void PrintExceptionDetails(Exception exception) {
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(exception)) {
                Console.WriteLine("{0}: {1}", descriptor.Name, descriptor.GetValue(exception));
            }
        }
    }
}