// File name: ArgumentNullExceptionHandler.cs
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

using JetBrains.Annotations;
using System;
using System.Runtime.CompilerServices;

#pragma warning disable CC0091 // Use static method

namespace PommaLabs.Thrower.ExceptionHandlers
{
    /// <summary>
    ///   Handler for <see cref="ArgumentNullException"/>.
    /// </summary>
    public sealed class ArgumentNullExceptionHandler
    {
        private const string DefaultMessage = "Argument, or a nested object, is null";

        #region If(Not)

        /// <summary>
        ///   Throws <see cref="ArgumentNullException"/> if given condition is true.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <exception cref="ArgumentNullException">If given condition is true.</exception>
        [MethodImpl(Raise.MethodImplOptions)]
        public void If(bool condition)
        {
            if (condition)
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given condition is true.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException">If given condition is true.</exception>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
        [MethodImpl(Raise.MethodImplOptions)]
        public void If(bool condition, string argumentName, string message = null)
        {
            if (condition)
            {
                throw new ArgumentNullException(argumentName, message ?? DefaultMessage);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentNullException"/> if given condition is false.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <exception cref="ArgumentNullException">If given condition is false.</exception>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfNot(bool condition)
        {
            if (!condition)
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given condition is false.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException">If given condition is false.</exception>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfNot(bool condition, string argumentName, string message = null)
        {
            if (!condition)
            {
                throw new ArgumentNullException(argumentName, message ?? DefaultMessage);
            }
        }

        #endregion If(Not)

        #region Classes

        /// <summary>
        ///   Throws <see cref="ArgumentNullException"/> if given argument if null.
        /// </summary>
        /// <typeparam name="TArg">The type of the argument.</typeparam>
        /// <param name="argument">The argument.</param>
        /// <exception cref="ArgumentNullException">If given argument is null.</exception>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNull<TArg>([NoEnumeration] TArg argument)
        {
            if (ReferenceEquals(argument, null))
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentNullException"/> if given argument if null.
        /// </summary>
        /// <typeparam name="TArg">The type of the argument.</typeparam>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
        /// <exception cref="ArgumentNullException">If given argument is null.</exception>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNull<TArg>([NoEnumeration] TArg argument, string argumentName, string message = null)
        {
            if (ReferenceEquals(argument, null))
            {
                throw new ArgumentNullException(argumentName, message ?? DefaultMessage);
            }
        }

        #endregion Classes

        #region Nullable structs

        /// <summary>
        ///   Throws <see cref="ArgumentNullException"/> if given argument if null.
        /// </summary>
        /// <typeparam name="TArg">The type of the nullable argument.</typeparam>
        /// <param name="argument">The argument.</param>
        /// <exception cref="ArgumentNullException">If given argument has no value.</exception>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNull<TArg>(TArg? argument)
            where TArg : struct
        {
            if (!argument.HasValue)
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentNullException"/> if given argument if null.
        /// </summary>
        /// <typeparam name="TArg">The type of the nullable argument.</typeparam>
        /// <param name="argument">The argument, by reference.</param>
        /// <exception cref="ArgumentNullException">If given argument has no value.</exception>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNull<TArg>(ref TArg? argument)
            where TArg : struct
        {
            if (!argument.HasValue)
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentNullException"/> if given argument if null.
        /// </summary>
        /// <typeparam name="TArg">The type of the nullable argument.</typeparam>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
        /// <exception cref="ArgumentNullException">If given argument has no value.</exception>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNull<TArg>(TArg? argument, string argumentName, string message = null)
            where TArg : struct
        {
            if (!argument.HasValue)
            {
                throw new ArgumentNullException(argumentName, message ?? DefaultMessage);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentNullException"/> if given argument if null.
        /// </summary>
        /// <typeparam name="TArg">The type of the nullable argument.</typeparam>
        /// <param name="argument">The argument, by reference.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
        /// <exception cref="ArgumentNullException">If given argument has no value.</exception>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNull<TArg>(ref TArg? argument, string argumentName, string message = null)
            where TArg : struct
        {
            if (!argument.HasValue)
            {
                throw new ArgumentNullException(argumentName, message ?? DefaultMessage);
            }
        }

        #endregion Nullable structs
    }
}

#pragma warning restore CC0091 // Use static method