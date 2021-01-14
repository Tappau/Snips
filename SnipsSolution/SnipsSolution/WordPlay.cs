using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SnipsSolution
{
    public class WordPlay
    {
        public static bool IsPalindrome(string wordToTest)
        {
            // One method using a test to check each character matches
            var min = 0;
            var max = wordToTest.Length - 1;
            while (true)
            {
                if (min > max)
                {
                    return true;
                }

                var a = wordToTest[min];
                var b = wordToTest[max];
                if (char.ToUpper(a) != char.ToUpper(b))
                {
                    return false;
                }

                min++;
                max--;


                //Another method using LINQ
                //var s = wordToTest.ToLower().Select(n => n).ToArray();
                //return new string(s).Equals(new string(s.Reverse().ToArray()));
            }
        }


        /// <summary>
        ///     Gets the hamming distance.
        /// </summary>
        /// <returns>The hamming distance.</returns>
        /// <param name="a">The alpha component.</param>
        /// <param name="b">The blue component.</param>
        public static int GetHammingDistance(string a, string b)
        {
            //Takes two strings if not equal throws a new error, else calaculates the distance between two strings
            if (a.Length != b.Length)
            {
                throw new Exception("Strings must be of equal length");
            }

            var dist = a.ToCharArray().Zip(b.ToCharArray(), (c1, c2) => new {c1, c2}).Count(mn => mn.c1 != mn.c2);
            return dist;
        }

        /// <summary>
        ///     Compute the differance between two strings.
        /// </summary>
        /// <returns>The distance.</returns>
        /// <param name="a">The alpha component.</param>
        /// <param name="b">The blue component.</param>
        public static int LevenshteinDistance(string a, string b)
        {
            var n = a.Length;
            var m = b.Length;
            var d = new int[n + 1, m + 1];
            //Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            //Step 2
            for (var i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (var j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (var i = 1; i <= n; i++)
            {
                //Step 4
                for (var j = 1; j <= m; j++)
                {
                    // Step 5
                    var cost = b[j - 1] == a[i - 1] ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }

            // Step 7
            return d[n, m];
        }

        public static int CountWords1(string test)
        {
            var count = 0;
            var inWord = false;

            foreach (var t in test)
            {
                if (char.IsWhiteSpace(t))
                {
                    inWord = false;
                }
                else
                {
                    if (!inWord)
                    {
                        count++;
                    }

                    inWord = true;
                }
            }

            return count;
        }

        public static int CountWords2(string s)
        {
            //Very accurate, but marginally slower than CountWords1

            //HOWEVER easier to maintain \S means characters that are not spaces.
            var collection = Regex.Matches(s, @"[\S]+");
            return collection.Count;
        }


        public static string ReverseSentence(string sentence)
        {
            var words = sentence.Split(' ');
            Array.Reverse(words);
            return string.Join(" ", words);
        }

        public static void ReverseWords(string rev)
        {
            var str = rev.ToCharArray();

            var n = str.Length;
            var start = 0;
            for (var i = 0; i < n; i++)
            {
                if (str[i] == ' ' && i > 0)
                {
                    Reverse(str, start, i - 1);
                    start = i + 1;
                }
                else if (i == n - 1)
                {
                    Reverse(str, start, i);
                }
            }

            Reverse(str, 0, n - 1);
        }

        private static void Reverse(char[] str, int start, int end)
        {
            while (start < end)
            {
                Swap(str, start, end);
                start++;
                end--;
            }
        }

        private static void Swap(char[] str, int start, int end)
        {
            var tmp = str[start];
            str[start] = str[end];
            str[end] = tmp;
        }

        public static int IndexOfLongestCharacterRun(string s)
        {
            int bestIdx = 0, bestScore = 0, currentIdx = 0;
            for (var i = 0; i < s.Length; ++i)
            {
                if (s[i] == s[currentIdx])
                {
                    if (bestScore >= i - currentIdx)
                    {
                        continue;
                    }

                    bestIdx = currentIdx;
                    bestScore = i - currentIdx;
                }
                else
                {
                    currentIdx = i;
                }
            }

            return bestIdx;
        }

        private static bool IsAnagram(string a, string b)
        {
            //ANAGRAMS must be same length
            //Validate the strings are not empty or not same length
            if (string.IsNullOrWhiteSpace(a) || string.IsNullOrWhiteSpace(b))
            {
                return false;
            }

            if (a.Length != b.Length)
            {
                return false;
            }

            var letters = new int[256];
            var aArray = a.ToCharArray();
            foreach (var c in aArray)
            {
                letters[c]++;
            }

            foreach (var c in b)
            {
                if (--letters[c] < 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static string GetAngrams(string s)
        {
            var arrayOfWords = s.Split('\n', '\r', ' ');
            return GetAnagrams(arrayOfWords);
        }

        private static string GetAnagrams(string[] wordsArray)
        {
            var result = "";

            for (var i = 0; i < wordsArray.Length; i++)
            {
                for (var j = i + 1; j < wordsArray.Length; j++)
                {
                    if (IsAnagram(wordsArray[i], wordsArray[j]))
                    {
                        result += wordsArray[i] + " is anagram of: " + wordsArray[j] + "\n";
                    }
                }
            }

            return result;
        }
    }
}