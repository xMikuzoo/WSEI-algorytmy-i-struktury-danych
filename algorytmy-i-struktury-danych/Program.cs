using System;

class Program {
    static void Main() {
        var parts = Console.ReadLine().Split();
        long n = long.Parse(parts[0]);
        long m = long.Parse(parts[1]);
        long k = long.Parse(parts[2]);
        
        long res = 0;
        long fullModLimit = Math.Min(k - 1, n);
        for (long j = 2; j <= fullModLimit; j++) {
            res = (res + k) % j;
        }
        long subStart = Math.Max(k, 2);
        for (long j = subStart; j <= n; j++) {
            res += k;
            if (res >= j) res -= j;
        }
        
        long ans = (res + m - 1) % n + 1;
        Console.WriteLine(ans);
    }
}