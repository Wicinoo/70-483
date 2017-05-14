using System;
using System.Runtime.InteropServices;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    public class TaskD
    {
        private delegate void AskQuestion(Person person);

        public static void Run()
        {
            var person = new Person();
            var student = new Student();

            AskQuestion askName = p => p.Introduce();

            askName.Invoke(person);
            askName.Invoke(student);
        }

        private class Person
        {
            public virtual void Introduce()
            {
                Console.WriteLine("Jane Doe");
            }
        }

        private class Student : Person
        {
            public override void Introduce()
            {
                Console.WriteLine("Bc. Jane Doe");
            }
        }
    }
}