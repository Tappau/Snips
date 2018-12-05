using System;
using NUnit.Framework;
using SnipsSolution;
using SnipsSolution.Extensions;

namespace Snips.Test
{
    [TestFixture]
    public class ValidationTests
    {

        private static Validation _validator;

        public ValidationTests()
        {
            _validator = new Validation();
        }

        [TestCase("30/11/1989")]
        [TestCase("24/06/15")]
        [TestCase("09/16")]
        [TestCase("09/2016")]
        [TestCase("6/5/15")]
        [TestCase("6/5/2015")]
        [TestCase("15/6/15")]
        [TestCase("15/6/2015")]
        public static void Return_True_WhenValidDateFormatsProvided(string testCase)
        {
            Assert.IsTrue(testCase.IsUkDateFormat());
        }

        [TestCase("06/25/2016")]
        [TestCase("06-2-2016")]
        public static void Return_False_WhenNonUKDateProvided(string testCase)
        {
            Assert.IsFalse(testCase.IsUkDateFormat());
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public static void Throw_ArgumentNullException_When_DateStringIsInvalid(string testCase)
        {
            Assert.Throws<ArgumentNullException>(() => testCase.IsUkDateFormat());
        }

       [Test]
        public static void Return_NewGuid_WhenGuidEmpty()
        {
            var guid = Guid.Empty;
            var outcome = guid.NewGuidIfEmpty();
            Assert.AreNotSame(guid, outcome);
        }

        [TestCase("ValidP@ssword1", true)]
        [TestCase("Valid", false)]
        [TestCase("", false)]
        [TestCase("PASS", false)]
        public static void CheckValidationOfPassword(string testCase, bool expectedResult)
        {
            var outcome = _validator.CheckPassword(testCase);
            Assert.AreEqual(expectedResult, outcome);
        }
    }
}