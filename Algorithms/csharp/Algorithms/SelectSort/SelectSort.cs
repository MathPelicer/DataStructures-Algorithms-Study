namespace Algorithms.SelectSort;

public static class SelectSort
{
    private static int FindSmallerIndex(this int[] myArray)
    {
        var smallerIndex = 0;
        var smaller = myArray[smallerIndex];

        for (int i = 0; i < myArray.Length; i++)
        {
            if (myArray[i] < smaller)
            {
                smaller = myArray[i];
                smallerIndex = i;
            }
        }

        return smallerIndex;
    }

    public static int[] MySelectSort(this int[] myArray)
    {
        var newArray = new int[myArray.Length];
        var arraySize = myArray.Length;
        for (int i = 0; i < arraySize; i++)
        {
            var smallerIndex = FindSmallerIndex(myArray);
            newArray[i] = myArray[smallerIndex];
            myArray = [.. myArray.Where((val, index) => index != smallerIndex)];
        }

        return newArray;
    }
}
