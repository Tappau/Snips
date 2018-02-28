using System;
using NUnit.Framework;
using SnipsSolution.Extensions;

namespace Snips.Test.ExtensionTests
{
    [TestFixture]
    public class DataExtensionsTest
    {
        [Test]
        public void ToCSV_Should_Return_Correct_Comma_Seperated_Values(){
            var values = new[] { 1, 2, 3, 4, 5 };
            string csv = values.ToCsv();

            Assert.AreEqual("1,2,3,4,5", csv);
        }
        [Test]
        public void ToCSV_Should_Return_Correct_Comma_Seperated_Using_Specified_Value()
        {
            var values = new[] { 1, 2, 3, 4, 5 };
            string csv = values.ToCsv('%');

            Assert.AreEqual("1%2%3%4%5", csv);
        }
    }
}
