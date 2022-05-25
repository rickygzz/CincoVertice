// <copyright file="Strings.cs" company="Ricardo Gonzalez-Garza and 5Vertice Team">
// This file is part of the VerticeLib distribution (https://github.com/rickygzz/VerticeLib/).
// Copyright (c) 2018 - 2022 Ricardo Gonzalez-Garza and 5Vertice Team. All Rights Reserved.
// Contact ricardo@5vertice.com for additional information.
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, version 3.
//
// This program is distributed in the hope that it will be useful, but
// WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
// General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program. If not, see (http://www.gnu.org/licenses/).
// </copyright>

namespace VerticeLib.Strings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Strings class.
    /// </summary>
    public class Strings
    {
        /// <summary>
        /// After. Gets the string after the delimiter.
        /// <para>Example: After("A = B", "=", true) will return "B".</para>
        /// </summary>
        /// <param name="text">The string to work with.</param>
        /// <param name="delimiter">The string to look up within text, delimiting the text before and after.</param>
        /// <param name="trim">If true, it removes all leading and trailing white-spaces from the current string.</param>
        /// <returns>If sucessful, gets the string after the delimiter. Otherwise, returns string.Empty if there is no characters after delimiter or no delimiter is found.</returns>
        public static string After(string text, string delimiter, bool trim = false)
        {
            int textLength = text.Length;
            int delimiterLength = delimiter.Length;

            for (int i = 0; i < (textLength - delimiterLength); i++)
            {
                if (text.Substring(i, delimiterLength) == delimiter)
                {
                    if (trim)
                    {
                        return text.Substring(i + delimiterLength).Trim();
                    }

                    return text.Substring(i + delimiterLength);
                }
            }

            return string.Empty;
        }
    }
}
