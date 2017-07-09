using System;
using System.Runtime.InteropServices;
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
        public void ToBoolean_ForMoneyCreatedByInteger_ShouldThrowInvalidCastException()
        {
            Assert.Throws<InvalidCastException>(() =>
            {
                bool amount = Convert.ToBoolean(new Money(1234, "USD"));
            });
        }


        [Fact]
        public void ToInt32_ForMoneyCreatedByDecimal_ShouldThrowInvalidCastException()
        {
            Assert.Throws<InvalidCastException>(() =>
            {
                int amount = Convert.ToInt32(new Money(1234.50M, "USD"));
            });
        }

        [Fact]
        public void ToInt32_ForMoneyCreatedByInteger_ShouldReturnItsAmount()
        {
            int amount = Convert.ToInt32(new Money(1234, "USD"));
            Assert.Equal(1234, amount);
        }

        [Fact]
        public void ToDecimal_ForAnyValidMoney_ShouldReturnItsAmount()
        {
            decimal amount = Convert.ToDecimal(new Money(1234.50M, "USD"));   // 1234.50M 
            Assert.Equal(1234.50M, amount);
        }

        // Implement missing tests

        class Money : IConvertible
        {
            decimal Amount { get; }
            string Currency { get; }

            public Money(decimal amout, string currency)
            {
                Amount = amout;
                Currency = currency;
            }
            public int ToInt32(IFormatProvider provider)
            {
                int result = decimal.ToInt32(Amount);
                if (!Amount.Equals(result))
                {
                    throw new InvalidCastException();}
                return result;
            }

            public decimal ToDecimal(IFormatProvider provider)
            {
                return Amount;
            }

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