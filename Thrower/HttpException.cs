// File name: HttpException.cs
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
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT
// OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using PommaLabs.Thrower.Validation;
using System;
using System.Net;
using System.Runtime.Serialization;

namespace PommaLabs.Thrower
{
    /// <summary>
    ///   Additional info which will be included into <see cref="HttpException"/>.
    /// </summary>
    [Serializable]
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
    [Serializable]
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

#if !PORTABLE

        /// <summary>
        ///   Initializes a new instance of the <see cref="HttpException"/> class with serialized data.
        /// </summary>
        /// <param name="info">
        ///   The <see cref="SerializationInfo"/> that holds the serialized object data about the
        ///   exception being thrown.
        /// </param>
        /// <param name="context">
        ///   The <see cref="StreamingContext"/> that contains contextual information about the
        ///   source or destination.
        /// </param>
        private HttpException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            HttpStatusCode = (HttpStatusCode) info.GetInt32(nameof(HttpStatusCode));
            ErrorCode = info.GetString(nameof(ErrorCode));
            UserMessage = info.GetString(nameof(UserMessage));
        }

        /// <summary>
        ///   When overridden in a derived class, sets the <see cref="SerializationInfo"/> with
        ///   information about the exception.
        /// </summary>
        /// <param name="info">
        ///   The <see cref="SerializationInfo"/> that holds the serialized object data about the
        ///   exception being thrown.
        /// </param>
        /// <param name="context">
        ///   The <see cref="StreamingContext"/> that contains contextual information about the
        ///   source or destination.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///   The <paramref name="info"/> parameter is a null reference (Nothing in Visual Basic).
        /// </exception>
        [System.Security.Permissions.SecurityPermissionAttribute(System.Security.Permissions.SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Preconditions
            Raise.ArgumentNullException.IfIsNull(info, nameof(info));

            info.AddValue(nameof(HttpStatusCode), (int) HttpStatusCode);
            info.AddValue(nameof(ErrorCode), ErrorCode?.ToString() ?? string.Empty);
            info.AddValue(nameof(UserMessage), UserMessage ?? string.Empty);

            // MUST call through to the base class to let it save its own state.
            base.GetObjectData(info, context);
        }

#endif

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