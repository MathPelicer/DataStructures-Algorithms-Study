package main

import "fmt"

type Graph struct {
	nodes map[string][]Edge
}

type Edge struct {
	node   string
	weight int
}

func NewGraph() *Graph {
	return &Graph{nodes: make(map[string][]Edge)}
}

func (graph *Graph) AddEdge(from string, to string, weight int) {
	graph.nodes[from] = append(graph.nodes[from], Edge{node: to, weight: weight})
}

func ExecuteDijkstra(graph *Graph, startNode string) (distances map[string]int, previous map[string]string) {
	distances = make(map[string]int)
	previous = make(map[string]string)
	unvisited := make(map[string]bool)

	// initialize all distances to infinite and set nodes to unvisited list
	for node := range graph.nodes {
		distances[node] = int(^uint(0) >> 1)
		unvisited[node] = true
	}
	distances[startNode] = 0

	for len(unvisited) > 0 {
		// search for smallest not visited node
		var curNode string
		smallestDistance := int(^uint(0) >> 1)
		for node := range unvisited {
			if distances[node] < smallestDistance {
				smallestDistance = distances[node]
				curNode = node
			}
		}

		// delete it from unvisited
		delete(unvisited, curNode)

		// update neightbours distances
		for _, edge := range graph.nodes[curNode] {
			newDistance := distances[curNode] + edge.weight
			if newDistance < distances[edge.node] {
				distances[edge.node] = newDistance
				previous[edge.node] = curNode
			}
		}
	}

	return distances, previous
}

func main() {
	graph := NewGraph()

	edges := []struct {
		from   string
		to     string
		weight int
	}{
		{"A", "B", 7},
		{"A", "C", 9},
		{"A", "F", 14},
		{"B", "C", 10},
		{"B", "D", 15},
		{"C", "D", 11},
		{"C", "F", 2},
		{"D", "E", 6},
		{"E", "F", 9},
	}

	for _, edge := range edges {
		graph.AddEdge(edge.from, edge.to, edge.weight)
		graph.AddEdge(edge.to, edge.from, edge.weight) // Assuming undirected graph
	}

	distances, previous := ExecuteDijkstra(graph, "A")

	fmt.Println("Distances:", distances)
	fmt.Println("Previous nodes:", previous)
}
