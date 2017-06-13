using System;
using Xunit;

namespace Lessons._04
{
    /// <summary>
    /// Write tests for all possible cases. 
    /// Each of possible exceptions should have a test case.
    /// Implement the method ParseUnsignedInteger.
    /// </summary>
    public class TaskB
    {
        [Fact]
        public void ParseUnsignedInteger_WhenNull_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentException>(() => ParseUnsignedInteger(null));
        }

        [Fact]
        public void ParseUnsignedInteger_WhenAbc_ShouldThrowFormatExceptionException()
        {
            Assert.Throws<FormatException>(() => ParseUnsignedInteger("abc"));
        }

        [Fact]
        public void ParseUnsignedInteger_WhenNegative_ShouldThrowOverflowExceptionException()
        {
            Assert.Throws<OverflowException>(() => ParseUnsignedInteger("-5"));
        }

        [Fact]
        public void ParseUnsignedInteger_WhenDecimal_ShouldThrowFormatExceptionException()
        {
            Assert.Throws<FormatException>(() => ParseUnsignedInteger("0.555"));
        }

        public void ParseUnsignedInteger_WhenLongValue_ShouldThrowOverflowExceptionnException()
        {
            long maxValue = (long)UInt32.MaxValue + 1;
            Assert.Throws<OverflowException>(() => ParseUnsignedInteger(maxValue.ToString()));
        }

        public void ParseUnsignedInteger_WhenTwo_ShouldReturnTwo()
        {
            Assert.True(2 == ParseUnsignedInteger("2"));
        }

        ///
        /// Summary:
        ///     Converts the string representation of a number to its 32-bit unsigned integer
        ///     equivalent.
        ///
        /// Parameters:
        ///   s:
        ///     A string representing the number to convert.
        ///
        /// Returns:
        ///     A 32-bit unsigned integer equivalent to the number contained in s.
        ///
        /// Exceptions:
        ///   T:System.ArgumentNullException:
        ///     The s parameter is null.
        ///
        ///   T:System.FormatException:
        ///     The s parameter is not of the correct format.
        ///
        ///   T:System.OverflowException:
        ///     The s parameter represents a number that is less than System.UInt32.MinValue
        ///     or greater than System.UInt32.MaxValue.
        public uint ParseUnsignedInteger(string s)
        {
            if(s == null)
                throw new ArgumentException();
            return Convert.ToUInt32(s);
        }
    }
}