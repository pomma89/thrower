// File name: GenericExceptionHandler.cs
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

using PommaLabs.Thrower.Reflection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace PommaLabs.Thrower.ExceptionHandlers
{
    /// <summary>
    ///   Generic handler used for common exceptions like <see cref="NotSupportedException"/>.
    /// </summary>
    /// <typeparam name="TException">The type of the handled exception.</typeparam>
    public abstract class GenericExceptionHandler<TException>
        where TException : Exception, new()
    {
        #region Abstract members

        /// <summary>
        ///   Creates an exception with given message.
        /// </summary>
        /// <param name="message">The message used by the exception.</param>
        /// <returns>An exception with given message.</returns>
        protected abstract TException NewWithMessage(string message);

        #endregion Abstract members

        #region If (not)

        /// <summary>
        ///   Throws <typeparamref name="TException"/> if given condition is true.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="message">The optional message.</param>
        /// <exception cref="Exception">
        ///   If given condition is true, an exception of type <typeparamref name="TException"/> is thrown.
        /// </exception>
        public void If(bool condition, string message = null)
        {
            if (condition)
            {
                throw string.IsNullOrEmpty(message) ? new TException() : NewWithMessage(message);
            }
        }

        /// <summary>
        ///   Throws <typeparamref name="TException"/> if given condition is false.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="message">The optional message.</param>
        /// <exception cref="Exception">
        ///   If given condition is true, an exception of type <typeparamref name="TException"/> is thrown.
        /// </exception>
        public void IfNot(bool condition, string message = null)
        {
            if (!condition)
            {
                throw string.IsNullOrEmpty(message) ? new TException() : NewWithMessage(message);
            }
        }

        #endregion If (not)

        #region Reflection

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TException"/> if and only if an
        ///   instance of given type can be assigned to specified object.
        /// </summary>
        /// <typeparam name="TType">The type whose instance must be assigned to given object.</typeparam>
        /// <param name="instance">The object to be tested.</param>
        /// <param name="message">The optional message.</param>
        /// <exception cref="Exception">
        ///   If given condition is true, an exception of type <typeparamref name="TException"/> is thrown.
        /// </exception>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public void IfIsAssignableFrom<TType>(object instance, string message = null)
        {
            if (ReferenceEquals(instance, null) || PortableTypeInfo.IsAssignableFrom(instance, typeof(TType)))
            {
                throw string.IsNullOrEmpty(message) ? new TException() : NewWithMessage(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TException"/> if and only if an
        ///   instance of given type cannot be assigned to specified object.
        /// </summary>
        /// <typeparam name="TType">
        ///   The type whose instance must not be assigned to given object.
        /// </typeparam>
        /// <param name="instance">The object to be tested.</param>
        /// <param name="message">The optional message.</param>
        /// <exception cref="Exception">
        ///   If given condition is true, an exception of type <typeparamref name="TException"/> is thrown.
        /// </exception>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public void IfIsNotAssignableFrom<TType>(object instance, string message = null)
        {
            if (!PortableTypeInfo.IsAssignableFrom(instance, typeof(TType)))
            {
                throw string.IsNullOrEmpty(message) ? new TException() : NewWithMessage(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TException"/> if and only if an
        ///   instance of given type can be assigned to specified object.
        /// </summary>
        /// <param name="instance">The object to be tested.</param>
        /// <param name="type">The type whose instance must be assigned to given object.</param>
        /// <param name="message">The optional message.</param>
        /// <exception cref="Exception">
        ///   If given condition is true, an exception of type <typeparamref name="TException"/> is thrown.
        /// </exception>
        public void IfIsAssignableFrom(object instance, Type type, string message = null)
        {
            if (PortableTypeInfo.IsAssignableFrom(instance, type))
            {
                throw string.IsNullOrEmpty(message) ? new TException() : NewWithMessage(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TException"/> if and only if an
        ///   instance of given type cannot be assigned to specified object.
        /// </summary>
        /// <param name="instance">The object to be tested.</param>
        /// <param name="type">The type whose instance must not be assigned to given object.</param>
        /// <param name="message">The optional message.</param>
        /// <exception cref="Exception">
        ///   If given condition is true, an exception of type <typeparamref name="TException"/> is thrown.
        /// </exception>
        public void IfIsNotAssignableFrom(object instance, Type type, string message = null)
        {
            if (ReferenceEquals(instance, null) || !PortableTypeInfo.IsAssignableFrom(instance, type))
            {
                throw string.IsNullOrEmpty(message) ? new TException() : NewWithMessage(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TException"/> if and only if specified
        ///   object has given type.
        /// </summary>
        /// <typeparam name="TType">The type the object must have.</typeparam>
        /// <param name="instance">The object to be tested.</param>
        /// <param name="message">The optional message.</param>
        /// <exception cref="Exception">
        ///   If given condition is true, an exception of type <typeparamref name="TException"/> is thrown.
        /// </exception>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public void IfIsInstanceOf<TType>(object instance, string message = null)
        {
            if (instance is TType)
            {
                throw string.IsNullOrEmpty(message) ? new TException() : NewWithMessage(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TException"/> if and only if specified
        ///   object has not given type.
        /// </summary>
        /// <typeparam name="TType">The type the object must not have.</typeparam>
        /// <param name="instance">The object to be tested.</param>
        /// <param name="message">The optional message.</param>
        /// <exception cref="Exception">
        ///   If given condition is true, an exception of type <typeparamref name="TException"/> is thrown.
        /// </exception>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public void IfIsNotInstanceOf<TType>(object instance, string message = null)
        {
            if (!(instance is TType))
            {
                throw string.IsNullOrEmpty(message) ? new TException() : NewWithMessage(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TException"/> if and only if specified
        ///   object has given type.
        /// </summary>
        /// <param name="instance">The object to be tested.</param>
        /// <param name="type">The type the object must have.</param>
        /// <param name="message">The optional message.</param>
        /// <exception cref="Exception">
        ///   If given condition is true, an exception of type <typeparamref name="TException"/> is thrown.
        /// </exception>
        public void IfIsInstanceOf(object instance, Type type, string message = null)
        {
            if (PortableTypeInfo.IsInstanceOf(instance, type))
            {
                throw string.IsNullOrEmpty(message) ? new TException() : NewWithMessage(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TException"/> if and only if specified
        ///   object has not given type.
        /// </summary>
        /// <param name="instance">The object to be tested.</param>
        /// <param name="type">The type the object must not have.</param>
        /// <param name="message">The optional message.</param>
        /// <exception cref="Exception">
        ///   If given condition is true, an exception of type <typeparamref name="TException"/> is thrown.
        /// </exception>
        public void IfIsNotInstanceOf(object instance, Type type, string message = null)
        {
            if (!PortableTypeInfo.IsInstanceOf(instance, type))
            {
                throw string.IsNullOrEmpty(message) ? new TException() : NewWithMessage(message);
            }
        }

        #endregion Reflection
    }
}