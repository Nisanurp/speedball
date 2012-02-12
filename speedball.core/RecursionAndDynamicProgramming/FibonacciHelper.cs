using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace speedball.core.RecursionAndDynamicProgramming
{
    public static class FibonacciHelper
    {
        // sucks: runtime is exponential: O(2^n)
        public static int GetFibonacciNumber(int i)
        {
            if (i == 0) return 0;
            if (i == 1) return 1;
            return GetFibonacciNumber(i - 1) + GetFibonacciNumber(i - 2);
        }

        // runtime is linear: O(n)
        private static Dictionary<int, int> fib = new Dictionary<int, int>();
        public static int GetFibonacciNumberBetter(int i)
        {
            if (i == 0) return 0;
            if (i == 1) return 1;
            if (fib.ContainsKey(i)) return fib[i];  // return cached result

            fib[i] = GetFibonacciNumberBetter(i - 1) + GetFibonacciNumberBetter(i - 2); // cache result

            return fib[i];
        }

        public static void Run()
        {
            var input = 42;
            var timer = new System.Diagnostics.Stopwatch();
            timer.Start();
            var result = GetFibonacciNumber(input);
            timer.Stop();

            Console.WriteLine("The {0}th fibonacci number is {1} and it was calculated in {2:00}:{3:00}:{4:00}.{5:00}",
            input, result, timer.Elapsed.Hours, timer.Elapsed.Minutes, timer.Elapsed.Seconds, timer.Elapsed.Milliseconds / 10);
            Console.WriteLine("");

            timer.Reset();
            result = GetFibonacciNumberBetter(input);
            timer.Stop();

            Console.WriteLine("The {0}th fibonacci number (better algorithm) is {1} and it was calculated in {2:00}:{3:00}:{4:00}.{5:00}",
            input, result, timer.Elapsed.Hours, timer.Elapsed.Minutes, timer.Elapsed.Seconds, timer.Elapsed.Milliseconds / 10);
        }
    }
}
