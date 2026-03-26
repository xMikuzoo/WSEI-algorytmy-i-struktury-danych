namespace algorytmy_i_struktury_danych;

public class Node<T>
{    
    public T Data {get; set;}
    public Node<T> Next {get; set;}
    public Node(T data, Node<T> next = null) {
        Data = data; Next = next;
    }
    public override string ToString() => (this==null)? "null" : $"{Data} -> ";
}