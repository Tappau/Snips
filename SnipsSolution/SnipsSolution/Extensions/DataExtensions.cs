using System;
using System.Collections.Generic;
using System.Reflection;
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

        /// <summary>
        /// Returns a string sperated by given seperator, of a given IEnumerable<T>"/>
        /// </summary>
        /// <returns>The csv string</returns>
        /// <param name="instance">List of items</param>
        /// <param name="seperator">Desired seperator</param>
        public static string ToCsv<T>(this IEnumerable<T> instance, char seperator){
            StringBuilder csv;
            if(instance != null){
                csv = new StringBuilder();
                instance.Each(value => csv.AppendFormat("{0}{1}", value, seperator));
                return csv.ToString(0, csv.Length - 1);
            }
            return null;
        }

        /// <summary>
        /// Returns CSV of a given IEnumerable Type
        /// </summary>
        /// <returns>The csv string</returns>
        /// <param name="instance">Lst of items</param>
        public static string ToCsv<T>(this IEnumerable<T> instance){
            StringBuilder csv;
            if(instance !=null){
                csv = new StringBuilder();
                instance.Each(v => csv.AppendFormat("{0},", v));
                return csv.ToString(0, csv.Length - 1);
            }

            return null;
        }
    }
}

