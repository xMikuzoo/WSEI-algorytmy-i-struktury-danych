using BenchmarkDotNet.Attributes;

namespace algorytmy_i_struktury_danych;

[ShortRunJob]
[MemoryDiagnoser]
public class ArraySortingBenchmark
{
    [Params(100,1000,10000)]
    public int Size { get; set; }
    
    [Params("Random", "Sorted", "Reversed", "AlmostSorted", "FewUnique")]
    public required string DataType { get; set; }

    private int[] _data = [];
    
    [GlobalSetup]
    public void Setup()
    {
        _data = DataType switch
        {
            "Random"      => Generators.GenerateRandom(Size),
            "Sorted"      => Generators.GenerateSorted(Size),
            "Reversed"    => Generators.GenerateReversed(Size),
            "AlmostSorted"=> Generators.GenerateAlmostSorted(Size),
            "FewUnique"   => Generators.GenerateFewUnique(Size),
            _             => throw new ArgumentException("Nieznany typ danych")
        };
    }

    [Benchmark(Baseline = true)]
    public void QuickSort()
    {
        var arr = (int[])_data.Clone();
        SortingAlgorithms.QuickSort(arr);
    }
    
    [Benchmark]
    public void InsertionSort()
    {
        var arr = (int[])_data.Clone();
        SortingAlgorithms.InsertionSort(arr);
    }

    [Benchmark]
    public void MergeSort()
    {
        var arr = (int[])_data.Clone();
        SortingAlgorithms.MergeSort(arr, 0, arr.Length - 1);
    }

    [Benchmark]
    public void QuickSortClassical()
    {
        var arr = (int[])_data.Clone();
        SortingAlgorithms.QuickSortClassical(arr, 0, arr.Length - 1);
    }
}