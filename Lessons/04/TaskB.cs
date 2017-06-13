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
            var underTest = new TaskB();
            Exception thrownException = new Exception();

            try
            {
                underTest.ParseUnsignedInteger(null);
            }
            catch (Exception ex)
            {
                thrownException = ex;
            }

            Assert.IsType<ArgumentNullException>(thrownException);
        }

        [Fact]
        public void ParseUnsignedInteger_WhenParameterIsNotOfTheCorrectFormat_ShouldThrowFormatException()
        {
            var underTest = new TaskB();
            Exception thrownException = new Exception();

            try
            {
                underTest.ParseUnsignedInteger("hello");
            }
            catch (Exception ex)
            {
                thrownException = ex;
            }

            Assert.IsType<FormatException>(thrownException);
        }

        [Fact]
        public void ParseUnsignedInteger_WhenParameterIsNotOfTheCorrectFormat_ShouldThrowArgumentNullException()
        {
            var underTest = new TaskB();
            Exception thrownException = new Exception();

            try
            {
                underTest.ParseUnsignedInteger("-1");
            }
            catch (Exception ex)
            {
                thrownException = ex;
            }

            Assert.IsType<OverflowException>(thrownException);
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