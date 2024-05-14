package main

import (
	"fmt"
)

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

	curNode := linkedList.head

	for curNode.next != nil {
		curNode = curNode.next
	}

	curNode.next = &Node{value: value, next: nil}

	linkedList.len++
}

func (linkedList *LinkedList) remove(value int) {
	if linkedList.head != nil && linkedList.head.value == value {
		linkedList.head = linkedList.head.next

		linkedList.len--
		return
	}

	curNode := linkedList.head

	for curNode.next != nil {
		if curNode.next.value == value {
			curNode.next = curNode.next.next

			linkedList.len--
			return
		}
		curNode = curNode.next
	}
}

func search() {

}

func (linkedList *LinkedList) print() {
	if linkedList.len == 0 {
		return
	}

	curNode := linkedList.head
	fmt.Printf("%d -> ", curNode.value)

	for curNode.next != nil {
		curNode = curNode.next
		fmt.Printf("%d -> ", curNode.value)
	}

	fmt.Println()
}

func main() {
	linkedList := &LinkedList{}

	linkedList.add(5)
	linkedList.add(7)
	linkedList.add(8)

	linkedList.print()
	linkedList.remove(7)
	linkedList.remove(8)

	linkedList.print()
}
