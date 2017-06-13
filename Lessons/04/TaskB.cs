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
            Exception ex = Assert.Throws<ArgumentNullException>(() => ParseUnsignedInteger(null));
        }

        [Fact]
        public void ParseUnsignedInteger_WhenAlphaNumber_ShouldThrowFormatException()
        {
            Exception ex = Assert.Throws<FormatException>(() => ParseUnsignedInteger("abc1234"));
        }

        [Fact]
        public void ParseUnsignedInteger_WhenLessThanMinValue_ShouldThrowOverflowException()
        {
            int x = (int)System.UInt32.MinValue - 1;
            Exception ex = Assert.Throws<OverflowException>(() => ParseUnsignedInteger(x.ToString()));

        }

        [Fact]
        public void ParseUnsignedInteger_WhenMoreThanMaxValue_ShouldThrowOverflowException()
        {
            UInt64 x = (UInt64)System.UInt32.MaxValue + 1;
            Exception ex = Assert.Throws<OverflowException>(() => ParseUnsignedInteger(x.ToString()));
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
            double dResult;

            double.TryParse(s, out dResult);

            if (dResult < System.UInt32.MinValue || dResult > System.UInt32.MaxValue)
            {
                throw new OverflowException();
            }

            if ( !UInt32.TryParse(s, out result) )
            {
                throw new FormatException();
            }

            return result;
        }
    }
}