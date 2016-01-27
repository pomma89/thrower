// File name: RaiseHttpException.cs
// 
// Author(s): Alessio Parma <alessio.parma@gmail.com>
// 
// The MIT License (MIT)
// 
// Copyright (c) 2013-2016 Alessio Parma <alessio.parma@gmail.com>
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
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using PommaLabs.Thrower.Validation;
using System;
using System.Net;

namespace PommaLabs.Thrower
{
    /// <summary>
    ///   Utility methods which can be used to handle error codes through HTTP.
    /// </summary>
    public static class RaiseHttpException
    {
        /// <summary>
        ///   Throws <see cref="HttpException"/> if given condition is true.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="httpStatusCode">The HTTP status code corresponding to the error.</param>
        /// <param name="message">The optional message.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void If(bool condition, HttpStatusCode httpStatusCode, string message = null)
        {
            if (condition)
            {
                throw string.IsNullOrEmpty(message) ? new HttpException(httpStatusCode) : new HttpException(httpStatusCode, message);
            }
        }

        /// <summary>
        ///   Throws <see cref="HttpException"/> if given condition is true.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="httpStatusCode">The HTTP status code corresponding to the error.</param>
        /// <param name="message">The required message.</param>
        /// <param name="additionalInfo">Additional exception info.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void If(bool condition, HttpStatusCode httpStatusCode, string message, HttpExceptionInfo additionalInfo)
        {
            if (condition)
            {
                throw new HttpException(httpStatusCode, message, additionalInfo);
            }
        }

        /// <summary>
        ///   Throws <see cref="HttpException"/> if given condition is false.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="httpStatusCode">The HTTP status code corresponding to the error.</param>
        /// <param name="message">The optional message.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void IfNot(bool condition, HttpStatusCode httpStatusCode, string message = null)
        {
            if (!condition)
            {
                throw string.IsNullOrEmpty(message) ? new HttpException(httpStatusCode) : new HttpException(httpStatusCode, message);
            }
        }

        /// <summary>
        ///   Throws <see cref="HttpException"/> if given condition is false.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="httpStatusCode">The HTTP status code corresponding to the error.</param>
        /// <param name="message">The required message.</param>
        /// <param name="additionalInfo">Additional exception info.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void IfNot(bool condition, HttpStatusCode httpStatusCode, string message, HttpExceptionInfo additionalInfo)
        {
            if (!condition)
            {
                throw new HttpException(httpStatusCode, message, additionalInfo);
            }
        }
    }

    /// <summary>
    ///   Additional info which will be included into <see cref="HttpException"/>.
    /// </summary>
    public struct HttpExceptionInfo
    {
        /// <summary>
        ///   Builds the additional exception info.
        /// </summary>
        /// <param name="errorCode">The application defined error code.</param>
        /// <param name="userMessage">The user message.</param>
        public HttpExceptionInfo(object errorCode = null, string userMessage = null)
        {
            ErrorCode = errorCode ?? HttpException.DefaultErrorCode;
            UserMessage = userMessage ?? HttpException.DefaultUserMessage;
        }

        /// <summary>
        ///   The application defined error code.
        /// </summary>
        [Validate(Required = false)]
        public object ErrorCode { get; set; }

        /// <summary>
        ///   An error message which can be shown to user.
        /// </summary>
        [Validate(Required = false)]
        public string UserMessage { get; set; }
    }

    /// <summary>
    ///   Represents an exception which contains an error message that should be delivered through
    ///   the HTTP response, using given status code.
    /// </summary>
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
            : base()
        {
            HttpStatusCode = httpStatusCode;
            ErrorCode = additionalInfo.ErrorCode ?? DefaultErrorCode;
            UserMessage = additionalInfo.UserMessage ?? DefaultUserMessage;
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
    }
}