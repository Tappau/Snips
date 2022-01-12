using System;
using System.Collections.Generic;
using NUnit.Framework;
using SnipsSolution.Extensions;

namespace Snips.Test.ExtensionTests
{
    public class EnumerableExtensionTests
    {
        [Test]
        public void ConsecutiveDistinct_ThrowsArgumentNullException_WhenCollectionIsNull()
        {
            int[] nums = { 1, 2, 3, 4 };
            Assert.Throws<ArgumentNullException>(() => ((List<int>)null).ConsecutiveDistinct());
        }

        [Test]
        public void ConsecutiveDistinct_IfCollectionIsEmpty_JustReturnTheList()
        {
            int[] nums = { 1, 2, 3, 4 };
            var result = (new List<int>()).ConsecutiveDistinct();
            CollectionAssert.AreEquivalent(new List<int>(), result);
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void ConsecutiveDistinct_IfCollectionOfInt_ReturnsExpected()
        {
            int[] input = { 1, 2,2,  3, 4, 4, 5,6,7,7 };
            int[] expected = { 1, 2,  3, 4, 5,6,7, };
            var result = input.ConsecutiveDistinct();
            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void ConsecutiveDistinct_IfCollectionOfString_ReturnsExpected()
        {
            int[] input = { 1, 2,2,  3, 4, 4, 5,6,7,7 };
            int[] expected = { 1, 2,  3, 4, 5,6,7, };
            var result = input.ConsecutiveDistinct();
            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}