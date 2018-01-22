using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._3._5
{
    public class Diagnostics
    {
        public static void Run()
        {
            Debug();

            TraceSourceBasicExample();

            ExamExample();
            ReallExample();
        }

        private class ActivityTracerScope : IDisposable
        {
            private readonly Guid oldActivityId;
            private readonly Guid newActivityId;
            private readonly TraceSource ts;
            private readonly string activityName;
            
            public ActivityTracerScope(TraceSource ts, string activityName)
            {
                this.ts = ts;
                this.oldActivityId = Trace.CorrelationManager.ActivityId;
                this.activityName = activityName;

                this.newActivityId = Guid.NewGuid();

                if (this.oldActivityId != Guid.Empty)
                {
                    ts.TraceTransfer(0, "Transfering to new activity...", this.newActivityId);
                }
                Trace.CorrelationManager.ActivityId = newActivityId;
                ts.TraceEvent(TraceEventType.Start, 0, activityName);
            }

            public void Dispose()
            {
                if (this.oldActivityId != Guid.Empty)
                {
                    ts.TraceTransfer(0, "Transfering back to old activity...", oldActivityId);
                }
                ts.TraceEvent(TraceEventType.Stop, 0, activityName);
                Trace.CorrelationManager.ActivityId = oldActivityId;
            }
        };

        private static void ReallExample()
        {
            //https://www.codeproject.com/Articles/185666/ActivityTracerScope-Easy-activity-tracing-with

            //add new listener 
            Stream stream = File.Create("TraceFile.txt");
            TextWriterTraceListener textWriterTraceListener = new TextWriterTraceListener(stream);

            //var ts = new TraceSource("TestTraceSource", SourceLevels.ActivityTracing);
            var ts = new TraceSource("TestTraceSource", SourceLevels.All);
            ts.Listeners.Add(textWriterTraceListener);

            using (var acs = new ActivityTracerScope(ts, "Main activity"))
            {
                ts.TraceEvent(TraceEventType.Information, 0, "Information event 1");
                using (new ActivityTracerScope(ts, "SubActivity 1"))
                {
                    ts.TraceEvent(TraceEventType.Information, 0, "Another information event 1");
                }

                using (new ActivityTracerScope(ts, "SubActivity 2"))
                {
                    ts.TraceEvent(TraceEventType.Information, 0, "Another information event 2");
                    ts.TraceEvent(TraceEventType.Information, 0, "Another information event 3");
                    ts.TraceEvent(TraceEventType.Warning, 0, "WARNING MESSAGE");
                }
            }
            ts.Flush();
            ts.Close();
        }

        private static void ExamExample()
        {
            TraceSource ts = new TraceSource("TestApplication", SourceLevels.ActivityTracing);
            var originalId = Trace.CorrelationManager.ActivityId;
            try
            {
                var guid = Guid.NewGuid();
                ts.TraceTransfer(1, "Changing Activity", guid);
                Trace.CorrelationManager.ActivityId = guid;
                ts.TraceEvent(TraceEventType.Start, 0, "Start");
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                ts.TraceTransfer(1, "Changing Activity", originalId);
                ts.TraceEvent(TraceEventType.Stop, 0, "Stop");
                Trace.CorrelationManager.ActivityId = originalId;
            }
        }

        private static void TraceSourceBasicExample()
        {
            //when we use level on top, others will not be saved (in this case information levels)
            TraceSource traceSource = new TraceSource("myTraceSource", SourceLevels.Critical);
            traceSource.TraceInformation("This is TraceInformation message");
            traceSource.TraceEvent(TraceEventType.Critical, 0, "This is TraceEvent with Critical type");
            traceSource.TraceData(TraceEventType.Information, 0, new object[] { "a", "b", "c" });
            traceSource.Flush();
            traceSource.Close();
        }

        private static void Debug()
        {
            System.Diagnostics.Debug.WriteLine("This is debug message information");

            //Debug.Assert(false,"This is Debug.Assert");

            System.Diagnostics.Debug.WriteLine("This is structured output");
            System.Diagnostics.Debug.Indent();
            System.Diagnostics.Debug.WriteLine("First indent");
            System.Diagnostics.Debug.WriteLine("Second indent");
            System.Diagnostics.Debug.Indent();
            System.Diagnostics.Debug.WriteLine("First.First indent");
            System.Diagnostics.Debug.Unindent();
            System.Diagnostics.Debug.Unindent();


            System.Diagnostics.Debug.Print("print message");
            //Debug.Fail("This is fail");
        }
    }
}
