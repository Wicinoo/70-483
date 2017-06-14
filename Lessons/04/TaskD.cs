using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lessons._04
{
    /// <summary>
    /// Create your own custom exception.
    /// Use it in a reasonable context and simulate throwing and catching.
    /// </summary>
    public class TaskD
    {
        public static void Run()
        {
            Wallet w0 = new Wallet(0);
            Wallet w = new Wallet(90);
            Wallet w2 = new Wallet(45);
            Wallet w3 = new Wallet(36);
            Wallet w4 = new Wallet(36);

            BuyOctan(ref w0);
            BuyPilsner(ref w);
            BuyPilsner(ref w);
            BuyPilsner(ref w2);
            BuyOctan(ref w3);
            BuyOctan(ref w3);
            BuyOctan(ref w3);
            BuyOctan(ref w3);
            BuyOctan(ref w4);
        }

        public static void BuyPilsner(ref Wallet w)
        {
            try
            {
                Bar.BuyBeer(ref w, "Plzen");
            }
            catch (Exception e)
            {
                PrintExceptionDetails(e);
            }
        }

        private static void BuyOctan(ref Wallet w)
        {
            try
            {
                Bar.BuyBeer(ref w, "Octan");
            }
            catch (Exception e)
            {
                PrintExceptionDetails(e);
            }
        }

        private static void PrintExceptionDetails(Exception ex)
        {
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(ex))
            {
                Console.WriteLine("{0}: {1}", property.Name, property.GetValue(ex));
            }
        }
    }


    public static class Bar
    {

        private static Queue<Beer> _stock = new Queue<Beer>(new[] { new Beer("Plzen", 45), new Beer("Plzen", 45), new Beer("Octan", 12), new Beer("Octan", 12), new Beer("Octan", 12) });
        public static Beer BuyBeer(ref Wallet wallet, string brand)
        {
            if(_stock.Count==0)
                throw new NoMoreBeerException();

            Beer b = _stock.Peek();

            if (!string.IsNullOrEmpty(brand))
            {
                if (!brand.Equals(b.Brand))
                    throw new IDontLikeThisBeerException();
            }

            wallet.Take(b.Price);

            return _stock.Dequeue();
        }
    }

    public class Wallet
    {
        public  decimal CurrentValue { get; private set; }

        public Wallet(decimal initialValue)
        {
            CurrentValue = initialValue;
        }

        public void Take(decimal take)
        {
            if (CurrentValue >= take)
                CurrentValue -= take;
            else
            {
                throw new IDontHaveMoneyException(take, CurrentValue);
            }
        }

        public void Put(decimal put)
        {
            CurrentValue += put;
        }
    }

    public class Beer
    {
        public string Brand { get; private set; }
        public decimal Price { get; private set; }

        public Beer(string brand, decimal price)
        {
            Brand = brand;
            Price = price;
        }
    }


    public class IDontLikeThisBeerException : Exception
    {
        public IDontLikeThisBeerException() : base("Dont like this s...")
        {

        }
    }


    public class NoMoreBeerException : Exception
    {
        public NoMoreBeerException() : base("No more beer")
        {

        }
    }

    public class IDontHaveMoneyException : Exception
    {
        public decimal Need { get; private set; }

        public decimal Have { get; private set; }

        public IDontHaveMoneyException(decimal need, decimal have)
        {
            Need = need;
            Have = have;
        }

    }
}
