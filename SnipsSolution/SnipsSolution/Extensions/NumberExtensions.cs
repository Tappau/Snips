namespace SnipsSolution.Extensions
{
    public static class NumberExtensions
    {
        public static double GetPercentage(this double value, int percentage)
        {
            var percentAsDouble = (double)percentage / 100;
            return value * percentAsDouble;
        }
    }
}
