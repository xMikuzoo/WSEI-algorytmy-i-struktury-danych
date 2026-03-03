namespace algorytmy_i_struktury_danych;

public static class Program
{
    public static void Main()
    {
        var input = Console.ReadLine();
        var parts = input?.Split();
        var n = int.Parse(parts?[0] ?? "");    
        var m = int.Parse(parts?[1] ?? "");
        var count = 0;
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
}