using System;

namespace Lessons._04
{
    public class YouCantMeanThatException : Exception { }

    /// <summary>
    /// Create your own custom exception.
    /// Use it in a reasonable context and simulate throwing and catching.
    /// </summary>
    public class TaskD
    {
        

        public static void Run() {
            double a = 25;
            double b = 0;

            try {
                Divide(a, b);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public static double Divide(double a, double b) {
            if (b == 0){
                throw new YouCantMeanThatException();
            }
            return a/b;
        }
    }
}