using System;

namespace algorytmy_i_struktury_danych;

public static class Program
{
    public static void Main()
    {
        RunEuclidisFormula();

        void RunEuclidisFormula()
        {
            var count = 0;
            var (n, m) = ReadInput();

            for (var p = 2; p * p <= m; p++)
            {
                for (var q = 1; q < p; q++)
                {
                    if (!BothOdd(p, q) && GreatestCommonDivisor(p, q) == 1)
                    {
                        var a = (p * p) - (q * q);
                        var b = 2 * p * q;
                        var c = (p * p) + (q * q);

                        for (var k = 1; k * c <= m; k++)
                        {
                            var ka = k * a;
                            var kb = k * b;
                            var kc = k * c;

                            if (ka >= n && ka <= m && kb >= n && kb <= m && kc >= n && kc <= m)
                                count++;
                        }
                    }
                }
            }

            Console.WriteLine(count);

            int GreatestCommonDivisor(int a, int b) => b == 0 ? a : GreatestCommonDivisor(b, a % b);
            bool BothOdd(int a, int b) => (a % 2 == 1) && (b % 2 == 1);
        }

        void RunFirstSolution()
        {
            var count = 0;
            var (n, m) = ReadInput();

            for(var a = n; a <= m; a++)
            {
                for(var b = a; b <= m; b++)
                {
                    var cSquared = (a * a) + (b * b) ;
                    var c = (int)Math.Sqrt(cSquared);
                    if (c <= m && c * c == cSquared)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }

        (int, int) ReadInput()
        {
            var input = Console.ReadLine();
            var parts = input?.Split();
            var n = int.Parse(parts?[0] ?? "");
            var m = int.Parse(parts?[1] ?? "");
            return (n, m);
        }
    }
}