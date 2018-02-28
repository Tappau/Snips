using System;
using NUnit.Framework;
using SnipsSolution.Extensions;

namespace Snips.Test.ExtensionTests
{
    [TestFixture]
    public class StringExtensionsTest
    {
        [Test]
        public void ReturnStringFromRight(){
            var testCase = @"Quick Brown Fox";
            var expectedResult = @" Fox";
            var outcome = testCase.Right(4);
            Assert.AreEqual(expectedResult, outcome, null, "Success");
        }

        [Test]
        public void ReturnFromLeft(){
            var testCase = @"Quick Brown Fox";
            var expectedResult = @"Quick ";
            var outcome = testCase.Left(6);
            Assert.AreEqual(expectedResult, outcome, null, "Success");
        }

    }
}
