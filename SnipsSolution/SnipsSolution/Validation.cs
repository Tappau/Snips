using System.Linq;

namespace SnipsSolution
{
    public class Validation
    {
        public static bool CheckPassword(string pass)
        {
            //min 6 chars, max 12
            if (pass.Length < 6 || pass.Length > 12)
                return false;

            //No white space
            if (string.IsNullOrWhiteSpace(pass))
                return false;
            //At least 1 upper case character
            if (!pass.Any(char.IsUpper))
                return false;
            //At least 1 lower case
            if (!pass.All(char.IsLower))
                return false;

            //No two similar characters consecutively
            for (var i = 0; i < pass.Length - 1; i++)
            {
                if (pass[i] == pass[i + 1])
                    return false;
            }

            //At least 1 special character
            var specialCharacters = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
            var specialCharactersArray = specialCharacters.ToCharArray();
            foreach (var c in specialCharactersArray)
            {
                if (pass.Contains(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
}