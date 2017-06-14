using System;
using Rhino.Mocks;
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
            Assert.Throws(typeof (ArgumentNullException), () => ParseUnsignedInteger(null));
        }

        [Fact]
        public void ParseUnsignedInteger_WhenNull_FormatException()
        {
            Assert.Throws(typeof(FormatException), () => ParseUnsignedInteger("not a number"));
        }

        [Fact]
        public void ParseUnsignedInteger_WhenNull_OverflowException()
        {
            Assert.Throws(typeof(OverflowException), () => ParseUnsignedInteger("861687186768686846468468468416841614684684"));
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
                throw new ArgumentNullException(nameof(s), "The s parameter is null.");
            }

            return uint.Parse(s);
 
        }
    }
}