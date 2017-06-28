using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
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

			public string TranslatedText { get; private set; }

            public MorseCode(string morseCodeWithDelimiters, string _morseDelimiter = null)
            {
				_morseDelimiter = _morseDelimiter ?? MorseCodeConstants.SEPARATOR.ToString();
				TranslatedText = MorseCodeConverter.ToMorseCode(morseCodeWithDelimiters, _morseDelimiter);
            }

			public static implicit operator string(MorseCode mc)
			{
				return mc.TranslatedText;
			}

			public static implicit operator MorseCode(string @string)
			{
				return new MorseCode(@string);
			}

			// Implement implicit operator for converting from string to MorseCode.
			// Implement implicit operator for converting from MorseCode to string.
		}

        public static class MorseCodeConverter
        {
			

            public static string ToMorseCode(string text) {
				return ToMorseCode(text, MorseCodeConstants.SEPARATOR);
            }

			public static string ToMorseCode(string text, string delimiter = null) {
				delimiter = delimiter ?? MorseCodeConstants.SEPARATOR.ToString();
				return ToMorseCode(text, delimiter.First());
			}

			private static string ToMorseCode(string text, char delimiter) {
				StringBuilder sb = new StringBuilder();
				text.ToList().ForEach(x => {
					sb.Append(MorseCodeConstants.Alphabet.FirstOrDefault(y => y.Key == char.ToLower(x)).Value ?? "").Append(delimiter);
					}
				);

				return sb.ToString().TrimEnd(delimiter);
			}

            public static string FromMorseCode(string morseCode) {
				StringBuilder sb = new StringBuilder();
				morseCode.Split(MorseCodeConstants.SEPARATOR).ToList().ForEach(x => {
					sb.Append(MorseCodeConstants.Alphabet.FirstOrDefault(y => y.Value == x).Key);
					}
				);

				return sb.ToString().TrimEnd('\0');
			}
        }

        public class MorseCodeConstants {
            public const char SEPARATOR = '|';

			public static readonly Dictionary<char, string> Alphabet = new Dictionary<char, string>() {
				{'0', "-----"},
				{'1', ".----"},
				{'2', "..---"},
				{'3', "...--"},
				{'4', "....-"},
				{'5', "....."},
				{'6', "-...."},
				{'7', "--..."},
				{'8', "---.."},
				{'9', "----."},
				{'a', ".-"},
				{'b', "-..."},
				{'c', "-.-."},
				{'d', "-.."},
				{'e', "."},
				{'f', "..-."},
				{'g', "--."},
				{'h', "...."},
				{'i', ".."},
				{'j', ".---"},
				{'k', "-.-"},
				{'l', ".-.."},
				{'m', "--"},
				{'n', "-."},
				{'o', "---"},
				{'p', ".--."},
				{'q', "--.-"},
				{'r', ".-."},
				{'s', "..."},
				{'t', "-"},
				{'u', "..-"},
				{'v', "...-"},
				{'w', ".--"},
				{'x', "-..-"},
				{'y', "-.--"},
				{'z', "--.."},
				{'.', ".-.-.-"},
				{',', "--..--"},
				{'?', "..--.."},
				{'!', "-.-.--"},
				{'-', "-....-"},
				{'/', "-..-."},
				{'@', ".--.-."},
				{'(', "-.--."},
				{ ')', "-.--.-" }
			};


            public const string AlphabetInJSON =
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