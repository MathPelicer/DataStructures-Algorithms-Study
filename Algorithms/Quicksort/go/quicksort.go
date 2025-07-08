package main

import "fmt"

func Quicksort(arr []int) []int {
	if len(arr) < 2 {
		return arr
	}

	pivot := arr[0]
	greater := []int{}
	smaller := []int{}

	for _, elem := range arr[1:] {
		if elem >= pivot {
			greater = append(greater, elem)
		} else {
			smaller = append(smaller, elem)
		}
	}

	smaller = append(smaller, pivot)
	return append(smaller, greater...)
}

func main() {
	array := []int{5, 1, 2, 3, 4}
	array = Quicksort(array)

	fmt.Println(array)
}
