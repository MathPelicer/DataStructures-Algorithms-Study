using Stack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class MyStack<T>
    {
        public int stackSize;
        public Node<T> firstNode;
        public Node<T> lastNode;

        public MyStack()
        {
            this.stackSize = 0;
            this.firstNode = null;
            this.lastNode = null;
        }

        public void Insert(T newNodeValue)
        {
            Node<T> newNode = new(newNodeValue);

            if (firstNode == null && lastNode == null)
            {
                firstNode = newNode;
                lastNode = newNode;
                stackSize++;

                return;
            }

            lastNode.next = newNode;
            newNode.prev = lastNode;
            lastNode = newNode;
            stackSize++;
        }

        public void Remove()
        {
            if (lastNode == null)
            {
                return;
            }

            lastNode = lastNode.prev;
            lastNode.next = null;
            stackSize--;
        }

        public void printStack()
        {
            var curNode = firstNode;

            while (curNode != null)
            {
                Console.Write($"{curNode.value} ");
                curNode = curNode.next;
            }
            Console.WriteLine("");
        }
    }
}
