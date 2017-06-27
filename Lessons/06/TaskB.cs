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
            var value = Convert.ToDecimal(new Money(1234.50M, "USD"));
            decimal expected = 1234.50M;
            Assert.Equal(value, expected);
        }

        [Fact]
        public void ToInt32_ForMoneyWithoutDecimalPlaces_ShouldReturnItsAmount()
        {
            var value = Convert.ToInt32(new Money(1234, "USD"));
            int expected = 1234;
            Assert.Equal(value, expected);
        }

        [Fact]
        public void ToInt32_ForMoneyWithDecimalPlaces_ShouldThrowInvalidCastException()
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToInt32(new Money(1234.50M, "USD")));
        }

        [Fact]
        public void ToBoolean_ForMoney_ShouldThrowInvalidCastException()
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(new Money(1234.50M, "USD")));
        }

        class Money : IConvertible
        {
            decimal Amount { get; }
            string Currency { get; }

            public Money(decimal amount, string currency)
            {
                Amount = amount;
                Currency = currency;
            }

            public TypeCode GetTypeCode()
            {
                return TypeCode.Decimal;
            }

            public bool ToBoolean(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public char ToChar(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public sbyte ToSByte(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public byte ToByte(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public short ToInt16(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public ushort ToUInt16(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public int ToInt32(IFormatProvider provider)
            {
                if (Amount % 1 == 0)
                {
                    return Convert.ToInt32(Amount, provider);
                }

                throw new InvalidCastException();
            }

            public uint ToUInt32(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public long ToInt64(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public ulong ToUInt64(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public float ToSingle(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public double ToDouble(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public decimal ToDecimal(IFormatProvider provider)
            {
                return Convert.ToDecimal(Amount, provider);
            }

            public DateTime ToDateTime(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public string ToString(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public object ToType(Type conversionType, IFormatProvider provider)
            {
                throw new InvalidCastException();
            }
        }
    }
}