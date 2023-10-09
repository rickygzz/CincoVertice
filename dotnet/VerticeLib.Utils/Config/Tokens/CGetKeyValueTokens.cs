using VerticeLib.Utils.IO;
using VerticeLib.Utils.Lexer;
using VerticeLib.Utils.Lexer.Extensions;
using VerticeLib.Utils.Lexer.Tokens;

namespace VerticeLib.Utils.Config.Tokens
{
    public static class CGetKeyValueTokens
    {
        /// <summary>
        /// {Token}     ::=  {Space}* ({Key-Value} | {Comment})
        /// {Key-Value} ::=  {Key} {Space}* [=] {Space}* {Value}
        /// {Comment}   ::=  [#] {Printable} {EOL}
        /// {Key}             ::= {Letter} ({Letter} | {Digit} | [_])* {Space}* = {Space}*
        /// {Value}           ::= ({NumericValue} | {String}) {EOL}
        /// {NumericValue}    ::= ({Hex} | {Oct} | {Bin} | {Number}).
        /// {String}          ::= ({String-Quoted} | {String-Unquoted})
        /// {String-Quoted}   ::= [[] ['] ({Printable}|{EOL})* ["] []] {Spaces}*
        /// {String-Unquoted} ::= {Printable}*
        /// </summary>
        /// <param name="lexer"></param>
        /// <returns></returns>
        public static ConfigItemModel GetKeyValueTokens(this ConfigLexer lexer)
        {
            GenericToken nullToken = lexer.NullToken();

            GenericToken keyToken = lexer.GetKey();
            if (keyToken.Type == ConfigTokenType.Null)
            {
                return new ConfigItemModel { Key = nullToken, Value = nullToken };
            }

            lexer.SkipBlankChars();

            if (!lexer.SkipChar('='))
            {
                lexer.Char(nullToken.StartPos);
                return new ConfigItemModel { Key = nullToken, Value = nullToken };
            }

            lexer.SkipBlankChars();
            GenericToken valueToken = lexer.GetValue();

            if (valueToken.Type == ConfigTokenType.Null)
            {
                valueToken.Type = ConfigTokenType.ErrorNoValueFound;
            }

            return new ConfigItemModel { Key = keyToken, Value = valueToken }; ;
        }
    }
}
