using LinkedList.Interfaces;
using LinkedList.Models;

namespace LinkedList
{
    public class MyLinkedList<T> : ILinkedList<T>
    {
        private int size;
        private Node<T> firstNode;
        private Node<T> lastNode;
        public MyLinkedList()
        {
            this.size = size;
            this.firstNode = null;
            this.lastNode = null;
        }

        public void Insert(T value)
        {
            Node<T> newNode = new(value);

            if(size == 0)
            {
                firstNode = newNode;
                lastNode = newNode;
                size++;
                return;
            }

            lastNode.next = newNode;
            lastNode = lastNode.next;
            size++;
            return;
        }

        public void Remove(T value)
        {
            Node<T> curNode = firstNode;
            Node<T> prevNode = null;

            while (curNode != null)
            {
                if (curNode.value.Equals(value))
                {
                    prevNode.next = curNode.next;
                    size--;
                    return;
                }

                prevNode = curNode;
                curNode = curNode.next;
            }

            return;
        }

        public void Print()
        {
            Node<T> temp = firstNode;
            while (temp != null)
            {
                Console.WriteLine(temp.value);
                temp = temp.next;
            }
            Console.WriteLine("");
        }
    }
}
