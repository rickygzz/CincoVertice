using System.Runtime.CompilerServices;
using VerticeLib.Utils.IO;
using VerticeLib.Utils.Lexer;
using VerticeLib.Utils.Lexer.Extensions;
using VerticeLib.Utils.Lexer.Tokens;

namespace VerticeLib.Utils.Config.Tokens
{
    public static class CGetString
    {
        /// <summary>
        /// Gets {String} from CharIndex.
        /// {String}          ::= ({String-Quoted} | {String-Unquoted}) {EOL}
        /// {String-Quoted}   ::= [[] ['] ({Printable}|{EOL})* ["] []] {Spaces}*
        /// {String-Unquoted} ::= {Printable}*
        ///
        /// {Printable} ::= [0x09 0x20-0x07E 0x80-0xFFFD].
        /// </summary>
        /// <param name="lexer">Lexer instance.</param>
        /// <returns>GenericToken.
        ///     <para>If successfull, Type = Key.</para>
        ///     <para>Otherwise, Type = Null and returns CharIndex to initial position.</para>
        /// </returns>
        public static GenericToken GetString(this ConfigLexer lexer)
        {
            GenericToken token = lexer.NullToken();

            if (lexer.SkipChar('[') && lexer.SkipChar('\"'))
            {
                while (lexer.CurrentChar != '\0')
                {
                    if (lexer.CurrentChar == '\"' && lexer.SkipGivenString("\"]"))
                    {
                        token.StartPos += 2;
                        token.Length = lexer.CharIndex - token.StartPos - 2;
                        token.Type = ConfigTokenType.StringQuoted;

                        return token;
                    }

                    lexer.NextChar();
                }

                token.StartPos += 2;
                token.Length = lexer.CharIndex - token.StartPos;
                token.Type = ConfigTokenType.ErrorQuotedStringNotClosed;

                return token;
            }

            lexer.Char(token.StartPos);

            if (lexer.SkipPrintables() && lexer.IsEOL())
            {
                token.Length = lexer.CharIndex - token.StartPos;
                token.Type = ConfigTokenType.StringUnquoted;

                lexer.SkipOneEOL();
            }

            return token;
        }
    }
}
