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
            private string _morseCode = String.Empty;

            public MorseCode(string morseCodeWithDelimiters, string _morseDelimiter = MorseCodeConstants.MorseCodesSeparator)
            {
                _morseCode = MorseCodeConverter.ToMorseCode(morseCodeWithDelimiters, _morseDelimiter);
            }

            public static implicit operator MorseCode(string text)
            {
                return new MorseCode(text);
            }

            public static implicit operator string(MorseCode morseCode)
            {
                return morseCode._morseCode;
            }

            // Implement implicit operator for converting from string to MorseCode.
            // Implement implicit operator for converting from MorseCode to string.
        }

        public static class MorseCodeConverter
        {
            public static string ToMorseCode(string text, string separator = null)
            {
                if (text.Length == 0)
                {
                    return String.Empty;
                }

                if (separator == null)
                {
                    separator = MorseCodeConstants.MorseCodesSeparator;
                }


                var sb = new StringBuilder();

                foreach (var letter in text)
                {
                    if (MorseCodeAlphabetProvider.MorseCodeAlphabet.ContainsKey(letter.ToString()))
                    {
                        sb.Append(MorseCodeAlphabetProvider.MorseCodeAlphabet[letter.ToString()]);
                        sb.Append(separator);
                    }
                }

                sb.Length--;
                return sb.ToString();
            }

            public static string FromMorseCode(string morseCode)
            {
                if (morseCode.Length == 0)
                {
                    return String.Empty;
                }

                var stringMessage = new StringBuilder();
                var morseCodeWord = new StringBuilder();

                foreach (var code in morseCode)
                {
                    if (code.ToString() == MorseCodeConstants.MorseCodesSeparator)
                    {
                        AppendCharToMessage(stringMessage, morseCodeWord);
                    }
                    else
                    {
                        morseCodeWord.Append(code);
                    }
                }

                if (morseCodeWord.Length > 0)
                {
                    AppendCharToMessage(stringMessage, morseCodeWord);
                }

                return stringMessage.ToString();
            }

            private static void AppendCharToMessage(StringBuilder stringMessage, StringBuilder morseCodeWord)
            {
                var letter = MorseCodeAlphabetProvider.MorseCodeAlphabet.FirstOrDefault(x => x.Value == morseCodeWord.ToString()).Key;
                stringMessage.Append(letter);
                morseCodeWord.Clear();
            }
        }

        public static class MorseCodeAlphabetProvider
        {
            private static Dictionary<string, string> _morseCodeAlphabet;

            public static Dictionary<string, string> MorseCodeAlphabet
            {
                get
                {
                    return _morseCodeAlphabet == null ? _morseCodeAlphabet = CreateAlphabeth() : _morseCodeAlphabet;
                }
            }

            private static Dictionary<string, string> CreateAlphabeth()
            {
                dynamic dynJson = JsonConvert.DeserializeObject(MorseCodeConstants.MorseAlphabetAsJson);
                var morseCodeAlphabet = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

                foreach (var item in dynJson)
                {
                    morseCodeAlphabet.Add(item.Name.ToString(), item.Value.ToString());
                }

                return morseCodeAlphabet;
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