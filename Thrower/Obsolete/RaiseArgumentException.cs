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
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT
// OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using PommaLabs.Thrower.Validation;
using System;
using System.Collections.Generic;

namespace PommaLabs.Thrower
{
    /// <summary>
    ///   Utility methods which can be used to handle bad arguments.
    /// </summary>
    /// <remarks>
    ///   This class is no longer maintained.
    /// </remarks>
    [Obsolete("Please use Raise.ArgumentException.If* overloads, this class has been deprecated and it will be removed in v4", true)]
    public sealed class RaiseArgumentException : RaiseBase
    {
        #region If

        private const string DefaultIfMessage = "Argument is not valid";

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given condition is true.
        /// </summary>
        /// <param name="condition">The condition.</param>
#if (NET45 || NET46 || PORTABLE)
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
#if (NET45 || NET46 || PORTABLE)
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
#if (NET45 || NET46 || PORTABLE)
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
#if (NET45 || NET46 || PORTABLE)
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
#if (NET45 || NET46 || PORTABLE)
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
#if (NET45 || NET46 || PORTABLE)
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

        #region IfIsNotValidEmailAddress

        private const string DefaultIfIsNotValidEmailAddressMessage = "String \"{0}\" is not a valid email address";

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given string is not a valid email address.
        /// </summary>
        /// <param name="emailAddress">An email address.</param>
#if (NET45 || NET46 || PORTABLE)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void IfIsNotValidEmailAddress(string emailAddress)
        {
            if (!EmailAddressValidator.Validate(emailAddress))
            {
                var exceptionMsg = string.Format(DefaultIfIsNotValidEmailAddressMessage, emailAddress);
                throw new ArgumentException(exceptionMsg);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given string is not a valid email address.
        /// </summary>
        /// <param name="emailAddress">An email address.</param>
        /// <param name="validatorOptions">Customizations for the validation process.</param>
#if (NET45 || NET46 || PORTABLE)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void IfIsNotValidEmailAddress(string emailAddress, EmailAddressValidator.Options validatorOptions)
        {
            if (!EmailAddressValidator.Validate(emailAddress, validatorOptions))
            {
                var exceptionMsg = string.Format(DefaultIfIsNotValidEmailAddressMessage, emailAddress);
                throw new ArgumentException(exceptionMsg);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given string is not a valid email address.
        /// </summary>
        /// <param name="emailAddress">An email address.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message.</param>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void IfIsNotValidEmailAddress(string emailAddress, string argumentName, string message = null)
        {
            if (!EmailAddressValidator.Validate(emailAddress))
            {
                var exceptionMsg = message ?? string.Format(DefaultIfIsNotValidEmailAddressMessage, emailAddress);
                throw new ArgumentException(exceptionMsg, argumentName);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given string is not a valid email address.
        /// </summary>
        /// <param name="emailAddress">An email address.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="validatorOptions">Customizations for the validation process.</param>
        /// <param name="message">The message.</param>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void IfIsNotValidEmailAddress(string emailAddress, string argumentName, EmailAddressValidator.Options validatorOptions, string message = null)
        {
            if (!EmailAddressValidator.Validate(emailAddress, validatorOptions))
            {
                var exceptionMsg = message ?? string.Format(DefaultIfIsNotValidEmailAddressMessage, emailAddress);
                throw new ArgumentException(exceptionMsg, argumentName);
            }
        }

        #endregion IfIsNotValidEmailAddress

        #region IfIsNotValidPhoneNumber

        private const string DefaultIfIsNotValidPhoneNumberMessage = "String \"{0}\" is not a valid phone number";

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given string is not a valid phone number.
        /// </summary>
        /// <param name="phoneNumber">A phone number.</param>
#if (NET45 || NET46 || PORTABLE)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void IfIsNotValidPhoneNumber(string phoneNumber)
        {
            if (!PhoneNumberValidator.Validate(phoneNumber))
            {
                var exceptionMsg = string.Format(DefaultIfIsNotValidPhoneNumberMessage, phoneNumber);
                throw new ArgumentException(exceptionMsg);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given string is not a valid phone number.
        /// </summary>
        /// <param name="phoneNumber">A phone number.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message.</param>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void IfIsNotValidPhoneNumber(string phoneNumber, string argumentName, string message = null)
        {
            if (!PhoneNumberValidator.Validate(phoneNumber))
            {
                var exceptionMsg = message ?? string.Format(DefaultIfIsNotValidPhoneNumberMessage, phoneNumber);
                throw new ArgumentException(exceptionMsg, argumentName);
            }
        }

        #endregion IfIsNotValidPhoneNumber

        #region String validation

        private const string StringIsNullOrEmptyMessage = "Argument cannot be a null or empty string";
        private const string StringIsNullOrWhiteSpaceMessage = "Argument cannot be a null, empty or blank string";

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given string is null or empty.
        /// </summary>
        /// <param name="value">The string value.</param>
#if (NET45 || NET46 || PORTABLE)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void IfIsNullOrEmpty(string value)
        {
            if (ReferenceEquals(value, null) || string.Empty.Equals(value))
            {
                throw new ArgumentException(StringIsNullOrEmptyMessage);
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
#if (NET45 || NET46 || PORTABLE)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void IfIsNullOrEmpty(string value, string argumentName, string message = null)
        {
            if (ReferenceEquals(value, null) || string.Empty.Equals(value))
            {
                throw new ArgumentException(message ?? StringIsNullOrEmptyMessage, argumentName);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given string is null, empty or blank.
        /// </summary>
        /// <param name="value">The string value.</param>
#if (NET45 || NET46 || PORTABLE)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void IfIsNullOrWhiteSpace(string value)
        {
            if (ReferenceEquals(value, null) || string.Empty.Equals(value.Trim()))
            {
                throw new ArgumentException(StringIsNullOrWhiteSpaceMessage);
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
#if (NET45 || NET46 || PORTABLE)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void IfIsNullOrWhiteSpace(string value, string argumentName, string message = null)
        {
            if (ReferenceEquals(value, null) || string.Empty.Equals(value.Trim()))
            {
                throw new ArgumentException(message ?? StringIsNullOrWhiteSpaceMessage, argumentName);
            }
        }

        #endregion String validation

        #region Collection validation

        internal const string CollectionIsNullOrEmptyMessage = "Argument cannot be a null or empty collection";

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given collection is null or empty.
        /// </summary>
        /// <typeparam name="TItem">The type of the items contained in the collection.</typeparam>
        /// <param name="value">The collection.</param>
#if (NET45 || NET46 || PORTABLE)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void IfIsNullOrEmpty<TItem>(ICollection<TItem> value)
        {
            if (ReferenceEquals(value, null) || value.Count == 0)
            {
                throw new ArgumentException(CollectionIsNullOrEmptyMessage);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given collection is null or empty.
        /// </summary>
        /// <typeparam name="TItem">The type of the items contained in the collection.</typeparam>
        /// <param name="value">The collection.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The optional message.</param>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        public static void IfIsNullOrEmpty<TItem>(ICollection<TItem> value, string argumentName, string message = null)
        {
            if (ReferenceEquals(value, null) || value.Count == 0)
            {
                throw new ArgumentException(message ?? CollectionIsNullOrEmptyMessage, argumentName);
            }
        }

        #endregion Collection validation
    }
}