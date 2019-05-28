using NUnit.Framework;
using SnipsSolution.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Snips.Test.ExtensionTests
{
    [TestFixture]
    public class HasAtLeastTests
    {
        private static readonly IEnumerable<char> Letters = "abcd";
        private static readonly IEnumerable<string> Fruits = new[] { "apple", "apricot", "banana" };
        [Test]
        public static void Throws_ArgumentNullException_When_Sequence_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => ((IEnumerable<object>)null).HasAtLeast(1));
        }

        [Test]
        public static void Throw_ArgumentOutOfRangeException_When_ExpectedCount_Is_Negative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Letters.HasAtLeast(-1));
        }

        [Test]
        public static void Throws_ArgumentNullException_When_Sequence_Is_Null_With_Predicate()
        {
            bool AlwaysTruePredcate(object o) => true;
            Assert.Throws<ArgumentNullException>(() => ((IEnumerable<object>)null).HasAtLeast(1, AlwaysTruePredcate));
        }

        [Test]
        public static void Throws_ArgumentNullException_When_Predicate_IsNull()
        {
            Assert.Throws<ArgumentNullException>(() => Letters.HasAtLeast(1, null));
        }

        [Test]
        public static void Returns_True_When_ActualCount_Is_GreaterThanOrEqual_ToExpected()
        {

            Assert.IsTrue(Letters.HasAtLeast(0));
            Assert.IsTrue(Letters.HasAtLeast(2));
            Assert.IsTrue(Letters.HasAtLeast(4));

            //TestEarly Exit on ICollection.Count
            Assert.IsTrue(Letters.ToList().HasAtLeast(0));
            Assert.IsTrue(Letters.ToList().HasAtLeast(2));
            Assert.IsTrue(Letters.ToList().HasAtLeast(4));
        }

        [Test]
        public static void Return_False_When_ActualCount_Is_LowerThanExpected()
        {
            Assert.IsFalse(Letters.HasAtLeast(5));
            Assert.IsFalse(Letters.HasAtLeast(10));

            //Test ICollection
            Assert.IsFalse(Letters.ToList().HasAtLeast(5));
            Assert.IsFalse(Letters.ToList().HasAtLeast(10));
        }

        [Test]
        public static void Throws_ArgumentOutOfRangeException_When_ExpectedMinCount_IsNegative_With_Predicate()
        {
            bool ValidPredicate(char c) => c == 'a';
            Assert.Throws<ArgumentOutOfRangeException>(() => Letters.HasAtLeast(-1, ValidPredicate));
        }

        [Test]
        public static void Returns_True_When_ActualCount_IsGreaterThanOrEqual_To_ExpectedMinCount_With_Predicate()
        {
            IEnumerable<string> emptyEnumerable = Enumerable.Empty<string>();
            Assert.IsTrue(Fruits.HasAtLeast(1, fruit => fruit.StartsWith("a")));
            Assert.IsTrue(Fruits.HasAtLeast(2, fruit => fruit.StartsWith("a")));
            Assert.IsTrue(Fruits.HasAtLeast(1, fruit => fruit.StartsWith("b")));

            Assert.IsTrue(emptyEnumerable.HasAtLeast(0, _ => true));
        }

        [Test]
        public static void Returns_False_When_ActualCount_IsLowerThan_ExpectedMinCount_With_Predicate()
        {
            Assert.IsFalse(Fruits.HasAtLeast(3, f => f.StartsWith("a")));
            Assert.IsFalse(Fruits.HasAtLeast(2, f => f.StartsWith("b")));

        }
    }
}