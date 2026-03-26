namespace algorytmy_i_struktury_danych;
public static class Program
{
    public static void Main()
    {
        Node<int> head = 
            new Node<int>(2,
                new Node<int>(5,
                    new Node<int>(1)));
        AddAtEndOfSingleLinkedList<int>( -1, ref head);
        PrintSingleLinkedList<int>(head);
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

    public static void AddAtEndOfSingleLinkedList<T>(T element, ref Node<T> head)
    {
        if (head == null)
        {
            head = new Node<T>(element);
            return;
        }
        
        var current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = new Node<T>(element);
    }
}