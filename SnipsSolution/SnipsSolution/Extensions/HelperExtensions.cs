using System;
using System.Collections.Generic;
using System.Linq;

namespace SnipsSolution.Extensions
{/*
   IsAnyOf<T> enables the replacement of multiple If cases for same check
   e.g.
        if(string == "value1" || string == "value2" etc...)
   --Replaces with

        if(string.IsAnyOf("value1","value2")
 */
    public static class HelperExtensions
    {

        /// <summary>
        /// Checks if equal to multiple possible values
        /// </summary>
        /// <returns><c>true</c>, if any are equal, <c>false</c> otherwise.</returns>
        /// <param name="source">Source.</param>
        /// <param name="list">List.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static bool IsAnyOf<T>(this T source, params T[] list)
        {
            if (null == source)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return list.Contains(source);
        }


        /// <summary>
        /// Shuffle Function, that utilises the Fisher-Yates Algorithm 
        /// </summary>
        /// <returns>The shuffle.</returns>
        /// <param name="source">Source.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return ShuffleIterator(source);
        }

        private static IEnumerable<T> ShuffleIterator<T>(this IEnumerable<T> source)
        {
            T[] array = source.ToArray();
            Random rnd = new Random();
            for (int n = array.Length; n > 1;)
            {
                int k = rnd.Next(n--);

                //do the swapping 
                if (n != k)
                {
                    T tmp = array[k];
                    array[k] = array[n];
                    array[n] = tmp;
                }
            }

            foreach (var item in array)
            {
                yield return item;
            }
        }

    }
}
