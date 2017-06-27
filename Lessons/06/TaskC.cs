using System;

namespace Lessons._06
{
    using System.Collections.Generic;
    using System.Dynamic;

    /// <summary>
    /// Implement MyDynamicSession class by using DynamicObject as a base class. 
    /// Check the output in Run() method.
    /// </summary>
    public class TaskC
    {
        public static void Run()
        {

            dynamic myDynamicSession = new MyDynamicSession();

            myDynamicSession.Key1 = "valueForKey1";
            Console.WriteLine(myDynamicSession.Key1);   // valueForKey1

            myDynamicSession.Key2 = DateTime.Now;
            Console.WriteLine(myDynamicSession.Key2);   // <Today date and time>

            Console.WriteLine(myDynamicSession.NonexistingKey ?? "null");   // null
        }

        public class MyDynamicSession : DynamicObject
        {
            private Dictionary<string, object> innerValues;

            public MyDynamicSession()
            {
                innerValues = new Dictionary<string, object>();
            } 

            public override bool TryGetMember(GetMemberBinder binder,
                                              out object result)
            {
                bool keyExists = innerValues.ContainsKey(binder.Name);
                result = keyExists ? innerValues[binder.Name] : null;
                return keyExists;
            }

            public override bool TrySetMember(SetMemberBinder binder,
                                              object value)
            {
                innerValues[binder.Name] = value;
                return true;
            }
        }
    }
}