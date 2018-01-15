using System.Collections.Generic;

namespace Lessons._4._5_Store_data
{
    public class Lists
    {
        public static void Run()
        {
            var class1 = new TestClassa(1);
            var class2 = new TestClassa(2);
            IList<TestClassa> list = new List<TestClassa>() { class1, class2 };

            var index = list.IndexOf(class2);
            list.Remove(class1);


            IDictionary<int, TestClassa> dictionary = new Dictionary<int, TestClassa>() { { 2, new TestClassa(1) } };


        }
    }
    public class TestClassa
    {
        public TestClassa(int id)
        {
            Id = id;
        }

        public int Id { get; }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
