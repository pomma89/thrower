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
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT
// OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Net;

namespace PommaLabs.Thrower
{
    /// <summary>
    ///   Utility methods which can be used to handle error codes through HTTP.
    /// </summary>
    /// <remarks>This class is no longer maintained.</remarks>
    [Obsolete("Please use Raise.HttpException.If* overloads, this class has been deprecated and it will be removed in v4", true)]
    public static class RaiseHttpException
    {
        /// <summary>
        ///   Throws <see cref="HttpException"/> if given condition is true.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="httpStatusCode">The HTTP status code corresponding to the error.</param>
        /// <param name="message">The optional message.</param>
#if (NET45 || NET46 || PORTABLE)

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
#if (NET45 || NET46 || PORTABLE)

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
#if (NET45 || NET46 || PORTABLE)

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
#if (NET45 || NET46 || PORTABLE)

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
}