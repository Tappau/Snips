using NUnit.Framework;
using SnipsSolution.Extensions;

namespace Snips.Test.ExtensionTests
{
    public class CharExtensionTests
    {
        [TestCase('c', 4, "cccc")]
        [TestCase('f', 2, "ff")]
        public void Replicate(char character, int replicationTimes, string expectedResponse)
        {
            Assert.AreEqual(expectedResponse, character.Replicate(replicationTimes));
        }
    }
}