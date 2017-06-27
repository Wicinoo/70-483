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
            var actualValue = Convert.ToDecimal(new Money(1234.50M, "USD"));   // 1234.50M
            var expectedValue = 1234.50M;
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void ToInt32_ForInvalidMoney_ShouldThrowInvalidCastException()
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToInt32(new Money(1234.50M, "USD")));   // 1234.50M
        }

        [Fact]
        public void ToInt32_ForAnyValidMoney_ShouldReturnItsAmount()
        {
            var actualValue = Convert.ToInt32(new Money(1234, "USD"));   // 1234.50M
            var expectedValue = 1234;
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void ToBoolean_ForAnyMoney_ShouldThrowInvalidCastException()
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(new Money(1234M, "USD")));   // 1234.50M
        }
        // Implement missing tests

        class Money : IConvertible
        {
            public Money(decimal amount, string currency)
            {
                Amount = amount;
                Currency = currency;
            }
            decimal Amount { get; }
            string Currency { get; }

            public TypeCode GetTypeCode()
            {
                throw new NotImplementedException();
            }

            public bool ToBoolean(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public byte ToByte(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public char ToChar(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public DateTime ToDateTime(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public decimal ToDecimal(IFormatProvider provider)
            {
                return Amount;
            }

            public double ToDouble(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public short ToInt16(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public int ToInt32(IFormatProvider provider)
            {
                var floored = Math.Floor(Amount);
                if (Amount.Equals(floored))
                {
                    return Decimal.ToInt32(Amount);
                }
                throw new InvalidCastException();
            }

            public long ToInt64(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public sbyte ToSByte(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public float ToSingle(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public string ToString(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public object ToType(Type conversionType, IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public ushort ToUInt16(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public uint ToUInt32(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public ulong ToUInt64(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }
        }
    }
}