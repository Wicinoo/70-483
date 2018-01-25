using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Anothers.Reflection
{
    public class GetMethod
    {
        public static void Run()
        {
            Console.WriteLine(new MyTestClass().doOperation1("AddNumb", 1, 2));
            Console.WriteLine(new MyTestClass().doOperation2("AddNumb", 1, 2));
            Console.WriteLine(new MyTestClass().doOperation3("AddNumb", 1, 2));
           
        }
    }

    public class MyTestClass
    {
        public int AddNumb(int numb1, int numb2)
        {
            return numb1 + numb2;
        }
        public int SubNumb(int numb1, int numb2)
        {
            return numb1 - numb2;
        }

        public string doOperation1(string operationName, int numb1, int numb2)
        {
            object[] mParam = new object[] { numb1, numb2 };
            MyTestClass myClassObject = new MyTestClass();
            Type myTypeObj = myClassObject.GetType();
            MethodInfo myMethodInfo =  myTypeObj.GetMethod(operationName);
            return myMethodInfo.Invoke(myClassObject, mParam).ToString();
        }
        public string doOperation2(string operationName, int numb1, int numb2)
        {
            object[] mParam = new object[] { numb1, numb2 };
            
            Type myTypeObj =this.GetType();
            MethodInfo myMethodInfo = myTypeObj.GetMethod(operationName);
            return myMethodInfo.Invoke(this, mParam).ToString();
        }

        public string doOperation3(string operationName, int numb1, int numb2)
        {
            object[] mParam = new object[] { numb1, numb2 };

            Type myTypeObj = typeof(MyTestClass);
            MethodInfo myMethodInfo = myTypeObj.GetMethod(operationName);
            return myMethodInfo.Invoke(this, mParam).ToString();
        }
    }

}
