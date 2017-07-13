using System;
using FluentAssertions.Execution;
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
            var value = Convert.ToDecimal(new Money(1234.50M, "USD"));   // 1234.50M 
            Assert.Equal(1234.50M, value);
        }

        // Implement missing tests

        [Fact]
        public void ToInt32_ForAnyValidMoney_ShouldReturnItsAmount()
        {
            var value = Convert.ToInt32(new Money(1234, "USD"));  
            Assert.Equal(1234, value);
        }

        [Fact]
        public void ToInt32_ForAnyValidMoney_ShouldThrowAnException()
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToInt32(new Money(1234.50M, "USD")));
        }

        [Fact]
        public void ToBoolean_ForAnyValidMoney_ShouldThrowAnException()
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(new Money(1234, "USD")));
        }

        class Money : IConvertible
        {
            public Money(decimal value, string ccy)
            {
                Amount = value;
                Currency = ccy;
            }

            public Money(int value, string ccy)
            {
                Amount = value;
                Currency = ccy;
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

            public char ToChar(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public sbyte ToSByte(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public byte ToByte(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public short ToInt16(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public ushort ToUInt16(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public int ToInt32(IFormatProvider provider)
            {
                if (Amount.ToString().Contains("."))
                {
                    throw new InvalidCastException();
                }

                return decimal.ToInt32(Amount);
            }

            public uint ToUInt32(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public long ToInt64(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public ulong ToUInt64(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public float ToSingle(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public double ToDouble(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public decimal ToDecimal(IFormatProvider provider)
            {
                return Amount;
            }

            public DateTime ToDateTime(IFormatProvider provider)
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
        }
    }
}