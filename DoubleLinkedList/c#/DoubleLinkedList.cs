internal class Node{
    internal int value;
    internal Node prevNode;
    internal Node nextNode;

    public Node(int value)
    {
        this.value = value;
        this.prevNode = null;
        this.nextNode = null;
    }   
}

internal class DoubleLinkedList
{
    private Node first;
    private Node last;
    private int n;
    private Node head;

    public bool insert(int value)
    {
        Node newNode = new Node(value);
        if (newNode == null)
            return false;

        Node prevNode = null;
        Node curNode = first;

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

        n = n + 1;
        return true;
    }

    public bool remove(int value)
    {
        if(value == null)
        {
            return false;
        }

        Node prevNode = null;
        Node curNode = first;

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

        n = n - 1;
        return true;
    }

    public Node search(int value)
    {
        if (value == null)
        {
            return null;
        }

        Node prevNode = null;
        Node curNode = first;

        while (curNode != null && curNode.value < value && curNode.nextNode != null)
        {
            prevNode = curNode;
            curNode = curNode.nextNode;
        }

        if(curNode.value == value)
        { 
            return curNode;
        }

        return null;
    }

    public void print()
    {
        Node temp = first;
        while(temp != null)
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
        l.insert(3);
        l.insert(7);
        l.insert(1);
        l.insert(3);
        l.insert(6);
        l.insert(9);
        l.insert(24);

        l.print();

        System.Console.WriteLine("Removing some nodes...");

        l.remove(1);
        l.remove(9);
        l.remove(24);
        l.print();
        
        System.Console.WriteLine("Searching for a node...");
        Node? findThis = l.search(33);

        if(findThis != null)
            Console.WriteLine(findThis?.value.ToString());
        Console.WriteLine("Node not found =(");
    }
}

