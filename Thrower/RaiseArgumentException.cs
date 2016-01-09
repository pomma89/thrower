// File name: RaiseArgumentException.cs
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

using PommaLabs.Thrower.Validation;
using System;
using System.Collections.Generic;

namespace PommaLabs.Thrower
{
    /// <summary>
    ///   Utility methods which can be used to handle bad arguments.
    /// </summary>
    public sealed class RaiseArgumentException : RaiseBase
    {
        #region If

        const string DefaultIfMessage = "Argument is not valid";

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given condition is true.
        /// </summary>
        /// <param name="condition">The condition.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void If(bool condition)
        {
            if (condition)
            {
                throw new ArgumentException(DefaultIfMessage);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given condition is true.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message.</param>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void If(bool condition, string argumentName, string message = null)
        {
            if (condition)
            {
                throw new ArgumentException(message ?? DefaultIfMessage, argumentName);
            }
        }

        #endregion If

        #region IfNot

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given condition is false.
        /// </summary>
        /// <param name="condition">The condition.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void IfNot(bool condition)
        {
            if (!condition)
            {
                throw new ArgumentException(DefaultIfMessage);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given condition is false.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message.</param>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void IfNot(bool condition, string argumentName, string message = null)
        {
            if (!condition)
            {
                throw new ArgumentException(message ?? DefaultIfMessage, argumentName);
            }
        }

        #endregion IfNot

        #region IfIsNotValid

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given argument is not valid.
        /// </summary>
        /// <typeparam name="TArg">The type of the argument.</typeparam>
        /// <param name="argument">The argument.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void IfIsNotValid<TArg>(TArg argument)
        {
            IList<ValidationError> validationErrors;
            if (!ObjectValidator.Validate(argument, out validationErrors))
            {
                throw new ArgumentException(ObjectValidator.FormatValidationErrors(validationErrors, null));
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given argument is not valid.
        /// </summary>
        /// <typeparam name="TArg">The type of the argument.</typeparam>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message.</param>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void IfIsNotValid<TArg>(TArg argument, string argumentName, string message = null)
        {
            IList<ValidationError> validationErrors;
            if (!ObjectValidator.Validate(argument, out validationErrors))
            {
                throw new ArgumentException(ObjectValidator.FormatValidationErrors(validationErrors, message), argumentName);
            }
        }

        #endregion IfIsNotValid

        #region IfIsNotValidEmail

        const string DefaultIfIsNotValidEmailMessage = "String \"{0}\" is not a valid email address";

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given string is not a valid email address.
        /// </summary>
        /// <param name="email">An email address.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void IfIsNotValidEmail(string email)
        {
            if (!EmailValidator.Validate(email))
            {
                var exceptionMsg = string.Format(DefaultIfIsNotValidEmailMessage, email);
                throw new ArgumentException(exceptionMsg);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given string is not a valid email address.
        /// </summary>
        /// <param name="email">An email address.</param>
        /// <param name="allowInternational">
        ///   <value>true</value> if the validator should allow international characters; otherwise, <value>false</value>.
        /// </param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void IfIsNotValidEmail(string email, bool allowInternational)
        {
            if (!EmailValidator.Validate(email, allowInternational))
            {
                var exceptionMsg = string.Format(DefaultIfIsNotValidEmailMessage, email);
                throw new ArgumentException(exceptionMsg);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given string is not a valid email address.
        /// </summary>
        /// <param name="email">An email address.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message.</param>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void IfIsNotValidEmail(string email, string argumentName, string message = null)
        {
            if (!EmailValidator.Validate(email))
            {
                var exceptionMsg = message ?? string.Format(DefaultIfIsNotValidEmailMessage, email);
                throw new ArgumentException(exceptionMsg, argumentName);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given string is not a valid email address.
        /// </summary>
        /// <param name="email">An email address.</param>
        /// <param name="allowInternational">
        ///   <value>true</value> if the validator should allow international characters; otherwise, <value>false</value>.
        /// </param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message.</param>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void IfIsNotValidEmail(string email, bool allowInternational, string argumentName, string message = null)
        {
            if (!EmailValidator.Validate(email, allowInternational))
            {
                var exceptionMsg = message ?? string.Format(DefaultIfIsNotValidEmailMessage, email);
                throw new ArgumentException(exceptionMsg, argumentName);
            }
        }

        #endregion IfIsNotValidEmail

        #region String validation

        const string IsNullOrEmptyMessage = "Argument cannot be a null or empty string";
        const string IsNullOrWhiteSpaceMessage = "Argument cannot be a null, empty or blank string";

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given string is null or empty.
        /// </summary>
        /// <param name="value">The string value.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void IfIsNullOrEmpty(string value)
        {
            if (value == null || value == string.Empty)
            {
                throw new ArgumentException(IsNullOrEmptyMessage);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given string is null or empty.
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The optional message.</param>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void IfIsNullOrEmpty(string value, string argumentName, string message = null)
        {
            if (value == null || value == string.Empty)
            {
                throw new ArgumentException(message ?? IsNullOrEmptyMessage, argumentName);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given string is null, empty or blank.
        /// </summary>
        /// <param name="value">The string value.</param>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void IfIsNullOrWhiteSpace(string value)
        {
            if (value == null || value.Trim() == string.Empty)
            {
                throw new ArgumentException(IsNullOrWhiteSpaceMessage);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given string is null, empty or blank.
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The optional message.</param>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
#if (NET45 || NET46)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void IfIsNullOrWhiteSpace(string value, string argumentName, string message = null)
        {
            if (value == null || value.Trim() == string.Empty)
            {
                throw new ArgumentException(message ?? IsNullOrWhiteSpaceMessage, argumentName);
            }
        }

        #endregion String validation
    }
}
