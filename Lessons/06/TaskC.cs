using System;
using System.Collections.Generic;
using System.Dynamic;
using Rhino.Mocks.Constraints;

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

        public class MyDynamicSession : DynamicObject
        {
            private Dictionary<string, System.Type> _propertiesDictionary = new Dictionary<string, System.Type>()
            {
                {"key1",typeof(string)},
                {"key2",typeof(DateTime)}
            };
            
            private Dictionary<string, object> _values = new Dictionary<string, object>(); 

            public override bool TrySetMember(SetMemberBinder binder, object value)
            {
                System.Type type;
                if (_propertiesDictionary.TryGetValue(binder.Name.ToLower(), out type))
                {
                    if (value.GetType() == type)
                    {
                        if (_values.ContainsKey(binder.Name.ToLower()))
                        {
                            _values[binder.Name.ToLower()] = value;
                        }
                        else
                        {
                            _values.Add(binder.Name.ToLower(), value);
                        }
                        return true;
                    }
                }
                return false;
            }

            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                System.Type type;
                if (_propertiesDictionary.TryGetValue(binder.Name.ToLower(), out type))
                {
                    return _values.TryGetValue(binder.Name.ToLower(), out result);

                }
                result = null;
                return true;
            }
        }
    }
}