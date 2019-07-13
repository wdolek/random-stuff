using System.Linq;
using _1337Code.SortArrayByParity;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace _1337Code.Benchmarks
{
    [BenchmarkCategory("Sort array by parity")]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class SortArrayByParity
    {
        private ParityArraySortator _sortator = new ParityArraySortator();
        private int[] _data;

        [Params(4, 128, 512)]
        public int InputSize;

        [GlobalSetup]
        public void Setup()
        {
            var rnd = new Bogus.Randomizer();
            _data = Enumerable
                .Range(0, InputSize)
                .Select(_ => rnd.Number(0, 100))
                .ToArray();
        }

        [Benchmark(Description = "In place", Baseline = true)]
        public int[] SortBySwap() => _sortator.SortArrayByParityInPlace(_data);

        [Benchmark(Description = "In place, unsafe")]
        public int[] SortBySwapUnsafe() => _sortator.SortArrayByParityUnsafe(_data);

        [Benchmark(Description = "In place, ref")]
        public int[] SortBySwapRefs() => _sortator.SortArrayByParityRefs(_data);

        [Benchmark(Description = "In place, ref Span<T>")]
        public int[] SortBySwapRefSpan() => _sortator.SortArrayByParityRefSpan(_data);

        [Benchmark(Description = "LINQ")]
        public int[] SortUsingLinq() => _sortator.SortArrayByParity(_data);
    }
}
