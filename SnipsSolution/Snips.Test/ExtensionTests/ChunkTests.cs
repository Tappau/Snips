using NUnit.Framework;
using SnipsSolution.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Snips.Test.ExtensionTests
{
    [TestFixture]
    public class ChunkTests
    {
        [Test]
        public static void Throws_ArgumentNullException_WhenSequence_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => ((IEnumerable<object>)null).Chunk(2));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void ThrowsArgumentExceptionWhenChunkSize_Is_ZeroOrNegative(int chunkSize)
        {
            int[] nums = { 1, 2, 3, 4 };
            Assert.Throws<ArgumentException>(() => nums.Chunk(chunkSize), "Chunk size must be greater than or equal to 1");
        }

        [Test]
        public void ReturnEmptySequence_When_PassedEmptySequence()
        {
            var nums = new int[0];
            var chunks = nums.Chunk(2);
            Assert.IsEmpty(chunks);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(100)]
        public void ReturnSingleChunkifSequenceOnlyHasOneElement(int chunkSize)
        {
            int[] numbers = { 42 };
            var chunks = numbers.Chunk(chunkSize).ToArray();

            Assert.AreEqual(1, chunks.Count());
            Assert.Contains(42, chunks.First());
        }

        [Test]
        public static void CorrectlySplitsASequence_Into_SingleElementChunks()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };
            int[][] expectedChunks =
            {
                new[] {1}, new[] {2}, new[] {3}, new[] {4}, new[] {5}, new[] {6}, new[] {7}
            };

            var actualChunks = numbers.Chunk(1).ToArray();

            for (var i = 0; i < actualChunks.Length; i++)
            {
                var actual = actualChunks[i];
                var expected = expectedChunks[i];

                Assert.AreEqual(expected, actual);
            }
        }

        [Test]
        public void CorrectlySplitsSequence_Into_TwoElementChunks()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };
            int[][] expectedChunks =
            {
                new[] {1, 2}, new[] {3, 4}, new[] {5, 6}, new[] {7}
            };
            var actualChunks = numbers.Chunk(2).ToArray();

            Assert.AreEqual(expectedChunks.Count(), actualChunks.Count());

            for (int i = 0; i < actualChunks.Length; i++)
            {
                var actual = actualChunks[i];
                var expected = expectedChunks[i];

                Assert.AreEqual(expected, actual);
            }
        }

    }
}