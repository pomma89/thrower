// File name: ArgumentOutOfRangeExceptionHandler.cs
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

#pragma warning disable CC0091 // Use static method

namespace PommaLabs.Thrower.ExceptionHandlers
{
    /// <summary>
    ///   Handler for <see cref="System.ArgumentOutOfRangeException"/>
    /// </summary>
    public sealed class ArgumentOutOfRangeExceptionHandler
    {
        #region If

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if given condition is true.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="argumentName">The optional name of the argument.</param>
        public void If(bool condition, string argumentName = null)
        {
            if (condition)
            {
                throw string.IsNullOrEmpty(argumentName) ? new ArgumentOutOfRangeException() : new ArgumentOutOfRangeException(argumentName);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if given condition is true.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message.</param>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
        public void If(bool condition, string argumentName, string message)
        {
            if (condition)
            {
                throw new ArgumentOutOfRangeException(argumentName, message);
            }
        }

        #endregion If

        #region IfNot

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if given condition is false.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="argumentName">The optional name of the argument.</param>
        public void IfNot(bool condition, string argumentName = null)
        {
            if (!condition)
            {
                throw string.IsNullOrEmpty(argumentName) ? new ArgumentOutOfRangeException() : new ArgumentOutOfRangeException(argumentName);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if given condition is false.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message.</param>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
        public void IfNot(bool condition, string argumentName, string message)
        {
            if (!condition)
            {
                throw new ArgumentOutOfRangeException(argumentName, message);
            }
        }

        #endregion IfNot

        #region IfIsNaN

        /// <summary>
        ///   Throws an exception of type <see cref="ArgumentOutOfRangeException"/> if and only if
        ///   specified double is <see cref="double.NaN"/>.
        /// </summary>
        /// <param name="number">The double to be tested for <see cref="double.NaN"/> equality.</param>
        /// <param name="argumentName">The optional argument name.</param>
        /// <exception cref="ArgumentOutOfRangeException">Specified double is <see cref="double.NaN"/>.</exception>
        public void IfIsNaN(double number, string argumentName = null)
        {
            if (double.IsNaN(number))
            {
                throw string.IsNullOrEmpty(argumentName) ? new ArgumentOutOfRangeException() : new ArgumentOutOfRangeException(argumentName);
            }
        }

        /// <summary>
        ///   Throws an exception of type <see cref="ArgumentOutOfRangeException"/> if and only if
        ///   specified double is <see cref="double.NaN"/>.
        /// </summary>
        /// <param name="number">The double to be tested for <see cref="double.NaN"/> equality.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ArgumentOutOfRangeException">Specified double is <see cref="double.NaN"/>.</exception>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
        public void IfIsNaN(double number, string argumentName, string message)
        {
            if (double.IsNaN(number))
            {
                throw new ArgumentOutOfRangeException(argumentName, message);
            }
        }

        #endregion IfIsNaN

        #region IfIsPositiveInfinity

        /// <summary>
        ///   Throws an exception of type <see cref="ArgumentOutOfRangeException"/> if and only if
        ///   specified double is <see cref="double.PositiveInfinity"/>.
        /// </summary>
        /// <param name="number">
        ///   The double to be tested for <see cref="double.PositiveInfinity"/> equality.
        /// </param>
        /// <param name="argumentName">The optional argument name.</param>
        /// <exception cref="ArgumentOutOfRangeException">Specified double is <see cref="double.PositiveInfinity"/>.</exception>
        public void IfIsPositiveInfinity(double number, string argumentName = null)
        {
            if (double.IsPositiveInfinity(number))
            {
                throw string.IsNullOrEmpty(argumentName) ? new ArgumentOutOfRangeException() : new ArgumentOutOfRangeException(argumentName);
            }
        }

        /// <summary>
        ///   Throws an exception of type <see cref="ArgumentOutOfRangeException"/> if and only if
        ///   specified double is <see cref="double.PositiveInfinity"/>.
        /// </summary>
        /// <param name="number">
        ///   The double to be tested for <see cref="double.PositiveInfinity"/> equality.
        /// </param>
        /// <param name="argumentName">The argument name.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ArgumentOutOfRangeException">Specified double is <see cref="double.PositiveInfinity"/>.</exception>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
        public void IfIsPositiveInfinity(double number, string argumentName, string message)
        {
            if (double.IsPositiveInfinity(number))
            {
                throw new ArgumentOutOfRangeException(argumentName, message);
            }
        }

        #endregion IfIsPositiveInfinity

        #region IfIsNegativeInfinity

        /// <summary>
        ///   Throws an exception of type <see cref="ArgumentOutOfRangeException"/> if and only if
        ///   specified double is <see cref="double.NegativeInfinity"/>.
        /// </summary>
        /// <param name="number">
        ///   The double to be tested for <see cref="double.NegativeInfinity"/> equality.
        /// </param>
        /// <param name="argumentName">The optional argument name.</param>
        /// <exception cref="ArgumentOutOfRangeException">Specified double is <see cref="double.NegativeInfinity"/>.</exception>
        public void IfIsNegativeInfinity(double number, string argumentName = null)
        {
            if (double.IsNegativeInfinity(number))
            {
                throw string.IsNullOrEmpty(argumentName) ? new ArgumentOutOfRangeException() : new ArgumentOutOfRangeException(argumentName);
            }
        }

        /// <summary>
        ///   Throws an exception of type <see cref="ArgumentOutOfRangeException"/> if and only if
        ///   specified double is <see cref="double.NegativeInfinity"/>.
        /// </summary>
        /// <param name="number">
        ///   The double to be tested for <see cref="double.NegativeInfinity"/> equality.
        /// </param>
        /// <param name="argumentName">The argument name.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ArgumentOutOfRangeException">Specified double is <see cref="double.NegativeInfinity"/>.</exception>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
        public void IfIsNegativeInfinity(double number, string argumentName, string message)
        {
            if (double.IsNegativeInfinity(number))
            {
                throw new ArgumentOutOfRangeException(argumentName, message);
            }
        }

        #endregion IfIsNegativeInfinity

        #region Less - Without parameter name, without message

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   less than <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        public void IfIsLess<TArg>(TArg argument1, TArg argument2)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   less than <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        public void IfIsLess(IComparable argument1, IComparable argument2)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        #endregion Less - Without parameter name, without message

        #region Less - With parameter name, without message

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   less than <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public void IfIsLess<TArg>(TArg argument1, TArg argument2, string argumentName)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) < 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   less than <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public void IfIsLess(IComparable argument1, IComparable argument2, string argumentName)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) < 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        #endregion Less - With parameter name, without message

        #region Less - With parameter name, with message

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   less than <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
        public void IfIsLess<TArg>(TArg argument1, TArg argument2, string argumentName, string message)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) < 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument1, message);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   less than <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
        public void IfIsLess(IComparable argument1, IComparable argument2, string argumentName, string message)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) < 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument1, message);
            }
        }

        #endregion Less - With parameter name, with message

        #region LessEqual - Without parameter name, without message

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   less than or equal to <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        public void IfIsLessOrEqual<TArg>(TArg argument1, TArg argument2)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   less than or equal to <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        public void IfIsLessOrEqual(IComparable argument1, IComparable argument2)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        #endregion LessEqual - Without parameter name, without message

        #region LessEqual - With parameter name, without message

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   less than or equal to <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public void IfIsLessOrEqual<TArg>(TArg argument1, TArg argument2, string argumentName)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) <= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   less than or equal to <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public void IfIsLessOrEqual(IComparable argument1, IComparable argument2, string argumentName)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) <= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        #endregion LessEqual - With parameter name, without message

        #region LessEqual - With parameter name, with message

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   less than or equal to <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
        public void IfIsLessOrEqual<TArg>(TArg argument1, TArg argument2, string argumentName, string message)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) <= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument1, message);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   less than or equal to <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
        public void IfIsLessOrEqual(IComparable argument1, IComparable argument2, string argumentName, string message)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) <= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument1, message);
            }
        }

        #endregion LessEqual - With parameter name, with message

        #region Greater - Without parameter name, without message

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   greater than <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        public void IfIsGreater<TArg>(TArg argument1, TArg argument2)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) > 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   greater than <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        public void IfIsGreater(IComparable argument1, IComparable argument2)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) > 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        #endregion Greater - Without parameter name, without message

        #region Greater - With parameter name, without message

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   greater than <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public void IfIsGreater<TArg>(TArg argument1, TArg argument2, string argumentName)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) > 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   greater than <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public void IfIsGreater(IComparable argument1, IComparable argument2, string argumentName)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) > 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        #endregion Greater - With parameter name, without message

        #region Greater - With parameter name, with message

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   greater than <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
        public void IfIsGreater<TArg>(TArg argument1, TArg argument2, string argumentName, string message)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) > 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument1, message);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   greater than <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
        public void IfIsGreater(IComparable argument1, IComparable argument2, string argumentName, string message)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) > 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument1, message);
            }
        }

        #endregion Greater - With parameter name, with message

        #region GreaterEqual - Without parameter name, without message

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   greater than or equal to <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        public void IfIsGreaterOrEqual<TArg>(TArg argument1, TArg argument2)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) >= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   greater than or equal to <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        public void IfIsGreaterOrEqual(IComparable argument1, IComparable argument2)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) >= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        #endregion GreaterEqual - Without parameter name, without message

        #region GreaterEqual - With parameter name, without message

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   greater than or equal to <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public void IfIsGreaterOrEqual<TArg>(TArg argument1, TArg argument2, string argumentName)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) >= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   greater than or equal to <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public void IfIsGreaterOrEqual(IComparable argument1, IComparable argument2, string argumentName)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) >= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        #endregion GreaterEqual - With parameter name, without message

        #region GreaterEqual - With parameter name, with message

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   greater than or equal to <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
        public void IfIsGreaterOrEqual<TArg>(TArg argument1, TArg argument2, string argumentName, string message)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) >= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument1, message);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   greater than or equal to <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
        public void IfIsGreaterOrEqual(IComparable argument1, IComparable argument2, string argumentName, string message)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) >= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument1, message);
            }
        }

        #endregion GreaterEqual - With parameter name, with message

        #region Equal - Without parameter name, without message

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   equal to <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        public void IfIsEqual<TArg>(TArg argument1, TArg argument2)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   equal to <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        public void IfIsEqual(IComparable argument1, IComparable argument2)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        #endregion Equal - Without parameter name, without message

        #region Equal - With parameter name, without message

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   equal to <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public void IfIsEqual<TArg>(TArg argument1, TArg argument2, string argumentName)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) == 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   equal to <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public void IfIsEqual(IComparable argument1, IComparable argument2, string argumentName)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) == 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        #endregion Equal - With parameter name, without message

        #region Equal - With parameter name, with message

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   equal to <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
        public void IfIsEqual<TArg>(TArg argument1, TArg argument2, string argumentName, string message)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) == 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument1, message);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   equal to <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
        public void IfIsEqual(IComparable argument1, IComparable argument2, string argumentName, string message)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) == 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument1, message);
            }
        }

        #endregion Equal - With parameter name, with message

        #region NotEqual - Without parameter name, without message

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is not
        ///   equal to <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        public void IfIsNotEqual<TArg>(TArg argument1, TArg argument2)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) != 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is not
        ///   equal to <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        public void IfIsNotEqual(IComparable argument1, IComparable argument2)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) != 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        #endregion NotEqual - Without parameter name, without message

        #region NotEqual - With parameter name, without message

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is not
        ///   equal to <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public void IfIsNotEqual<TArg>(TArg argument1, TArg argument2, string argumentName)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) != 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is not
        ///   equal to <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public void IfIsNotEqual(IComparable argument1, IComparable argument2, string argumentName)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) != 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        #endregion NotEqual - With parameter name, without message

        #region NotEqual - With parameter name, with message

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is not
        ///   equal to <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
        public void IfIsNotEqual<TArg>(TArg argument1, TArg argument2, string argumentName, string message)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) != 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument1, message);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is not
        ///   equal to <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
        public void IfIsNotEqual(IComparable argument1, IComparable argument2, string argumentName, string message)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) != 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument1, message);
            }
        }

        #endregion NotEqual - With parameter name, with message
    }
}

#pragma warning restore CC0091 // Use static method