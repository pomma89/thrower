// File name: HttpException.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace PommaLabs.Thrower
{
    /// <summary>
    ///   Additional info which will be included into <see cref="HttpException"/>.
    /// </summary>
    [Serializable]
    public struct HttpExceptionInfo : IEquatable<HttpExceptionInfo>
    {
        private readonly object _errorCode;
        private readonly string _userMessage;

        /// <summary>
        ///   Builds the additional exception info.
        /// </summary>
        /// <param name="errorCode">The application defined error code.</param>
        /// <param name="userMessage">The user message.</param>
        public HttpExceptionInfo(object errorCode = null, string userMessage = null)
        {
            _errorCode = errorCode ?? HttpException.DefaultErrorCode;
            _userMessage = userMessage ?? HttpException.DefaultUserMessage;
        }

        /// <summary>
        ///   The application defined error code.
        /// </summary>
        public object ErrorCode => _errorCode ?? HttpException.DefaultErrorCode;

        /// <summary>
        ///   An error message which can be shown to user.
        /// </summary>
        public string UserMessage => _userMessage ?? HttpException.DefaultUserMessage;

        /// <summary>
        ///   Compares two info.
        /// </summary>
        /// <param name="info1">Left info.</param>
        /// <param name="info2">Right info.</param>
        /// <returns>True if they are not equal, false otherwise.</returns>
        public static bool operator !=(HttpExceptionInfo info1, HttpExceptionInfo info2) => !(info1 == info2);

        /// <summary>
        ///   Compares two info.
        /// </summary>
        /// <param name="info1">Left info.</param>
        /// <param name="info2">Right info.</param>
        /// <returns>True if they are equal, false otherwise.</returns>
        public static bool operator ==(HttpExceptionInfo info1, HttpExceptionInfo info2) => info1.Equals(info2);

        /// <summary>
        ///   Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <returns>
        ///   true if <paramref name="obj"/> and this instance are the same type and represent the
        ///   same value; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current instance.</param>
        public override bool Equals(object obj) => obj is HttpExceptionInfo && Equals((HttpExceptionInfo) obj);

        /// <summary>
        ///   Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        ///   true if the current object is equal to the <paramref name="other"/> parameter;
        ///   otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(HttpExceptionInfo other) => ErrorCode == other.ErrorCode && UserMessage == other.UserMessage;

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
                hash = hash * prime + EqualityComparer<object>.Default.GetHashCode(ErrorCode);
                hash = hash * prime + EqualityComparer<string>.Default.GetHashCode(UserMessage);
                return hash;
            }
        }
    }

    /// <summary>
    ///   Represents an exception which contains an error message that should be delivered through
    ///   the HTTP response, using given status code.
    /// </summary>
    [Serializable]
    [SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors")]
    public sealed class HttpException : Exception
    {
        /// <summary>
        ///   Builds the exception using given status code.
        /// </summary>
        /// <param name="httpStatusCode">The HTTP status code.</param>
        public HttpException(HttpStatusCode httpStatusCode)
            : this(httpStatusCode, new HttpExceptionInfo())
        {
        }

        /// <summary>
        ///   Builds the exception using given status code.
        /// </summary>
        /// <param name="httpStatusCode">The HTTP status code.</param>
        /// <param name="additionalInfo">Additional exception info.</param>
        public HttpException(HttpStatusCode httpStatusCode, HttpExceptionInfo additionalInfo)
        {
            HttpStatusCode = httpStatusCode;
            ErrorCode = additionalInfo.ErrorCode ?? DefaultErrorCode;
            UserMessage = additionalInfo.UserMessage ?? DefaultUserMessage;

            CustomizeException();
        }

        /// <summary>
        ///   Builds the exception using given status code and message.
        /// </summary>
        /// <param name="httpStatusCode">The HTTP status code.</param>
        /// <param name="message">The exception message.</param>
        public HttpException(HttpStatusCode httpStatusCode, string message)
            : this(httpStatusCode, message, new HttpExceptionInfo())
        {
        }

        /// <summary>
        ///   Builds the exception using given status code, message and error code.
        /// </summary>
        /// <param name="httpStatusCode">The HTTP status code.</param>
        /// <param name="message">The exception message.</param>
        /// <param name="additionalInfo">Additional exception info.</param>
        public HttpException(HttpStatusCode httpStatusCode, string message, HttpExceptionInfo additionalInfo)
            : base(message)
        {
            HttpStatusCode = httpStatusCode;
            ErrorCode = additionalInfo.ErrorCode ?? DefaultErrorCode;
            UserMessage = additionalInfo.UserMessage ?? DefaultUserMessage;

            CustomizeException();
        }

        /// <summary>
        ///   Builds the exception using given status code, message and inner exception.
        /// </summary>
        /// <param name="httpStatusCode">The HTTP status code.</param>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        public HttpException(HttpStatusCode httpStatusCode, string message, Exception innerException)
            : this(httpStatusCode, message, innerException, new HttpExceptionInfo())
        {
        }

        /// <summary>
        ///   Builds the exception using given status code, message, error code and inner exception.
        /// </summary>
        /// <param name="httpStatusCode">The HTTP status code.</param>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="additionalInfo">Additional exception info.</param>
        public HttpException(HttpStatusCode httpStatusCode, string message, Exception innerException, HttpExceptionInfo additionalInfo)
            : base(message, innerException)
        {
            HttpStatusCode = httpStatusCode;
            ErrorCode = additionalInfo.ErrorCode ?? DefaultErrorCode;
            UserMessage = additionalInfo.UserMessage ?? DefaultUserMessage;

            CustomizeException();
        }

        /// <summary>
        ///   The HTTP status code assigned to this exception.
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; }

        /// <summary>
        ///   The application defined error code.
        /// </summary>
        public object ErrorCode { get; }

        /// <summary>
        ///   The default application defined error code, used when none has been specified.
        /// </summary>
        public static object DefaultErrorCode { get; set; } = "unspecified";

        /// <summary>
        ///   An error message which can be shown to the user.
        /// </summary>
        public string UserMessage { get; }

        /// <summary>
        ///   The default user message.
        /// </summary>
        public static string DefaultUserMessage { get; set; } = "unspecified";

        private void CustomizeException()
        {
            HResult = (int) HttpStatusCode;

            Data.Add(nameof(HttpStatusCode), HttpStatusCode.ToString());
            Data.Add(nameof(ErrorCode), ErrorCode?.ToString());
            Data.Add(nameof(UserMessage), UserMessage);
        }
    }
}