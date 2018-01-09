using System;

namespace Lessons._4._5_Store_data
{
    public class Arrays
    {
        public static void Run()
        {

            //https://msdn.microsoft.com/en-us/library/system.array(v=vs.110).aspx
            SingleDimensionArray();

            MultidimensionalArray();

            JaggedArray();

            ArrayBehaviours();
        }

        private static void ArrayBehaviours()
        {
            var array = new string[] { "jedna", "dve" };
            var anotherArr = new string[] { "jedna", "dve" };

            Console.WriteLine(array == anotherArr);
            Console.WriteLine(array.Equals(anotherArr));
            Console.WriteLine(array.GetType().IsArray);
            Console.WriteLine(array.GetType().GetElementType());


            // - array is reference type
            var secArray = array;
            Console.WriteLine(array == secArray);


            object[] copiedArray = new object[array.Length];
            array.CopyTo(copiedArray, 0);  //method CopyTo uses automatically casting, so we can copy int to object

            Console.WriteLine(array.Equals(copiedArray));
            Print(array);
            Print(copiedArray);


            //uses copyTo deep copy?
            TestClass[] testArray = new TestClass[] { new TestClass() };
            TestClass[] anotherArry = new TestClass[copiedArray.Length];

            testArray.CopyTo(anotherArry, 0);
            Console.WriteLine(testArray[0].Equals(anotherArry[0]));   //no, it uses shallow copy
            Console.WriteLine(testArray[0] == anotherArry[0]);
        }

        private static void JaggedArray()
        {
            int[][] jagged = new int[][] {
                new int[] { 1,2,3,4 },
                new int[] { 4,5,6,7,8}
            };
        }

        private static void MultidimensionalArray()
        {
            int[,] multiArray = { { 0, 1 }, { 1, 1 } };
            string[,] anotherMultiArray = new string[2, 2] { { "one", "two" }, { "three", "four" } };
            Console.WriteLine(anotherMultiArray[1, 1]);
        }

        private static void SingleDimensionArray()
        {
            int[] myArray = new int[10];
            for (int i = 0; i < 10; i++)  //zero based index
            {
                myArray[i] = i;
            }

            foreach (var item in myArray)
            {
                Console.Write(item);
            }

            //declaration with inicialization example
            int[] anotherArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        }

        private static void Print(object[] array)
        {
            foreach(var item in array)
            {
                Console.WriteLine(item.ToString());

            }
        }
       
    }
    public class TestClass
    {
        public TestClass()
        {
            Console.WriteLine("constructor was called");            
        }

    }
}
