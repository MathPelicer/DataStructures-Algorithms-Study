package main

import "fmt"

type DoubleLinkedList struct {
	len   int
	head  *Node
	first *Node
	last  *Node
}

type Node struct {
	value int
	prev  *Node
	next  *Node
}

func (dlList *DoubleLinkedList) addOrdered(value int) {
	newNode := &Node{value: value, next: nil, prev: nil}

	if dlList.first == nil {
		dlList.first = newNode
		dlList.last = newNode
		dlList.head = newNode
		dlList.len++
		return
	}

	dlList.head = dlList.first
	prevNode := dlList.head.prev

	for dlList.head != nil && dlList.head.value < value {
		prevNode = dlList.head
		dlList.head = dlList.head.next
	}

	if prevNode == nil {
		dlList.first = newNode
	} else {
		prevNode.next = newNode
	}
	newNode.next = dlList.head

	if dlList.head == nil {
		dlList.last = newNode
	} else {
		dlList.head.prev = newNode
	}

	newNode.prev = prevNode

	dlList.len++
}

func (dlList *DoubleLinkedList) addNonOrdered(value int) {
	newNode := &Node{value: value, next: nil, prev: nil}

	if dlList.first == nil {
		dlList.first = newNode
		dlList.last = newNode
		dlList.head = newNode
		dlList.len++
		return
	}

	dlList.head = dlList.last

	dlList.head.next = newNode
	newNode.prev = dlList.head
	dlList.last = newNode
	dlList.len++
}

func (dlList *DoubleLinkedList) remove(value int) bool {
	dlList.head = dlList.first
	prevNode := dlList.head.prev

	for dlList.head != nil && dlList.head.value < value {
		prevNode = dlList.head
		dlList.head = dlList.head.next
	}

	if dlList.head.value != value {
		return false
	}

	if prevNode == nil {
		dlList.first = dlList.head.next
	} else {
		prevNode.next = dlList.head.next
	}

	if dlList.head.next == nil {
		dlList.last = prevNode
	} else {
		dlList.head.next.prev = prevNode
	}

	dlList.len--
	return true
}

func (dlList *DoubleLinkedList) search(value int) bool {
	dlList.head = dlList.first

	for dlList.head != nil && dlList.head.value < value && dlList.head.next != nil {
		dlList.head = dlList.head.next
	}

	return dlList.head.value == value
}

func (dlList *DoubleLinkedList) print() {
	dlList.head = dlList.first
	if dlList.len == 0 {
		return
	}

	fmt.Printf(" <- %d -> ", dlList.head.value)

	for dlList.head.next != nil {
		dlList.head = dlList.head.next
		fmt.Printf(" <- %d -> ", dlList.head.value)
	}
}

func main() {
	dlList := &DoubleLinkedList{}

	dlList.addOrdered(1)
	dlList.addOrdered(4)
	dlList.addOrdered(3)
	dlList.addOrdered(2)
	dlList.addNonOrdered(2)
	dlList.addNonOrdered(2)

	dlList.remove(2)

	dlList.print()
}
