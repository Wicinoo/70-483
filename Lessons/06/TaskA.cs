using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            public string Value { get; set; }

            private string MorseDelimiter { get; set; }

            public MorseCode(string morseCodeWithDelimiters, string _morseDelimiter = MorseCodeConstants.MorseCodesSeparator)
            {
                Value = MorseCodeConverter.ToMorseCode(morseCodeWithDelimiters, _morseDelimiter);
            }

            public static implicit operator string(MorseCode morseCode)
            {
                return morseCode.Value;
            }

            public static implicit operator MorseCode(string text)
            {
                return new MorseCode(text);
            }
            // Implement implicit operator for converting from string to MorseCode.
            // Implement implicit operator for converting from MorseCode to string.
        }

        public static class MorseCodeConverter
        {
            public static Dictionary<string, string> MorseCodeDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(MorseCodeConstants.MorseAlphabetAsJson);


            public static string ToMorseCode(string text, string delimiter = MorseCodeConstants.MorseCodesSeparator)
            {
                var morseCode = string.Empty;

                foreach (var character in text)
                {
                    if (!text.StartsWith(character.ToString()))
                    {
                        morseCode = string.Concat(morseCode, delimiter);
                    }

                    var key = character.ToString().ToLowerInvariant();
                    if (MorseCodeDictionary.ContainsKey(key))
                    {
                        var value = MorseCodeDictionary[key];
                        morseCode = string.Concat(morseCode, value);
                    }
                }

                return morseCode;
            }

            public static string FromMorseCode(string morseCode, string delimiter = MorseCodeConstants.MorseCodesSeparator)
            {
                var text = string.Empty;
                var morseCodeLetters = morseCode.Split(delimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                foreach (var letter in morseCodeLetters)
                {
                    if (MorseCodeDictionary.ContainsValue(letter))
                    {
                        var key = MorseCodeDictionary.First(x => x.Value == letter).Key;
                        text = string.Concat(text, key);
                    }
                }

                return text;
            }
        }

        public class MorseCodeConstants
        {
            public const string MorseCodesSeparator = "|";

            public const string MorseAlphabetAsJson =
                @"{
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