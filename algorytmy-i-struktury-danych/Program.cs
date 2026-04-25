// kompilator C# 7.1 (mono-Linux)
using System;

public class Program
{
    public static void Main()
    {
        //1
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

    //1
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
