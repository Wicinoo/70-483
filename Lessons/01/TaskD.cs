using System;
using System.Text;
using Xunit.Sdk;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    public class TaskD
    {
        delegate void GetParagraphFor(Instrument instrument);

        delegate void GetFancyParagraphFor(GreatInstrument greatInstrument);

        public static void Run()
        {
            GetParagraphFor getNormalParagraphFor = GetNormalParagraph;
            getNormalParagraphFor(new QuiteOkInstrument(5, 0.005m));
            getNormalParagraphFor(new GreatInstrument(1000, 0.2m, 0.15m, "Ulve von der Hohe"));

            GetFancyParagraphFor getFancyParagraph = GetFancyParagraph;
            getFancyParagraph(new GreatInstrument(1000, 0.2m, 0.15m, "Ulve von der Hohe"));
        }


        private static void GetNormalParagraph(Instrument instrument)
        {
            var paragraph = new StringBuilder();
            paragraph.AppendLine($"This is {instrument.GetType().Name}");
            paragraph.AppendLine($"Yearly profit per unit might be £{instrument.CalculateProfit()}.");
            paragraph.AppendLine($"Have a good day.");
            Console.WriteLine(paragraph);
        }

        private static void GetFancyParagraph(GreatInstrument greatInstrument)
        {
            var paragraph = new StringBuilder();
            paragraph.AppendLine($"This is new and amazing {greatInstrument.GetType().Name} managed by {greatInstrument.ManagerName}");
            paragraph.AppendLine($"Yearly profit per unit is unbelievable £{greatInstrument.CalculateProfit()}.");
            paragraph.AppendLine($"Mayonnaise is good for you.");
            Console.WriteLine(paragraph);
        }
    }

    public abstract class Instrument
    {
        protected Instrument(decimal unitPrice, decimal profitIndex)
        {
            UnitPrice = unitPrice;
            ProfitIndex = profitIndex;
        }

        public decimal UnitPrice { get; set; }
        public decimal ProfitIndex { get; set; }
        public virtual decimal CalculateProfit()
        {
            return UnitPrice * ProfitIndex * 365.25m;
        }
    }

    public class QuiteOkInstrument : Instrument
    {
        public QuiteOkInstrument(decimal unitPrice, decimal profitIndex) : base(unitPrice, profitIndex)
        { 
        }
    }

    public class GreatInstrument : Instrument
    {
        public GreatInstrument(decimal unitPrice, decimal profitIndex, decimal anotherMultiplier, string managerName) : base(unitPrice, profitIndex)
        {
            ManagerName = managerName;
            AnotherMultiplier = anotherMultiplier;
        }

        public string ManagerName { get; set; }
        public decimal AnotherMultiplier { get; set; }
        public override decimal CalculateProfit()
        {
            return base.CalculateProfit() * AnotherMultiplier;
        }
    }
}