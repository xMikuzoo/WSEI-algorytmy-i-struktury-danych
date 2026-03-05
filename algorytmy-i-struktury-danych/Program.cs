using BenchmarkDotNet.Running;

namespace algorytmy_i_struktury_danych
{
    class Program 
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ArraySortingBenchmark>();
            Console.WriteLine(summary); 
        }
    }
}