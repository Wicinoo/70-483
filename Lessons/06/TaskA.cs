using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Xunit;

namespace Lessons._06
{

    /// <summary>
    /// Implement MorseCodeConverter to pass all tests.
    /// Implement MorseCode class to pass all tests. Use MorseCodeConverter.
    /// </summary>
    public class TaskA
    {
        public class MorseCodeConverterTests
        {
            // Task: Implement MorseCodeConverter.ToMorseCode
            // Don't care about invalid characters.

            [Theory]
            [InlineData("", "")]
            [InlineData("a", ".-")]
            [InlineData("A", ".-")]
            [InlineData("42", "....-|..---")]
            [InlineData("Keep@it@secret!", "-.-|.|.|.--.|.--.-.|..|-|.--.-.|...|.|-.-.|.-.|.|-|-.-.--")]
            public void ToMorseCode_ForGivenText_ShouldReturnExpected(string text, string expectedMorseCode)
            {
                var morseCode = MorseCodeConverter.ToMorseCode(text, MorseCodeConstants.MorseCodesSeparator);
                Assert.Equal(expectedMorseCode, morseCode);
            }

            // Task: Implement MorseCodeConverter.FromMorseCode
            // Don't care about invalid characters.

            [Theory]
            [InlineData("", "")]
            [InlineData("....|.|.-..|.--.|--|.", "helpme")]
            [InlineData("...|.|-.-.|.-.|.|-|...--|..---|----.|----.|---..|--...", "secret329987")]
            public void FromMorseCode_ForGivenText_ShouldReturnExpected(string morseCode, string expectedText)
            {
                var text = MorseCodeConverter.FromMorseCode(morseCode, MorseCodeConstants.MorseCodesSeparator);
                Assert.Equal(expectedText, text);
            }
        }

        public class MorseCodeTests
        {
            [Theory]
            [InlineData("", "")]
            [InlineData("a", ".-")]
            [InlineData("A", ".-")]
            [InlineData("42", "....-|..---")]
            [InlineData("Keep@it@secret!", "-.-|.|.|.--.|.--.-.|..|-|.--.-.|...|.|-.-.|.-.|.|-|-.-.--")]
            public void Ctor_ForGivenTextAndDefaultDelimiter_ShouldReturnExpectedFromImplicitConversion(string text, string expectedMorseCodeText)
            {
                var morseCode = new MorseCode(text);
                string morseCodeText = morseCode;

                Assert.Equal(expectedMorseCodeText, morseCodeText);
            }

            [Fact]
            public void Ctor_ForGivenTextAndExplicitDelimiter_ShouldReturnExpectedFromImplicitConversion()
            {
                var morseCode = new MorseCode("helpme", '*');
                string morseCodeText = morseCode;
                var expectedMorseCodeText = "....*.*.-..*.--.*--*.";

                Assert.Equal(expectedMorseCodeText, morseCodeText);
            }

            [Fact]
            public void ImplicitConversionFromString_ForGivenString_ShouldReturnExpectedFromImplicitConversion()
            {
                MorseCode morseCode = "helpme";
                string morseCodeText = morseCode;
                var expectedMorseCodeText = "....|.|.-..|.--.|--|.";

                Assert.Equal(expectedMorseCodeText, morseCodeText);
            }
        }

        public class MorseCode
        {
            private static string _morseCodeWithDelimiters;
            private static char _morseDelimiter;

            public MorseCode(string morseCodeWithDelimiters, char morseDelimiter = MorseCodeConstants.MorseCodesSeparator)
            {
                _morseCodeWithDelimiters = morseCodeWithDelimiters;
                _morseDelimiter = morseDelimiter;
            }

            // Implement implicit operator for converting from string to MorseCode.
            public static implicit operator string(MorseCode morse)
            {
                return MorseCodeConverter.ToMorseCode(_morseCodeWithDelimiters, _morseDelimiter);
            }

            // Implement implicit operator for converting from MorseCode to string.
            public static implicit operator MorseCode(string morse)
            {
                return new MorseCode(morse);
            }

        }

        public static class MorseCodeConverter
        {
            static readonly Dictionary<string, string> MorseConstants = JsonConvert.DeserializeObject<Dictionary<string, string>>(MorseCodeConstants.MorseAlphabetAsJson);

            private static readonly Dictionary<string, string> InvertedMorseConstants = MorseConstants.ToDictionary(pair => pair.Value, pair => pair.Key);

            public static string ToMorseCode(string text, char morseDelimiter)
            {
                var textCharacters = Regex.Split(text, @morseDelimiter.ToString()).Where(s => s != string.Empty);

                return string.Join(morseDelimiter.ToString(), textCharacters.Select(textCharacter => MorseConstants.ContainsKey(textCharacter.ToLower()) ? MorseConstants[textCharacter.ToLower()] : string.Empty).ToList());
            }

            public static string FromMorseCode(string morseCode, char morseDelimiter)
            {
                var morseCodeCharactersAsEnumerable = morseCode.Split(morseDelimiter);

                return string.Concat(morseCodeCharactersAsEnumerable.Select(s => s).Select(result => InvertedMorseConstants.ContainsKey(result) ? InvertedMorseConstants[result] : string.Empty));
            }
        }

        public class MorseCodeConstants
        {
            public const char MorseCodesSeparator = '|';

            public const string MorseAlphabetAsJson =
                @"
{
  ""0"": ""-----"",
  ""1"": "".----"",
  ""2"": ""..---"",
  ""3"": ""...--"",
  ""4"": ""....-"",
  ""5"": ""....."",
  ""6"": ""-...."",
  ""7"": ""--..."",
  ""8"": ""---.."",
  ""9"": ""----."",
  ""a"": "".-"",
  ""b"": ""-..."",
  ""c"": ""-.-."",
  ""d"": ""-.."",
  ""e"": ""."",
  ""f"": ""..-."",
  ""g"": ""--."",
  ""h"": ""...."",
  ""i"": "".."",
  ""j"": "".---"",
  ""k"": ""-.-"",
  ""l"": "".-.."",
  ""m"": ""--"",
  ""n"": ""-."",
  ""o"": ""---"",
  ""p"": "".--."",
  ""q"": ""--.-"",
  ""r"": "".-."",
  ""s"": ""..."",
  ""t"": ""-"",
  ""u"": ""..-"",
  ""v"": ""...-"",
  ""w"": "".--"",
  ""x"": ""-..-"",
  ""y"": ""-.--"",
  ""z"": ""--.."",
  ""."": "".-.-.-"",
  "","": ""--..--"",
  ""?"": ""..--.."",
  ""!"": ""-.-.--"",
  ""-"": ""-....-"",
  ""/"": ""-..-."",
  ""@"": "".--.-."",
  ""("": ""-.--."",
  "")"": ""-.--.-""
}";
        }
    }
}