using System;
using System.Collections.Generic;
using NUnit.Framework;
using SnipsSolution.Extensions;

namespace Snips.Test
{
    [TestFixture]
    public class PartitionTests
    {
        private static readonly Func<int, bool> IsEven = x => x % 2 == 0;
        [Test]
        public static void Throws_ArgumentNullException_When_Sequence_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => ((IEnumerable<char>) null).Partition(char.IsUpper));
        }

        [Test]
        public static void Throws_ArgumentNullException_When_Predicate_Is_Null()
        {
            int[] numbers = {1, 2, 3};
            Assert.Throws<ArgumentNullException>(() => numbers.Partition(null));
        }

        [Test]
        public static void Return_Two_EmptySequences_For_EmptySequence()
        {
            int[] numbers = { };

            var evenAndOddNums = numbers.Partition(IsEven);
            Assert.IsEmpty(evenAndOddNums.Matches);
            Assert.IsEmpty(evenAndOddNums.Mismatches);
        }

        [TestCase(new[] {1}, new int[0], new[] {1})]
        [TestCase(new[] {1, -2}, new int[] {-2}, new[] {1})]
        [TestCase(new[] {0, 0, 0}, new int[] {0, 0, 0}, new int[0])]
        [TestCase(new[] {1, 3, 5}, new int[0], new[] {1, 3, 5})]
        [TestCase(new[] {1, 2, 3, 4, 5}, new int[] {2, 4}, new[] {1, 3, 5})]
        public void CorrectlyPartition_GivenSequenceOfNumbersInto_EvenAndOdds(int[] numbers, int[] expectedEvens,
            int[] expectedOdds)
        {
            var evenAndOddNums = numbers.Partition(IsEven);

            Assert.AreEqual(expectedEvens, evenAndOddNums.Matches);
            Assert.AreEqual(expectedOdds, evenAndOddNums.Mismatches);
        }

    }
}