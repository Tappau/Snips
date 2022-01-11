namespace SnipsSolution.Extensions
{
    public static class CharExtensions
    {
        public static string Replicate(this char character, int timesToReplicate)
        {
            return new string(character, timesToReplicate);
        }
    }
}