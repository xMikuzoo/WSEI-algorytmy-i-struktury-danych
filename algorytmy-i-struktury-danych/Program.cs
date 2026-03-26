namespace algorytmy_i_struktury_danych;
public static class Program
{
    public static void Main()
    {
        Node<int> head1 = 
            new Node<int>(2,
                new Node<int>(5,
                    new Node<int>(1)));
        PrintSingleLinkedList<int>(head1);
    }

    public static void PrintSingleLinkedList<T>(Node<T> head)
    {
        var current = head;
        Console.Write("head -> ");
        while (current != null)
        {
            Console.Write(current);
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}