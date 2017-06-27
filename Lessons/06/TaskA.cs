using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            private readonly Dictionary<string, string> _dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(MorseCodeConstants.MorseAlphabetAsJson);

            private string _text;

            public MorseCode(string morseCodeWithDelimiters, string _morseDelimiter = MorseCodeConstants.MorseCodesSeparator)
            {
                if (string.IsNullOrEmpty(morseCodeWithDelimiters))
                {
                    _text = string.Empty;
                }
                else
                {
                    _text = string.Join(
                        _morseDelimiter, 
                        morseCodeWithDelimiters.Select(
                            x => 
                                (_dictionary.ContainsKey(x.ToString().ToLower()) ?
                                    _dictionary[x.ToString().ToLower()] :
                                    string.Empty
                                )
                            )
                        );
                }
            }

            public static implicit operator string(MorseCode morseCode)
            {
                return morseCode._text;
            }

            public static implicit operator MorseCode(string text)
            {
                return new MorseCode(text);
            }
        }

        public static class MorseCodeConverter
        {
            public static string ToMorseCode(string text)
            {
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(MorseCodeConstants.MorseAlphabetAsJson);


                    return string.Join(
                        MorseCodeConstants.MorseCodesSeparator,
                        text.Select(
                            x =>
                                (dictionary.ContainsKey(x.ToString().ToLower()) ?
                                    dictionary[x.ToString().ToLower()] :
                                    string.Empty
                                )
                            )
                        );
            }

            public static string FromMorseCode(string morseCode)
            {
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(MorseCodeConstants.MorseAlphabetAsJson).ToDictionary(x => x.Value, x=> x.Key);
                var splitText = morseCode.Split(MorseCodeConstants.MorseCodesSeparator.ToCharArray());

                return string.Join(
                    string.Empty,
                    splitText.Select(
                        x =>
                            (dictionary.ContainsKey(x.ToString()) ?
                                dictionary[x.ToString()] :
                                string.Empty
                            )
                        )
                    );
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