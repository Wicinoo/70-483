using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._4._5_Store_data
{
    public class Lists
    {
        public static void Run()
        {
            var class1 = new TestClassa();
            var class2 = new TestClassa();
            IList<TestClassa> list = new List<TestClassa>() { class1, class2 };

            var index = list.IndexOf(class2);
            list.Remove(class1);


            IDictionary<int, TestClassa> dictionary = new Dictionary<int, TestClassa>() { { 2, new TestClassa() } };

        }
        
    }
    public class TestClassa
    {
    }
}
