using System.Text.RegularExpressions;

using Xunit;

namespace Lessons._10
{
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