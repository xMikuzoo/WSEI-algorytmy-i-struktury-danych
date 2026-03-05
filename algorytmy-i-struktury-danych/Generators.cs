using System.Drawing;

namespace algorytmy_i_struktury_danych;

public static class Generators
{
    private static readonly Random Random = new Random();

    public static int[] GenerateRandom(int size)
    {
        var array = new int[size];
        for (var i = 0; i < size; i++)
            array[i] = Random.Next(0, 10000);
        return array;
    }

    public static int[] GenerateSorted(int size)
    {
        var array = GenerateRandom(size);
        Array.Sort(array);
        return array;
    }

    public static int[] GenerateReversed(int size)
    {
        var array = GenerateSorted(size);
        Array.Reverse(array);
        return array;
    }

    public static int[] GenerateAlmostSorted(int size)
    {
        var array = GenerateSorted(size);
        for (var i = 0; i < size / 20; i++)
        {
            int a = Random.Next(size), b = Random.Next(size);
            (array[a], array[b]) = (array[b], array[a]);
        }
        return array;
    }

    public static int[] GenerateFewUnique(int size)
    {
        int[] values = [1, 2, 3, 4, 5];
        var array = new int[size];
        for (var i = 0; i < size; i++)
            array[i] = values[Random.Next(values.Length)];
        return array;
    }
}