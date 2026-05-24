using algorytmy_i_struktury_danych;

// --- Przykład 1: PriorityList<double> z domyślnym porządkiem ---
{
    PriorityList<double> list = new PriorityList<double>();
    list.push(5.0);
    list.push(4.0);
    list.push(3.0);
    while (list.size() > 0)
    {
        System.Console.WriteLine(" > " + list.pop());
    }
}

// --- Przykład 2: PriorityList<string> z StringComparer.OrdinalIgnoreCase ---
PriorityList<string> ls = new PriorityList<string>(StringComparer.OrdinalIgnoreCase);
ls.push("CCC");
ls.push("ADA");
ls.push("aBA");
ls.push("AaA");
while (ls.size() != 0)
{
    System.Console.WriteLine("" + ls.pop());
}

// --- Przykład 3: IEnumerable — dwukrotny foreach i ręczny enumerator ---
{
    PriorityList<double> list = new PriorityList<double>();
    list.push(5.0); list.push(4.0); list.push(3.0);
    foreach (var s in list)
        Console.WriteLine(s);
    foreach (var s in list)
        Console.WriteLine(s);
    IEnumerator<string> i = ls.GetEnumerator();
    while (i.MoveNext())
    {
        Console.WriteLine(" >> {0}", i.Current);
    }
}

// --- Przykład 4: konstruktor (kolekcja, porządek) ---
{
    List<string> ll = new List<string>();
    ll.Add("BB"); ll.Add("AA");
    PriorityList<string> lista = new PriorityList<string>(ll, StringComparer.Ordinal);
    foreach (var s in lista)
        Console.WriteLine(s);
}
