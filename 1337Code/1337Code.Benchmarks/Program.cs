using BenchmarkDotNet.Running;

namespace _1337Code.Benchmarks
{
    class Program
    {
        static void Main(string[] args) =>
            BenchmarkSwitcher
                .FromAssembly(typeof(Program).Assembly)
                .Run(args);
    }
}
