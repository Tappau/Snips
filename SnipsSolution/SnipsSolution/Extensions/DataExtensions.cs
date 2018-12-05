using System;
using System.Collections.Generic;
using System.Text;

namespace SnipsSolution.Extensions
{
    public static class DataExtensions
    {
       internal static void Each<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (T item in enumerable)
            {
                action(item);
            }
        }

        /// <summary T="&quot;/&gt;">
        /// Returns a string seperated by given seperator, of a given IEnumerable
        /// </summary>
        /// <returns>The csv string</returns>
        /// <param name="instance">List of items</param>
        /// <param name="seperator">Desired seperator</param>
        public static string ToCsv<T>(this IEnumerable<T> instance, char seperator){
            if (instance == null) return null;
            var csv = new StringBuilder();
            instance.Each(value => csv.AppendFormat("{0}{1}", value, seperator));
            return csv.ToString(0, csv.Length - 1);
        }

        /// <summary>
        /// Returns CSV of a given IEnumerable Type
        /// </summary>
        /// <returns>The csv string</returns>
        /// <param name="instance">Lst of items</param>
        public static string ToCsv<T>(this IEnumerable<T> instance){
            if (instance == null) return null;
            var csv = new StringBuilder();
            instance.Each(v => csv.AppendFormat("{0},", v));
            return csv.ToString(0, csv.Length - 1);
        }
    }
}

