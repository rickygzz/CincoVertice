﻿using VerticeLib.Utils.IO;
using VerticeLib.Utils.Lexer;
using VerticeLib.Utils.Lexer.Extensions;
using VerticeLib.Utils.Lexer.Tokens;

namespace VerticeLib.Utils.Config.Tokens
{
    public static class CGetKey
    {
        /// <summary>
        /// Gets key from CharIndex.
        /// <para>{Key}     ::= {Letter} ({Letter} | {Digit} | [_])*.</para>
        /// </summary>
        /// <param name="lexer">Lexer instance.</param>
        /// <returns>GenericToken.
        ///     <para>If successfull, Type = Key.</para>
        ///     <para>Otherwise, Type = Null and returns CharIndex to initial position.</para>
        /// </returns>
        public static GenericToken GetKey(this ConfigLexer lexer)
        {
            GenericToken token = lexer.NullToken();

            if (lexer.SkipLetter())
            {
                while (lexer.IsLetterChar() || lexer.IsDigit() || lexer.CurrentChar == '_')
                {
                    lexer.NextChar();
                }

                token.Length = lexer.CharIndex - token.StartPos;
                token.Type = ConfigTokenType.Key;
            }

            return token;
        }
    }
}
