internal class Node<T>
{
    internal T value;
    internal Node<T>? next;

    public Node(T value)
    {
        this.value = value;
        this.next = null;
    }
}

internal class Queue<T>
{
    private Node<T>? firstNode;
    private Node<T>? lastNode;
    private int queueSize;

    public void Enqueue(T value)
    {
        Node<T> curNode = new(value);

        if(queueSize > 0)
        {
            lastNode.next = curNode;
        } else
        {
            firstNode = curNode;
        }

        lastNode = curNode;
        queueSize++;
    }

    public void Dequeue()
    {
        if(queueSize == 0)
        {
            return;
        }

        firstNode = firstNode.next;
        queueSize--;
    }

    public void printQueue()
    {
        var curNode = firstNode;

        while(curNode != null)
        {
            Console.Write($"{curNode.value} ");
            curNode = curNode.next;
        }
        Console.WriteLine("");
    }
}

public class Program
{
    static void Main()
    {
        Queue<int> queue = new();
        queue.Dequeue();
        queue.Enqueue(1);
        queue.Enqueue(3);
        queue.Enqueue(5);
        queue.Enqueue(7);
        queue.Enqueue(9);
        queue.printQueue();
        queue.Dequeue();
        queue.Dequeue();
        queue.printQueue();
    }
    
}