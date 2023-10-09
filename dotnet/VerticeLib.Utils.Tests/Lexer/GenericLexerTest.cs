using VerticeLib.Utils.Lexer;
using Xunit;

namespace VerticeLib.Utils.Tests.Lexer
{
    public class GenericLexerTest
    {
        [Theory]
        [InlineData("abc", 'a')]
        [InlineData("test string", 't')]
        public void CharIndexCurrentChar_InitialSetup(string testStr, char initialChar)
        {
            // Arrange
            GenericLexer lexer = new(testStr);

            // Assert
            Assert.Equal(0, lexer.CharIndex);
            Assert.Equal(initialChar, lexer.CurrentChar);
            Assert.Equal(testStr, lexer.Text);
            Assert.Equal(testStr.Length, lexer.TextLength);
        }

        [Theory]
        [InlineData("abc", 1, 2, "bc")]
        public void Substring_GetsValidParams_ReturnsSubString(string testStr, int startIndex, int length, string expectedResult)
        {
            // Arrange
            GenericLexer lexer = new(testStr);

            // Act
            string result = lexer.Substring(startIndex, length);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("abc", 4, 1, "startIndex cannot be larger than length of string")]
        [InlineData("abc", 1, 3, "Index and length must refer to a location within the string")]
        public void Substring_GetsInvalidIndexAndLength_ThrowsOurOfRangeException(
            string testStr,
            int startIndex,
            int length,
            string expectedError)
        {
            // Arrange
            GenericLexer lexer = new(testStr);

            // Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                lexer.Substring(startIndex, length);
            });

            // Act and assert
            Assert.StartsWith(expectedError, exception.Message);
        }

        [Theory]
        [InlineData("abc")]
        [InlineData("test string")]
        public void NextChar_TestLexerText(string testStr)
        {
            // Arrange
            GenericLexer lexer = new(testStr);

            // Act and assert
            foreach (char c in testStr)
            {
                Assert.Equal(c, lexer.CurrentChar);
                lexer.NextChar();
            }

            Assert.Equal('\0', lexer.CurrentChar);
            Assert.Equal(testStr.Length, lexer.CharIndex);

            lexer.NextChar();
            Assert.Equal('\0', lexer.CurrentChar);
            Assert.Equal(testStr.Length, lexer.CharIndex);
        }

        [Theory]
        [InlineData("abc")]
        [InlineData("abcd")]
        public void PrevChar_TestLexerText(string testStr)
        {
            // Arrange
            GenericLexer lexer = new(testStr);
            lexer.Char(testStr.Length - 1);

            // Act and assert
            for (int i = testStr.Length - 1; i >= 0; i--)
            {
                Assert.Equal(testStr[i], lexer.CurrentChar);
                lexer.PrevChar();
            }

            Assert.Equal('\0', lexer.CurrentChar);
            Assert.Equal(testStr.Length, lexer.CharIndex);

            lexer.PrevChar();
            Assert.Equal(testStr[testStr.Length - 1], lexer.CurrentChar);
            Assert.Equal(testStr.Length - 1, lexer.CharIndex);
        }
    }
}
