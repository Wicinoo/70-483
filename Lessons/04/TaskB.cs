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
            Assert.Throws<ArgumentNullException>(() => { ParseUnsignedInteger(null); });
        }

        [Fact]
        public void ParseUnsignedInteger_WhenOK_ShouldReturnNumber()
        {
            Assert.True(ParseUnsignedInteger("123456") == 123456);
        }

        [Fact]
        public void ParseUnsignedInteger_WhenIncorrectFormat_ShouldThrowFormatException()
        {
            Assert.Throws<FormatException>(() => ParseUnsignedInteger("incorrect format"));
        }

        [Fact]
        public void ParseUnsignedInteger_WhenBiggerThenUIntMax_ShouldThrowOverflowException()
        {
            Assert.Throws<OverflowException>(() => ParseUnsignedInteger("999999999999999999999999999999999999"));
        }

        [Fact]
        public void ParseUnsignedInteger_WhenSignedInt_ShouldThrowOverflowException()
        {
            Assert.Throws<OverflowException>(() => ParseUnsignedInteger("-12345678"));
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
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }

            return Convert.ToUInt32(s);
        }
    }
}
