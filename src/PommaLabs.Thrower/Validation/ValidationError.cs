// File name: ValidationError.cs
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

namespace PommaLabs.Thrower.Validation
{
    /// <summary>
    ///   Represents an error found while validating an object.
    /// </summary>
    [Serializable]
    public struct ValidationError : IEquatable<ValidationError>
    {
        private readonly string _path;
        private readonly string _reason;

        /// <summary>
        ///   Builds a validation error.
        /// </summary>
        /// <param name="path">Path.</param>
        /// <param name="reason">Reason.</param>
        public ValidationError(string path, string reason)
        {
            _path = path ?? string.Empty;
            _reason = reason ?? string.Empty;
        }

        /// <summary>
        ///   The path to the wrong property.
        /// </summary>
        public string Path => _path ?? string.Empty;

        /// <summary>
        ///   What caused the error.
        /// </summary>
        public string Reason => _reason ?? string.Empty;

        /// <summary>
        ///   Compares two errors.
        /// </summary>
        /// <param name="error1">Left error.</param>
        /// <param name="error2">Right error.</param>
        /// <returns>True if they are not equal, false otherwise.</returns>
        public static bool operator !=(ValidationError error1, ValidationError error2) => !(error1 == error2);

        /// <summary>
        ///   Compares two errors.
        /// </summary>
        /// <param name="error1">Left error.</param>
        /// <param name="error2">Right error.</param>
        /// <returns>True if they are equal, false otherwise.</returns>
        public static bool operator ==(ValidationError error1, ValidationError error2) => error1.Equals(error2);

        /// <summary>
        ///   Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <returns>
        ///   true if <paramref name="obj"/> and this instance are the same type and represent the
        ///   same value; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current instance.</param>
        public override bool Equals(object obj) => obj is ValidationError && Equals((ValidationError) obj);

        /// <summary>
        ///   Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        ///   true if the current object is equal to the <paramref name="other"/> parameter;
        ///   otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(ValidationError other) => Path == other.Path && Reason == other.Reason;

        /// <summary>
        ///   Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                const int prime = -1521134295;
                var hash = 12345701;
                hash = hash * prime + EqualityComparer<string>.Default.GetHashCode(Path);
                hash = hash * prime + EqualityComparer<string>.Default.GetHashCode(Reason);
                return hash;
            }
        }
    }
}