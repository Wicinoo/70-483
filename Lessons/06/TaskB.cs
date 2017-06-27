using System;
using Xunit;

namespace Lessons._06
{
    /// <summary>
    /// Let Money implement IConvertible.
    /// Implement only methods from the convertions below.
    /// Write unit tests to cover the cases.
    /// 
    /// Convert.ToDecimal(new Money(1234.50M, "USD"));   // 1234.50M 
    /// Convert.ToInt32(new Money(1234.50M, "USD"));     // InvalidCastException
    /// Convert.ToInt32(new Money(1234, "USD"));     // 1234
    /// Convert.ToBoolean(new Money(1234, "USD"));  // InvalidCastException
    /// </summary>
    public class TaskB
    {
        [Fact]
        public void ToDecimal_ForAnyValidMoney_ShouldReturnItsAmount()
        {
            Assert.Equal(Convert.ToDecimal(new Money(1234.50M, "USD")), 1234.50M);

        }

        [Fact]
        public void ToInt32_ForDecimalAmount_ShouldThrowInvalidCastException()
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToInt32(new Money(1234.50M, "USD")));

        }

        [Fact]
        public void ToInt32_ForIntegerAmount_ShouldReturnItsAmount()
        {
            Assert.Equal(Convert.ToDecimal(new Money(1234, "USD")), 1234);
        }

        [Fact]
        public void ToBoolean_ForIncorrectAmount_ShouldThrowInvalidCastException()
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(new Money(1234, "USD")));

        }

        class Money : IConvertible
        {
            public Money(decimal amount, string currency)
            {
                Amount = amount;
                Currency = currency;
            }

            decimal Amount { get; }
            string Currency { get; }
            decimal IConvertible.ToDecimal(IFormatProvider provider)
            {
                return Amount;
            }

            public TypeCode GetTypeCode()
            {
                throw new NotImplementedException();
            }

            Int32 IConvertible.ToInt32(IFormatProvider provider)
            {
                if (Amount != Math.Round(Amount))
                {
                    throw new InvalidCastException();
                }
                return Convert.ToInt32(Amount);
            }

            bool IConvertible.ToBoolean(IFormatProvider provider)
            {
                if (Amount != 0 && Amount != 1)
                {
                    throw new InvalidCastException();
                }
                return Convert.ToBoolean(Amount);
            }

            byte IConvertible.ToByte(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            char IConvertible.ToChar(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            DateTime IConvertible.ToDateTime(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            double IConvertible.ToDouble(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            short IConvertible.ToInt16(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            long IConvertible.ToInt64(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            sbyte IConvertible.ToSByte(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            float IConvertible.ToSingle(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            string IConvertible.ToString(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            object IConvertible.ToType(Type conversionType, IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            ushort IConvertible.ToUInt16(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            uint IConvertible.ToUInt32(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            ulong IConvertible.ToUInt64(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }
        }
    }
}