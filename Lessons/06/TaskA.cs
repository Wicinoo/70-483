using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Newtonsoft.Json;

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
                //throw new NotImplementedException();

                var morseCode = new MorseCode(text);
                string morseCodeText = morseCode;

                Assert.Equal(expectedMorseCodeText, morseCodeText);
            }

            [Fact]
            public void Ctor_ForGivenTextAndExplicitDelimiter_ShouldReturnExpectedFromImplicitConversion()
            {
                //throw new NotImplementedException();

                var morseCode = new MorseCode("helpme", "*");
                string morseCodeText = morseCode;
                var expectedMorseCodeText = "....*.*.-..*.--.*--*.";

                Assert.Equal(expectedMorseCodeText, morseCodeText);
            }

            [Fact]
            public void ImplicitConversionFromString_ForGivenString_ShouldReturnExpectedFromImplicitConversion()
            {
                //throw new NotImplementedException();

                MorseCode morseCode = "helpme";
                string morseCodeText = morseCode;
                var expectedMorseCodeText = "....|.|.-..|.--.|--|.";

                Assert.Equal(expectedMorseCodeText, morseCodeText);
            }
        }

        public class MorseCode
        {
            private string codeWithDelimiters;
            private string delimiter;

            public MorseCode(string _morseCodeWithDelimiters, string _morseDelimiter = MorseCodeConstants.MorseCodesSeparator)
            {
                codeWithDelimiters = _morseCodeWithDelimiters;
                delimiter = _morseDelimiter;
            }

            // Implement implicit operator for converting from string to MorseCode.
            public static implicit operator string(MorseCode code)
            {
                return MorseCodeConverter.ToMorseCode(code.codeWithDelimiters, code.delimiter);
            }

            // Implement implicit operator for converting from MorseCode to string.
            public static implicit operator MorseCode(string text)
            {
                return new MorseCode(text);
            }
        }

        public static class MorseCodeConverter
        {
            public static string ToMorseCode(string text)
            {
                return ToMorseCode(text, MorseCodeConstants.MorseCodesSeparator);
            }

            public static string ToMorseCode(string text, string separator)
            {
                var alphabet = GetMorseCodeAlphabet(MorseCodeConstants.MorseAlphabetAsJson);

                var outputBuilder = new StringBuilder();

                foreach (var character in text.ToLower())
                {
                    var translatedCharacter = alphabet.SingleOrDefault(x => x.Key == character).Value;

                    if (translatedCharacter != null)
                    {
                        outputBuilder.Append((outputBuilder.Length == 0 ? string.Empty : separator) + translatedCharacter);
                    }
                }

                return outputBuilder.ToString();
            }

            public static string FromMorseCode(string morseCode)
            {
                return FromMorseCode(morseCode, MorseCodeConstants.MorseCodesSeparator);
            }

            public static string FromMorseCode(string morseCode, string separator)
            {
                var alphabet = GetMorseCodeAlphabet(MorseCodeConstants.MorseAlphabetAsJson);

                var stringsToTranslate = morseCode.Split(separator.ToCharArray()[0]);

                var outputBuilder = new StringBuilder();

                foreach (var stringToTranslate in stringsToTranslate)
                {
                    var translated = alphabet.SingleOrDefault(x => x.Value.Equals(stringToTranslate)).Key;

                    if (translated != char.MinValue)
                    {
                        outputBuilder.Append(translated);
                    }
                }

                return outputBuilder.ToString();
            }

            private static Dictionary<char, string> GetMorseCodeAlphabet(string alphabetAsJson)
            {
                return JsonConvert.DeserializeObject<Dictionary<char, string>>(alphabetAsJson);
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