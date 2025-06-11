internal class Node(int value)
{
    internal int value = value;
    internal Node prevNode = null;
    internal Node nextNode = null;
}

internal class DoubleLinkedList
{
    private Node? first;
    private Node? last;
    private int n;
    private Node? head;

    public bool Insert(int value)
    {
        Node newNode = new(value);
        if (newNode == null)
            return false;

        Node? prevNode = null;
        Node? curNode = first;

        while(curNode != null && curNode.value < value)
        {
            prevNode = curNode;
            curNode = curNode.nextNode;
        }

        if(prevNode != null)
        {
            prevNode.nextNode = newNode;
        } 
        else
        {
            first = newNode;
        }
        newNode.nextNode = curNode;

        if(curNode != null)
        {
            curNode.prevNode = newNode;
        }
        else
        {
            last = newNode;
        }
        newNode.prevNode = prevNode;

        n++;
        return true;
    }

    public bool Remove(int value)
    {
        if(value == null)
        {
            return false;
        }

        Node? prevNode = null;
        Node? curNode = first;

        while (curNode != null && curNode.value < value)
        {
            prevNode = curNode;
            curNode = curNode.nextNode;
        }

        if (curNode.value != value)
        {
            return false;
        }

        if(prevNode != null)
        {
            prevNode.nextNode = curNode.nextNode;
        }
        else
        {
            first = curNode.nextNode;
        }

        if(curNode.nextNode != null)
        {
            curNode.nextNode.prevNode = prevNode;
        }
        else
        {
            last = curNode.prevNode;
        }

        n--;
        return true;
    }

    public Node? Search(int value)
    {
        if (value == null)
        {
            return null;
        }

        head = first;

        while (head != null && head.value < value && head.nextNode != null)
        {
            head = head.nextNode;
        }

        if(head.value == value)
        { 
            return head;
        }

        return null;
    }

    public Node? BinarySearch(int value)
    {
        if (value == null || n <= 0)
        {
            return null;
        }

        var bottom = 0;
        var last = n - 1;
        head = first;

        while (last >= bottom)
        {
            int middle = (bottom + last) / 2;

            for (var i = 0; i < middle; i++)
            {
                head = head.nextNode;

                if (head.value == value)
                {
                    return head;
                }
                else if (head.value < value)
                {
                    bottom = middle + 1;
                }
                else if (head.value > value)
                {
                    last = middle - 1;
                }
            }
        }

        return null;
    }

    public void Print()
    {
        Node? temp = first;
        while (temp != null)
        {
            Console.WriteLine($"prev: {temp.prevNode?.value} <- {temp.value} -> next {temp.nextNode?.value}");
            temp = temp.nextNode;
        }
        Console.WriteLine("");
    }
}

public class Program{
    static void Main()
    {
        DoubleLinkedList l = new();
        l.Insert(3);
        l.Insert(7);
        l.Insert(1);
        l.Insert(3);
        l.Insert(6);
        l.Insert(9);
        l.Insert(24);

        l.Print();

        Console.WriteLine("Removing some nodes...");

        l.Remove(1);
        l.Remove(9);
        l.Print();

        Console.WriteLine("Searching for a node 33...");
        Node? findThis = l.Search(33);

        if (findThis != null)
            Console.WriteLine(findThis?.value.ToString());
        else
            Console.WriteLine("Node not found =(");
        
        Console.WriteLine("Binary Searching for a node 24...");
        Node? findThis2 = l.BinarySearch(24);

        if(findThis2 != null)
            Console.WriteLine(findThis2?.value.ToString());
        else
            Console.WriteLine("Node not found =(");
    }
}

