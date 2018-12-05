using System.Diagnostics.CodeAnalysis;

namespace SnipsSolution
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Encryptions
    {
        /// <summary>
        ///     XOR Encryption, also known as XOR Cipher, is a encryption algorithm.
        ///     With this algorithm, a string of text can be encrypted by applying the bitwise XOR operator to every character
        ///     using a given key.
        ///     To decrypt the output, merely reapplying the XOR function with the key will remove the cipher.
        /// </summary>
        /// <returns>The ipher.</returns>
        /// <param name="data">Data.</param>
        /// <param name="key">Key.</param>
        public static string XORCipher(string data, string key)
        {
            var dataLen = data.Length;
            var keyLen = key.Length;

            var output = new char[dataLen];

            for (var i = 0; i < dataLen; ++i)
            {
                output[i] = (char) (data[i] ^ key[i%keyLen]);
            }
            return new string(output);

            /*
             * Example Usage
             * 
             *  string text = "The quick brown fox jumps over the lazy dog.";
                string key = "secret";
                string cipherText = XORCipher(text, key);
                string plainText = XORCipher(cipherText, key);
             * 
             * Output = 
             * cipherText: "'\r\u0006R\u0014\u0001\u001a\u0006\bR\a\u0006\u001c\u0012\rR\u0003\u001b\vE\t\a\b\u0004\0E\f\u0004\0\u0006S\u0011\v\u0017E\u0018\u0012\u001f\u001aR\u0001\u001b\u0014K"
               plainText: "The quick brown fox jumps over the lazy dog."
             * 
             */
        }

        /// <summary>
        ///     BKDR is a simple hash function using a strange set of possible seeds which all constitute a pattern of
        ///     31....31...31 etc.
        /// </summary>
        /// <returns>The hash.</returns>
        /// <param name="toHash">To hash.</param>
        public static uint BKDRHash(string toHash)
        {
            const uint seed = 131;
            uint hash = 0;
            uint i;

            for (i = 0; i < toHash.Length; i++)
            {
                hash = hash*seed + (byte) toHash[(int) i];
            }

            return hash;

            // Example Usage
            //string data = "jdfgsdhfsdfsd 6445dsfsd7fg/*/+bfjsdgf %$^";
            //uint val = BKDRHash(data);

            //Output
            //3255416723
        }

        public static uint SDBMHash(string str)
        {
            uint hash = 0;
            uint i;
            for (i = 0; i < str.Length; i++)
            {
                hash = (byte) str[(int) i] + (hash << 6) + (hash << 16) - hash;
            }
            return hash;
        }
    }
}