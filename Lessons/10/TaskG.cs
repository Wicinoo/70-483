using System.Text.RegularExpressions;

using Xunit;

namespace Lessons._10
{
    /*
G. Write a method that checks if a string is a valid name with these rules:

- Only characters a, ..., z and A, ..., Z are allowed in each word
- Words are delimited by a space.
- There should be at least one word in a name.
- There should be maximal three words in a name.
- Upper characters should be only at the beginning of a word.

Use a regular expression. 

Examples:
IsValidName("Kent Beck"); // true
IsValidName("Kent"); // true
IsValidName("Kent Beck Jr"); // true
IsValidName("KentBeck"); // false
IsValidName("Kent  Beck"); // false (two spaces)
IsValidName("Kent Beck Beck Beck"); // false (too many words)
IsValidName("Kent BECK"); // false (upper chars on other positions in the word)

        https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference
     */

    public class TaskG
    {
        private const string NamePattern = @"^[A-Z][a-z]*(\s[A-Z][a-z]*){0,2}$";

        private static readonly Regex NamePatternRegex = new Regex(NamePattern);

        public static void Run()
        {
        }

        [Theory]
        [InlineData("Kent Beck", true)]
        [InlineData("Kent", true)]
        [InlineData("Kent Beck Jr", true)]
        [InlineData("KentBeck", false)]
        [InlineData("Kent  Beck", false)]
        [InlineData("Kent Beck Beck Beck", false)]
        [InlineData("Kent BECK", false)]
        public void IsValidNameTest(string s, bool expected)
        {
            Assert.Equal(expected, IsValidName(s));
        }

        private static bool IsValidName(string input)
        {
            return NamePatternRegex.IsMatch(input);
        }
    }
}
