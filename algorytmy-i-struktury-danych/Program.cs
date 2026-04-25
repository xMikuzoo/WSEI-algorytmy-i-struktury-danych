using System;
using System.Diagnostics;
using algorytmy_i_struktury_danych;

class Program
{
    const int N = 101;
    const int MAX_PROBES = 20;

    static string?[] table = new string?[N];
    static bool[] deleted = new bool[N];

    static int Hash(string key)
    {
        long sum = 0;
        for (int i = 0; i < key.Length; i++)
            sum += (long)key[i] * (i + 1);
        long h = 19L * sum % N;
        if (h < 0) h += N;
        return (int)h;
    }

    static int Probe(int baseHash, int j)
    {
        long p = ((long)baseHash + (long)j * j + 23L * j) % N;
        if (p < 0) p += N;
        return (int)p;
    }

    static void Insert(string key)
    {
        int b = Hash(key);
        int firstTomb = -1;

        for (int j = 0; j < MAX_PROBES; j++)
        {
            int p = Probe(b, j);

            if (table[p] != null)
            {
                if (table[p].Equals(key, StringComparison.Ordinal))
                    return;
                continue;
            }

            if (deleted[p])
            {
                if (firstTomb == -1) firstTomb = p;
                continue;
            }

            int target = (firstTomb != -1) ? firstTomb : p;
            table[target] = key;
            deleted[target] = false;
            return;
        }

        if (firstTomb != -1)
        {
            table[firstTomb] = key;
            deleted[firstTomb] = false;
        }
    }

    static void Delete(string key)
    {
        int b = Hash(key);
        for (int j = 0; j < MAX_PROBES; j++)
        {
            int p = Probe(b, j);

            if (table[p] == null)
            {
                if (deleted[p]) continue;
                return;
            }

            if (table[p].Equals(key, StringComparison.Ordinal))
            {
                table[p] = null;
                deleted[p] = true;
                return;
            }
        }
    }

    static void Main()
    {
        // int n = int.Parse(Console.ReadLine().Trim());
        // for (int i = 0; i < n; i++)
        // {
        //     string line = Console.ReadLine();
        //     if (line == null) break;
        //     int colon = line.IndexOf(':');
        //     if (colon < 0) continue;
        //     string op = line.Substring(0, colon);
        //     string key = line.Substring(colon + 1);
        //     if (op == "INSERT") Insert(key);
        //     else if (op == "DELETE") Delete(key);
        // }
        //
        // int count = 0;
        // for (int i = 0; i < N; i++) if (table[i] != null) count++;
        // Console.WriteLine(count);
        // for (int i = 0; i < N; i++)
        //     if (table[i] != null)
        //         Console.WriteLine(i + ":" + table[i]);
        
        var hashTable = new HashTable(5);
        hashTable.Add("123");
        hashTable.Add("456");
        hashTable.Add("321");
        hashTable.Add("234");
        hashTable.Add("123");
        hashTable.Add("00569");
        Console.WriteLine( string.Join(", ", hashTable.GetPhoneNumbers(0)) );
        Console.WriteLine( string.Join(", ", hashTable.GetPhoneNumbers(1)) );
        Console.WriteLine( string.Join(", ", hashTable.GetPhoneNumbers(2)) );

        int index;
        Debug.Assert(hashTable.Contains("123", out index) == true);
        Debug.Assert(index == 0);

        Console.WriteLine(hashTable.Dump());

        hashTable.Remove("123");
        Console.WriteLine(hashTable.Dump());

        hashTable.Remove("321");
        Console.WriteLine(hashTable.Dump());
    }
}