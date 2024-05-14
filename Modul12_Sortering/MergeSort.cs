namespace Sortering;

public static class MergeSort
{

    public static void Sort(int[] array)
    {
        _mergeSort(array, 0, array.Length - 1);
    }

    private static void _mergeSort(int[] array, int l, int h)
    {
        if (l < h)
        {
            int m = (l + h) / 2;
            _mergeSort(array, l, m);
            _mergeSort(array, m + 1, h);
            Merge(array, l, m, h);
        }
    }

    private static void Merge(int[] array, int low, int middle, int high)
    {
        // Antal elementer i de to subarrays, + 1 for leftArray for at få middelværdien med
        int leftArrayLength = middle - low + 1;
        int rightArrayLength = high - middle;

        // Midlertidige arrays til de to halvdele
        int[] leftArray = new int[leftArrayLength];
        int[] rightArray = new int[rightArrayLength];

        // Kopier data til de midlertidige arrays
        Array.Copy(array, low, leftArray, 0, leftArrayLength);
        Array.Copy(array, middle + 1, rightArray, 0, rightArrayLength);

        // Indekser til iteration over de midlertidige arrays
        int leftIndex = 0, rightIndex = 0;
        int arrayIndex = low; // Starter fra laveste punkt i det oprindelige array

        // Sammenfletning af de to subarrays tilbage i det oprindelige array
        while (leftIndex < leftArrayLength && rightIndex < rightArrayLength)
        {
            if (leftArray[leftIndex] <= rightArray[rightIndex])
            {
                array[arrayIndex] = leftArray[leftIndex];
                leftIndex++;
            }
            else
            {
                array[arrayIndex] = rightArray[rightIndex];
                rightIndex++;
            }
            arrayIndex++;
        }

        // Kopier eventuelle resterende elementer fra venstre subarray, hvis nogen
        while (leftIndex < leftArrayLength)
        {
            array[arrayIndex] = leftArray[leftIndex];
            leftIndex++;
            arrayIndex++;
        }

        // Kopier eventuelle resterende elementer fra højre subarray, hvis nogen
        while (rightIndex < rightArrayLength)
        {
            array[arrayIndex] = rightArray[rightIndex];
            rightIndex++;
            arrayIndex++;
        }
    }

}
