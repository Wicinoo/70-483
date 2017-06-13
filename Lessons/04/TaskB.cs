using System;
using System.Diagnostics.CodeAnalysis;
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
            string s = null;
            Assert.Throws<ArgumentNullException>(() => ParseUnsignedInteger(s));
        }

        [Fact]
        public void ParseUnsignedInteger_WhenIncorrectFormat_ShouldThrowFormatException()
        {
            string s = "A";
            Assert.Throws<FormatException>(() => ParseUnsignedInteger(s));
        }

        [Fact]
        public void ParseUnsignedInteger_WhenOverflow_ShouldThrowOverflowException()
        {
            string s = "4294967296"; // UInt32.MaxValue + 1
            Assert.Throws<OverflowException>(() => ParseUnsignedInteger(s));
        }

        [Fact]
        public void ParseUnsignedInteger_WhenUnderflow_ShouldThrowOverflowException()
        {
            string s = "-1"; // UInt32.MinValue - 1
            Assert.Throws<OverflowException>(() => ParseUnsignedInteger(s));
        }

        [Theory]
        [InlineData("0", 0)] // UInt32.MinValue
        [InlineData("4294967295", 4294967295)] // UInt32.MaxValue
        [InlineData("2147483648", 2147483648)] // Int32.MaxValue + 1        
        public void ParseUnsignedInteger_WhenValidInput_ShouldReturnCorrectResult(string s, uint expected)
        {
            Assert.Equal(expected, ParseUnsignedInteger(s));
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
            return uint.Parse(s);
        }
    }
}