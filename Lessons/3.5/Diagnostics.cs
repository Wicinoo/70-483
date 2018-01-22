using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            TraceSource traceSource = new TraceSource("myTraceSource", SourceLevels.Critical);
            traceSource.TraceInformation("This is TraceInformation message");
            traceSource.TraceEvent(TraceEventType.Critical, 0, "This is TraceEvent with Critical type");
            traceSource.TraceData(TraceEventType.Information, 0, new object[] {"a", "b", "c"});
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
