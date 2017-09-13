// File name: ArgumentExceptionHandler.cs
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
using PommaLabs.Thrower.Validation;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#pragma warning disable CC0091 // Use static method

namespace PommaLabs.Thrower.ExceptionHandlers
{
    /// <summary>
    ///   Handler for <see cref="ArgumentException"/>.
    /// </summary>
    public sealed class ArgumentExceptionHandler
    {
        #region If

        private const string DefaultIfMessage = "Argument is not valid";

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given condition is true.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <exception cref="ArgumentException">If given condition is true.</exception>
        [MethodImpl(Raise.MethodImplOptions)]
        public void If(bool condition)
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
        /// <exception cref="ArgumentException">If given condition is true.</exception>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
        [MethodImpl(Raise.MethodImplOptions)]
        public void If(bool condition, string argumentName, string message = null)
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
        /// <exception cref="ArgumentException">If given condition is false.</exception>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfNot(bool condition)
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
        /// <exception cref="ArgumentException">If given condition is false.</exception>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfNot(bool condition, string argumentName, string message = null)
        {
            if (!condition)
            {
                throw new ArgumentException(message ?? DefaultIfMessage, argumentName);
            }
        }

        #endregion IfNot

        #region IfIsEqualTo

        private const string DefaultIfIsEqualMessage = "Argument is equal to given value";

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if <paramref name="argument"/> is equal to <paramref name="comparand"/>.
        /// </summary>
        /// <param name="argument">First argument to be tested for equality.</param>
        /// <param name="comparand">Second argument to be tested for equality.</param>
        /// <exception cref="ArgumentException"><paramref name="argument"/> is equal to <paramref name="comparand"/>.</exception>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsEqualTo<TArg1, TArg2>([NoEnumeration] TArg1 argument, [NoEnumeration] TArg2 comparand)
        {
            if (Equals(argument, comparand))
            {
                throw new ArgumentException(DefaultIfIsEqualMessage);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if <paramref name="argument"/> is equal to <paramref name="comparand"/>.
        /// </summary>
        /// <param name="argument">First argument to be tested for equality.</param>
        /// <param name="comparand">Second argument to be tested for equality.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentException"><paramref name="argument"/> is equal to <paramref name="comparand"/>.</exception>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsEqualTo<TArg1, TArg2>([NoEnumeration] TArg1 argument, [NoEnumeration] TArg2 comparand, string argumentName, string message = null)
        {
            if (Equals(argument, comparand))
            {
                throw new ArgumentException(message ?? DefaultIfIsEqualMessage, argumentName);
            }
        }

        #endregion IfIsEqualTo

        #region IfIsNotEqualTo

        private const string DefaultIfIsNotEqualMessage = "Argument is not equal to given value";

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if <paramref name="argument"/> is not equal to <paramref name="comparand"/>.
        /// </summary>
        /// <param name="argument">First argument to be tested for equality.</param>
        /// <param name="comparand">Second argument to be tested for equality.</param>
        /// <exception cref="ArgumentException">
        ///   <paramref name="argument"/> is not equal to <paramref name="comparand"/>.
        /// </exception>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNotEqualTo<TArg1, TArg2>([NoEnumeration] TArg1 argument, [NoEnumeration] TArg2 comparand)
        {
            if (!Equals(argument, comparand))
            {
                throw new ArgumentException(DefaultIfIsNotEqualMessage);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if <paramref name="argument"/> is not equal to <paramref name="comparand"/>.
        /// </summary>
        /// <param name="argument">First argument to be tested for equality.</param>
        /// <param name="comparand">Second argument to be tested for equality.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentException">
        ///   <paramref name="argument"/> is not equal to <paramref name="comparand"/>.
        /// </exception>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNotEqualTo<TArg1, TArg2>([NoEnumeration] TArg1 argument, [NoEnumeration] TArg2 comparand, string argumentName, string message = null)
        {
            if (!Equals(argument, comparand))
            {
                throw new ArgumentException(message ?? DefaultIfIsNotEqualMessage, argumentName);
            }
        }

        #endregion IfIsNotEqualTo

        #region IfIsSameAs

        private const string DefaultIfIsSameMessage = "Argument is the same object as given value";

        /// <summary>
        ///   Throws an exception of type <see cref="ArgumentException"/> if and only if specified
        ///   arguments reference the same object.
        /// </summary>
        /// <param name="argument">First argument to test for reference equality.</param>
        /// <param name="comparand">Second argument to test for reference equality.</param>
        /// <exception cref="ArgumentException">
        ///   <paramref name="argument"/> is the same object as <paramref name="comparand"/>.
        /// </exception>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsSameAs<TArg1, TArg2>([NoEnumeration] TArg1 argument, [NoEnumeration] TArg2 comparand)
        {
            if (ReferenceEquals(argument, comparand))
            {
                throw new ArgumentException(DefaultIfIsSameMessage);
            }
        }

        /// <summary>
        ///   Throws an exception of type <see cref="ArgumentException"/> with given message
        ///   <paramref name="message"/> if and only if specified arguments reference the same object.
        /// </summary>
        /// <param name="argument">First argument to test for reference equality.</param>
        /// <param name="comparand">Second argument to test for reference equality.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ArgumentException">
        ///   <paramref name="argument"/> is the same object as <paramref name="comparand"/>.
        /// </exception>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsSameAs<TArg1, TArg2>([NoEnumeration] TArg1 argument, [NoEnumeration] TArg2 comparand, string argumentName, string message = null)
        {
            if (ReferenceEquals(argument, comparand))
            {
                throw new ArgumentException(message ?? DefaultIfIsSameMessage, argumentName);
            }
        }

        #endregion IfIsSameAs

        #region IfIsNotSameAs

        private const string DefaultIfIsNotSameMessage = "Argument is not the same object as given value";

        /// <summary>
        ///   Throws an exception of type <see cref="ArgumentException"/> if and only if specified
        ///   arguments do not reference the same object.
        /// </summary>
        /// <param name="argument">First argument to test for reference equality.</param>
        /// <param name="comparand">Second argument to test for reference equality.</param>
        /// <exception cref="ArgumentException">
        ///   <paramref name="argument"/> is not the same object as <paramref name="comparand"/>.
        /// </exception>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNotSameAs<TArg1, TArg2>([NoEnumeration] TArg1 argument, [NoEnumeration] TArg2 comparand)
        {
            if (!ReferenceEquals(argument, comparand))
            {
                throw new ArgumentException(DefaultIfIsNotSameMessage);
            }
        }

        /// <summary>
        ///   Throws an exception of type <see cref="ArgumentException"/> with given message
        ///   <paramref name="message"/> if and only if specified arguments do not reference the same object.
        /// </summary>
        /// <param name="argument">First argument to test for reference equality.</param>
        /// <param name="comparand">Second argument to test for reference equality.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ArgumentException">
        ///   <paramref name="argument"/> is not the same object as <paramref name="comparand"/>.
        /// </exception>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNotSameAs<TArg1, TArg2>([NoEnumeration] TArg1 argument, [NoEnumeration] TArg2 comparand, string argumentName, string message = null)
        {
            if (!ReferenceEquals(argument, comparand))
            {
                throw new ArgumentException(message ?? DefaultIfIsNotSameMessage, argumentName);
            }
        }

        #endregion IfIsNotSameAs

        #region IfIsNotValid

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given argument is not valid.
        /// </summary>
        /// <typeparam name="TArg">The type of the argument.</typeparam>
        /// <param name="argument">The argument.</param>
        /// <exception cref="ArgumentException">If given argument is not valid.</exception>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNotValid<TArg>([NoEnumeration] TArg argument)
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
        /// <exception cref="ArgumentException">If given argument is not valid.</exception>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNotValid<TArg>([NoEnumeration] TArg argument, string argumentName, string message = null)
        {
            IList<ValidationError> validationErrors;
            if (!ObjectValidator.Validate(argument, out validationErrors))
            {
                throw new ArgumentException(ObjectValidator.FormatValidationErrors(validationErrors, message), argumentName);
            }
        }

        #endregion IfIsNotValid

        #region IfIsNotValidEnum

        private const string DefaultIfIsNotValidEnumMessage = "Enumeration \"{0}\" is not a valid value for type \"{1}\"";

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given enumeration argument is not defined.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enumeration argument.</typeparam>
        /// <param name="argument">The enumeration argument.</param>
        /// <exception cref="ArgumentException">If given enumeration argument is not defined.</exception>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNotValidEnum<TEnum>(TEnum argument)
            where TEnum : struct
        {
            if (!EnumerationValidator.Validate(argument))
            {
                var exceptionMsg = string.Format(DefaultIfIsNotValidEnumMessage, argument, typeof(TEnum).Name);
                throw new ArgumentException(exceptionMsg);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given enumeration argument is not defined.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enumeration argument.</typeparam>
        /// <param name="argument">The enumeration argument.</param>
        /// <param name="argumentName">The name of the enumeration argument.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentException">If given enumeration argument is not defined.</exception>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNotValidEnum<TEnum>(TEnum argument, string argumentName, string message = null)
            where TEnum : struct
        {
            if (!EnumerationValidator.Validate(argument))
            {
                var exceptionMsg = message ?? string.Format(DefaultIfIsNotValidEnumMessage, argument, typeof(TEnum).Name);
                throw new ArgumentException(exceptionMsg, argumentName);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given enumeration argument is not defined.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enumeration argument.</typeparam>
        /// <param name="argument">The enumeration argument.</param>
        /// <exception cref="ArgumentException">If given enumeration argument is not defined.</exception>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNotValidEnum<TEnum>(TEnum? argument)
            where TEnum : struct
        {
            if (!EnumerationValidator.Validate(argument))
            {
                var exceptionMsg = string.Format(DefaultIfIsNotValidEnumMessage, argument, typeof(TEnum).Name);
                throw new ArgumentException(exceptionMsg);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given enumeration argument is not defined.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enumeration argument.</typeparam>
        /// <param name="argument">The enumeration argument.</param>
        /// <param name="argumentName">The name of the enumeration argument.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentException">If given enumeration argument is not defined.</exception>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNotValidEnum<TEnum>(TEnum? argument, string argumentName, string message = null)
            where TEnum : struct
        {
            if (!EnumerationValidator.Validate(argument))
            {
                var exceptionMsg = message ?? string.Format(DefaultIfIsNotValidEnumMessage, argument, typeof(TEnum).Name);
                throw new ArgumentException(exceptionMsg, argumentName);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given enumeration argument is not defined.
        /// </summary>
        /// <param name="enumType">The enumeration type.</param>
        /// <param name="argument">The enumeration argument.</param>
        /// <exception cref="ArgumentException">If given enumeration argument is not defined.</exception>
        /// <remarks>
        ///   This methid is slower than <see cref="IfIsNotValidEnum{TEnum}(TEnum)"/>, please use
        ///   that one if possible.
        /// </remarks>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNotValidEnum(Type enumType, object argument)
        {
            if (!EnumerationValidator.Validate(enumType, argument))
            {
                var exceptionMsg = string.Format(DefaultIfIsNotValidEnumMessage, argument, enumType.Name);
                throw new ArgumentException(exceptionMsg);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given enumeration argument is not defined.
        /// </summary>
        /// <param name="enumType">The enumeration type.</param>
        /// <param name="argument">The enumeration argument.</param>
        /// <param name="argumentName">The name of the enumeration argument.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentException">If given enumeration argument is not defined.</exception>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        ///
        ///   This methid is slower than
        ///   <see cref="IfIsNotValidEnum{TEnum}(TEnum, string, string)"/>, please use that one if possible.
        /// </remarks>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNotValidEnum(Type enumType, object argument, string argumentName, string message = null)
        {
            if (!EnumerationValidator.Validate(enumType, argument))
            {
                var exceptionMsg = message ?? string.Format(DefaultIfIsNotValidEnumMessage, argument, enumType.Name);
                throw new ArgumentException(exceptionMsg, argumentName);
            }
        }

        #endregion IfIsNotValidEnum

        #region IfIsNotValidEmailAddress

        private const string DefaultIfIsNotValidEmailAddressMessage = "String \"{0}\" is not a valid email address";

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given string is not a valid email address.
        /// </summary>
        /// <param name="emailAddress">An email address.</param>
        /// <exception cref="ArgumentException">If given string is not a valid email address.</exception>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNotValidEmailAddress(string emailAddress)
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
        /// <exception cref="ArgumentException">If given string is not a valid email address.</exception>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNotValidEmailAddress(string emailAddress, EmailAddressValidator.Options validatorOptions)
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
        /// <exception cref="ArgumentException">If given string is not a valid email address.</exception>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNotValidEmailAddress(string emailAddress, string argumentName, string message = null)
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
        /// <exception cref="ArgumentException">If given string is not a valid email address.</exception>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNotValidEmailAddress(string emailAddress, string argumentName, EmailAddressValidator.Options validatorOptions, string message = null)
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
        /// <exception cref="ArgumentException">If given string is not a valid phone number.</exception>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNotValidPhoneNumber(string phoneNumber)
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
        /// <exception cref="ArgumentException">If given string is not a valid phone number.</exception>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNotValidPhoneNumber(string phoneNumber, string argumentName, string message = null)
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
        /// <exception cref="ArgumentException">If given string is null or empty.</exception>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNullOrEmpty(string value)
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
        /// <exception cref="ArgumentException">If given string is null or empty.</exception>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNullOrEmpty(string value, string argumentName, string message = null)
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
        /// <exception cref="ArgumentException">If given string is null, empty or blank.</exception>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNullOrWhiteSpace(string value)
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
        /// <exception cref="ArgumentException">If given string is null, empty or blank.</exception>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNullOrWhiteSpace(string value, string argumentName, string message = null)
        {
            if (ReferenceEquals(value, null) || string.Empty.Equals(value.Trim()))
            {
                throw new ArgumentException(message ?? StringIsNullOrWhiteSpaceMessage, argumentName);
            }
        }

        #endregion String validation

        #region Collection and enumerable validation

        internal const string CollectionIsNullOrEmptyMessage = "Argument cannot be a null or empty collection";
        internal const string EnumerableIsNullOrEmptyMessage = "Argument cannot be a null or empty enumerable";

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given collection is null or empty.
        /// </summary>
        /// <typeparam name="TItem">The type of the items contained in the collection.</typeparam>
        /// <param name="value">The collection.</param>
        /// <exception cref="ArgumentException">If given collection is null or empty.</exception>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNullOrEmpty<TItem>(ICollection<TItem> value)
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
        /// <exception cref="ArgumentException">If given collection is null or empty.</exception>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNullOrEmpty<TItem>(ICollection<TItem> value, string argumentName, string message = null)
        {
            if (ReferenceEquals(value, null) || value.Count == 0)
            {
                throw new ArgumentException(message ?? CollectionIsNullOrEmptyMessage, argumentName);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given enumerable is null or empty.
        /// </summary>
        /// <typeparam name="TItem">The type of the items contained in the enumerable.</typeparam>
        /// <param name="value">The enumerable.</param>
        /// <exception cref="ArgumentException">If given enumerable is null or empty.</exception>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNullOrEmpty<TItem>([NoEnumeration] IEnumerable<TItem> value)
        {
            if (ReferenceEquals(value, null) || !value.GetEnumerator().MoveNext())
            {
                throw new ArgumentException(CollectionIsNullOrEmptyMessage);
            }
        }

        /// <summary>
        ///   Throws <see cref="ArgumentException"/> if given enumerable is null or empty.
        /// </summary>
        /// <typeparam name="TItem">The type of the items contained in the enumerable.</typeparam>
        /// <param name="value">The enumerable.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="message">The optional message.</param>
        /// <exception cref="ArgumentException">If given enumerable is null or empty.</exception>
        /// <remarks>
        ///   <paramref name="message"/> and <paramref name="argumentName"/> are strictly required arguments.
        /// </remarks>
        [MethodImpl(Raise.MethodImplOptions)]
        public void IfIsNullOrEmpty<TItem>([NoEnumeration] IEnumerable<TItem> value, string argumentName, string message = null)
        {
            if (ReferenceEquals(value, null) || !value.GetEnumerator().MoveNext())
            {
                throw new ArgumentException(message ?? CollectionIsNullOrEmptyMessage, argumentName);
            }
        }

        #endregion Collection and enumerable validation
    }
}

#pragma warning restore CC0091 // Use static method