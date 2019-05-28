using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace SnipsSolution
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class NumberPlay
    {
        /// <summary>
        ///     Calculates the Greatest Common Divisor of two numbers
        /// </summary>
        /// <returns>The Greatest Common Divisor</returns>
        /// <param name="num1">Num1.</param>
        /// <param name="num2">Num2.</param>
        public static int GetGCD(int num1, int num2)
        {
            while (num1 != num2)
            {
                if (num1 > num2)
                    num1 = num1 - num2;
                if (num2 > num1)
                    num2 = num2 - num1;
            }

            return num1;
        }

        /// <summary>
        ///     Returns the Least Common multiple of the 2 given numbers
        /// </summary>
        /// <returns>The Least common Multiple</returns>
        /// <param name="num1">Num1.</param>
        /// <param name="num2">Num2.</param>
        public static int GetLCM(int num1, int num2)
        {
            /*Once we know the Greatest Common Divider calculating the Least common Multiple is easy
                Using the below formula
                    LCM(a,b) = (a * b)/ GCD(a,b)
                    
*/
            return num1 * num2 / GetGCD(num1, num2);
        }

        public static string GetFizzBuzz()
        {
            var result = "";
            for (var i = 1; i < 101; i++)
                if (i % 3 == 0 && i % 5 == 0)
                    result += "FizzBuzz" + Environment.NewLine;
                else if (i % 3 == 0)
                    result += "Fizz" + Environment.NewLine;
                else if (i % 5 == 0)
                    result += "Buzz" + Environment.NewLine;
                else
                    result += i + Environment.NewLine;
            return result;
        }

        /// <summary>
        ///     Determines whether the specified number is even.
        /// </summary>
        /// <param name="num">The number to test.</param>
        /// <returns>
        ///     <c>true</c> if the specified number is even; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEven(decimal num)
        {
            return num % 2 == 0;
        }

        /// <summary>
        ///     Determines whether the specified number is even.
        /// </summary>
        /// <param name="num">The number to test</param>
        /// <returns>
        ///     <c>true</c> if the specified number is even; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEven(int num)
        {
            return num % 2 == 0;
        }

        [SuppressMessage("ReSharper", "ConvertClosureToMethodGroup")]
        public int AddEvenNumbersOnly(string commaSeperatedNumbers)
        {
            var split = commaSeperatedNumbers.Split(',').Select(val => int.Parse(val));
            var evens = split.Where(i => IsEven(i)).ToList();
            var sum = evens.Sum();

            return sum;
        }


        public static void MaxOccurance(int[] numbers)
        {
            var counts = new Dictionary<int, int>();
            foreach (var num in numbers)
            {
                counts.TryGetValue(num, out var count);
                count++;
                counts[num] = count;
            }

            int mostCommonNumber = 0, occurrences = 0;
            foreach (var pair in counts)
                if (pair.Value > occurrences)
                {
                    occurrences = pair.Value;
                    mostCommonNumber = pair.Key;
                }

            Console.WriteLine("The Most common number is {0} and it appears {1} times.", mostCommonNumber, occurrences);
        }

        public static bool IsArmstrongNumber(int number)
        {
            var digitsCount = (int)Math.Floor(Math.Log10(number)) + 1;
            var total = 0;
            var tmp = number;
            for (var i = 0; i < digitsCount; i++)
            {
                var digit = tmp % 10;
                total += (int)Math.Pow(digit, digitsCount);
                tmp = tmp / 10;
            }

            return total == number;
        }

        public static bool IsStringANumber(string input)
        {
            return decimal.TryParse(input, out _);
        }

        public static bool IsPerfectNumber(long number)
        {
            //odd Perfects number do not exist so check its even

            if (number % 2 == 1) return false;
            long result = 1;
            long i = 2;

            while (i * i <= number)
            {
                //until i <= sqrt(number)
                if (number % i == 0)
                {
                    result += i;
                    result += number / i;
                }

                i++;
            }

            if (i * i == number) result -= i;
            return result == number;
        }

        /// <summary>
        ///     Solves the quadratic equation in form
        ///     ax^2 + bx + c = 0
        /// </summary>
        /// <returns>array of real valued roots, null if equation has no real valued solution</returns>
        /// <param name="a">The alpha component.</param>
        /// <param name="b">The beta component.</param>
        /// <param name="c">C</param>
        public static double[] SolveQuadraticEquation(double a, double b, double c)
        {
            var d = b * b - 4 * a * c; //discriminant
            if (d < 0) return null;
            if (Equals(d, 0))
            {
                double[] result = { -b / 2 * a };
                return result;
            }
            else
            {
                double[] result = { (-b + Math.Sqrt(d)) / (2 * a), (-b - Math.Sqrt(d)) / (2 * a) };
                return result;
            }
        }


        public double GetFactorial(int number)
        {
            double result = 1;
            while (number != 1)
            {
                result = result * number;
                number = number - 1;
            }

            return result;
        }

        public bool IsPrimeNumber(long num)
        {
            if (num <= 1)
                return false;
            if (num % 2 == 0)
                return num == 2;

            var N = (long)(Math.Sqrt(num) + 0.5);

            for (var i = 3; i <= N; i += 2)
                if (num % i == 0)
                    return false;
            return true;
        }

        public static string WordifyNumber(decimal val)
        {
            //Humanizer nuget does this and whole lot more
            if (val == 0) return "zero";
            if (val < 0) return "- " + WordifyNumber(val);

            var units = "|One|Two|Three|Four|Five|Six|Seven|Eight|Nine".Split('|');
            var teens = "|eleven|twelve|thir#|four#|fif#|six#|seven#|eigh#|nine#".Replace("#", "teen").Split('|');
            var tens = "|Ten|Twenty|Thirty|Forty|Fifty|Sixty|Seventy|Eighty|Ninety".Split('|');
            var thou = "|Thousand|m#|b#|tr#|quadr#|quint#|sex#|sept#|oct#".Replace("#", "illion").Split('|');
            var w = "";
            var p = 0;
            val = Math.Abs(val);
            while (val > 0)
            {
                var b = (int)(val % 1000);
                if (b > 0)
                {
                    var h = b / 100;
                    var t = (b - h * 100) / 10;
                    var u = b - h * 100 - t * 10;
                    var s = (h > 0 ? units[h] + " Hundred" + ((t > 0) | (u > 0) ? " and " : "") : "") +
                            (t > 0 ? t == 1 && u > 0 ? teens[u] : tens[t] + (u > 0 ? "-" : "") : "") +
                            (t != 1 ? units[u] : "");
                    s = (val > 1000 && h == 0 && p == 0 ? " and " : val > 1000 ? ", " : "") + s;
                    w = s + " " + thou[p] + w;
                }

                val = val / 1000;
                p++;
            }

            return w;
        }

        public static int CalculateAge(DateTime dob)
        {
            return (int.Parse(DateTime.UtcNow.Date.ToString("yyyyMMdd")) - int.Parse(dob.ToString("yyyyMMdd"))) / 10000;

            //int now = int.Parse(DateTime.UtcNow.Date.ToString("yyyyMMdd"));
            //int givendob = int.Parse(dob.ToString("yyyyMMdd"));
            //return (now - givendob) / 10000;
        }

        public static int CalculateAge(string dob)
        {
            return CalculateAge(DateTime.Parse(dob));
        }
    }
}