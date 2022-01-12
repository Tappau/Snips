using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SnipsSolution.Extensions
{
    public static class EnumerableExtensions
    {
        #region Chunk

        /// <summary>
        ///     Splits given sequence into chunks of the given size.
        ///     If sequence length isn't evenly divisable by chunk size, the last chunk will contain all remaining elements.
        /// </summary>
        /// <typeparam name="TSource">Type of the elements of <paramref name="source" /></typeparam>
        /// <param name="source">The sequence</param>
        /// <param name="chunkSize">The number of elements per chunk.</param>
        /// <returns>The chunked sequence.</returns>
        public static IEnumerable<TSource[]> Chunk<TSource>(this IEnumerable<TSource> source, int chunkSize)
        {
            if (source.IsNull())
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (chunkSize <= 0)
            {
                throw new ArgumentException(nameof(chunkSize), string.Concat(nameof(chunkSize), "must be positive."));
            }

            return ChunkIterator(source, chunkSize);
        }

        private static IEnumerable<TSource[]> ChunkIterator<TSource>(IEnumerable<TSource> source, int chunkSize)
        {
            TSource[] currentChunk = null;
            var currIdx = 0;

            foreach (var element in source)
            {
                currentChunk = currentChunk ?? new TSource[chunkSize];
                currentChunk[currIdx++] = element;

                if (currIdx == chunkSize)
                {
                    yield return currentChunk;
                    currIdx = 0;
                    currentChunk = null;
                }
            }

            if (currentChunk != null)
            {
                //Last chunk is incomplete, otherwise would be returned already
                var lastChunk = new TSource[currIdx];
                Array.Copy(currentChunk, lastChunk, currIdx);

                yield return lastChunk;
            }
        }

        #endregion

        #region HasAtLeast

        /// <summary>
        ///     Determines whether the specified sequence's element count is equal to or greater than
        ///     <paramref name="minElementCount" />.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{TSource}" /> whose elements to count.</param>
        /// <param name="minElementCount">The minimum number of elements the specified sequence is expected to contain.</param>
        /// <returns>
        ///     <c>true</c> if the element count of <paramref name="source" /> is equal to or greater than
        ///     <paramref name="minElementCount" />; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasAtLeast<TSource>(this IEnumerable<TSource> source, int minElementCount)
        {
            return HasAtLeast(source, minElementCount, _ => true);
        }

        /// <summary>
        ///     Determines whether the specified sequence contains exactly <paramref name="minElementCount" /> or more elements
        ///     satisfying a condition.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{TSource}" /> whose elements to count.</param>
        /// <param name="minElementCount">
        ///     The minimum number of elements satisfying the specified condition the specified sequence
        ///     is expected to contain.
        /// </param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>
        ///     <c>true</c> if the element count of satisfying elements is equal to or greater than
        ///     <paramref name="minElementCount" />; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasAtLeast<TSource>(this IEnumerable<TSource> source, int minElementCount,
            Func<TSource, bool> predicate)
        {
            ThrowIf.Argument.IsNull(source, nameof(source));
            ThrowIf.Argument.IsNull(predicate, nameof(predicate));
            ThrowIf.Argument.IsNegative(minElementCount, nameof(minElementCount));

            if (minElementCount == 0)
            {
                return true;
            }

            var sourceCollection = source as ICollection;

            if (sourceCollection != null && sourceCollection.Count < minElementCount)
            {
                return false;
            }

            var matches = 0;

            foreach (var unused in source.Where(predicate))
            {
                matches++;

                if (matches >= minElementCount)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Partition

        /// <summary>
        ///     Uses the given predicate to partition the given sequence into two sequences,
        ///     one with all the matches and one with all the mismatches.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The sequence to partition.</param>
        /// <param name="predicate">The predicate that determines whether an element is a match.</param>
        /// <returns>An object holding the two partitions (matches and mismatches).</returns>
        public static PartitionedSequence<TSource> Partition<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            ThrowIf.Argument.IsNull(source, "values");
            ThrowIf.Argument.IsNull(predicate, "predicate");

            var matches = new List<TSource>();
            var mismatches = new List<TSource>();

            foreach (var value in source)
            {
                if (predicate(value))
                {
                    matches.Add(value);
                }
                else
                {
                    mismatches.Add(value);
                }
            }

            return new PartitionedSequence<TSource>(matches, mismatches);
        }

        public class PartitionedSequence<TSource>
        {
            public PartitionedSequence(IList<TSource> matches, IList<TSource> mismatches)
            {
                Matches = matches;
                Mismatches = mismatches;
            }

            public IList<TSource> Matches { get; }
            public IList<TSource> Mismatches { get; }
        }

        #endregion

        #region NonConsecutive

        public static IEnumerable<T> ConsecutiveDistinct<T>(this IEnumerable<T> input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return NonConsecutiveImplementation(input);
        }

        private static IEnumerable<T> NonConsecutiveImplementation<T>(IEnumerable<T> input)
        {
            var isFirst = true;
            var last = default(T);
            foreach (var item in input)
            {
                if (isFirst || !object.Equals(item, last))
                {
                    yield return item;
                    last = item;
                    isFirst = false;
                }
            }
        }

        #endregion
    }
}