using System;
using NUnit.Framework;
using SnipsSolution.Extensions;
// ReSharper disable StringLiteralTypo

namespace Snips.Test.ExtensionTests
{
    public class Person
    {
        public string Name { get; set; }
        public string Age { get; set; }
    }

    [TestFixture]
    public class StringExtensionsTest
    {
        private const string TestXml = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<Person xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n  <Name>John Doe</Name>\r\n  <Age>31</Age>\r\n</Person>";

        [TestCase("Quick Brown Fox", 4, " Fox")]
        [TestCase("Lorem ipsum dolor", 7, "m dolor")]
        public void ReturnStringFromRight(string testCase, int charsToGet, string expectedOutcome)
        {
            Assert.AreEqual(expectedOutcome, testCase.Right(charsToGet));
        }

        [TestCase("Quick Brown Fox", 6, "Quick ")]
        [TestCase("Lorem ipsum dolor", 7, "Lorem i")]
        public void ReturnFromLeft(string testCase, int charsToGet, string expected)
        {
            Assert.AreEqual(expected, testCase.Left(charsToGet));
        }

        [Test]
        public void ThrowArgumentNullException_OnLeft_And_OnRight()
        {
            Assert.Throws<ArgumentNullException>(()=>((string) null).Left());
            Assert.Throws<ArgumentNullException>(() => ((string) null).Right());
        }

        [TestCase("Quick Brown Fox", 7, "Quic...")]
        [TestCase(" ", 5, " ")]
        [TestCase("Quick", 10, "Quick")]
        public void Test_Truncate(string testCase, int length, string expected)
        {
            Assert.AreEqual(expected, testCase.Truncate(length));
        }

        [Test]
        public void Test_ParseXmlTo_Poco()
        {
            var outcome = TestXml.ParseXmlTo<Person>();
            Assert.AreEqual("John Doe", outcome.Name);
            Assert.AreEqual("31",outcome.Age);
        }

        [Test]
        public void Test_XmlTo_Poco()
        {
            var person = new Person {Name = "John Doe", Age = "31"};
            var outcome = person.ToXml();
            Assert.AreEqual(TestXml, outcome);
        }

        [TestCase("Lorem ipsum", "m", 2, 10)]
        [TestCase("Quick Brown Fox", "O", 1, -1)]
        [TestCase("Quick Brown Fox", "o", 1, 8)]
        public void Test_NthIndexOf(string testCase, string indexOf,int nthOccurance, int expected)
        {
            Assert.AreEqual(expected, testCase.NthIndexOf(indexOf, nthOccurance));
        }

        [TestCase("Lorem ipsum dolor", "Lorem ipsum dolo")]
        [TestCase("Quick Brown Fox J", "Quick Brown Fox ")]
        public void Test_RemoveLastCharacter(string testCase, string expected)
        {
            Assert.AreEqual(expected, testCase.RemoveLastCharacter());
        }

        [TestCase("Lorem ipsum dolor", "orem ipsum dolor")]
        [TestCase("Quick Brown Fox J", "uick Brown Fox J")]
        public void Test_RemoveFirstCharacter(string testCase, string expected)
        {
            Assert.AreEqual(expected, testCase.RemoveFirstCharacter());
        }

        [TestCase("   ")]
        [TestCase("")]
        [TestCase(null)]
        public void Throws_ArgumentNullException_RemoveLastCharacter(string testcase)
        {
            Assert.Throws<ArgumentNullException>(() => testcase.RemoveLastCharacter());
        }

        [TestCase("   ")]
        [TestCase("")]
        [TestCase(null)]
        public void Throws_ArgumentNullException_RemoveFirstCharacter(string testcase)
        {
            Assert.Throws<ArgumentNullException>(() => testcase.RemoveFirstCharacter());
        }

        [TestCase("Lorem ipsum dolor", "Lorem ipsum do", 3)]
        [TestCase("Quick Brown Fox J", "Quick Brown", 6)]
        public void Test_RemoveLast_X_Characters(string testcase, string expected, int toRemove)
        {
            Assert.AreEqual(expected, testcase.RemoveLast(toRemove));
        }

        [TestCase("Lorem ipsum dolor", "em ipsum dolor", 3)]
        [TestCase("Quick Brown Fox J", "Brown Fox J", 6)]
        public void Test_RemoveFirst_X_Characters(string testcase, string expected, int toRemove)
        {
            Assert.AreEqual(expected, testcase.RemoveFirst(toRemove));
        }

        [TestCase("   ")]
        [TestCase("")]
        [TestCase(null)]
        public void Throws_ArgumentNullException_RemoveLast(string testcase)
        {
            Assert.Throws<ArgumentNullException>(() => testcase.RemoveLast());
        }

        [TestCase("   ")]
        [TestCase("")]
        [TestCase(null)]
        public void Throws_ArgumentNullException_RemoveFirst(string testcase)
        {
            Assert.Throws<ArgumentNullException>(() => testcase.RemoveFirst());
        }

        [TestCase("1234", 1234)]
        [TestCase("2147483647", int.MaxValue)]
        [TestCase("-2147483648", int.MinValue)]
        public void Test_StringToInt(string testCase, int expected)
        {
           Assert.AreEqual(expected, testCase.ToInt());
        }

        [TestCase("12.34", 12.34)]
        [TestCase("1.7", 1.7)]
        [TestCase("156.36", 156.36)]
        public void Test_StringToDouble(string testCase, double expected)
        {
            Assert.AreEqual(expected, testCase.ToDouble());
        }
    }
}