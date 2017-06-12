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
            Assert.Throws<ArgumentNullException>(() => ParseUnsignedInteger(null));
        }

        [Fact]
        public void ParseUnsignedInteger_WhenHasInvalidFormat_ShouldThrowFormatException()
        {
            Assert.Throws<FormatException>(() => ParseUnsignedInteger("A1"));
        }

        [Fact]
        public void ParseUnsignedInteger_WhenIsLessThanMinValue_ShouldThrowOverflowException()
        {
            var minValue = UInt32.MinValue;

            Assert.Throws<OverflowException>(() => ParseUnsignedInteger(checked(minValue - 10).ToString()));
        }

        [Fact]
        public void ParseUnsignedInteger_WhenIsMoreThanMaxValue_ShouldThrowOverflowException()
        {
            var maxValue = UInt32.MaxValue;

            Assert.Throws<OverflowException>(() => ParseUnsignedInteger(checked(maxValue + 10).ToString()));
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
        public UInt32 ParseUnsignedInteger(string s)
        {
            Console.WriteLine(s);
            return UInt32.Parse(s);
        }
    }
}