using Algorithms.SelectSort;

int[] myArray = [5, 3, 7, 2, 1];

var sortedArray = SelectSort.MySelectSort(myArray);

foreach (var item in sortedArray)
{
    Console.WriteLine(item);    
}



