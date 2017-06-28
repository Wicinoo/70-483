using System;
using System.Collections.Generic;
using System.Dynamic;
using Lessons._03;

namespace Lessons._06
{
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
    }

    public class MyDynamicSession : DynamicObject
    {
        private IDictionary<string, object> _data = new Dictionary<string, object>();  

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = _data.ContainsKey(binder.Name) ? _data[binder.Name] : null;

            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _data.Add(binder.Name, value);
            return true;
        }
    }
}