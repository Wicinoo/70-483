using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
                throw new NotImplementedException();

                //var morseCode = new MorseCode(text);
                //string morseCodeText = morseCode;

                //Assert.Equal(expectedMorseCodeText, morseCodeText);
            }

            [Fact]
            public void Ctor_ForGivenTextAndExplicitDelimiter_ShouldReturnExpectedFromImplicitConversion()
            {
                throw new NotImplementedException();

                //var morseCode = new MorseCode("helpme", "*");
                //string morseCodeText = morseCode;
                //var expectedMorseCodeText = "....*.*.-..*.--.*--*.";

                //Assert.Equal(expectedMorseCodeText, morseCodeText);
            }

            [Fact]
            public void ImplicitConversionFromString_ForGivenString_ShouldReturnExpectedFromImplicitConversion()
            {
                throw new NotImplementedException();

                //MorseCode morseCode = "helpme";
                //string morseCodeText = morseCode;
                //var expectedMorseCodeText = "....|.|.-..|.--.|--|.";

                //Assert.Equal(expectedMorseCodeText, morseCodeText);
            }
        }







        public class MorseCode
        {
            public string ReadableText;

            public MorseCode(string morseCodeWithDelimiters, string _morseDelimiter = MorseCodeConstants.MorseCodesSeparator)
            {
                this.ReadableText = MorseCodeConverter.FromMorseCode(morseCodeWithDelimiters);
            }

            // Implement implicit operator for converting from string to MorseCode.
            public static implicit operator string (MorseCode morseCode)
            {
                return morseCode.ReadableText;
            }
            
            // Implement implicit operator for converting from MorseCode to string.
            public static implicit operator MorseCode (string text)
            {
                return new MorseCode(text);
            }
        }



        public static class MorseCodeConverter
        {
            public static string ToMorseCode(string text)
            {
                Dictionary<string, string> conversionTable = JsonConvert.DeserializeObject<Dictionary<string, string>>(MorseCodeConstants.MorseAlphabetAsJson);

                string morse = "";

                for (int i = 0; i < text.Length; i++)
                {
                    char c = text[i];
                    morse += conversionTable[c.ToString()];

                    if (i < text.Length - 1)
                    {
                        morse += MorseCodeConstants.MorseCodesSeparator;
                    }
                }

                return morse;
            }

            public static string FromMorseCode(string morseCode)
            {
                Dictionary<string, string> conversionTable = JsonConvert.DeserializeObject<Dictionary<string, string>>(MorseCodeConstants.MorseAlphabetAsJson);
                var reversedTable = conversionTable.ToDictionary(x => x.Value, x => x.Key);

                string text = "";
                var codeList = morseCode.Split(MorseCodeConstants.MorseAlphabetAsJson[0]);

                foreach (var singleCode in codeList)
                {
                    text += reversedTable[singleCode];
                }

                return text;
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