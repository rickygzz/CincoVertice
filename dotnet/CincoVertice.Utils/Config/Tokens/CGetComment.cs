﻿using CincoVertice.Utils.Config;
using CincoVertice.Utils.Lexer;
using CincoVertice.Utils.Lexer.Extensions;
using CincoVertice.Utils.Lexer.Tokens;

namespace CincoVertice.Utils.Config.Tokens
{
    public static class CGetComment
    {
        /// <summary>
        /// Gets comment from CharIndex.
        /// <para>{Comment}  ::=  [#] {Printable} {EOL}.</para>
        /// </summary>
        /// <param name="lexer">Lexer instance.</param>
        /// <returns>GenericToken.
        ///     <para>If successfull, Type = Comment.</para>
        ///     <para>Otherwise, Type = Null and returns CharIndex to initial position.</para>
        /// </returns>
        public static GenericToken GetComment(this ConfigLexer lexer)
        {
            GenericToken token = lexer.NullToken();

            if (lexer.SkipChar('#') && lexer.SkipPrintables() && lexer.IsEOL())
            {
                token.Length = lexer.CharIndex - token.StartPos;
                token.Type = ConfigTokenType.Comment;

                lexer.SkipOneEOL();

                return token;
            }

            lexer.Char(token.StartPos);

            return token;
        }
    }
}
