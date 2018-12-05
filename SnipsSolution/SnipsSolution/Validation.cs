using System.Linq;

namespace SnipsSolution
{
    public class Validation
    {
        public bool CheckPassword (string pass)
        {
            //min 6 chars, max 12
            if (pass.Length < 6 || pass.Length > 32)
                return false;

            //No white space
            if (string.IsNullOrWhiteSpace(pass))
                return false;
            //At least 1 upper case character
            if (!pass.Any(char.IsUpper))
                return false;
            //At least 1 lower case
            if (!pass.Any(char.IsLower))
                return false;

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