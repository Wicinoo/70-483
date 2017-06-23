using System;

namespace Lessons._06
{
    public static class _01_UserDefinedConversions
    {
        public static void Run()
        {
            Money money = new Money(42.42M);
            decimal amount = money;
            int truncatedAmount = (int)money;

            Console.WriteLine($"Amount: {amount}");
            Console.WriteLine($"Truncated amount: {truncatedAmount}");
        }

        class Money
        {
            public Money(decimal amount)
            {
                Amount = amount;
            }
            public decimal Amount { get; set; }

            public static implicit operator decimal(Money money)
            {
                return money.Amount;
            }
            public static explicit operator int(Money money)
            {
                return (int)money.Amount;
            }
        }

    }
}