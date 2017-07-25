using System;

namespace SnipsSolution
{
    public class Algorithms
    {
        private static void Main(string[] args)
        {
            int[] a = {30, 20, 50, 40, 10};
            int x;
            Console.WriteLine("The Array is: ");
            for (var i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }
            //Bubble Sort it here

            for (var j = 0; j <= a.Length - 2; j++)
            {
                for (var i = 0; i <= a.Length - 2; i++)
                {
                    if (a[i] > a[i + 1])
                    {
                        x = a[i + 1];
                        a[i + 1] = a[i];
                        a[i] = x;
                    }
                }
            }
            Console.WriteLine("Sorted Array is: ");
            foreach (var k in a)
            {
                Console.Write(k + " ");
                Console.ReadLine();
            }
        }

        /// <summary>
        ///     Very fast &amp; simple that walks through all bits that are one, incrementing the counter for each.
        /// </summary>
        /// <returns>The bit count.</returns>
        /// <param name="n">N.</param>
        public static int SparseBitCount(int n)
        {
            var cnt = 0;
            while (n != 0)
            {
                cnt++;
                n &= n - 1;
            }
            return cnt;
        }
    }
}