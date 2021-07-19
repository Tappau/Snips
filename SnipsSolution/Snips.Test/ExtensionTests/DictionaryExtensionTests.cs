using System.Collections.Generic;
using NUnit.Framework;
using SnipsSolution.Extensions;

namespace Snips.Test.ExtensionTests
{
    [TestFixture]
    public class DictionaryExtensionTests
    {
        [Test]
        public void SelectKeys_Returns_ExpectedValuesInDictionary()
        {
            var sourceDictionary = new Dictionary<string, string>
            {
                {"A", "String A"}, {"B", "String B"}, {"C", "String C"}, {"D", "String D"}
            };

            var result = sourceDictionary.SelectKeys("A", "C");

            CollectionAssert.AreEquivalent(new Dictionary<string, string>
            {
                {"A", "String A"}, {"C", "String C"}
            }, result);
        }

        [Test]
        public void SelectKeys_Returns_EmptyInstanceOfDictionary_If_Source_IsEmpty()
        {
            var sourceDictionary = new Dictionary<string, string>();
            var result = sourceDictionary.SelectKeys("A");
            Assert.That(result, Is.InstanceOf<Dictionary<string, string>>());
            Assert.That(result, Is.Empty);
        }
    }
}