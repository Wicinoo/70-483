using System;

namespace Lessons._01
{
    using System.Collections.Generic;

    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    /// 
    public class TaskD
    {
        private delegate IEnumerable<string> GetList(); 

        public static void Run()
        {
            GetList getList = GetBuildingsList;
            var list = getList();
            Console.WriteLine("list is of type {0}", list.GetType().Name);
            Console.WriteLine(String.Join(",",list));
        }

        private static List<string> GetBuildingsList()
        {
            var list = new string[] { "Skyscraper", "Cottage", "House", "Pit" };
            return new List<string>(list);
        }
    }
}