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

                Assert.Equal(morseCodeText, text);
            }

            [Fact]
            public void Ctor_ForGivenTextAndExplicitDelimiter_ShouldReturnExpectedFromImplicitConversion()
            {
                var morseCode = new MorseCode("helpme", "*");
                string morseCodeText = morseCode.Code;
                var expectedMorseCodeText = "....*.*.-..*.--.*--*.";

                Assert.Equal(expectedMorseCodeText, morseCodeText);
            }

            [Fact]
            public void ImplicitConversionFromString_ForGivenString_ShouldReturnExpectedFromImplicitConversion()
            {
                MorseCode morseCode = "helpme";
                string morseCodeText = morseCode.Code;
                var expectedMorseCodeText = "....|.|.-..|.--.|--|.";

                Assert.Equal(expectedMorseCodeText, morseCodeText);
            }
        }

        public class MorseCode
        {
            private string plainText;
            private string delimiter;

            public string Code { get; private set; }

            public MorseCode(string plainText, string _morseDelimiter = MorseCodeConstants.MorseCodesSeparator)
            {
                this.plainText = plainText;
                Code = MorseCodeConverter.ToMorseCode(plainText, _morseDelimiter);
                delimiter = _morseDelimiter;
            }

            // Implement implicit operator for converting from string to MorseCode.
            public static implicit operator MorseCode(string text)
            {
                return new MorseCode(text);
            }

            // Implement implicit operator for converting from MorseCode to string.
            public static implicit operator string(MorseCode code)
            {
                return code.plainText;
            }
        }

        public static class MorseCodeConverter
        {
            private static IDictionary<string, string> characters;

            private static IDictionary<string, string> switchedCharacters;

            public static string ToMorseCode(string text, string _morseDelimiter = MorseCodeConstants.MorseCodesSeparator)
            {
                if (string.IsNullOrWhiteSpace(text))
                {
                    return string.Empty;
                }

                PopulateCharacters();

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < text.Length; i++)
                {
                    sb.Append(characters[text[i].ToString().ToLower()]);
                    if (i < text.Length-1)
                    {
                        sb.Append(_morseDelimiter);
                    }
                }

                return sb.ToString();
            }

            public static string FromMorseCode(string morseCode, string _morseDelimiter = MorseCodeConstants.MorseCodesSeparator)
            {
                if (string.IsNullOrWhiteSpace(morseCode))
                {
                    return string.Empty;
                }

                PopulateCharacters();

                StringBuilder sb = new StringBuilder();
                var codes = morseCode.Split(_morseDelimiter[0]);

                for (int i = 0; i < codes.Length; i++)
                {
                    sb.Append(switchedCharacters[codes[i]]);
                }

                return sb.ToString();
            }

            private static void PopulateCharacters()
            {
                if (characters != null)
                {
                    return;
                }

                characters = JsonConvert.DeserializeObject<IDictionary<string, string>>(MorseCodeConstants.MorseAlphabetAsJson);
                switchedCharacters = characters.ToDictionary(x => x.Value, x => x.Key);
            }
        }

        public class MorseCodeCharacter
        {
            public MorseCodeCharacter(char character, string morseCode)
            {
                Character = character;
                MorseCode = morseCode;
            }

            public char Character { get; private set; }

            public string MorseCode { get; private set; }
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