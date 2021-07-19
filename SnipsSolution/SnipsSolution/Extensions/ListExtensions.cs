using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SnipsSolution.Extensions
{
    public static class ListExtensions
    {
        public static void AddIf<T>(this IList<T> list, [NotNull] Func<T, bool> predicate, T objectToAdd)
        {
            if (predicate != null && predicate.Invoke(objectToAdd))
            {
                list.Add(objectToAdd);
            }
        }
    }
}