using System.Collections;

namespace algorytmy_i_struktury_danych;

public class PriorityList<T> : IEnumerable<T> where T : IComparable<T>
{
    private readonly LinkedList<T> _items = new();
    private readonly IComparer<T> _comparer;

    public PriorityList()
    {
        _comparer = Comparer<T>.Default;
    }

    public PriorityList(IComparer<T> comparer)
    {
        ArgumentNullException.ThrowIfNull(comparer);
        _comparer = comparer;
    }

    public PriorityList(IEnumerable<T> source, IComparer<T> comparer) : this(comparer)
    {
        ArgumentNullException.ThrowIfNull(source);
        foreach (var item in source) push(item);
    }

    public void push(T item)
    {
        for (var node = _items.First; node is not null; node = node.Next)
        {
            if (_comparer.Compare(node.Value, item) > 0)
            {
                _items.AddBefore(node, item);
                return;
            }
        }
        _items.AddLast(item);
    }

    public T? pop()
    {
        if (_items.First is null) return default;
        var value = _items.First.Value;
        _items.RemoveFirst();
        return value;
    }

    public int size() => _items.Count;

    public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
