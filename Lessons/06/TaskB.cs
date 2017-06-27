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
            var res = Convert.ToDecimal(new Money(1234.50M, "USD"));   // 1234.50M 
            Assert.True(res == 1234.50M);
        }

        // Implement missing tests
        [Fact]
        public void TInt_ForDecimal_ShouldReturnInvaliCast()
        {
            //var res = Convert.ToInt32(new Money(1234.50M, "USD"));   // 1234.50M 
            Assert.Throws<InvalidCastException>(() => Convert.ToInt32(new Money(1234.50M, "USD")));
        }

        [Fact]
        public void TInt_ForInt_ShouldReturnInt()
        {
            var res = Convert.ToInt32(new Money(1234, "USD"));   // 1234.50M 
            Assert.True(res == 1234);
        }

        [Fact]
        public void TBool_ForInt_ShouldReturnInvalidCast()
        {
            //var res = Convert.ToBoolean(new Money(1234, "USD"));    // 1234.50M 
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(new Money(1234, "USD")));
        }


        class Money : IConvertible
        {
            decimal Amount { get; }
            string Currency { get; }

            public Money(decimal amount, string cur)
            {
                Amount = amount;
                Currency = cur;
            }

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
                if (Math.Floor(Amount) == Amount)
                {
                    return (int)Amount;
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