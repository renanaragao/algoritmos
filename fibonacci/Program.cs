using System;
using System.Diagnostics;

namespace fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var before0 = GC.CollectionCount(0);
            var before1 = GC.CollectionCount(1);
            var before2 = GC.CollectionCount(2);

            var sw = new Stopwatch();
            sw.Start();

            Console.WriteLine($"Result = {fib2(200)}");

            sw.Stop();
            Console.WriteLine($"Time: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine($"# Gen0: {GC.CollectionCount(0) - before0}");
            Console.WriteLine($"# Gen1: {GC.CollectionCount(1) - before1}");
            Console.WriteLine($"# Gen2: {GC.CollectionCount(2) - before2}");
        }

        private static int fib2(int n)
        {
            if(n == 0) return n;

            var vetor = new int[n];
            vetor[0] = 0;
            vetor[1] = 1;

            for (int i = 2; i < n; i++)
            {
                vetor[i] = vetor[i - 1] + vetor[i - 2];
            }

            return vetor[n - 1];
        }
    }
}
