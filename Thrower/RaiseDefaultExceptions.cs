// File name: RaiseDefaultExceptions.cs
// 
// Author(s): Alessio Parma <alessio.parma@gmail.com>
// 
// The MIT License (MIT)
// 
// Copyright (c) 2014-2016 Alessio Parma <alessio.parma@gmail.com>
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

using System;
using System.Diagnostics;

namespace PommaLabs.Thrower
{
    /// <summary>
    ///   Utility methods which can be used to handle null references.
    /// </summary>
    public sealed class RaiseArgumentNullException : RaiseBase
    {
        /// <summary>
        ///   Throws <see cref="ArgumentNullException"/> if given argument if null.
        /// </summary>
        /// <typeparam name="TArg">The type of the argument.</typeparam>
        /// <param name="argument">The argument.</param>
        [Conditional(UseThrowerDefine)]
        public static void IfIsNull<TArg>(TArg argument)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsNull<TArg>(TArg argument, string argumentName)
        {
            if (ReferenceEquals(argument, null))
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentNullException"/> if given argument if null.
        /// </summary>
        /// <typeparam name="TArg">The type of the argument.</typeparam>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
        [Conditional(UseThrowerDefine)]
        public static void IfIsNull<TArg>(TArg argument, string argumentName, string message)
        {
            if (ReferenceEquals(argument, null))
            {
                throw new ArgumentNullException(argumentName, message);
            }
        }
    }

    /// <summary>
    ///   Utility methods which can be used to handle ranges.
    /// </summary>
    public sealed class RaiseArgumentOutOfRangeException : RaiseBase
    {
        #region Less - Without parameter name, without message

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   less than <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        [Conditional(UseThrowerDefine)]
        public static void IfIsLess<TArg>(TArg argument1, TArg argument2)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsLess(IComparable argument1, IComparable argument2)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsLess<TArg>(TArg argument1, TArg argument2, string argumentName)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsLess(IComparable argument1, IComparable argument2, string argumentName)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsLess<TArg>(TArg argument1, TArg argument2, string argumentName, string message)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsLess(IComparable argument1, IComparable argument2, string argumentName, string message)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsLessOrEqual<TArg>(TArg argument1, TArg argument2)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsLessOrEqual(IComparable argument1, IComparable argument2)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsLessOrEqual<TArg>(TArg argument1, TArg argument2, string argumentName)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsLessOrEqual(IComparable argument1, IComparable argument2, string argumentName)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsLessOrEqual<TArg>(TArg argument1, TArg argument2, string argumentName, string message)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsLessOrEqual(IComparable argument1, IComparable argument2, string argumentName, string message)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsGreater<TArg>(TArg argument1, TArg argument2)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsGreater(IComparable argument1, IComparable argument2)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsGreater<TArg>(TArg argument1, TArg argument2, string argumentName)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsGreater(IComparable argument1, IComparable argument2, string argumentName)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsGreater<TArg>(TArg argument1, TArg argument2, string argumentName, string message)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsGreater(IComparable argument1, IComparable argument2, string argumentName, string message)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsGreaterOrEqual<TArg>(TArg argument1, TArg argument2)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsGreaterOrEqual(IComparable argument1, IComparable argument2)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsGreaterOrEqual<TArg>(TArg argument1, TArg argument2, string argumentName)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsGreaterOrEqual(IComparable argument1, IComparable argument2, string argumentName)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsGreaterOrEqual<TArg>(TArg argument1, TArg argument2, string argumentName, string message)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsGreaterOrEqual(IComparable argument1, IComparable argument2, string argumentName, string message)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsEqual<TArg>(TArg argument1, TArg argument2)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsEqual(IComparable argument1, IComparable argument2)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsEqual<TArg>(TArg argument1, TArg argument2, string argumentName)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsEqual(IComparable argument1, IComparable argument2, string argumentName)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsEqual<TArg>(TArg argument1, TArg argument2, string argumentName, string message)
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
        [Conditional(UseThrowerDefine)]
        public static void IfIsEqual(IComparable argument1, IComparable argument2, string argumentName, string message)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) == 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument1, message);
            }
        }

        #endregion Equal - With parameter name, with message

        #region NotEqual - Without parameter name, without message

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   not equal to <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        [Conditional(UseThrowerDefine)]
        public static void IfIsNotEqual<TArg>(TArg argument1, TArg argument2)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) != 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   not equal to <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        [Conditional(UseThrowerDefine)]
        public static void IfIsNotEqual(IComparable argument1, IComparable argument2)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) != 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        #endregion NotEqual - Without parameter name, without message

        #region NotEqual - With parameter name, without message

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   not equal to <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        [Conditional(UseThrowerDefine)]
        public static void IfIsNotEqual<TArg>(TArg argument1, TArg argument2, string argumentName)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) != 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   not equal to <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        [Conditional(UseThrowerDefine)]
        public static void IfIsNotEqual(IComparable argument1, IComparable argument2, string argumentName)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) != 0)
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }

        #endregion NotEqual - With parameter name, without message

        #region NotEqual - With parameter name, with message

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   not equal to <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
        [Conditional(UseThrowerDefine)]
        public static void IfIsNotEqual<TArg>(TArg argument1, TArg argument2, string argumentName, string message)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) != 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument1, message);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   not equal to <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
        [Conditional(UseThrowerDefine)]
        public static void IfIsNotEqual(IComparable argument1, IComparable argument2, string argumentName, string message)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) != 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument1, message);
            }
        }

        #endregion NotEqual - With parameter name, with message
    }
}
