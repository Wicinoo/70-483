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
            Assert.ThrowsAny<ArgumentNullException>(() => ParseUnsignedInteger(null));
            Assert.ThrowsAny<FormatException>(() => ParseUnsignedInteger("Three"));
            Assert.ThrowsAny<OverflowException>(() => ParseUnsignedInteger(((decimal)uint.MaxValue + 1).ToString()));
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
            if (string.IsNullOrEmpty(s)) throw new ArgumentNullException("Value cannot be null or empty.", nameof(s));

            return uint.Parse(s);
        }
    }
}