using System;
using System.Dynamic;
using System.Linq;
using System.Collections.Generic;
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

	public class MyDynamicSession :DynamicObject {

		private Dictionary<string, object> dict = new Dictionary<string, object>();

		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			if (dict.ContainsKey(binder.Name))
			{
				dict.TryGetValue(binder.Name, out result);
			}
			else
			{
				result = null;
			}

			return true;
		}

		public override bool TrySetMember(SetMemberBinder binder, object value)
		{
			dict[binder.Name] = value;
			return true;
		}
	}
	
}