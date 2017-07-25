namespace SnipsSolution
{
    public class SearchTypes
    {
        public static int LinearSearch(int[] list, int data)
        {
            //Linear search, also known as sequential search is an algorithm for finding a target value within a list.It sequentially checks each element of the list for the target value until a match is found or until all the elements have been searched.

            for (var i = 0; i < list.Length; i++)
            {
                if (data == list[i]) return i;
            }
            return -1;
        }

        public static int InterpolationSearch(int[] list, int dataToFind)
        {
            var lo = 0;
            // ReSharper disable once TooWideLocalVariableScope
            var mid = -1;
            var hi = list.Length - 1;
            var index = -1;

            while (lo <= hi)
            {
                mid = (int) (lo + (double) (hi - lo)/(list[hi] - list[lo])*(dataToFind - list[lo]));

                if (list[mid] == dataToFind)
                {
                    index = mid;
                    break;
                }
                if (list[mid] < dataToFind)
                    lo = mid + 1;
                else
                    hi = mid - 1;
            }
            return index;
        }
    }
}