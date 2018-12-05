using NUnit.Framework;
using SnipsSolution.Extensions;

namespace Snips.Test.ExtensionTests
{
    [TestFixture]
    public class FileExtensionTests
    {
        [TestCase(0, ExpectedResult = "0.0 bytes")]
        [TestCase(1, ExpectedResult = "1.0 bytes")]
        [TestCase(1000, ExpectedResult = "1000.0 bytes")]
        [TestCase(1500, ExpectedResult = "1.0 KB")]
        [TestCase(1500000, ExpectedResult = "1.4 MB")]
        [TestCase(int.MaxValue, ExpectedResult = "2.0 GB")]
        [TestCase(long.MaxValue, ExpectedResult = "8.0 EB")]
        public string Test_FileSize_To_ReadableString(long size)
        {
            return size.ToFileSize();
        }
    }
}