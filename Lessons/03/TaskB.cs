using System;
using System.Diagnostics;
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
            // bitwise & calculation means that numbers are compared based on their binary representation.
            // i.e. 8 or 10000000 & 7 or 01110000 == 0; returns true
            // bits in each position are compared one against each other and the condition is:
            // if they are both 1, result is 1, else 0.
            // The result of the & operation is then the sum of all operations against each bit.
            return number != 0 && (number & (number - 1)) == 0;
        }
    }
}