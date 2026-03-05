namespace algorytmy_i_struktury_danych;

public static  class SortingAlgorithms
{
    public static void InsertionSort(int[] array)
    {
        for (var i = 1; i < array.Length; i++)
        {
            var key = array[i];
            var j = i - 1;
            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
        }
    }
    
    public static void MergeSort(int[] array, int left, int right)
    {
        if (left < right) {

            int m = left + (right - left) / 2;

            MergeSort(array, left, m);
            MergeSort(array, m + 1, right);

            Merge(array, left, m, right);
        }
    }
    private static void Merge(int[] array, int left, int middle, int right)
    {
        int n1 = middle - left + 1;
        int n2 = right - middle;

        int[] l = new int[n1];
        int[] r = new int[n2];
        int i, j;

        for (i = 0; i < n1; ++i)
            l[i] = array[left + i];
        for (j = 0; j < n2; ++j)
            r[j] = array[middle + 1 + j];

        i = 0;
        j = 0;

        int k = left;
        while (i < n1 && j < n2) {
            if (l[i] <= r[j]) {
                array[k] = l[i];
                i++;
            }
            else {
                array[k] = r[j];
                j++;
            }
            k++;
        }

        while (i < n1) {
            array[k] = l[i];
            i++;
            k++;
        }
        
        while (j < n2) {
            array[k] = r[j];
            j++;
            k++;
        }
    }
    
    public static void QuickSortClassical(int[] array, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(array, low, high);
            QuickSortClassical(array, low, pi - 1);
            QuickSortClassical(array, pi + 1, high);
        }
    }
    private static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high];
        int i = low - 1;

        for (int j = low; j <= high - 1; j++)
        {
            if (array[j] < pivot)
            {
                i++;
                Swap(array, i, j);
            }
        }

        Swap(array, i + 1, high);
        return i + 1;
    }
    private static void Swap(int[] array, int i, int j)
    {
        (array[i], array[j]) = (array[j], array[i]);
    }

    public static void QuickSort(int[] array)
    {
        Array.Sort(array);
    }
}