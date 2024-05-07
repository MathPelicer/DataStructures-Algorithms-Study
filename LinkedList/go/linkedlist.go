package linkedlist

type LinkedList struct {
	len  int
	head *Node
}

type Node struct {
	value int
	next  *Node
}

func (linkedList *LinkedList) add(value int) {
	if linkedList.head == nil {
		curNode := &Node{value: value, next: nil}

		linkedList.head = curNode
		linkedList.len++
		return
	}

	// rest
}

func (linkedList *LinkedList) remove() {

}

func search() {

}

func print() {

}

func main() {
	linkedList := &LinkedList{}

	linkedList.add(5)
}
