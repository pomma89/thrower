// File name: InvalidDataExceptionHandler.cs
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

using System.IO;

#pragma warning disable CC0091 // Use static method

namespace PommaLabs.Thrower.ExceptionHandlers.IO
{
    /// <summary>
    ///   Handler for <see cref="InvalidDataException"/>.
    /// </summary>
    public sealed class InvalidDataExceptionHandler : GenericExceptionHandler<InvalidDataException>
    {
        /// <summary>
        ///   Creates an exception with given message.
        /// </summary>
        /// <param name="message">The message used by the exception.</param>
        /// <returns>An exception with given message.</returns>
        protected override InvalidDataException NewWithMessage(string message) => new InvalidDataException(message);
    }
}

#pragma warning restore CC0091 // Use static method
