using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
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

                var morseCode = new MorseCode(text);
                string morseCodeText = morseCode;

                Assert.Equal(expectedMorseCodeText, morseCodeText);
            }

            [Fact]
            public void Ctor_ForGivenTextAndExplicitDelimiter_ShouldReturnExpectedFromImplicitConversion()
            {
                throw new NotImplementedException();

                var morseCode = new MorseCode("helpme", "*");
                string morseCodeText = morseCode;
                var expectedMorseCodeText = "....*.*.-..*.--.*--*.";

                Assert.Equal(expectedMorseCodeText, morseCodeText);
            }

            [Fact]
            public void ImplicitConversionFromString_ForGivenString_ShouldReturnExpectedFromImplicitConversion()
            {
                throw new NotImplementedException();

                MorseCode morseCode = "helpme";
                string morseCodeText = morseCode;
                var expectedMorseCodeText = "....|.|.-..|.--.|--|.";

                Assert.Equal(expectedMorseCodeText, morseCodeText);
            }

            
        }

        public class MorseCode
        {
            public string normal;
            private string delimiter;

           
            public MorseCode(string morseCodeWithDelimiters, string _morseDelimiter = MorseCodeConstants.MorseCodesSeparator)
            {
                delimiter = _morseDelimiter;
                normal = morseCodeWithDelimiters;
            }



            // Implement implicit operator for converting from string to MorseCode.
            public static implicit operator MorseCode(string s)
            {
                var invalid = (from letter in s.AsEnumerable() let str = letter.ToString() where !CodeBook.TextToMorse.ContainsKey(str) select str);
                if (invalid.Count() > 0)
                    throw new ArgumentException();

                return new MorseCode(s);
            }

            // Implement implicit operator for converting from MorseCode to string.
            public static implicit operator string(MorseCode d)
            {
                return string.Join(string.Empty, (from x in d.normal.AsEnumerable() select CodeBook.TextToMorse[x.ToString()] + d.delimiter)).TrimEnd(d.delimiter[0]); 
            }
        }

        public static class CodeBook
        {
            public static Dictionary<string, string> TextToMorse;
            public static Dictionary<string, string> MorseToText;

            static CodeBook()
            {
                TextToMorse = new JavaScriptSerializer().Deserialize < Dictionary < string,string>> (MorseCodeConstants.MorseAlphabetAsJson);
                MorseToText = new Dictionary<string, string>();
                TextToMorse.ToList().ForEach(x => MorseToText.Add(x.Value, x.Key));
            }
        }

        public static class MorseCodeConverter
        {
            public static string ToMorseCode(string text)
            {
                return string.Join(string.Empty, (from x in text.ToArray() select CodeBook.TextToMorse[x.ToString().ToLower()] + MorseCodeConstants.MorseCodesSeparator)).TrimEnd(MorseCodeConstants.MorseCodesSeparator[0]);
            }

            public static string FromMorseCode(string morseCode)
            {
                return string.Join(string.Empty, (from x in morseCode.Split(new[] { MorseCodeConstants.MorseCodesSeparator }, StringSplitOptions.RemoveEmptyEntries) select CodeBook.MorseToText[x]));
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
