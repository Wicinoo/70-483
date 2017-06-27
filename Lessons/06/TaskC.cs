using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

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
        private Dictionary<string, object> properties;

        public MyDynamicSession()
        {
            properties = new Dictionary<string, object>();
        }

        private object GetPropertyByName(string name)
        {
            return properties.SingleOrDefault(x => x.Key.Equals(name)).Value;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = GetPropertyByName(binder.Name);
            return true;
        }

        private bool SetPropertyByName(string name, object value)
        {
            DeletePropertyByName(name);
            properties.Add(name, value);
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {

            return SetPropertyByName(binder.Name, value);
        }

        private bool DeletePropertyByName(string name)
        {
            return properties.Remove(name);
        }

        public override bool TryDeleteMember(DeleteMemberBinder binder)
        {
            return DeletePropertyByName(binder.Name);
        }
    }
}