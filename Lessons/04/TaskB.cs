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
            try
            {
                ParseUnsignedInteger(null);
            }
            catch (ArgumentNullException)
            {
                return;                
            }
        }

        [Fact]
        public void ParseUnsignedInteger_WhenString_Is_not_in_correct_format_ShouldThrowFormatException()
        {
            try
            {
                ParseUnsignedInteger("aaaa");
            }
            catch (FormatException)
            {
                return;
            }
        }
        [Fact]
        public void ParseUnsignedInteger_WhenValue_Is_Out_Of_Range_ShouldThrowOverflowException()
        {
            try
            {
                ParseUnsignedInteger("9999999999999999");
            }
            catch (OverflowException)
            {
                return;
            }

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