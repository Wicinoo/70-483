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
            Convert.ToDecimal(new Money(1234.50M, "USD"));   // 1234.50M 
        }

        [Fact]
        public void ToInt32_ForAnyValidIntMoney_ShouldReturnItsAmount()
        {
            Convert.ToInt32(new Money(1234, "USD"));   // 1234.50M 
        }

        [Fact]
        public void ToInt32_ForAnyValidIntMoney2_ShouldReturnItsAmount()
        {
            Convert.ToInt32(new Money(1234.000M, "USD"));   // 1234.50M 
        }

        [Fact]
        public void ToInt32_ForNonIntMoney_ShouldThrowInvalidCastException()
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToInt32(new Money(1234.50M, "USD")));   // 1234.50M 
        }

        [Fact]
        public void ToInt32_ForIntMoneyOutOfRange_ShouldThrowInvalidCastException()
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToInt32(new Money(1M + Int32.MaxValue, "USD")));   // 1234.50M 
        }

        [Fact]
        public void ToBoolean_ForAnyValidMoney_ShouldThrowInvalidCastException()
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(new Money(1234.50M, "USD")));   // 1234.50M 
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

            TypeCode IConvertible.GetTypeCode()
            {
                return Type.GetTypeCode(typeof(Money));
            }

            decimal IConvertible.ToDecimal(IFormatProvider provider)
            {
                return Amount;
            }

            int IConvertible.ToInt32(IFormatProvider provider)
            {
                if (Amount >= Int32.MinValue && Amount <= Int32.MaxValue)
                {
                    Int32 intAmount = Convert.ToInt32(Amount);
                    if (Convert.ToDecimal(intAmount) == Amount)
                    {
                        return intAmount;
                    }
                    else
                    {
                        throw new InvalidCastException("Conversion to int not allowed because Amount contains nonzero numbers after the decimal point");
                    }
                }
                throw new InvalidCastException("Conversion to int not allowed because Amount is outside of <int.MinValue, int.MaxValue>");
            }

            string IConvertible.ToString(IFormatProvider provider)
            {
                return $"{Amount} {Currency}";
            }

            bool IConvertible.ToBoolean(IFormatProvider provider)
            {
                //not sure if it is ok to throw InvalidCastException, thought it was to be thrown only by .NET framework code
                throw new InvalidCastException("Conversion to boolean not allowed.");
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