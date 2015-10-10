// File name: RaiseIndexOutOfRangeException.cs
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

using System;
using System.Diagnostics;

namespace PommaLabs.Thrower
{
    /// <summary>
    ///   Utility methods which can be used to handle indexes.
    /// </summary>
    public sealed class RaiseIndexOutOfRangeException : RaiseBase
    {
        #region Less - Without message

        /// <summary>
        ///   Throws <see cref="IndexOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   less than <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsLess<TArg>(TArg argument1, TArg argument2)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        ///   Throws <see cref="IndexOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   less than <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsLess(IComparable argument1, IComparable argument2)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        #endregion Less - Without message

        #region Less - With message

        /// <summary>
        ///   Throws <see cref="IndexOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   less than <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsLess<TArg>(TArg argument1, TArg argument2, string message)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) < 0)
            {
                throw new IndexOutOfRangeException(message);
            }
        }

        /// <summary>
        ///   Throws <see cref="IndexOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   less than <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsLess(IComparable argument1, IComparable argument2, string message)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) < 0)
            {
                throw new IndexOutOfRangeException(message);
            }
        }

        #endregion Less - With message

        #region LessEqual - Without message

        /// <summary>
        ///   Throws <see cref="IndexOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   less than or equal to <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsLessOrEqual<TArg>(TArg argument1, TArg argument2)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) <= 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        ///   Throws <see cref="IndexOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   less than or equal to <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsLessOrEqual(IComparable argument1, IComparable argument2)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) <= 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        #endregion LessEqual - Without message

        #region LessEqual - With message

        /// <summary>
        ///   Throws <see cref="IndexOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   less than or equal to <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsLessOrEqual<TArg>(TArg argument1, TArg argument2, string message)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) <= 0)
            {
                throw new IndexOutOfRangeException(message);
            }
        }

        /// <summary>
        ///   Throws <see cref="IndexOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   less than or equal to <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsLessOrEqual(IComparable argument1, IComparable argument2, string message)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) <= 0)
            {
                throw new IndexOutOfRangeException(message);
            }
        }

        #endregion LessEqual - With message

        #region Greater - Without message

        /// <summary>
        ///   Throws <see cref="IndexOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   greater than <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsGreater<TArg>(TArg argument1, TArg argument2)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) > 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        ///   Throws <see cref="IndexOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   greater than <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsGreater(IComparable argument1, IComparable argument2)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) > 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        #endregion Greater - Without message

        #region Greater - With message

        /// <summary>
        ///   Throws <see cref="IndexOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   greater than <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsGreater<TArg>(TArg argument1, TArg argument2, string message)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) > 0)
            {
                throw new IndexOutOfRangeException(message);
            }
        }

        /// <summary>
        ///   Throws <see cref="IndexOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   greater than <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsGreater(IComparable argument1, IComparable argument2, string message)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) > 0)
            {
                throw new IndexOutOfRangeException(message);
            }
        }

        #endregion Greater - With message

        #region GreaterEqual - Without message

        /// <summary>
        ///   Throws <see cref="IndexOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   greater than or equal to <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsGreaterOrEqual<TArg>(TArg argument1, TArg argument2)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) >= 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        ///   Throws <see cref="IndexOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   greater than or equal to <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsGreaterOrEqual(IComparable argument1, IComparable argument2)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) >= 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        #endregion GreaterEqual - Without message

        #region GreaterEqual - With message

        /// <summary>
        ///   Throws <see cref="IndexOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   greater than or equal to <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsGreaterOrEqual<TArg>(TArg argument1, TArg argument2, string message)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) >= 0)
            {
                throw new IndexOutOfRangeException(message);
            }
        }

        /// <summary>
        ///   Throws <see cref="IndexOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   greater than or equal to <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsGreaterOrEqual(IComparable argument1, IComparable argument2, string message)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) >= 0)
            {
                throw new IndexOutOfRangeException(message);
            }
        }

        #endregion GreaterEqual - With message

        #region Equal - Without message

        /// <summary>
        ///   Throws <see cref="IndexOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   equal to <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsEqual<TArg>(TArg argument1, TArg argument2)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) == 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        ///   Throws <see cref="IndexOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   equal to <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsEqual(IComparable argument1, IComparable argument2)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) == 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        #endregion Equal - Without message

        #region Equal - With message

        /// <summary>
        ///   Throws <see cref="IndexOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   equal to <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsEqual<TArg>(TArg argument1, TArg argument2, string message)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) == 0)
            {
                throw new IndexOutOfRangeException(message);
            }
        }

        /// <summary>
        ///   Throws <see cref="IndexOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   equal to <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsEqual(IComparable argument1, IComparable argument2, string message)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) == 0)
            {
                throw new IndexOutOfRangeException(message);
            }
        }

        #endregion Equal - With message

        #region NotEqual - Without message

        /// <summary>
        ///   Throws <see cref="IndexOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   not equal to <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsNotEqual<TArg>(TArg argument1, TArg argument2)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) != 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        ///   Throws <see cref="IndexOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   not equal to <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsNotEqual(IComparable argument1, IComparable argument2)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) != 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        #endregion NotEqual - Without message

        #region NotEqual - With message

        /// <summary>
        ///   Throws <see cref="IndexOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   not equal to <paramref name="argument2"/>.
        /// </summary>
        /// <typeparam name="TArg">The type of the arguments.</typeparam>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsNotEqual<TArg>(TArg argument1, TArg argument2, string message)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) != 0)
            {
                throw new IndexOutOfRangeException(message);
            }
        }

        /// <summary>
        ///   Throws <see cref="IndexOutOfRangeException"/> if <paramref name="argument1"/> is
        ///   not equal to <paramref name="argument2"/>.
        /// </summary>
        /// <param name="argument1">The left side argument.</param>
        /// <param name="argument2">The right side argument.</param>
        /// <param name="message">The message that should be put into the exception.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsNotEqual(IComparable argument1, IComparable argument2, string message)
        {
            if (ReferenceEquals(argument1, null) || argument1.CompareTo(argument2) != 0)
            {
                throw new IndexOutOfRangeException(message);
            }
        }

        #endregion NotEqual - With message
    }
}
