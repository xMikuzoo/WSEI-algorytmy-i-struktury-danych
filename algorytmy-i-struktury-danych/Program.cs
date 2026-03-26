namespace algorytmy_i_struktury_danych;
public static class Program
{
    public static void Main()
    {
        var head = CreateSingleLinkedList<int>(new int[] {1, 2, 3, 4} );
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

    public static Node<T> CreateSingleLinkedList<T>(params T[] arr)
    {
        if (arr == null || arr.Length == 0)
        {
            return null;
        }
        var head = new Node<T>(arr[0]);
        var current = head;
        for (int i = 1; i < arr.Length; i++)
        {
            current.Next = new Node<T>(arr[i]);
            current = current.Next;
        }
        return head;
    }
}