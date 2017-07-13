using System;
using System.Collections.Generic;
using System.IO;
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
            private string _morseCodeWithDelimiters;

            private string _morseDelimiter;

            public MorseCode(string text, string morseDelimiter = MorseCodeConstants.MorseCodesSeparator)
            {
                _morseCodeWithDelimiters = MorseCodeConverter.ToMorseCode(text, morseDelimiter);
                _morseDelimiter = morseDelimiter;
            }

            // Implement implicit operator for converting from string to MorseCode.
            public static implicit operator string(MorseCode morseCode)
            {
                return morseCode._morseCodeWithDelimiters;
            }

            // Implement implicit operator for converting from MorseCode to string.
            public static implicit operator MorseCode(string text)
            {
                return new MorseCode(text);
            }
        }

        public static class MorseCodeConverter
        {
            private static Dictionary<char, string> _mapping = new JsonSerializer().Deserialize<Dictionary<char, string>>(new JsonTextReader(new StringReader(MorseCodeConstants.MorseAlphabetAsJson)));
            public static string ToMorseCode(string text, string morseDelimiter = MorseCodeConstants.MorseCodesSeparator)
            {
                var textArr = text.ToLower().ToCharArray();
                var morseString = new StringBuilder();
                for (var i = 0; i < textArr.Length; i++)
                {
                    morseString.Append(_mapping[textArr[i]]);

                    if (i < textArr.Length - 1)
                    {
                        morseString.Append(morseDelimiter);
                    }
                }

                return morseString.ToString();
            }

            public static string FromMorseCode(string morseCode, string morseDelimiter = MorseCodeConstants.MorseCodesSeparator)
            {
                var textArr = morseCode.Split(morseDelimiter.ToCharArray()[0]);
                var morseString = new StringBuilder();
                for (var i = 0; i < textArr.Length; i++)
                {
                    if(_mapping.Any(x => x.Value == textArr[i]))
                    {
                        morseString.Append(_mapping.First(x => x.Value == textArr[i]).Key);
                    }
                }

                return morseString.ToString();
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