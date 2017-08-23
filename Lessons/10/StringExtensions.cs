using System;
using System.Linq;
using System.Text;

namespace Lessons._10
{
    public static class StringExtensions
    {
        public static string RemoveLastOccurrence(this string input, string toRemove)
        {
            var lastIndex = input.LastIndexOf(toRemove, StringComparison.InvariantCulture);

            return input.Substring(0, lastIndex) + input.Substring(lastIndex).Replace(toRemove, string.Empty);
        }

        internal class Transform
        {
            public Func<char, bool> CanApply { get; set; }

            public Func<char, string> Apply { get; set; }

            public Transform(Func<char, bool> canApply, Func<char, string> apply)
            {
                CanApply = canApply;
                Apply = apply;
            }
        }

        internal static readonly Transform[] transforms =
            {
                new Transform(ch => char.IsDigit(ch), ch => "#"),
                new Transform(ch => char.IsUpper(ch), ch => string.Format("{0}{0}", char.ToLower(ch))),
                new Transform(ch => char.IsWhiteSpace(ch), ch => string.Empty),
                new Transform(ch => true, ch => $"{ch}")
            };

        public static string ApplyCrazyMapping(this string input)
        {
            var result = new StringBuilder();

            foreach (var ch in input)
            {
                result.Append(transforms.First(t => t.CanApply(ch)).Apply(ch));
            }

            return result.ToString();
        }
    }
}