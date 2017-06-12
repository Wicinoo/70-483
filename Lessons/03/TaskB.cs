using System;
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
            return (number & (number - 1)) == 0 && ((number & -1) != 0);

            /* n = bin -> expected ... n-1 = bin ... result
             * 0 = 0000 -> F ...-1 = 1111 ... 0000 ! extra case
             * 1 = 0001 -> T ... 0 = 0000 ... 0000
             * 2 = 0010 -> T ... 1 = 0001 ... 0000
             * 3 = 0011 -> T ... 2 = 0010 ... 0010 
             * 4 = 0100 -> T ... 3 = 0011 ... 0000
             * 5 = 0101 -> T ... 4 = 0100 ... 0100
             * 6 = 0110 -> T ... 5 = 0101 ... 0100
             * 7 = 0111 -> T ... 6 = 0110 ... 0110
             * 8 = 1000 -> T ... 7 = 0111 ... 0000
             * ...
             * 
             * 2^-1 = 0.5 
             * -1 = 1111...1111
             * int.MaxValue = 0111...1111
             */
        }
    }
}