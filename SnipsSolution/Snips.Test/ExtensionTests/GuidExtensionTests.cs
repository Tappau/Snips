using System;
using System.Collections.Generic;
using NUnit.Framework;
using SnipsSolution.Extensions;

namespace Snips.Test.ExtensionTests
{
    [TestFixture]
    public class GuidExtensionTests
    {
        private static IEnumerable<TestCaseData> NullableGuidTestCases()
        {
            yield return new TestCaseData(Guid.Empty as Guid?, true);
            yield return new TestCaseData(null as Guid?, true);
            yield return new TestCaseData(Guid.NewGuid() as Guid?, false);
        }

        private static IEnumerable<TestCaseData> GuidTestCases()
        {
            yield return new TestCaseData(Guid.Empty, true);
            yield return new TestCaseData(Guid.NewGuid(), false);
        }

        [TestCaseSource(nameof(NullableGuidTestCases))]
        public void IsNullOrEmpty_Given_NullableGuid_ReturnsExpected(Guid? testCase, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, testCase.IsNullOrEmpty());
        }

        [TestCaseSource(nameof(GuidTestCases))]
        public void IsEmpty_Given_Guid_ReturnsExpected(Guid testCase, bool expectedResults)
        {
            Assert.AreEqual(expectedResults, testCase.IsEmpty());
        }
    }
}