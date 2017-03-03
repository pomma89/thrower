// File name: FormattableObject.cs
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
using System.Linq;

namespace PommaLabs.Thrower.Goodies
{
    /// <summary>
    ///   Implements a simple <see cref="object.ToString"/>, so that you don't have to copy and paste
    ///   the same boilerplate code over and over again.
    /// </summary>
    [Serializable]
    public abstract class FormattableObject
    {
        #region Abstract Methods

        /// <summary>
        ///   Returns all property (or field) values, along with their names, so that they can be
        ///   used to produce a meaningful <see cref="object.ToString"/>.
        /// </summary>
        /// <returns>
        ///   All property (or field) values, along with their names, so that they can be used to
        ///   produce a meaningful <see cref="object.ToString"/>.
        /// </returns>
        protected abstract IEnumerable<KeyValuePair<string, string>> GetFormattingMembers();

        #endregion Abstract Methods

        #region Object Methods

        /// <summary>
        ///   Returns a <see cref="string"/> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string"/> that represents this instance.</returns>
        public override string ToString() => string.Join(", ", Enumerable.Select(GetFormattingMembers(), ToString).ToArray());

        #endregion Object Methods

        #region Static Methods

        /// <summary>
        ///   Formats given key-value pair in order to use it for <see cref="object.ToString"/>.
        /// </summary>
        /// <param name="pair">Key-value pair.</param>
        /// <returns>Formatted key-value pair.</returns>
        public static string ToString(KeyValuePair<string, string> pair)
        {
            var k = pair.Key;
            var v = pair.Value;

            // "{0}: [{1}]"

            if (v == null)
            {
                return $"{k}: null";
            }
            if (v.Length > 0)
            {
                var c = v[0];
                if (c == '"' || char.IsDigit(c))
                {
                    return $"{k}: {v}";
                }
            }
            return $"{k}: [{v}]";
        }

        #endregion Static Methods
    }
}