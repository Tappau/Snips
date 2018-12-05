using System;
using System.Collections.Generic;

namespace SnipsSolution.Extensions
{
    public static class DictionaryExtensions
    {
        /// <summary>
        ///     Gets the key using <paramref name="insensitiveKeySearch" /> from <paramref name="dictionary" />
        /// </summary>
        /// <typeparam name="T">The dictionary value.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="insensitiveKeySearch">The case insensitive key to look up</param>
        /// <returns>An existing key; or <see cref="string.Empty" /> if not found.</returns>
        public static string GetKeyIgnoringCase<T>(this IDictionary<string, T> dictionary, string insensitiveKeySearch)
        {
            if (string.IsNullOrWhiteSpace(insensitiveKeySearch)) return string.Empty;

            foreach (var key in dictionary.Keys)
                if (key.Equals(insensitiveKeySearch, StringComparison.InvariantCultureIgnoreCase))
                    return key;
            return string.Empty;
        }

        /// <summary>
        ///     Convert ananoymous type to dictionary
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Dictionary</returns>
        public static Dictionary<string, object> ToDictionary(this object obj)
        {
            var dictionary = new Dictionary<string, object>();
            foreach (var propertyInfo in obj.GetType().GetProperties())
                if (propertyInfo.GetIndexParameters().Length == 0)
                    dictionary.Add(propertyInfo.Name, propertyInfo.GetValue(obj, null));

            return dictionary;
        }
    }
}