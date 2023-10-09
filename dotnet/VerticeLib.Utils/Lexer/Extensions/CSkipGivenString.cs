namespace VerticeLib.Utils.Lexer.Extensions
{
    public static class CSkipGivenString
    {
        /// <summary>
        /// Skips str if it is found from current CharIndex.
        /// </summary>
        /// <param name="lexer">Lexer instance.</param>
        /// <param name="str">String to check its existance.</param>
        /// <returns>
        ///     If str is found, return true.
        ///     Otherwise, return false and leave CharIndex in its original position.
        /// </returns>
        public static bool SkipGivenString(this IGenericLexer lexer, string str)
        {
            int startIndex = lexer.CharIndex;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != lexer.CurrentChar)
                {
                    lexer.Char(startIndex);
                    return false;
                }

                lexer.NextChar();
            }

            return true;
        }
    }
}
