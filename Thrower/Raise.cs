// File name: Raise.cs
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

using PommaLabs.Thrower.ExceptionHandlers;
using System.Diagnostics.CodeAnalysis;

namespace PommaLabs.Thrower
{
    /// <summary>
    ///   New exception handling mechanism, which is more fluent than the old ones.
    /// </summary>
    public static class Raise
    {
        /// <summary>
        ///   Handler for <see cref="System.ArgumentException"/>
        /// </summary>
        public static ArgumentExceptionHandler ArgumentException { get; } = new ArgumentExceptionHandler();

        /// <summary>
        ///   Handler for <see cref="System.ArgumentNullException"/>
        /// </summary>
        public static ArgumentNullExceptionHandler ArgumentNullException { get; } = new ArgumentNullExceptionHandler();

        /// <summary>
        ///   Handler for <see cref="System.ArgumentOutOfRangeException"/>
        /// </summary>
        public static ArgumentOutOfRangeExceptionHandler ArgumentOutOfRangeException { get; } = new ArgumentOutOfRangeExceptionHandler();

        /// <summary>
        ///   Handler for <see cref="HttpException"/>
        /// </summary>
        public static HttpExceptionHandler HttpException { get; } = new HttpExceptionHandler();

        /// <summary>
        ///   Handler for <see cref="System.IndexOutOfRangeException"/>
        /// </summary>
        public static IndexOutOfRangeExceptionHandler IndexOutOfRangeException { get; } = new IndexOutOfRangeExceptionHandler();
        
        /// <summary>
        ///   Handler for <see cref="System.InvalidOperationException"/>
        /// </summary>
        public static InvalidOperationExceptionHandler InvalidOperationException { get; } = new InvalidOperationExceptionHandler();

        /// <summary>
        ///   Handler for <see cref="System.NotSupportedException"/>
        /// </summary>
        public static NotSupportedExceptionHandler NotSupportedException { get; } = new NotSupportedExceptionHandler();

        /// <summary>
        ///   Handler for <see cref="System.ObjectDisposedException"/>
        /// </summary>
        public static ObjectDisposedExceptionHandler ObjectDisposedException { get; } = new ObjectDisposedExceptionHandler();
    }
}