namespace SnipsSolution
{
    public class Sorting
    {
        public static int[] InsertionSort(int[] arrayToSort)
        {
            for (var i = 1; i < arrayToSort.Length; i++)
            {
                var temp = arrayToSort[i];
                var j = i - 1;

                while ((j > -1) && (arrayToSort[j] > temp))
                {
                    var tempo = arrayToSort[j + 1];
                    arrayToSort[j + 1] = arrayToSort[j];
                    arrayToSort[j] = tempo;

                    j = j - 1;
                }
            }
            return arrayToSort;
        }

        public static void HeapSort(ref int[] data)
        {
            var heapSize = data.Length;
            for (var p = (heapSize - 1) / 2; p >= 0; --p)
            {
                MaxHeapify(ref data, heapSize, p);
            }

            for (var i = data.Length - 1; i > 0; --i)
            {
                var temp = data[i];
                data[i] = data[0];
                data[0] = temp;

                --heapSize;
                MaxHeapify(ref data, heapSize, 0);
            }
        }

        private static void MaxHeapify(ref int[] data, int heapSize, int index)
        {
            var left = (index + 1) * 2 - 1;
            var right = (index + 1) * 2;
            int largest;

            if (left < heapSize && data[left] > data[index])
            {
                largest = left;
            }
            else
            {
                largest = index;
            }

            if (right < heapSize && data[right] > data[largest])
            {
                largest = right;
            }

            if (largest != index)
            {
                var temp = data[index];
                data[index] = data[largest];
                data[largest] = temp;

                MaxHeapify(ref data, heapSize, largest);
            }
        }

        public static int[] ShellSort(int[] array)
        {
            var gap = array.Length / 2;
            while (gap > 0)
            {
                for (var i = 0; i < array.Length - gap; i++) //modified insertion sort
                {
                    var j = i + gap;
                    var tmp = array[j];
                    while (j >= gap && tmp > array[j - gap])
                    {
                        array[j] = array[j - gap];
                        j -= gap;
                    }
                    array[j] = tmp;
                }
                if (gap == 2) //change the gap size
                {
                    gap = 1;
                }
                else
                {
                    gap = (int)(gap / 2.2);
                }
            }
            return array;
        }
    }
}