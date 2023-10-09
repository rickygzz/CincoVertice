using VerticeLib.Utils.Lexer;
using VerticeLib.Utils.Lexer.Extensions;
using Xunit;

namespace VerticeLib.Utils.Tests.Lexer.Extensions
{
    public class IsBinDigitTest
    {
        [Theory]
        [InlineData("01")]
        public void IsBinDigit_GetsValidBinDigit_ReturnsTrue(string testStr)
        {
            // Arrange
            GenericLexer lexer = new(testStr);

            // Assert
            while (lexer.CurrentChar != '\0')
            {
                Assert.True(lexer.IsBinDigit());

                lexer.NextChar();
            }
        }

        [Theory]
        [InlineData("23456789")]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
        [InlineData("abcdefghijklmnopqrstuvwxyz")]
        public void IsBinDigit_GetsInvalidBinDigit_ReturnsFalse(string testStr)
        {
            // Arrange
            GenericLexer lexer = new(testStr);

            // Assert
            while (lexer.CurrentChar != '\0')
            {
                Assert.False(lexer.IsBinDigit());

                lexer.NextChar();
            }
        }
    }
}
