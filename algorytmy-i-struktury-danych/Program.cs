namespace algorytmy_i_struktury_danych;
public static class Program
{
    public static void Main()
    {
        var head = CreateSingleLinkedList<int>(1, 1, 2, 2, 2, 5, 6);
        PrintSingleLinkedList<int>(head);
        RemoveAllDuplicatesFromSortedLinkedList<int>(ref head);
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

    public static Node<T> ReverseSingleLinkedList<T>(Node<T> head)
    {
        var current = head;
        Node<T> previous = null;
        while (current != null)
        {
            var next = current.Next;
            current.Next = previous;
            previous = current;
            current = next;
        }
        return previous;
    }

    public static void MoveLastNodeToFront<T>(ref Node<T> head)
    {
        if (head == null || head.Next == null)
        {
            return;
        }
        
        var current  = head;
        while(current.Next.Next != null)
        {
            current = current.Next;
        }
        var last = current.Next;
        current.Next = null;
        last.Next = head;
        head = last;
    }

    public static void RemoveNodeAt<T>(int position, ref Node<T> head)
    {
        if (head == null)
        {
            return;
        }
        
        var current = head;

        if (position == 0)
        {
            head = current.Next;
            return;
        }
        
        int index = 0;
        while (current != null && index != position - 1)
        {   
            current = current.Next;
            index++;
        }
        if (current == null)
        {
            return;
        }
        if(current.Next == null)
        {
            return;
        }
        current.Next = current.Next.Next;
    }

    public static void RemoveAllDuplicatesFromSortedLinkedList<T>(ref Node<T> head)
        where T : IEquatable<T>, IComparable<T>
    {
        if (head == null)
        {
            return;
        }
        var temp = new Node<T>( default(T) , head);
        var previous = temp;

        while (previous.Next != null)
        {
            Node<T> current = previous.Next;
            bool duplicate = false;

            while (current.Next != null && current.Data.Equals(current.Next.Data))
            {
                current = current.Next;
                duplicate = true;
            }

            if (duplicate)
            {
                previous.Next = current.Next;
            }
            else
            {
                previous = previous.Next;
            }
        }

        head = temp.Next;
    }
}