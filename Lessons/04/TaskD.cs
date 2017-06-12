using System;
using System.Dynamic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Rhino.Mocks.Constraints;
using Xunit.Sdk;

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
            var motor = new Engine();
            ExceptionDispatchInfo possibleException = null;

            var taskWork = Task.Run(() =>
            {
                try
                {
                    foreach (var i in Enumerable.Range(0, 100))
                    {
                        motor.Work();
                        Thread.Sleep(new Random().Next(100, 300));
                    }
                }
                catch (EngineException ex)
                {
                    possibleException = ExceptionDispatchInfo.Capture(ex);
                }
                
            });

           

            var cancelSource = new CancellationTokenSource();
            var token = cancelSource.Token;
            var taskCooling = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    motor.Cooling();
                    Thread.Sleep(200);
                }
                token.ThrowIfCancellationRequested();
            }, token);
            var taskFinally = taskCooling.ContinueWith(cooling =>
            {
                Console.WriteLine("Finally temperature:{0}", motor.Temperature);
            }, TaskContinuationOptions.NotOnCanceled);



            taskWork.Wait();
            if (possibleException != null)
            {
                Console.WriteLine(possibleException.SourceException.Message);
            }
            cancelSource.Cancel();
            taskFinally.Wait();

        }
    }

    public class Engine
    {
        private int _temperature = 0;
        private int _oilPressure = 0;

        public  int Temperature => _temperature;

        public void Work()
        {
            if (_temperature>130) throw new EngineException(_temperature, _oilPressure, "Temperature is too hight");
            Interlocked.Exchange(ref _temperature, _temperature + 5);
            Console.WriteLine("Engine working,  temperature:{0}", _temperature);
        }

        public void Cooling()
        {
            if (_temperature<-40) throw  new EngineException(_temperature, _oilPressure, "Temperature is too low");
            Interlocked.Decrement(ref _temperature);
            Console.WriteLine("Engine cooling,  temperature:{0}", _temperature);
        }
    }
    public class EngineException : Exception, ISerializable
    {
        public EngineException(int temperature, int oilPressure)
        {
            SetValues(temperature, oilPressure);
        }

        public EngineException(int temperature, int oilPressure, string message) : base(message)
        {
            SetValues(temperature, oilPressure);
        }

        private void SetValues(int temperature, int oilPressure)
        {
            Temperature = temperature;
            OilPresure = oilPressure;
            this.HelpLink = "https:/en.wikipedia.org/wiky/engine#Heat_engine";
        }

        public EngineException(int temperature, int oilPressure, string message, Exception innerException)
            : base(message, innerException)
        {
            SetValues(temperature, oilPressure);
        }

        protected EngineException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Temperature = (int) info.GetValue(nameof(this.Temperature), typeof (int));
            OilPresure = (int) info.GetValue(nameof(this.OilPresure), typeof (int));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Temperature), Temperature, typeof(int));
            info.AddValue(nameof(OilPresure), OilPresure, typeof(int));
        }

    public int Temperature { get; private set; }
        public int OilPresure { get; private set; }
        
    }
}