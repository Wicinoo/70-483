using System;

namespace Lessons._4._5_Store_data
{
    public class Arrays
    {
        public static void Run()
        {

            //https://msdn.microsoft.com/en-us/library/system.array(v=vs.110).aspx
            //http://referencesource.microsoft.com/#mscorlib/system/array.cs,156e066ecc4ccedf
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
            TestClass[] testArray = new TestClass[] { new TestClass(0) };
            TestClass[] anotherArry = new TestClass[copiedArray.Length];

            testArray.CopyTo(anotherArry, 0);
            Console.WriteLine(testArray[0].Equals(anotherArry[0]));   //no, it uses shallow copy
            Console.WriteLine(testArray[0] == anotherArry[0]);

            //what returns GetLowerBound and GetUpperBound if items are not initialized?
            Console.WriteLine(anotherArry.GetLowerBound(0));
            TestClass[] testB = new TestClass[testArray.Length+2];      
            Array.Copy(testArray, 0, testB, 1, testArray.Length);       //creates null, instance, null


            Console.WriteLine(testB.GetLowerBound(0));     //return 0 - zero base index
            Console.WriteLine(testB.GetUpperBound(0));     //return 2 - maximum of array - even is last item is null


            Array arrayA = Array.CreateInstance(typeof(TestClass), 10);
            Array arrayC = new TestClass[10];
            Console.WriteLine(arrayA.GetType().IsArray);   //is type of this object array?  
            Console.WriteLine(arrayA.GetType().GetElementType());
            Console.WriteLine(arrayC.GetType().IsArray);

            //https://msdn.microsoft.com/en-us/library/system.array(v=vs.110).aspx
            //Type objects provide information about array type declarations. Array objects with the same array type share the same Type object.
            //Type.IsArray and Type.GetElementType might not return the expected results with Array because if an array is cast to the type Array,
            //the result is an object, not an array. That is, typeof(System.Array).IsArray returns false, and typeof(System.Array).GetElementType returns null.

            
            TestClass[,] arrayB = new TestClass[5,7];
            Console.WriteLine("Range of dimension:{0}, by Rank property)", arrayB.Rank);
            Console.WriteLine("Number of all elements thrue all dimensions:{0} by Length property", arrayB.Length);

            //how to create instance for all item without loop for multidimensional array?
            
            

            //Array.Sort(arrayA);
            //Array.Reverse

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

        private int _id;
        public TestClass(int i)
        {
            Console.WriteLine("constructor was called");
            _id = i;
        }

        public int ID {
            get { return _id; }
        }
    }
}
