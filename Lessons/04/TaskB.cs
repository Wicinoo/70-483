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
            var s = (string)null;

            Assert.Throws<ArgumentNullException>(() => ParseUnsignedInteger(s));
        }

        [Fact]
        public void ParseUnsignedInteger_WhenInvalidFormat_ShouldThrowFormatException()
        {
            var s = "Hello world";

            Assert.Throws<FormatException>(() => ParseUnsignedInteger(s));
        }

        [Fact]
        public void ParseUnsignedInteger_WhenParameterLessUIntMin_ShouldThrowOverflowException()
        {
            var s = int.MinValue.ToString();

            Assert.Throws<OverflowException>(() => ParseUnsignedInteger(s));
        }

        [Fact]
        public void ParseUnsignedInteger_WhenParameterGreaterUIntMax_ShouldThrowOverflowException()
        {
            var s = long.MaxValue.ToString();

            Assert.Throws<OverflowException>(() => ParseUnsignedInteger(s));
        }

        [Fact]
        public void ParseUnsignedInteger_WhenParameterIsOk_ShouldReturnUInt()
        {
            var s = "12";

            var uintNum = ParseUnsignedInteger(s);

            Assert.Equal((uint)12, uintNum);
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