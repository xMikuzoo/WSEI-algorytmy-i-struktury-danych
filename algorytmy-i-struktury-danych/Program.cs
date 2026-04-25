// kompilator C# 7.1 (mono-Linux)
using System;

public class Program
{
    public static void Main()
    {
        // Solve1();   // //1 - najdłuższy ściśle rosnący spójny fragment
        Solve2();      // //2 - min. usunięć by reszta była niemalejąca
    }

    //1
    static void Solve1()
    {
        int n = ReadInt();
        if (n <= 0) { Console.WriteLine(0); return; }

        int best = 1;
        int cur = 1;
        int prev = ReadInt();

        for (int i = 1; i < n; i++)
        {
            int x = ReadInt();
            if (x > prev)
            {
                cur++;
                if (cur > best) best = cur;
            }
            else
            {
                cur = 1;
            }
            prev = x;
        }

        Console.WriteLine(best);
    }

    //2
    static void Solve2()
    {
        int n = ReadInt();
        if (n <= 0) { Console.WriteLine(0); return; }

        int[] tails = new int[n];
        int size = 0;

        for (int i = 0; i < n; i++)
        {
            int x = ReadInt();
            int lo = 0, hi = size;
            while (lo < hi)
            {
                int mid = (lo + hi) >> 1;
                if (tails[mid] <= x) lo = mid + 1;
                else hi = mid;
            }
            tails[lo] = x;
            if (lo == size) size++;
        }

        Console.WriteLine(n - size);
    }

    static int ReadInt()
    {
        int c, sign = 1, val = 0;
        do { c = Console.Read(); } while (c != -1 && (c < '0' || c > '9') && c != '-');
        if (c == -1) return 0;
        if (c == '-') { sign = -1; c = Console.Read(); }
        while (c >= '0' && c <= '9')
        {
            val = val * 10 + (c - '0');
            c = Console.Read();
        }
        return sign == 1 ? val : -val;
    }
}
