using System.Runtime.InteropServices.WindowsRuntime;
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
            return (number != 0) && ((number & (number - 1)) == 0);
        }
    }
}