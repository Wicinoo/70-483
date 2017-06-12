using System;
using System.Linq;
using System.Text.RegularExpressions;
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

            Action testTrigger = () => ParseUnsignedInteger(s);
            Assert.Throws<ArgumentNullException>(testTrigger);
        }

        [Fact]
        public void ParseUnsignedInteger_WhenNaN_ShouldThrowFormatException()
        {
            string s = "canOfBeans";

            Action testTrigger = () => ParseUnsignedInteger(s);
            Assert.Throws<FormatException>(testTrigger);
        }

        [Fact]
        public void ParseUnsignedInteger_WhenBiggerThanUIntAllows_ShouldThrowOverflowException()
        {
            string s = "999999999999999999";

            Action testTrigger = () => ParseUnsignedInteger(s);
            Assert.Throws<OverflowException>(testTrigger);
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
        public static uint ParseUnsignedInteger(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s), "Parameter s cannot be null");
            }

            if (!s.Any(c => c >= '0' && c <= '9'))
            {
                throw new FormatException("Input string is not a number.");
            }

            return uint.Parse(s);
        }
    }
}