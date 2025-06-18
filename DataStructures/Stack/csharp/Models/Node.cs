using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Models
{
    public class Node<T>
    {
        public T value;
        public Node<T> next;
        public Node<T> prev;

        public Node(T value)
        {
            this.value = value;
            this.next = null;
            this.prev = null;
        }
    }
}
