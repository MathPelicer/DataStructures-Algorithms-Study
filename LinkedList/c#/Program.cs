using LinkedList;

MyLinkedList<int> l = new();
l.Insert(3);
l.Insert(7);
l.Insert(1);
l.Insert(3);
l.Insert(6);
l.Insert(9);
l.Insert(24);

l.Print();

l.Remove(1);
l.Remove(9);
l.Remove(24);
l.Print();

