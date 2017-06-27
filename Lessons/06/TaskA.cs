using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                var morseCode = MorseCodeConverter.ToMorseCode(text);
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
                var text = MorseCodeConverter.FromMorseCode(morseCode);
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
                var morseCode = new MorseCode("helpme", "*");
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
            private readonly string _morseCodeWithDelimiters;
            private readonly string _morseDelimiter;

            public MorseCode(string morseCodeWithDelimiters, 
                string morseDelimiter = MorseCodeConstants.MorseCodesSeparator)
            {
                _morseCodeWithDelimiters = MorseCodeConverter.ToMorseCode(morseCodeWithDelimiters, morseDelimiter);
                _morseDelimiter = morseDelimiter;
            }

            public static implicit operator MorseCode(string v)
            {
                return new MorseCode(v);
            }

            public static implicit operator string(MorseCode v)
            {
                return v._morseCodeWithDelimiters;
            }
        }

        public static class MorseCodeConverter
        {
            public static string ToMorseCode(string text)
            {
                var morseAlphabet =
                    JsonConvert.DeserializeObject<Dictionary<string, string>>
                    (MorseCodeConstants.MorseAlphabetAsJson);

                var builder = (from character in text
                               where morseAlphabet.Keys.Contains(character.ToString(), 
                               StringComparer.InvariantCultureIgnoreCase)
                               select morseAlphabet[character.ToString().ToLowerInvariant()]).ToList();


                return string.Join(MorseCodeConstants.MorseCodesSeparator, builder);
            }

            public static string FromMorseCode(string morseCode)
            {
                var morseAlphabet =
                    JsonConvert.DeserializeObject<Dictionary<string, string>>
                    (MorseCodeConstants.MorseAlphabetAsJson);
                var split = morseCode.Split(new[] { MorseCodeConstants.MorseCodesSeparator }, 
                    StringSplitOptions.None);

                var builder = new StringBuilder();

                foreach (var correspondingChar in split.Where(character => morseAlphabet.Values.Contains(character)).Select(character => morseAlphabet.Where(keyValuePair 
                    => keyValuePair.Value == character)
                    .Select(keyValuePair => keyValuePair.Key)
                    .First()))
                {
                    builder.Append(correspondingChar);
                }

                return builder.ToString();
            }

            public static string ToMorseCode(string text, string morseDelimiter)
            {
                var morseAlphabet =
                    JsonConvert.DeserializeObject<Dictionary<string, string>>
                    (MorseCodeConstants.MorseAlphabetAsJson);

                var builder = (from character in text
                               where morseAlphabet.Keys.Contains(character.ToString(),
                               StringComparer.InvariantCultureIgnoreCase)
                               select morseAlphabet[character.ToString().ToLowerInvariant()]).ToList();


                return string.Join(morseDelimiter, builder);
            }
        }

        public class MorseCodeConstants
        {
            public const string MorseCodesSeparator = "|";

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