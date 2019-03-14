using NBench;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBenchDemo
{
    public class SimpleCache<T>
    {
        private readonly List<T> cache = new List<T>();

        public void Add(T item)
        {
            if (!Contains(item))
                cache.Add(item);
        }

        public bool Contains(T item)
        {
            return cache.Contains(item);
        }
    }
    
   public class CacheTest
    {
        private SimpleCache<string> cache = new SimpleCache<string>();

        [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Test,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]
        public void Add_Benchmark_Performance()
        {
            for (var i = 0; i < 100; i++)
            {
                cache.Add(i.ToString());
            }
        }
    }
}
