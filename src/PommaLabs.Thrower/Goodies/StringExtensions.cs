// File name: StringExtensions.cs
//
// Author(s): Alessio Parma <alessio.parma@gmail.com>
//
// The MIT License (MIT)
//
// Copyright (c) 2013-2018 Alessio Parma <alessio.parma@gmail.com>
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
// associated documentation files (the "Software"), to deal in the Software without restriction,
// including without limitation the rights to use, copy, modify, merge, publish, distribute,
// sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT
// NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT
// OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;

namespace PommaLabs.Thrower.Goodies
{
    /// <summary>
    ///   Extension methods for <see cref="string"/>.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///   Returned when there are no substrings.
        /// </summary>
        private static readonly IList<string> NoSubstrings = new string[0];

        /// <summary>
        ///   Truncates given string if its length is greater than specified <paramref name="maxLength"/>.
        /// </summary>
        /// <param name="str">The string to be truncated.</param>
        /// <param name="maxLength">The length at which string should be truncated.</param>
        /// <returns>The first <paramref name="maxLength"/> characters of <paramref name="str"/>.</returns>
        public static string Truncate(this string str, int maxLength)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            maxLength = Math.Max(0, maxLength);
            return (str.Length < maxLength ? str : str.Substring(0, maxLength));
        }

        /// <summary>
        ///   Returns a string array that contains the substrings in this string that are delimited
        ///   by elements of a specified Unicode character array. Substrings are trimmed before being
        ///   returned to the caller.
        /// </summary>
        /// <param name="str">The string that should be split.</param>
        /// <param name="separator">
        ///   An array of Unicode characters that delimit the substrings in this string, an empty
        ///   array that contains no delimiters, or null.
        /// </param>
        /// <returns>
        ///   A string array that contains the substrings in this string that are delimited by
        ///   elements of a specified Unicode character array. Substrings are trimmed before being
        ///   returned to the caller.
        /// </returns>
        public static IList<string> SplitAndTrim(this string str, params char[] separator)
        {
            if (string.IsNullOrEmpty(str))
            {
                return NoSubstrings;
            }

            var split = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            if (split.Length == 0)
            {
                return NoSubstrings;
            }

            var result = new string[split.Length];
            for (var i = 0; i < split.Length; ++i)
            {
                result[i] = split[i].Trim();
            }

            return result;
        }

        /// <summary>
        ///   Returns a string array that contains the substrings in this string that are delimited
        ///   by elements of a specified string array. Substrings are trimmed before being returned
        ///   to the caller.
        /// </summary>
        /// <param name="str">The string that should be split.</param>
        /// <param name="separator">
        ///   An array of strings that delimit the substrings in this string, an empty array that
        ///   contains no delimiters, or null.
        /// </param>
        /// <returns>
        ///   A string array that contains the substrings in this string that are delimited by
        ///   elements of a specified string array. Substrings are trimmed before being returned to
        ///   the caller.
        /// </returns>
        public static IList<string> SplitAndTrim(this string str, params string[] separator)
        {
            if (string.IsNullOrEmpty(str))
            {
                return NoSubstrings;
            }

            var split = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            if (split.Length == 0)
            {
                return NoSubstrings;
            }

            var result = new string[split.Length];
            for (var i = 0; i < split.Length; ++i)
            {
                result[i] = split[i].Trim();
            }

            return result;
        }
    }
}