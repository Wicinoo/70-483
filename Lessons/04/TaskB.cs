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
            throw new NotImplementedException();
        }

        [Fact]
        public void ParseUnsignedInteger_WhenAlphaNumber_ShouldThrowFormatException()
        {
            
        }

        [Fact]
        public void ParseUnsignedInteger_WhenLessThanMinValue_ShouldThrowOverflowException()
        {

        }

        [Fact]
        public void ParseUnsignedInteger_WhenMoreThanMaxValue_ShouldThrowOverflowException()
        {

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
                throw new ArgumentNullException();
            }

            uint result;

            if ( !UInt32.TryParse(s, out result) )
            {
                throw new FormatException();
            }

            if (result < System.UInt32.MinValue || result > System.UInt32.MaxValue )
            {
                throw new OverflowException();
            }

            return result;
        }
    }
}