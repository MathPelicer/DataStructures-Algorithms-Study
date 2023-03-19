using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Interfaces
{
    public interface ILinkedList<T>
    {
        public void Insert(T value);
        public void Remove(T value);
        public void Print();
    }
}
