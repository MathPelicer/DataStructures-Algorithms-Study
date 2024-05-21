package main

import "fmt"

type Queue struct {
	len   int
	first *Node
	last  *Node
}

type Node struct {
	value int
	next  *Node
}

func (queue *Queue) Enqueue(value int) {
	if queue.first == nil {
		newNode := &Node{value: value, next: nil}
		queue.first = newNode
		queue.last = newNode

		queue.len++
		return
	}

	lastNode := queue.last
	lastNode.next = &Node{value: value, next: nil}
	queue.last = lastNode.next
	queue.len++
}

func (queue *Queue) Dequeue() {
	if queue.len == 0 {
		return
	}

	deleteNode := queue.first
	queue.first = deleteNode.next
	deleteNode = nil
	queue.len--
}

func (queue *Queue) Print() {
	if queue.len == 0 {
		return
	}

	curNode := queue.first
	fmt.Printf("%d -> ", curNode.value)

	for curNode.next != nil {
		curNode = curNode.next
		fmt.Printf("%d -> ", curNode.value)
	}

	fmt.Println()
}

func main() {
	newQueue := &Queue{}

	newQueue.Enqueue(1)
	newQueue.Enqueue(2)
	newQueue.Enqueue(3)

	newQueue.Print()

	newQueue.Dequeue()

	newQueue.Print()
}
