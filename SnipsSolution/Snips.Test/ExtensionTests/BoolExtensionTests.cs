using NUnit.Framework;
using SnipsSolution.Extensions;
using System;

namespace Snips.Test.ExtensionTests
{
    [TestFixture]
    public class BoolExtensionTests
    {
        [TestCase("Y")]
        [TestCase("y")]
        [TestCase("yes")]
        [TestCase("Yes")]
        [TestCase("1")]
        [TestCase("true")]
        [TestCase("TRUE")]
        public void Returns_True_When_StringRepresentation_EqualsTrue(string testCase)
        {
            Assert.IsTrue(testCase.ToBoolean());
        }

        [TestCase("N")]
        [TestCase("n")]
        [TestCase("No")]
        [TestCase("no")]
        [TestCase("0")]
        [TestCase("False")]
        [TestCase("FALSE")]
        public void Returns_False_When_StringRepresentation_EqualsFalse(string testCase)
        {
            Assert.IsFalse(testCase.ToBoolean());
        }

        [TestCase("John")]
        public void Throws_ArgumentException_When_String_IsNot_Representative(string testcase)
        {
            Assert.Throws<ArgumentException>(() => testcase.ToBoolean());
        }
    }
}