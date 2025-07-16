using Algorithms.BreadthFirstSearch;
using Algorithms.SelectSort;

int[] myArray = [5, 3, 7, 2, 1];

var sortedArray = SelectSort.MySelectSort(myArray);

foreach (var item in sortedArray)
{
    Console.WriteLine(item);
}

Console.WriteLine();
Console.WriteLine("========");
Console.WriteLine("BSD algo");
Console.WriteLine("========");
Console.WriteLine();

var myBSD = new BreadthFirstSearch
{
    graph = {
        {"me", ["friend1", "friend2"]},
        {"friend1", ["friend3", "friend2"]},
        {"friend2", ["zfriend"]},
        {"friend3", []}
    }
};
var isZthere = myBSD.Search("me");
Console.WriteLine(isZthere);


