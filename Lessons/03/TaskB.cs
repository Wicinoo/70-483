using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Lessons._03
{
    /// <summary>
    /// Implement IsPowerOfTwo() method to pass all tests. 
    /// You have to use binary "&" operator in your implementation.
    /// </summary>
    public class TaskB
    {
        [Theory]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(2, true)]
        [InlineData(3, false)]
        [InlineData(4, true)]
        [InlineData(5, false)]
        [InlineData(8, true)]
        public void IsPowerOfTwo_ForGivenNumber_ShouldReturnExpected(int number, bool expectedIsPowerOfTwo)
        {
            var isPowerOfTwo = IsPowerOfTwo(number);
            Assert.Equal(expectedIsPowerOfTwo, isPowerOfTwo);
        }

        private bool IsPowerOfTwo(int number)
        {
            if (number <= 0) return false;
            return (number & (number - 1)) == 0 ? true : false;
        }

        public static void TestIsPowerOfTwo()
        {
            var test = new TaskB();

            var nums = new List<int>(Enumerable.Range(-1, 33));
            nums.AddRange(new int[] {
                255, 
                256,
                257,
                int.MaxValue,
                Convert.ToInt32(Math.Pow(2, 30)),
                Convert.ToInt32(Math.Pow(2, 30)) - 1
            });

            nums.ForEach(x =>
            {
                string yesNo = test.IsPowerOfTwo(x) ? "is" : "is not";
                Console.WriteLine($"{x} {yesNo} the power of two.");
            });
        }
    }
}