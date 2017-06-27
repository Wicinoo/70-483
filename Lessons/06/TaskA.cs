using System;
using System.Linq;
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
            private string _text;
            private string _morseDelimiter;
            private string _code;

            public MorseCode(string text, string morseDelimiter = MorseCodeConstants.MorseCodesSeparator)
            {
                _text = text;
                _morseDelimiter = morseDelimiter;
            }

            public string Text
            {
                get { return this._text; }
            }

            public string Code
            {
                get
                {
                    if (_code == null)
                    {
                        _code = MorseCodeConverter.ToMorseCode(_text, _morseDelimiter);
                    }
                    return _code;
                }
            }

            // Implement implicit operator for converting from string to MorseCode.
            // Implement implicit operator for converting from MorseCode to string.

            public static implicit operator MorseCode(string text)
            {
                return new MorseCode(text);
            }

            public static implicit operator string(MorseCode morseCode)
            {
                return morseCode.Code;
            }
        }

        public static class MorseCodeConverter
        {
            private static readonly Dictionary<char, string> _alfaCodes;
            private static readonly Dictionary<string, char> _morseCodes;

            static MorseCodeConverter()
            {
                _alfaCodes = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<char, string>>(MorseCodeConstants.MorseAlphabetAsJson);
                _morseCodes = _alfaCodes.Select(x => new KeyValuePair<string, char>(x.Value, x.Key)).ToDictionary(k => k.Key, v => v.Value);
            }

            public static string ToMorseCode(string text, string delimiter = MorseCodeConstants.MorseCodesSeparator)
            {
                if (String.IsNullOrEmpty(text)) return string.Empty;
                string result = string.Empty;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                foreach (char c in text.ToLower().ToCharArray())
                {
                    if (_alfaCodes.TryGetValue(c, out result))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(delimiter);
                        }
                        sb.Append(result);
                    }
                }

                return sb.ToString();
            }

            public static string FromMorseCode(string morseCode, string delimiter = MorseCodeConstants.MorseCodesSeparator)
            {
                if (String.IsNullOrEmpty(morseCode)) return string.Empty;
                char result;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                foreach (string code in morseCode.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (_morseCodes.TryGetValue(code, out result))
                    {
                        sb.Append(result);
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