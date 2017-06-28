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
        public void ToDecimal_ForAnyValidMoney_ShouldReturnItsAmount_InDecimal()
        {
            decimal expected = 1234.50M;
            decimal amount = Convert.ToDecimal(new Money(1234.50M, "USD"));

            Assert.Equal(expected, amount);
        }

        [Fact]
        public void ToInt32_ForAnyValidMoney_WithDecimalPlaces_ShouldThrowInvalidCastException()
        {
            Action cast = () =>
            {
                Convert.ToInt32(new Money(1234.50M, "USD"));
            };

            Assert.Throws<InvalidCastException>(cast);
        }

        [Fact]
        public void ToInt32_ForAnyValidMoney_WithoutDecimalPlaces_ShouldReturnItsAmount()
        {
            int expected = 1234;
            int amount = Convert.ToInt32(new Money(1234, "USD"));

            Assert.Equal(amount, expected);
        }

        [Fact]
        public void ToBoolean_ForAnyValidMoney_ShouldThrowException()
        {
            Action cast = () =>
            {
                Convert.ToBoolean(new Money(1234, "USD"));
            };

            Assert.Throws<InvalidCastException>(cast);
        }

        // Implement missing tests

        class Money : IConvertible
        {
            decimal Amount { get; }
            string Currency { get; }

            public Money(decimal amount, string currency)
            {
                Amount = amount;
                Currency = currency;
            }

            public bool ToBoolean(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public int ToInt32(IFormatProvider provider)
            {
                var hasFractionalPart = (Amount - Math.Round(Amount) != 0);

                if (hasFractionalPart)
                {
                    throw new InvalidCastException();
                }

                return Convert.ToInt32(Amount);
            }

            public decimal ToDecimal(IFormatProvider provider)
            {
                return Amount;
            }

            public DateTime ToDateTime(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public TypeCode GetTypeCode()
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
        }
    }
}