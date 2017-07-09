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
                

                MorseCode morseCode =new MorseCode("helpme");
                string morseCodeText = morseCode;
                var expectedMorseCodeText = "....|.|.-..|.--.|--|.";

                Assert.Equal(expectedMorseCodeText, morseCodeText);
            }
        }

        public class MorseCode
        {
            private readonly string _textWithDelimiters;
            private readonly char _morseDelimiter;

            
            public MorseCode(string textWithDelimiters, string morseDelimiter = MorseCodeConstants.MorseCodesSeparator)
            {
                if (morseDelimiter.Length!=1) throw new ArgumentNullException($"{nameof(morseDelimiter)}  must be char");
                _textWithDelimiters = textWithDelimiters;
                _morseDelimiter = morseDelimiter.First();
            }

            public static implicit operator string(MorseCode morseCode)
            {
                return MorseCodeConverter.ToMorseCode(morseCode._textWithDelimiters, morseCode._morseDelimiter.ToString());
            }

            // Implement implicit operator for converting from string to MorseCode.
            // Implement implicit operator for converting from MorseCode to string.
        }

        public static class MorseCodeConverter
        {
            public static string ToMorseCode(string text, string morseDelimiter = MorseCodeConstants.MorseCodesSeparator)
            {
                text = text.ToLower();
                var letters = text.ToArray();
                var result = new List<string>();
                var morseDictionary = GetMorseDIctionary();
                foreach (var letter in letters)
                {
                    string morseLetter;
                    if (morseDictionary.TryGetValue(letter.ToString(), out morseLetter))
                    {
                        result.Add(morseLetter);
                    }
                }
                return string.Join(morseDelimiter, result);
            }

            private static Dictionary<string, string> GetMorseDIctionary()
            {
                var morseDictionary =
                    JsonConvert.DeserializeObject<Dictionary<string, string>>(MorseCodeConstants.MorseAlphabetAsJson);
                return morseDictionary;
            }

            public static string FromMorseCode(string morseCode, string morseDelimiter = MorseCodeConstants.MorseCodesSeparator)
            {
                var morseDictionary = GetMorseDIctionary();
                var morseLetters = morseCode.Split(morseDelimiter.First());
                StringBuilder sb = new StringBuilder();
                foreach (var morseLetter in morseLetters)
                {
                    if (morseDictionary.ContainsValue(morseLetter))
                    {
                        sb.Append(morseDictionary.First(x => x.Value == morseLetter).Key);
                    }
                }
                return sb.ToString();
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