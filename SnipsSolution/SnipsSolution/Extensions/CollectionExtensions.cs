using System;
using System.Collections.Generic;
using System.Linq;

namespace SnipsSolution.Extensions
{
    /// <summary>
    ///     Collection Helper
    /// </summary>
    /// <remarks>
    ///     Use IEnumerable by default, but when altering or getting item at index use IList.
    /// </remarks>
    public static class CollectionHelper
    {
        #region Action;

        /// <summary>
        ///     Execute action at specified index
        /// </summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="value">Collection</param>
        /// <param name="index">Index</param>
        /// <param name="actionAt">Action to execute</param>
        /// <returns>New collection</returns>
        public static IList<T> ActionAt<T>(this IList<T> value, int index, Action<T> actionAt)
        {
            actionAt(value[index]);
            return value;
        }

        #endregion Action;

        #region Clone;

        /// <summary>
        /// </summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="value">Collection</param>
        /// <returns>Cloned collection</returns>
        public static IEnumerable<T> Clone<T>(this IEnumerable<T> value) where T : ICloneable
        {
            return value.Select(item => (T) item.Clone());
        }

        #endregion Clone;

        #region String;

        /// <summary>
        ///     Joins multiple string with Separator
        /// </summary>
        /// <param name="value">Collection</param>
        /// <param name="separator">Separator</param>
        /// <returns>Joined string</returns>
        public static string Join(this IEnumerable<string> value, string separator = "")
        {
            return string.Join(separator, value);
        }

        #endregion String;

        #region Alter;

        /// <summary>
        ///     Swap item to another place
        /// </summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="value"></param>
        /// <param name="indexA">Index a</param>
        /// <param name="indexB">Index b</param>
        /// <returns>New collection</returns>
        public static IList<T> Swap<T>(this IList<T> value, int indexA, int indexB)
        {
            var temp = value[indexA];
            value[indexA] = value[indexB];
            value[indexB] = temp;
            return value;
        }

        /// <summary>
        ///     Swap item to the left
        /// </summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="value">Collection</param>
        /// <param name="index">Index</param>
        /// <returns>New collection</returns>
        public static IList<T> SwapLeft<T>(this IList<T> value, int index)
        {
            return value.Swap(index, index - 1);
        }

        /// <summary>
        ///     Swap item to the right
        /// </summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="value">Collection</param>
        /// <param name="index">Index</param>
        /// <returns>New collection</returns>
        public static IList<T> SwapRight<T>(this IList<T> value, int index)
        {
            return value.Swap(index, index + 1);
        }

        #endregion Alter;

        #region Randomize;

        /// <summary>
        ///     Take random items
        /// </summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="value">Collection</param>
        /// <param name="count">Number of items to take</param>
        /// <returns>New collection</returns>
        public static IEnumerable<T> TakeRandom<T>(this IEnumerable<T> value, int count)
        {
            return Shuffle(value).Take(count);
        }

        /// <summary>
        ///     Take random item
        /// </summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="value">Collection</param>
        /// <returns>Item</returns>
        public static T TakeRandom<T>(this IEnumerable<T> value)
        {
            return value.TakeRandom(1).Single();
        }

        /// <summary>
        ///     Shuffle list
        /// </summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="value">Collection</param>
        /// <returns>New collection</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> value)
        {
            return value.OrderBy(item => Guid.NewGuid());
        }

        #endregion Randomize;

        #region Navigate;

        /// <summary>
        ///     Get next item in collection and give first item, when last item is selected;
        /// </summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="value">Collection</param>
        /// <param name="index">Index in collection</param>
        /// <returns>Next item</returns>
        public static T Next<T>(this IList<T> value, ref int index)
        {
            index = ++index >= 0 && index < value.Count ? index : 0;
            return value[index];
        }

        /// <summary>
        ///     Get previous item in collection and give last item, when first item is selected;
        /// </summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="value">Collection</param>
        /// <param name="index">Index in collection</param>
        /// <returns>Previous item</returns>
        public static T Previous<T>(this IList<T> value, ref int index)
        {
            index = --index >= 0 && index < value.Count ? index : value.Count - 1;
            return value[index];
        }

        #endregion Navigate;
    }
}