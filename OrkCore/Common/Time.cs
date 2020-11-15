using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine
{
    public class Time
    {
        
        public const long SECOND = 1000000000L;

        public static double GetTime()
        {
            return (double)nanoTime() / (double)SECOND;
        }


        public static long nanoTime()
        {
            long nano = 10000L * Stopwatch.GetTimestamp();
            nano /= TimeSpan.TicksPerMillisecond;
            nano *= 100L;
            return nano;
            
        }
    }
}
