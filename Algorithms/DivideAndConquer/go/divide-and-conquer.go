package main

import "fmt"

func divideAndSum(arr []int) int {
	if len(arr) == 1 {
		return arr[0]
	}

	return arr[0] + divideAndSum(arr[1:])
}

func divideAndCount(arr []int) int {
	if len(arr) == 1 {
		return 1
	}

	return 1 + divideAndCount(arr[1:])
}

func divideAndFindGreater(arr []int) int {
	if len(arr) == 2 {
		if arr[0] > arr[1] {
			return arr[0]
		} else {
			return arr[1]
		}
	}

	max := divideAndFindGreater(arr[1:])

	if arr[0] > max {
		return arr[0]
	} else {
		return max
	}
}

func main() {
	array := []int{5, 1, 2, 3, 4}
	fmt.Println(divideAndSum(array))
	fmt.Println(divideAndCount(array))
	fmt.Println(divideAndFindGreater(array))
}
