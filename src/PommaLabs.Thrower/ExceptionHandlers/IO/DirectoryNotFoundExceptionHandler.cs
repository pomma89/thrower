// File name: DirectoryNotFoundExceptionHandler.cs
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

#if !(NETSTD10 || NETSTD11)

using System.IO;
using System.Runtime.CompilerServices;

#pragma warning disable CC0091 // Use static method

namespace PommaLabs.Thrower.ExceptionHandlers.IO
{
    /// <summary>
    ///   Handler for <see cref="DirectoryNotFoundException"/>.
    /// </summary>
    public sealed class DirectoryNotFoundExceptionHandler : GenericExceptionHandler<DirectoryNotFoundException>
    {
        /// <summary>
        ///   Creates an exception with given message.
        /// </summary>
        /// <param name="message">The message used by the exception.</param>
        /// <returns>An exception with given message.</returns>
        protected override DirectoryNotFoundException NewWithMessage(string message) => new DirectoryNotFoundException(message);

        /// <summary>
        ///   The default message for <see cref="IfNotExists(string, string)"/>, used when none has
        ///   been specified.
        /// </summary>
        public static string DefaultNotExistsMessage { get; } = "Specified directory does not exist";

        /// <summary>
        ///   Throws <see cref="DirectoryNotFoundException"/> if specified directory does not exist.
        /// </summary>
        /// <param name="directoryPath">The path of the directory that should exist.</param>
        /// <param name="message">The optional message.</param>
        /// <exception cref="FileNotFoundException">If specified directory does not exist.</exception>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfNotExists(string directoryPath, string message = null)
        {
            if (!Directory.Exists(directoryPath))
            {
                var exMsg = $@"{message ?? DefaultNotExistsMessage} - ""{directoryPath}""";
                throw new DirectoryNotFoundException(exMsg);
            }
        }
    }
}

#pragma warning restore CC0091 // Use static method

#endif