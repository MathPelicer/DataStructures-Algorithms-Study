namespace Algorithms.BreadthFirstSearch;

public class BreadthFirstSearch
{
    public Dictionary<string, List<string>> graph = [];

    public bool Search(string name)
    {
        Console.WriteLine($"Searching for {name}'s friends");
        Queue<string> searchQueue = new();
        foreach (var friend in graph[name])
        {
            searchQueue.Enqueue(friend);
        }

        List<string> searched = [];

        while (searchQueue.Count != 0)
        {
            var person = searchQueue.Dequeue();
            if (!searched.Contains(person))
            {
                Console.WriteLine($"{person} hasn't being checked yet");
                if (person.StartsWith('z'))
                {
                    return true;
                }

                Console.WriteLine($"adding {person}'s friends to be searched");
                foreach (var friend in graph[person])
                {
                    searchQueue.Enqueue(friend);
                }
                searched.Add(person);
            }
        }

        return false;
    }
}
