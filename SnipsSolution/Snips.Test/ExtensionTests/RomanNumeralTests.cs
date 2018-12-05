using NUnit.Framework;
using SnipsSolution.Extensions;

namespace Snips.Test.ExtensionTests
{
    [TestFixture]
    public class RomanNumeralTests
    {
        [Test]
        public void IntegerToString()
        {
            Assert.AreEqual(2018.ToRomanNumeralString(), "MMXVIII");
        }

        /// <summary>
        ///     Test to check that an integer is converted to Roman Numeral
        /// </summary>
        /// <param name="num">Number.</param>
        /// <param name="expected">Expected.</param>
        [Test]
        [TestCase(4, "IV")]
        [TestCase(2018, "MMXVIII")]
        [TestCase(187, "CLXXXVII")]
        public void MakeInteger_To_String(int num, string expected)
        {
            var outcome = num.ToRomanNumeralString();
            Assert.AreEqual(expected, outcome);
        }

        /// <summary>
        ///     Test that checks if a string is converted to its integer equivalent
        /// </summary>
        /// <param name="toConvert">To convert.</param>
        /// <param name="expected">Expected.</param>
        [Test]
        [TestCase("IV", 4)]
        [TestCase("MMXVIII", 2018)]
        [TestCase("CLXXXVII", 187)]
        public void ShouldReturnIntegerOfString(string toConvert, int expected)
        {
            var outcome = toConvert.ParseRomanNumeral();
            Assert.AreEqual(expected, outcome);
        }

        /// <summary>
        ///     Test to see if roman numeral input is valid
        /// </summary>
        /// <param name="stringNumeral">String numeral.</param>
        [Test]
        [TestCase("IV")]
        [TestCase("MMXVIII")]
        public void StringIsValidRomanNumeral(string stringNumeral)
        {
            Assert.IsTrue(stringNumeral.IsValidRomanNumeral());
        }

        /// <summary>
        ///     Test to see if a roman numeral string is not valid
        /// </summary>
        /// <param name="stringNumeral">String numeral.</param>
        [Test]
        [TestCase("Foo")]
        [TestCase("MMXVIII9_KL")]
        public void StringNotValidRomanNumeral(string stringNumeral)
        {
            Assert.IsFalse(stringNumeral.IsValidRomanNumeral());
        }
    }
}