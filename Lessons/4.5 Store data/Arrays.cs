using System;
using System.Linq;

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
            ArrayAndReferenceType();

            ArrayAndCopyTo();

            Array arrayA = Array.CreateInstance(typeof(TestClass), 10);
            Array arrayC = new TestClass[10];
            Console.WriteLine(arrayA.GetType().IsArray);   //is type of this object array?  
            Console.WriteLine(arrayA.GetType().GetElementType());
            Console.WriteLine(arrayC.GetType().IsArray);

            //https://msdn.microsoft.com/en-us/library/system.array(v=vs.110).aspx
            //Type objects provide information about array type declarations. Array objects with the same array type share the same Type object.
            //Type.IsArray and Type.GetElementType might not return the expected results with Array because if an array is cast to the type Array,
            //the result is an object, not an array. That is, typeof(System.Array).IsArray returns false, and typeof(System.Array).GetElementType returns null.


            //initialize array with instance of elements and number of element
            var arrayL = new TestClass[10];
            arrayL = arrayL.Select((x, numberOfItem) => new TestClass(numberOfItem)).ToArray();


            TestClass[,] arrayB = new TestClass[5, 7];
            Console.WriteLine("Range of dimension:{0}, by Rank property)", arrayB.Rank);
            Console.WriteLine("Number of all elements thrue all dimensions:{0} by Length property", arrayB.Length);


            Console.WriteLine("Array before reverse operation");
            Print(arrayL);
            Array.Reverse(arrayL);
            Console.WriteLine("Arraya after reverse");
            Print(arrayL);

            //Sort array by another keys which is in array
            var valueArray = new string[] { "one", "two", "one", "two", "one", "two", "one", "two", "one", "two" };
            var keyArray = new int[] { 0, 6, 1, 7, 2, 8, 3, 9, 4, 5 };

            //Array.Sort(keyArray, valueArray);
            Print(valueArray);
        }

        private static void ArrayAndCopyTo()
        {

            Console.WriteLine("------ Array and CopyTo ----------");
            Console.WriteLine("Uses copyTo method deep copy?");
            TestClass[] testArray = new TestClass[] { new TestClass(0) };
            TestClass[] anotherArry = new TestClass[testArray.Length];

            testArray.CopyTo(anotherArry, 0);
            Console.WriteLine($"After we copied array contains reverence type to another array, we can test equals method: testArray[0].Equals(anotherArry[0]) {testArray[0].Equals(anotherArry[0])}");   //no, it uses shallow copy
            Console.WriteLine($"And for double check, we test: testArray[0] == anotherArry[0] {testArray[0] == anotherArry[0]}");

            Console.WriteLine();

            TestClass[] testB = new TestClass[testArray.Length + 2];
            Array.Copy(testArray, 0, testB, 1, testArray.Length);       //creates null, instance, null

            Console.WriteLine("We created array where first item is not initialized, second is instance of class, and last is not initialized what will return methods");
            Console.WriteLine($"testB.GetLowerBound(0) {testB.GetLowerBound(0)}");     //return 0 - zero base index
            Console.WriteLine($"testB.GetUpperBound(0) {testB.GetUpperBound(0)}");     //return 2 - maximum of array - even is last item is null
            Console.WriteLine($"So yea, array is still zero based and method return result independend of contains");
            Console.WriteLine();
        }

        private static void ArrayAndReferenceType()
        {
            Console.WriteLine("--------- array and things around reference type -------");

            //we create array with the same values
            var array = new string[] { "one", "two" };
            var anotherArr = new string[] { "one", "two" };

            //is the arrays the same? - no, because there are reference types
            
            Console.WriteLine($"two arrays with the same values is == ? {array == anotherArr}");
            Console.WriteLine($"two arrays with the same values is equal ? {array.Equals(anotherArr)}");
            Console.WriteLine($"string[] array.GetType().IsArray {array.GetType().IsArray}");
            Console.WriteLine($"string[] array.GetType().GetElementType() {array.GetType().GetElementType()}");

            Console.WriteLine();
            // - array is reference type
            var secArray = array;
            Console.WriteLine($"we create new reference to array  var secArray = array; and after that array == secArray? {array == secArray}");

            Console.WriteLine();
            object[] copiedArray = new object[array.Length];
            array.CopyTo(copiedArray, 0);  //method CopyTo uses automatically casting, so we can copy int to object

            Console.WriteLine($"When we use array.CopyTo, will the array equals? array.Equals(copiedArray) {array.Equals(copiedArray)}");
            Console.WriteLine("For double check, here are what arrays contains");
            Console.WriteLine("array:");
            Print(array);
            Console.WriteLine("copiedArray:");
            Print(copiedArray);
            Console.WriteLine();
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
            foreach (var item in array)
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

        public int ID
        {
            get { return _id; }
        }

        public override string ToString()
        {
            return _id.ToString();
        }
    }
}
