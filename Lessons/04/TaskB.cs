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
            Assert.Throws(typeof(ArgumentNullException), () => ParseUnsignedInteger(null));
        }

        [Fact]
        public void ParseUnsignedInteger_WhenIncorrectFormat_ShouldThrowFormatException()
        {
            Assert.Throws(typeof(FormatException), () => ParseUnsignedInteger("aaa"));
        }

        [Fact]
        public void ParseUnsignedInteger_WhenOverflow_ShouldThrowOverflowException()
        {
            Assert.Throws(typeof(OverflowException), () => ParseUnsignedInteger(int.MinValue.ToString()));
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
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentNullException(nameof(s), "Input string cannot be null.");
            }

            if (!int.TryParse(s, out int result))
            {
                throw new FormatException("Input string was not in correct format.");
            }

            if (result < uint.MinValue || result > uint.MinValue)
            {
                throw new OverflowException("Number was not in limits of uint.");
            }

            return (uint)result;
        }
    }
}