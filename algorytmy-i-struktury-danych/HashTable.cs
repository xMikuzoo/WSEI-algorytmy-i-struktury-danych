namespace algorytmy_i_struktury_danych;

public class HashTable
{
    private readonly List<string>[] _buckets;
    private int _count;

    public HashTable(int size)
    {
        Size = size;
        _buckets = new List<string>[size];
        for (int i = 0; i < size; i++)
            _buckets[i] = new List<string>();
        _count = 0;
        GetHashFunction = phone =>
        {
            int sum = 0;
            foreach (char c in phone) sum += (c - '0');
            return sum % Size;
        };
    }

    public bool Add(string phoneNumber)
    {
        int h = GetHashFunction(phoneNumber);
        if (_buckets[h].Contains(phoneNumber)) return false;
        _buckets[h].Add(phoneNumber);
        _count++;
        return true;
    }

    public bool Remove(string phoneNumber)
    {
        int h = GetHashFunction(phoneNumber);
        if (_buckets[h].Remove(phoneNumber))
        {
            _count--;
            return true;
        }
        return false;
    }

    public bool Contains(string phoneNumber, out int index)
    {
        int h = GetHashFunction(phoneNumber);
        index = _buckets[h].IndexOf(phoneNumber);
        return index != -1;
    }

    public IEnumerable<string> GetPhoneNumbers(int index)
    {
        var sorted = new List<string>(_buckets[index]);
        sorted.Sort(StringComparer.Ordinal);
        return sorted;
    }

    public Func<string, int> GetHashFunction { get; }
    public int Size { get; }
    public int Count => _count;
    public double LoadFactor => Math.Round((double)_count / Size, 2);

    public string Dump()
    {
        var sb = new System.Text.StringBuilder();
        for (int i = 0; i < Size; i++)
        {
            if (_buckets[i].Count == 0) continue;
            var sorted = new List<string>(_buckets[i]);
            sorted.Sort(StringComparer.Ordinal);
            sb.Append(i).Append(": ").Append(string.Join(", ", sorted)).Append('\n');
        }
        return sb.ToString();
    }
}