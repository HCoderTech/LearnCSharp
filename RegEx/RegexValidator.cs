using System.Text.RegularExpressions;

namespace RegEx
{
    public class RegexValidator
    {
        public static bool IsPatternMatch(string regexString,string input)
        {
            Regex regex = new Regex(regexString);
            return regex.IsMatch(input);
        }

        public static string ExtractPattern(string regexString, string input)
        {
            Regex regex = new Regex(regexString);
            Match match = regex.Match(input);
            if (match.Success)
                return match.Value;
            return string.Empty;
        }
    }
}
