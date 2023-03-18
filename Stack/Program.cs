using Stack;

internal class Program
{
    private static void Main(string[] args)
    {
        MyStack<int> stack = new();
        stack.Insert(1);
        stack.Insert(1);
        stack.Insert(3);
        stack.Insert(5);
        stack.Insert(7);
        stack.Insert(9);
        stack.printStack();
        stack.Remove();
        stack.Remove();
        stack.printStack();
    }
}