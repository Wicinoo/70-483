using System;
using Xunit;
using Xunit.Sdk;

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
            string input = null;
            Assert.Throws<ArgumentNullException>(() => { ParseUnsignedInteger(input); });
        }

        [Fact]
        public void ParseUnsignedInteger_WhenNull_ShouldThrowFormatException()
        {
            string input = "test";
            Assert.Throws<FormatException>(() => { ParseUnsignedInteger(input); });
        }

        [Fact]
        public void ParseUnsignedInteger_WhenNull_ShouldThrowOverflowException()
        {
            var input = (UInt64) UInt32.MaxValue + 1;
            Assert.Throws<OverflowException>(() => { ParseUnsignedInteger(input.ToString()); });
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
           return UInt32.Parse(s);
        }
    }
}