// File name: RaiseArgumentNullException.cs
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

using PommaLabs.Thrower.Core;
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
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsNull<TArg>(TArg argument)
        {
            if (!PortableTypeInfo.IsValueType(typeof(TArg)) && ReferenceEquals(argument, null))
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
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsNull<TArg>(TArg argument, string argumentName)
        {
            if (!PortableTypeInfo.IsValueType(typeof(TArg)) && ReferenceEquals(argument, null))
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
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        [Conditional(UseThrowerDefine)]
        public static void IfIsNull<TArg>(TArg argument, string argumentName, string message)
        {
            if (!PortableTypeInfo.IsValueType(typeof(TArg)) && ReferenceEquals(argument, null))
            {
                throw new ArgumentNullException(argumentName, message);
            }
        }
    }
}
