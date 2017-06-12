using System;

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
            var service = new PricingService();

            try
            {
                service.GetPrice(DateTime.Now);
            }
            catch (Exception e)
            {
                PrintEverything(e, 0);
            }
        }

        private static void PrintEverything(Exception e, int depth)
        {
            Console.WriteLine($"Depth: {depth}, Message: {e.Message}");

            if (e.InnerException != null)
            {
                PrintEverything(e.InnerException, ++depth);
            }
        }
    }

    public class PricingService
    {
        public void GetPrice(DateTime asAt)
        {
            //Oh noes
            throw new PriceMissingException("We forgot to impletment pricing service.");
        }
    }

    public class PriceMissingException : Exception
    {
        public PriceMissingException()
        {
            NotifyStaticDataOperationsTeam();
        }

        public PriceMissingException(string message) : base(message)
        {
            NotifyStaticDataOperationsTeam();
        }

        public PriceMissingException(string message, Exception deep) : base(message, deep)
        {
            NotifyStaticDataOperationsTeam();
        }

        private void NotifyStaticDataOperationsTeam()
        {
            var staticDataTeamAwake = false;

            if (staticDataTeamAwake)
            {
                //TODO: Send an email
            }
            else
            {
                throw new StaticDataTeamSleepingException("We need to wake them up.", this);
            }
        }
    }

    public class StaticDataTeamSleepingException : Exception
    {
        public StaticDataTeamSleepingException()
        {
        }

        public StaticDataTeamSleepingException(string message) : base(message)
        {
        }

        public StaticDataTeamSleepingException(string message, Exception deep) : base(message, deep)
        {
        }
    }
}