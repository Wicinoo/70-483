using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._4._5_Store_data
{
    public class HashSets
    {
        public static void Run()
        {

            ISet<int> set = new HashSet<int>() { 1, 2 };
            ISet<int> set2 = new HashSet<int>() { 2, 3 };

            Print(set.Intersect(set2), "Interselect {1,2} and {2,3}");
            Print(set.Union(set2), "Union   {1,2} and {2,3}");
            set.UnionWith(set2);
            Print(set, "UnionWith {1,2} and {2,3}");

            set.UnionWith(new HashSet<int>() { 4 });
            Print(set, "UnionWith {1,2,3} and {4}");

            Console.WriteLine(string.Format("IsProperSubSetOf {{1,2,3,4}} and {{2,3}} = {0}", set.IsProperSubsetOf(set2)));
            Console.WriteLine(string.Format("IsProperSubSetOf {{1,2}} and {{1,2}} = {0}", new HashSet<int>() { 1 }.IsProperSubsetOf(new HashSet<int>() { 1 }))); //???            

        }
        private static void Print(IEnumerable<int> resutl, string message)
        {
            Console.WriteLine(message);
            resutl.ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
