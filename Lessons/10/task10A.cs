using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._10
{
    public static class DurationMeasurer
    {
        public  static TimeSpan Measure(Action actionToMeasure)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            actionToMeasure.Invoke();
            watch.Stop();
            return watch.Elapsed;
        }
    }
}
