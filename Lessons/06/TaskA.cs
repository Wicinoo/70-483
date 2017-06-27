using System;
using System.Collections.Generic;
using System.Linq;
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

           // [Theory]
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
                var morseCode = (MorseCode)(text);

                Assert.Equal(expectedMorseCodeText, morseCode.MorseCodeWithDelimiters);
            }

            [Fact]
            public void Ctor_ForGivenTextAndExplicitDelimiter_ShouldReturnExpectedFromImplicitConversion()
            {
                var morseCode = new MorseCode("....*.*.-..*.--.*--*.", "*");
                string morseCodeText = morseCode;
                var expectedText = "helpme";

                Assert.Equal(expectedText, morseCodeText);
            }

            [Fact]
            public void ImplicitConversionFromString_ForGivenString_ShouldReturnExpectedFromImplicitConversion()
            {
                MorseCode morseCode = "helpme";
                string morseCodeText = morseCode.MorseCodeWithDelimiters;
                var expectedMorseCodeText = "....|.|.-..|.--.|--|.";

                Assert.Equal(expectedMorseCodeText, morseCodeText);
            }
        }

        public class MorseCode
        {
            public string MorseCodeWithDelimiters { get; set; }
            public string Delimiter { get; set; }
            public MorseCode(string morseCodeWithDelimiters, string morseDelimiter = MorseCodeConstants.MorseCodesSeparator)
            {
                MorseCodeWithDelimiters = morseCodeWithDelimiters;
                Delimiter = morseDelimiter;
            }

            public static implicit operator string(MorseCode code)
            {
                var split = code.MorseCodeWithDelimiters.Split(code.Delimiter.ToCharArray());
                var dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(MorseCodeConstants.MorseAlphabetAsJson);
                return split.Aggregate(string.Empty,(a, b) => a + dic.FirstOrDefault(x => x.Value == b).Key);
            }

            public static implicit operator MorseCode(string text)
            {
                var dic = JsonConvert.DeserializeObject<Dictionary<char, string>>(MorseCodeConstants.MorseAlphabetAsJson);
                return new MorseCode(String.Join(MorseCodeConstants.MorseCodesSeparator,text.ToLower().ToCharArray().Select(x => dic.ContainsKey(x) ? dic[x] : String.Empty)));
            }
        }

        public static class MorseCodeConverter
        {
            public static string ToMorseCode(string text)
            {
                return ((MorseCode) text).MorseCodeWithDelimiters;
            }

            public static string FromMorseCode(string morseCode)
            {
                return new MorseCode(morseCode);
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