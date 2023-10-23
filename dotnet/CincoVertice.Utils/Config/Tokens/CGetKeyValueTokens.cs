﻿using CincoVertice.Utils.Lexer;
using CincoVertice.Utils.Lexer.Extensions;
using CincoVertice.Utils.Lexer.Tokens;

namespace CincoVertice.Utils.Config.Tokens
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
            if (keyToken.Type == GenericTokenType.Null)
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

            if (valueToken.Type == GenericTokenType.Null)
            {
                valueToken.Type = ConfigTokenType.ErrorNoValueFound;
            }

            return new ConfigItemModel { Key = keyToken, Value = valueToken }; ;
        }
    }
}
