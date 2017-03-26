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

using PommaLabs.Thrower.Reflection;
using System;
using System.Collections.Generic;

namespace PommaLabs.Thrower.Goodies
{
    /// <summary>
    ///   Extension methods for <see cref="string"/>.
    /// </summary>
    public static class StringExtensions
    {
        #region String manipulation

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

        #endregion String manipulation

        #region Type conversion

        /// <summary>
        ///   Converts given string into the specified enumeration value, applying the specified
        ///   filter on casing.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enumeration.</typeparam>
        /// <param name="enumString">The string value of one enumeration value.</param>
        /// <param name="ignoreCase">Whether to consider casing or not while parsing the string.</param>
        /// <returns>An enumeration value parsed from given string.</returns>
        /// <exception cref="InvalidOperationException">
        ///   Given type parameter <typeparamref name="TEnum"/> is not an enum.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///   Given value cannot be mapped to any enum value.
        /// </exception>
        public static TEnum ToEnum<TEnum>(this string enumString, bool ignoreCase)
            where TEnum : struct
        {
            var enumType = typeof(TEnum);
            Raise.InvalidOperationException.IfNot(PortableTypeInfo.IsEnum(enumType), "Given type is not an enumeration");

#if NET35
            var enumValue = Enum.Parse(enumType, enumString, ignoreCase);
            if (Enum.IsDefined(enumType, enumValue))
            {
                return (TEnum) enumValue;
            }
#else
            TEnum enumValue;
            if (Enum.TryParse(enumString, ignoreCase, out enumValue))
            {
                return enumValue;
            }
#endif

            throw new ArgumentException($"Given value is not available for {enumType.Name}", nameof(enumString));
        }

        /// <summary>
        ///   Converts given string into the specified enumeration value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enumeration.</typeparam>
        /// <param name="enumString">The string value of one enumeration value.</param>
        /// <returns>An enumeration value parsed from given string.</returns>
        /// <exception cref="InvalidOperationException">
        ///   Given type parameter <typeparamref name="TEnum"/> is not an enum.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///   Given value cannot be mapped to any enum value.
        /// </exception>
        public static TEnum ToEnum<TEnum>(this string enumString) where TEnum : struct => ToEnum<TEnum>(enumString, true);

        /// <summary>
        ///   Converts given string into the specified enumeration value, applying the specified
        ///   filter on casing. If given string cannot be mapped to any enum value, then default
        ///   value for <typeparamref name="TEnum"/> is returned.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enumeration.</typeparam>
        /// <param name="enumString">The string value of one enumeration value.</param>
        /// <param name="ignoreCase">Whether to consider casing or not while parsing the string.</param>
        /// <returns>
        ///   An enumeration value parsed from given string or default enum value if that is not possible.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   Given type parameter <typeparamref name="TEnum"/> is not an enum.
        /// </exception>
        public static TEnum ToEnumOrDefault<TEnum>(this string enumString, bool ignoreCase)
            where TEnum : struct
        {
            var enumType = typeof(TEnum);
            Raise.InvalidOperationException.IfNot(PortableTypeInfo.IsEnum(enumType), "Given type is not an enumeration");

#if NET35
            var enumValue = Enum.Parse(enumType, enumString, ignoreCase);
            if (Enum.IsDefined(enumType, enumValue))
            {
                return (TEnum) enumValue;
            }
#else
            TEnum enumValue;
            if (Enum.TryParse(enumString, ignoreCase, out enumValue))
            {
                return enumValue;
            }
#endif

            // Not found, return default value.
            return default(TEnum);
        }

        /// <summary>
        ///   Converts given string into the specified enumeration value. If given string cannot be
        ///   mapped to any enum value, then default value for <typeparamref name="TEnum"/> is returned.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enumeration.</typeparam>
        /// <param name="enumString">The string value of one enumeration value.</param>
        /// <returns>
        ///   An enumeration value parsed from given string or default enum value if that is not possible.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///   Given type parameter <typeparamref name="TEnum"/> is not an enum.
        /// </exception>
        public static TEnum ToEnumOrDefault<TEnum>(this string enumString) where TEnum : struct => ToEnumOrDefault<TEnum>(enumString, true);

        #endregion Type conversion
    }
}