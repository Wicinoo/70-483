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
            decimal amount = Convert.ToDecimal(new Money(1234.50M, "USD"));
            Assert.Equal(1234.50M, amount);
        }

        [Fact]
        public void ToInt_ForMoneyWithNoDecimalPlaces_ShouldReturnItsAmount()
        {
            var moneyInDecimal = Convert.ToInt32(new Money(1234, "USD"));
            Assert.Equal(moneyInDecimal, 1234);
        }
        
        [Fact]
        public void ToInt_ForMoneyWithDecimalPlaces_ShouldThrowInvalidCastException()
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToInt32(new Money(1234.50M, "USD")));
        }

        [Fact]
        public void ToBool_ForAnyValidMoney_ShouldThrowInvalidCastException()
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(new Money(1234, "USD")));
        }
    }

    public class Money : IConvertible
    {
        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public Money(decimal amount, string currency)
        {
            Amount = amount;
            currency = Currency;
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return Amount;
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public int ToInt32(IFormatProvider provider)
        {
            int result = Convert.ToInt32(Amount);

            if (Amount != result)
            {
                throw new InvalidCastException();
            }

            return result;
        }

        public TypeCode GetTypeCode()
        {
            throw new NotImplementedException();
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

        public double ToDouble(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
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