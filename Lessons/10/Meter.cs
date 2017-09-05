using System;

namespace Lessons._10
{
    public static class Meter
    {
        public static TimeSpan Measure(Action actionToMeasure)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            actionToMeasure.Invoke();
            watch.Stop();
            return watch.Elapsed;
        }
    }
}