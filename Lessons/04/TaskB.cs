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
        public void ParseUnsignedInteger_WhenInvalidFormat_ShouldThrowIFormatException()
        {
            Assert.Throws<FormatException>(() => ParseUnsignedInteger("bla bla"));
        }

        [Fact]
        public void ParseUnsignedInteger_WhenOutOfRange_ShouldThrowOverflowException()
        {
            long value = (long)uint.MinValue - 1;
            Assert.Throws<OverflowException>(() => ParseUnsignedInteger(value.ToString()));
        }

        [Fact]
        public void ParseUnsignedInteger_WhenOutOfRange_ShouldThrowOverflowException2()
        {
            long value = (long)uint.MaxValue + 1;
            Assert.Throws<OverflowException>(() => ParseUnsignedInteger(value.ToString()));
        }

        [Fact]
        public void ParseUnsignedInteger_MinValue()
        {
            uint value = ParseUnsignedInteger(uint.MinValue.ToString());
            Assert.Equal<uint>(value, uint.MinValue);
        }

        [Fact]
        public void ParseUnsignedInteger_MaxValue()
        {
            uint value = ParseUnsignedInteger(uint.MaxValue.ToString());
            Assert.Equal<uint>(value, uint.MaxValue);
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
                throw new ArgumentNullException(nameof(s), "Input string cannot be null.");
            }

            long result;
            if (!long.TryParse(s, out result))
            {
                throw new FormatException("Invalid format of input string.");
            }

            if (result < uint.MinValue || result > uint.MaxValue)
            {
                throw new OverflowException($"Valid range if from {uint.MinValue} to {uint.MaxValue}");
            }

            return (uint)result;
        }
    }
}