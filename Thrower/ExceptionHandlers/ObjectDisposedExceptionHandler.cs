// File name: ObjectDisposedExceptionHandler.cs
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
using System.Runtime.CompilerServices;

#pragma warning disable CC0091 // Use static method

namespace PommaLabs.Thrower.ExceptionHandlers
{
    /// <summary>
    ///   Handler for <see cref="ObjectDisposedException"/>.
    /// </summary>
    public sealed class ObjectDisposedExceptionHandler
    {
        /// <summary>
        ///   Throws <see cref="ObjectDisposedException"/> if the object has been disposed.
        /// </summary>
        /// <param name="disposed">Whether the object has been disposed or not.</param>
        /// <param name="objectName">The required object name.</param>
        /// <param name="message">The optional message.</param>
        /// <exception cref="ObjectDisposedException">If the object has been disposed.</exception>
        [MethodImpl(Raise.MethodImplOptions)]
        public void If(bool disposed, string objectName, string message = null)
        {
            if (disposed)
            {
                throw string.IsNullOrEmpty(message) ? new ObjectDisposedException(objectName) : new ObjectDisposedException(objectName, message);
            }
        }
    }
}

#pragma warning restore CC0091 // Use static method