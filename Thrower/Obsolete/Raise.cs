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

using PommaLabs.Thrower.Reflection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace PommaLabs.Thrower
{
#pragma warning disable RECS0096 // Type parameter is never used

    public partial class Raise<TEx>
#pragma warning restore RECS0096 // Type parameter is never used
    {
        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if specified
        ///   arguments are equal.
        /// </summary>
        /// <param name="arg1">First argument to test for equality.</param>
        /// <param name="arg2">Second argument to test for equality.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with no parameters,
        ///   or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If arguments are equal, then an exception of type <typeparamref name="TEx"/> will be
        ///   thrown. <br/> In order to do that, <typeparamref name="TEx"/> must have a constructor
        ///   which doesn't take any arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4", true), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfAreEqual<TArg1, TArg2>(TArg1 arg1, TArg2 arg2)
        {
            if (Equals(arg1, arg2))
            {
                DoThrow();
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> with given message
        ///   <paramref name="message"/> if and only if specified arguments are equal.
        /// </summary>
        /// <param name="arg1">First argument to test for equality.</param>
        /// <param name="arg2">Second argument to test for equality.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor which takes, as
        ///   parameters, either a <see cref="string"/> or a <see cref="string"/> and an
        ///   <see cref="System.Exception"/>. The same exception is thrown when
        ///   <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If arguments are equal, then an exception of type <typeparamref name="TEx"/>, with the
        ///   message specified by <paramref name="message"/>, will be thrown. <br/> In order to do
        ///   that, <typeparamref name="TEx"/> must have either a constructor which takes a
        ///   <see cref="string"/> and an <see cref="System.Exception"/> as arguments, or a
        ///   constructor which takes a <see cref="string"/> as only parameter. <br/> If both
        ///   constructors are available, then the one which takes a <see cref="string"/> and an
        ///   <see cref="System.Exception"/> will be used to throw the exception.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4", true), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfAreEqual<TArg1, TArg2>(TArg1 arg1, TArg2 arg2, string message)
        {
            if (Equals(arg1, arg2))
            {
                DoThrow(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if specified
        ///   arguments are not equal.
        /// </summary>
        /// <param name="arg1">First argument to test for equality.</param>
        /// <param name="arg2">Second argument to test for equality.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with no parameters,
        ///   or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If arguments are not equal, then an exception of type <typeparamref name="TEx"/> will
        ///   be thrown. <br/> In order to do that, <typeparamref name="TEx"/> must have a
        ///   constructor which doesn't take any arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4", true), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfAreNotEqual<TArg1, TArg2>(TArg1 arg1, TArg2 arg2)
        {
            if (!Equals(arg1, arg2))
            {
                DoThrow();
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> with given message
        ///   <paramref name="message"/> if and only if specified arguments are not equal.
        /// </summary>
        /// <param name="arg1">First argument to test for equality.</param>
        /// <param name="arg2">Second argument to test for equality.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor which takes, as
        ///   parameters, either a <see cref="string"/> or a <see cref="string"/> and an
        ///   <see cref="System.Exception"/>. The same exception is thrown when
        ///   <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If arguments are not equal, then an exception of type <typeparamref name="TEx"/>, with
        ///   the message specified by <paramref name="message"/>, will be thrown. <br/> In order to
        ///   do that, <typeparamref name="TEx"/> must have either a constructor which takes a
        ///   <see cref="string"/> and an <see cref="System.Exception"/> as arguments, or a
        ///   constructor which takes a <see cref="string"/> as only parameter. <br/> If both
        ///   constructors are available, then the one which takes a <see cref="string"/> and an
        ///   <see cref="System.Exception"/> will be used to throw the exception.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4", true), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfAreNotEqual<TArg1, TArg2>(TArg1 arg1, TArg2 arg2, string message)
        {
            if (!Equals(arg1, arg2))
            {
                DoThrow(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if specified
        ///   arguments point to the same object.
        /// </summary>
        /// <param name="arg1">First argument to test for reference equality.</param>
        /// <param name="arg2">Second argument to test for reference equality.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with no parameters,
        ///   or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If arguments point to the same object, then an exception of type
        ///   <typeparamref name="TEx"/> will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have a constructor which doesn't take any arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfAreSame<TArg1, TArg2>(TArg1 arg1, TArg2 arg2)
        {
            if (ReferenceEquals(arg1, arg2))
            {
                DoThrow();
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> with given message
        ///   <paramref name="message"/> if and only if specified arguments point to the same object.
        /// </summary>
        /// <param name="arg1">First argument to test for reference equality.</param>
        /// <param name="arg2">Second argument to test for reference equality.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor which takes, as
        ///   parameters, either a <see cref="string"/> or a <see cref="string"/> and an
        ///   <see cref="System.Exception"/>. The same exception is thrown when
        ///   <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If arguments point to the same object, then an exception of type
        ///   <typeparamref name="TEx"/>, with the message specified by <paramref name="message"/>,
        ///   will be thrown. <br/> In order to do that, <typeparamref name="TEx"/> must have either
        ///   a constructor which takes a <see cref="string"/> and an <see cref="System.Exception"/>
        ///   as arguments, or a constructor which takes a <see cref="string"/> as only parameter.
        ///   <br/> If both constructors are available, then the one which takes a
        ///   <see cref="string"/> and an <see cref="System.Exception"/> will be used to throw the exception.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfAreSame<TArg1, TArg2>(TArg1 arg1, TArg2 arg2, string message)
        {
            if (ReferenceEquals(arg1, arg2))
            {
                DoThrow(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if specified
        ///   arguments do not point to the same object.
        /// </summary>
        /// <param name="arg1">First argument to test for reference equality.</param>
        /// <param name="arg2">Second argument to test for reference equality.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with no parameters,
        ///   or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If arguments do not point to the same object, then an exception of type
        ///   <typeparamref name="TEx"/> will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have a constructor which doesn't take any arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfAreNotSame<TArg1, TArg2>(TArg1 arg1, TArg2 arg2)
        {
            if (!ReferenceEquals(arg1, arg2))
            {
                DoThrow();
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> with given message
        ///   <paramref name="message"/> if and only if specified arguments do not point to the same object.
        /// </summary>
        /// <param name="arg1">First argument to test for reference equality.</param>
        /// <param name="arg2">Second argument to test for reference equality.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor which takes, as
        ///   parameters, either a <see cref="string"/> or a <see cref="string"/> and an
        ///   <see cref="System.Exception"/>. The same exception is thrown when
        ///   <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If arguments do not point to the same object, then an exception of type
        ///   <typeparamref name="TEx"/>, with the message specified by <paramref name="message"/>,
        ///   will be thrown. <br/> In order to do that, <typeparamref name="TEx"/> must have either
        ///   a constructor which takes a <see cref="string"/> and an <see cref="System.Exception"/>
        ///   as arguments, or a constructor which takes a <see cref="string"/> as only parameter.
        ///   <br/> If both constructors are available, then the one which takes a
        ///   <see cref="string"/> and an <see cref="System.Exception"/> will be used to throw the exception.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfAreNotSame<TArg1, TArg2>(TArg1 arg1, TArg2 arg2, string message)
        {
            if (!ReferenceEquals(arg1, arg2))
            {
                DoThrow(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if an instance of
        ///   given type can be assigned to specified object.
        /// </summary>
        /// <param name="instance">The object to test.</param>
        /// <param name="type">The type whose instance must be assigned to given object.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with no parameters,
        ///   or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If an instance of given type can be assigned to specified object, then an exception of
        ///   type <typeparamref name="TEx"/> will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have a constructor which doesn't take any arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsAssignableFrom(object instance, Type type)
        {
            if (PortableTypeInfo.IsAssignableFrom(instance, type))
            {
                DoThrow();
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> with given message
        ///   <paramref name="message"/> if and only if an instance of given type can be assigned to
        ///   specified object.
        /// </summary>
        /// <param name="instance">The object to test.</param>
        /// <param name="type">The type whose instance must be assigned to given object.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor which takes, as
        ///   parameters, either a <see cref="string"/> or a <see cref="string"/> and an
        ///   <see cref="System.Exception"/>. The same exception is thrown when
        ///   <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If an instance of given type can be assigned to specified object, then an exception of
        ///   type <typeparamref name="TEx"/>, with the message specified by
        ///   <paramref name="message"/>, will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have either a constructor which takes a
        ///   <see cref="string"/> and an <see cref="System.Exception"/> as arguments, or a
        ///   constructor which takes a <see cref="string"/> as only parameter. <br/> If both
        ///   constructors are available, then the one which takes a <see cref="string"/> and an
        ///   <see cref="System.Exception"/> will be used to throw the exception.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsAssignableFrom(object instance, Type type, string message)
        {
            if (ReferenceEquals(instance, null) || PortableTypeInfo.IsAssignableFrom(instance, type))
            {
                DoThrow(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if an instance of
        ///   given type can be assigned to specified object.
        /// </summary>
        /// <typeparam name="TType">The type whose instance must be assigned to given object.</typeparam>
        /// <param name="instance">The object to test.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with no parameters,
        ///   or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If an instance of given type can be assigned to specified object, then an exception of
        ///   type <typeparamref name="TEx"/> will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have a constructor which doesn't take any arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static void IfIsAssignableFrom<TType>(object instance)
        {
            if (ReferenceEquals(instance, null) || PortableTypeInfo.IsAssignableFrom(instance, typeof(TType)))
            {
                DoThrow();
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> with given message
        ///   <paramref name="message"/> if and only if an instance of given type can be assigned to
        ///   specified object.
        /// </summary>
        /// <typeparam name="TType">The type whose instance must be assigned to given object.</typeparam>
        /// <param name="instance">The object to test.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor which takes, as
        ///   parameters, either a <see cref="string"/> or a <see cref="string"/> and an
        ///   <see cref="System.Exception"/>. The same exception is thrown when
        ///   <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If an instance of given type can be assigned to specified object, then an exception of
        ///   type <typeparamref name="TEx"/>, with the message specified by
        ///   <paramref name="message"/>, will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have either a constructor which takes a
        ///   <see cref="string"/> and an <see cref="System.Exception"/> as arguments, or a
        ///   constructor which takes a <see cref="string"/> as only parameter. <br/> If both
        ///   constructors are available, then the one which takes a <see cref="string"/> and an
        ///   <see cref="System.Exception"/> will be used to throw the exception.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static void IfIsAssignableFrom<TType>(object instance, string message)
        {
            if (ReferenceEquals(instance, null) || PortableTypeInfo.IsAssignableFrom(instance, typeof(TType)))
            {
                DoThrow(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if an instance of
        ///   given type cannot be assigned to specified object.
        /// </summary>
        /// <param name="instance">The object to test.</param>
        /// <param name="type">The type whose instance must not be assigned to given object.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with no parameters,
        ///   or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If an instance of given type cannot be assigned to specified object, then an exception
        ///   of type <typeparamref name="TEx"/> will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have a constructor which doesn't take any arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsNotAssignableFrom(object instance, Type type)
        {
            if (ReferenceEquals(instance, null) || !PortableTypeInfo.IsAssignableFrom(instance, type))
            {
                DoThrow();
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> with given message
        ///   <paramref name="message"/> if and only if an instance of given type cannot be assigned
        ///   to specified object.
        /// </summary>
        /// <param name="instance">The object to test.</param>
        /// <param name="type">The type whose instance must not be assigned to given object.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor which takes, as
        ///   parameters, either a <see cref="string"/> or a <see cref="string"/> and an
        ///   <see cref="System.Exception"/>. The same exception is thrown when
        ///   <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If an instance of given type cannot be assigned to specified object, then an exception
        ///   of type <typeparamref name="TEx"/>, with the message specified by
        ///   <paramref name="message"/>, will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have either a constructor which takes a
        ///   <see cref="string"/> and an <see cref="System.Exception"/> as arguments, or a
        ///   constructor which takes a <see cref="string"/> as only parameter. <br/> If both
        ///   constructors are available, then the one which takes a <see cref="string"/> and an
        ///   <see cref="System.Exception"/> will be used to throw the exception.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsNotAssignableFrom(object instance, Type type, string message)
        {
            if (ReferenceEquals(instance, null) || !PortableTypeInfo.IsAssignableFrom(instance, type))
            {
                DoThrow(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if an instance of
        ///   given type cannot be assigned to specified object.
        /// </summary>
        /// <typeparam name="TType">
        ///   The type whose instance must not be assigned to given object.
        /// </typeparam>
        /// <param name="instance">The object to test.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with no parameters,
        ///   or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If an instance of given type cannot be assigned to specified object, then an exception
        ///   of type <typeparamref name="TEx"/> will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have a constructor which doesn't take any arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static void IfIsNotAssignableFrom<TType>(object instance)
        {
            if (!PortableTypeInfo.IsAssignableFrom(instance, typeof(TType)))
            {
                DoThrow();
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> with given message
        ///   <paramref name="message"/> if and only if an instance of given type cannot be assigned
        ///   to specified object.
        /// </summary>
        /// <typeparam name="TType">
        ///   The type whose instance must not be assigned to given object.
        /// </typeparam>
        /// <param name="instance">The object to test.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor which takes, as
        ///   parameters, either a <see cref="string"/> or a <see cref="string"/> and an
        ///   <see cref="System.Exception"/>. The same exception is thrown when
        ///   <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If an instance of given type cannot be assigned to specified object, then an exception
        ///   of type <typeparamref name="TEx"/>, with the message specified by
        ///   <paramref name="message"/>, will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have either a constructor which takes a
        ///   <see cref="string"/> and an <see cref="System.Exception"/> as arguments, or a
        ///   constructor which takes a <see cref="string"/> as only parameter. <br/> If both
        ///   constructors are available, then the one which takes a <see cref="string"/> and an
        ///   <see cref="System.Exception"/> will be used to throw the exception.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static void IfIsNotAssignableFrom<TType>(object instance, string message)
        {
            if (ReferenceEquals(instance, null) || !PortableTypeInfo.IsAssignableFrom(instance, typeof(TType)))
            {
                DoThrow(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if specified
        ///   argument is contained in given collection.
        /// </summary>
        /// <param name="argument">The argument to check.</param>
        /// <param name="collection">The collection that must not contain given argument.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with no parameters,
        ///   or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="argument"/> is contained, then an exception of type
        ///   <typeparamref name="TEx"/> will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have a constructor which doesn't take any arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsContainedIn(object argument, System.Collections.IList collection)
        {
            if (ReferenceEquals(collection, null) || collection.Contains(argument))
            {
                DoThrow();
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> with given message
        ///   <paramref name="message"/> if and only if specified argument is contained in given collection.
        /// </summary>
        /// <param name="argument">The argument to check.</param>
        /// <param name="collection">The collection that must not contain given argument.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor which takes, as
        ///   parameters, either a <see cref="string"/> or a <see cref="string"/> and an
        ///   <see cref="System.Exception"/>. The same exception is thrown when
        ///   <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="argument"/> is contained, then an exception of type
        ///   <typeparamref name="TEx"/>, with the message specified by <paramref name="message"/>,
        ///   will be thrown. <br/> In order to do that, <typeparamref name="TEx"/> must have either
        ///   a constructor which takes a <see cref="string"/> and an <see cref="System.Exception"/>
        ///   as arguments, or a constructor which takes a <see cref="string"/> as only parameter.
        ///   <br/> If both constructors are available, then the one which takes a
        ///   <see cref="string"/> and an <see cref="System.Exception"/> will be used to throw the exception.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsContainedIn(object argument, System.Collections.IList collection, string message)
        {
            if (ReferenceEquals(collection, null) || collection.Contains(argument))
            {
                DoThrow(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if specified
        ///   argument is not contained in given collection.
        /// </summary>
        /// <param name="argument">The argument to check.</param>
        /// <param name="collection">The collection that must contain given argument.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with no parameters,
        ///   or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="argument"/> is not contained, then an exception of type
        ///   <typeparamref name="TEx"/> will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have a constructor which doesn't take any arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsNotContainedIn(object argument, System.Collections.IList collection)
        {
            if (ReferenceEquals(collection, null) || !collection.Contains(argument))
            {
                DoThrow();
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> with given message
        ///   <paramref name="message"/> if and only if specified argument is not contained in given collection.
        /// </summary>
        /// <param name="argument">The argument to check.</param>
        /// <param name="collection">The collection that must contain given argument.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor which takes, as
        ///   parameters, either a <see cref="string"/> or a <see cref="string"/> and an
        ///   <see cref="System.Exception"/>. The same exception is thrown when
        ///   <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="argument"/> is not contained, then an exception of type
        ///   <typeparamref name="TEx"/>, with the message specified by <paramref name="message"/>,
        ///   will be thrown. <br/> In order to do that, <typeparamref name="TEx"/> must have either
        ///   a constructor which takes a <see cref="string"/> and an <see cref="System.Exception"/>
        ///   as arguments, or a constructor which takes a <see cref="string"/> as only parameter.
        ///   <br/> If both constructors are available, then the one which takes a
        ///   <see cref="string"/> and an <see cref="System.Exception"/> will be used to throw the exception.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsNotContainedIn(object argument, System.Collections.IList collection, string message)
        {
            if (ReferenceEquals(collection, null) || !collection.Contains(argument))
            {
                DoThrow(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if specified
        ///   argument is contained in given collection.
        /// </summary>
        /// <param name="arg">The argument to check.</param>
        /// <param name="collection">The collection that must not contain given argument.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with no parameters,
        ///   or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="arg"/> is contained, then an exception of type
        ///   <typeparamref name="TEx"/> will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have a constructor which doesn't take any arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsContainedIn<TArg>(TArg arg, System.Collections.Generic.IEnumerable<TArg> collection)
        {
            if (ReferenceEquals(collection, null) || collection.Contains(arg))
            {
                DoThrow();
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> with given message
        ///   <paramref name="message"/> if and only if specified argument is contained in given collection.
        /// </summary>
        /// <param name="arg">The argument to check.</param>
        /// <param name="collection">The collection that must not contain given argument.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor which takes, as
        ///   parameters, either a <see cref="string"/> or a <see cref="string"/> and an
        ///   <see cref="System.Exception"/>. The same exception is thrown when
        ///   <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="arg"/> is contained, then an exception of type
        ///   <typeparamref name="TEx"/>, with the message specified by <paramref name="message"/>,
        ///   will be thrown. <br/> In order to do that, <typeparamref name="TEx"/> must have either
        ///   a constructor which takes a <see cref="string"/> and an <see cref="System.Exception"/>
        ///   as arguments, or a constructor which takes a <see cref="string"/> as only parameter.
        ///   <br/> If both constructors are available, then the one which takes a
        ///   <see cref="string"/> and an <see cref="System.Exception"/> will be used to throw the exception.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsContainedIn<TArg>(TArg arg, System.Collections.Generic.IEnumerable<TArg> collection, string message)
        {
            if (ReferenceEquals(collection, null) || collection.Contains(arg))
            {
                DoThrow(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if specified
        ///   argument is not contained in given collection.
        /// </summary>
        /// <param name="arg">The argument to check.</param>
        /// <param name="collection">The collection that must contain given argument.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with no parameters,
        ///   or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="arg"/> is not contained, then an exception of type
        ///   <typeparamref name="TEx"/> will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have a constructor which doesn't take any arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsNotContainedIn<TArg>(TArg arg, System.Collections.Generic.IEnumerable<TArg> collection)
        {
            if (ReferenceEquals(collection, null) || !collection.Contains(arg))
            {
                DoThrow();
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> with given message
        ///   <paramref name="message"/> if and only if specified argument is not contained in given collection.
        /// </summary>
        /// <param name="arg">The argument to check.</param>
        /// <param name="collection">The collection that must contain given argument.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor which takes, as
        ///   parameters, either a <see cref="string"/> or a <see cref="string"/> and an
        ///   <see cref="System.Exception"/>. The same exception is thrown when
        ///   <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="arg"/> is not contained, then an exception of type
        ///   <typeparamref name="TEx"/>, with the message specified by <paramref name="message"/>,
        ///   will be thrown. <br/> In order to do that, <typeparamref name="TEx"/> must have either
        ///   a constructor which takes a <see cref="string"/> and an <see cref="System.Exception"/>
        ///   as arguments, or a constructor which takes a <see cref="string"/> as only parameter.
        ///   <br/> If both constructors are available, then the one which takes a
        ///   <see cref="string"/> and an <see cref="System.Exception"/> will be used to throw the exception.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsNotContainedIn<TArg>(TArg arg, System.Collections.Generic.IEnumerable<TArg> collection, string message)
        {
            if (ReferenceEquals(collection, null) || !collection.Contains(arg))
            {
                DoThrow(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if specified
        ///   argument is contained in given dictionary keys.
        /// </summary>
        /// <param name="arg">The argument to check.</param>
        /// <param name="dictionary">The dictionary that must not contain given argument.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with no parameters,
        ///   or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="arg"/> is contained, then an exception of type
        ///   <typeparamref name="TEx"/> will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have a constructor which doesn't take any arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsContainedIn<TArg>(TArg arg, System.Collections.IDictionary dictionary)
        {
            if (ReferenceEquals(dictionary, null) || dictionary.Contains(arg))
            {
                DoThrow();
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> with given message
        ///   <paramref name="message"/> if and only if specified argument is contained in given
        ///   dictionary keys.
        /// </summary>
        /// <param name="arg">The argument to check.</param>
        /// <param name="dictionary">The dictionary that must not contain given argument.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor which takes, as
        ///   parameters, either a <see cref="string"/> or a <see cref="string"/> and an
        ///   <see cref="System.Exception"/>. The same exception is thrown when
        ///   <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="arg"/> is contained, then an exception of type
        ///   <typeparamref name="TEx"/>, with the message specified by <paramref name="message"/>,
        ///   will be thrown. <br/> In order to do that, <typeparamref name="TEx"/> must have either
        ///   a constructor which takes a <see cref="string"/> and an <see cref="System.Exception"/>
        ///   as arguments, or a constructor which takes a <see cref="string"/> as only parameter.
        ///   <br/> If both constructors are available, then the one which takes a
        ///   <see cref="string"/> and an <see cref="System.Exception"/> will be used to throw the exception.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsContainedIn<TArg>(TArg arg, System.Collections.IDictionary dictionary, string message)
        {
            if (ReferenceEquals(dictionary, null) || dictionary.Contains(arg))
            {
                DoThrow(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if specified
        ///   argument is not contained in given dictionary keys.
        /// </summary>
        /// <param name="arg">The argument to check.</param>
        /// <param name="dictionary">The dictionary that must contain given argument.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with no parameters,
        ///   or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="arg"/> is not contained, then an exception of type
        ///   <typeparamref name="TEx"/> will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have a constructor which doesn't take any arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsNotContainedIn<TArg>(TArg arg, System.Collections.IDictionary dictionary)
        {
            if (ReferenceEquals(dictionary, null) || !dictionary.Contains(arg))
            {
                DoThrow();
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> with given message
        ///   <paramref name="message"/> if and only if specified argument is not contained in given
        ///   dictionary keys.
        /// </summary>
        /// <param name="arg">The argument to check.</param>
        /// <param name="dictionary">The dictionary that must contain given argument.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor which takes, as
        ///   parameters, either a <see cref="string"/> or a <see cref="string"/> and an
        ///   <see cref="System.Exception"/>. The same exception is thrown when
        ///   <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="arg"/> is not contained, then an exception of type
        ///   <typeparamref name="TEx"/>, with the message specified by <paramref name="message"/>,
        ///   will be thrown. <br/> In order to do that, <typeparamref name="TEx"/> must have either
        ///   a constructor which takes a <see cref="string"/> and an <see cref="System.Exception"/>
        ///   as arguments, or a constructor which takes a <see cref="string"/> as only parameter.
        ///   <br/> If both constructors are available, then the one which takes a
        ///   <see cref="string"/> and an <see cref="System.Exception"/> will be used to throw the exception.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsNotContainedIn<TArg>(TArg arg, System.Collections.IDictionary dictionary, string message)
        {
            if (ReferenceEquals(dictionary, null) || !dictionary.Contains(arg))
            {
                DoThrow(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if specified
        ///   arguments are contained in given dictionary pairs.
        /// </summary>
        /// <param name="arg1">The key argument to check.</param>
        /// <param name="arg2">The value argument to check.</param>
        /// <param name="dictionary">The dictionary that must not contain given arguments.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with no parameters,
        ///   or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="arg1"/> and <paramref name="arg2"/> are contained, then an exception
        ///   of type <typeparamref name="TEx"/> will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have a constructor which doesn't take any arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsContainedIn<TArg1, TArg2>(TArg1 arg1, TArg2 arg2, System.Collections.Generic.IDictionary<TArg1, TArg2> dictionary)
        {
            if (ReferenceEquals(dictionary, null) || dictionary.Contains(new System.Collections.Generic.KeyValuePair<TArg1, TArg2>(arg1, arg2)))
            {
                DoThrow();
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> with given message
        ///   <paramref name="message"/> if and only if specified arguments are contained in given
        ///   dictionary pairs.
        /// </summary>
        /// <param name="arg1">The key argument to check.</param>
        /// <param name="arg2">The value argument to check.</param>
        /// <param name="dictionary">The dictionary that must not contain given argument.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor which takes, as
        ///   parameters, either a <see cref="string"/> or a <see cref="string"/> and an
        ///   <see cref="System.Exception"/>. The same exception is thrown when
        ///   <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="arg1"/> and <paramref name="arg2"/> are contained, then an exception
        ///   of type <typeparamref name="TEx"/>, with the message specified by
        ///   <paramref name="message"/>, will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have either a constructor which takes a
        ///   <see cref="string"/> and an <see cref="System.Exception"/> as arguments, or a
        ///   constructor which takes a <see cref="string"/> as only parameter. <br/> If both
        ///   constructors are available, then the one which takes a <see cref="string"/> and an
        ///   <see cref="System.Exception"/> will be used to throw the exception.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsContainedIn<TArg1, TArg2>(TArg1 arg1, TArg2 arg2, System.Collections.Generic.IDictionary<TArg1, TArg2> dictionary,
            string message)
        {
            if (ReferenceEquals(dictionary, null) || dictionary.Contains(new System.Collections.Generic.KeyValuePair<TArg1, TArg2>(arg1, arg2)))
            {
                DoThrow(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if specified
        ///   arguments are not contained in given dictionary pairs.
        /// </summary>
        /// <param name="arg1">The key argument to check.</param>
        /// <param name="arg2">The value argument to check.</param>
        /// <param name="dictionary">The dictionary that must contain given argument.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with no parameters,
        ///   or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="arg1"/> and <paramref name="arg2"/> are not contained, then an
        ///   exception of type <typeparamref name="TEx"/> will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have a constructor which doesn't take any arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsNotContainedIn<TArg1, TArg2>(TArg1 arg1, TArg2 arg2, System.Collections.Generic.IDictionary<TArg1, TArg2> dictionary)
        {
            if (ReferenceEquals(dictionary, null) || !dictionary.Contains(new System.Collections.Generic.KeyValuePair<TArg1, TArg2>(arg1, arg2)))
            {
                DoThrow();
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> with given message
        ///   <paramref name="message"/> if and only if specified arguments are not contained in
        ///   given dictionary pairs.
        /// </summary>
        /// <param name="arg1">The key argument to check.</param>
        /// <param name="arg2">The value argument to check.</param>
        /// <param name="dictionary">The dictionary that must contain given argument.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor which takes, as
        ///   parameters, either a <see cref="string"/> or a <see cref="string"/> and an
        ///   <see cref="System.Exception"/>. The same exception is thrown when
        ///   <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="arg1"/> and <paramref name="arg2"/> are not contained, then an
        ///   exception of type <typeparamref name="TEx"/>, with the message specified by
        ///   <paramref name="message"/>, will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have either a constructor which takes a
        ///   <see cref="string"/> and an <see cref="System.Exception"/> as arguments, or a
        ///   constructor which takes a <see cref="string"/> as only parameter. <br/> If both
        ///   constructors are available, then the one which takes a <see cref="string"/> and an
        ///   <see cref="System.Exception"/> will be used to throw the exception.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsNotContainedIn<TArg1, TArg2>(TArg1 arg1, TArg2 arg2, System.Collections.Generic.IDictionary<TArg1, TArg2> dictionary,
            string message)
        {
            if (ReferenceEquals(dictionary, null) || !dictionary.Contains(new System.Collections.Generic.KeyValuePair<TArg1, TArg2>(arg1, arg2)))
            {
                DoThrow(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if specified
        ///   collection is null or empty.
        /// </summary>
        /// <param name="collection">The collection to check for emptiness.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with no parameters,
        ///   or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="collection"/> is null or empty, then an exception of type
        ///   <typeparamref name="TEx"/> will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have a constructor which doesn't take any arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsEmpty<TArg>(System.Collections.Generic.IEnumerable<TArg> collection)
        {
            if (ReferenceEquals(collection, null) || !collection.Any())
            {
                DoThrow();
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> with given message
        ///   <paramref name="message"/> if and only if specified collection is null or empty.
        /// </summary>
        /// <param name="collection">The collection to check for emptiness.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor which takes, as
        ///   parameters, either a <see cref="string"/> or a <see cref="string"/> and an
        ///   <see cref="System.Exception"/>. The same exception is thrown when
        ///   <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="collection"/> is null or empty, then an exception of type
        ///   <typeparamref name="TEx"/>, with the message specified by <paramref name="message"/>,
        ///   will be thrown. <br/> In order to do that, <typeparamref name="TEx"/> must have either
        ///   a constructor which takes a <see cref="string"/> and an <see cref="System.Exception"/>
        ///   as arguments, or a constructor which takes a <see cref="string"/> as only parameter.
        ///   <br/> If both constructors are available, then the one which takes a
        ///   <see cref="string"/> and an <see cref="System.Exception"/> will be used to throw the exception.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsEmpty<TArg>(System.Collections.Generic.IEnumerable<TArg> collection, string message)
        {
            if (ReferenceEquals(collection, null) || !collection.Any())
            {
                DoThrow(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if specified
        ///   collection is null or not empty.
        /// </summary>
        /// <param name="collection">The collection to check for emptiness.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with no parameters,
        ///   or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="collection"/> is null or not empty, then an exception of type
        ///   <typeparamref name="TEx"/> will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have a constructor which doesn't take any arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsNotEmpty<TArg>(System.Collections.Generic.IEnumerable<TArg> collection)
        {
            if (ReferenceEquals(collection, null) || collection.Any())
            {
                DoThrow();
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> with given message
        ///   <paramref name="message"/> if and only if specified collection is null or not empty.
        /// </summary>
        /// <param name="collection">The collection to check for emptiness.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor which takes, as
        ///   parameters, either a <see cref="string"/> or a <see cref="string"/> and an
        ///   <see cref="System.Exception"/>. The same exception is thrown when
        ///   <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="collection"/> is null or not empty, then an exception of type
        ///   <typeparamref name="TEx"/>, with the message specified by <paramref name="message"/>,
        ///   will be thrown. <br/> In order to do that, <typeparamref name="TEx"/> must have either
        ///   a constructor which takes a <see cref="string"/> and an <see cref="System.Exception"/>
        ///   as arguments, or a constructor which takes a <see cref="string"/> as only parameter.
        ///   <br/> If both constructors are available, then the one which takes a
        ///   <see cref="string"/> and an <see cref="System.Exception"/> will be used to throw the exception.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsNotEmpty<TArg>(System.Collections.Generic.IEnumerable<TArg> collection, string message)
        {
            if (ReferenceEquals(collection, null) || collection.Any())
            {
                DoThrow(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if specified object
        ///   has given type.
        /// </summary>
        /// <param name="instance">The object to test.</param>
        /// <param name="type">The type the object must have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with no parameters,
        ///   or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="instance"/> has given type, then an exception of type
        ///   <typeparamref name="TEx"/> will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have a constructor which doesn't take any arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsInstanceOf(object instance, Type type)
        {
            if (PortableTypeInfo.IsInstanceOf(instance, type))
            {
                DoThrow();
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> with given message
        ///   <paramref name="message"/> if and only if specified object has given type.
        /// </summary>
        /// <param name="instance">The object to test.</param>
        /// <param name="type">The type the object must have.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor which takes, as
        ///   parameters, either a <see cref="string"/> or a <see cref="string"/> and an
        ///   <see cref="System.Exception"/>. The same exception is thrown when
        ///   <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="instance"/> has given type, then an exception of type
        ///   <typeparamref name="TEx"/>, with the message specified by <paramref name="message"/>,
        ///   will be thrown. <br/> In order to do that, <typeparamref name="TEx"/> must have either
        ///   a constructor which takes a <see cref="string"/> and an <see cref="System.Exception"/>
        ///   as arguments, or a constructor which takes a <see cref="string"/> as only parameter.
        ///   <br/> If both constructors are available, then the one which takes a
        ///   <see cref="string"/> and an <see cref="System.Exception"/> will be used to throw the exception.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsInstanceOf(object instance, Type type, string message)
        {
            if (PortableTypeInfo.IsInstanceOf(instance, type))
            {
                DoThrow(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if specified object
        ///   has given type.
        /// </summary>
        /// <typeparam name="TType">The type the object must have.</typeparam>
        /// <param name="instance">The object to test.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with no parameters,
        ///   or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="instance"/> has given type, then an exception of type
        ///   <typeparamref name="TEx"/> will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have a constructor which doesn't take any arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static void IfIsInstanceOf<TType>(object instance)
        {
            if (instance is TType)
            {
                DoThrow();
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> with given message
        ///   <paramref name="message"/> if and only if specified object has given type.
        /// </summary>
        /// <typeparam name="TType">The type the object must have.</typeparam>
        /// <param name="instance">The object to test.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor which takes, as
        ///   parameters, either a <see cref="string"/> or a <see cref="string"/> and an
        ///   <see cref="System.Exception"/>. The same exception is thrown when
        ///   <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="instance"/> has given type, then an exception of type
        ///   <typeparamref name="TEx"/>, with the message specified by <paramref name="message"/>,
        ///   will be thrown. <br/> In order to do that, <typeparamref name="TEx"/> must have either
        ///   a constructor which takes a <see cref="string"/> and an <see cref="System.Exception"/>
        ///   as arguments, or a constructor which takes a <see cref="string"/> as only parameter.
        ///   <br/> If both constructors are available, then the one which takes a
        ///   <see cref="string"/> and an <see cref="System.Exception"/> will be used to throw the exception.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static void IfIsInstanceOf<TType>(object instance, string message)
        {
            if (instance is TType)
            {
                DoThrow(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if specified object
        ///   has not given type.
        /// </summary>
        /// <param name="instance">The object to test.</param>
        /// <param name="type">The type the object must not have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with no parameters,
        ///   or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="instance"/> has not given type, then an exception of type
        ///   <typeparamref name="TEx"/> will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have a constructor which doesn't take any arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsNotInstanceOf(object instance, Type type)
        {
            if (!PortableTypeInfo.IsInstanceOf(instance, type))
            {
                DoThrow();
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> with given message
        ///   <paramref name="message"/> if and only if specified object has not given type.
        /// </summary>
        /// <param name="instance">The object to test.</param>
        /// <param name="type">The type the object must not have.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor which takes, as
        ///   parameters, either a <see cref="string"/> or a <see cref="string"/> and an
        ///   <see cref="System.Exception"/>. The same exception is thrown when
        ///   <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="instance"/> has not given type, then an exception of type
        ///   <typeparamref name="TEx"/>, with the message specified by <paramref name="message"/>,
        ///   will be thrown. <br/> In order to do that, <typeparamref name="TEx"/> must have either
        ///   a constructor which takes a <see cref="string"/> and an <see cref="System.Exception"/>
        ///   as arguments, or a constructor which takes a <see cref="string"/> as only parameter.
        ///   <br/> If both constructors are available, then the one which takes a
        ///   <see cref="string"/> and an <see cref="System.Exception"/> will be used to throw the exception.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsNotInstanceOf(object instance, Type type, string message)
        {
            if (!PortableTypeInfo.IsInstanceOf(instance, type))
            {
                DoThrow(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if specified object
        ///   has not given type.
        /// </summary>
        /// <typeparam name="TType">The type the object must not have.</typeparam>
        /// <param name="instance">The object to test.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with no parameters,
        ///   or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="instance"/> has not given type, then an exception of type
        ///   <typeparamref name="TEx"/> will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have a constructor which doesn't take any arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static void IfIsNotInstanceOf<TType>(object instance)
        {
            if (!(instance is TType))
            {
                DoThrow();
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> with given message
        ///   <paramref name="message"/> if and only if specified object has not given type.
        /// </summary>
        /// <typeparam name="TType">The type the object must not have.</typeparam>
        /// <param name="instance">The object to test.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor which takes, as
        ///   parameters, either a <see cref="string"/> or a <see cref="string"/> and an
        ///   <see cref="System.Exception"/>. The same exception is thrown when
        ///   <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="instance"/> has not given type, then an exception of type
        ///   <typeparamref name="TEx"/>, with the message specified by <paramref name="message"/>,
        ///   will be thrown. <br/> In order to do that, <typeparamref name="TEx"/> must have either
        ///   a constructor which takes a <see cref="string"/> and an <see cref="System.Exception"/>
        ///   as arguments, or a constructor which takes a <see cref="string"/> as only parameter.
        ///   <br/> If both constructors are available, then the one which takes a
        ///   <see cref="string"/> and an <see cref="System.Exception"/> will be used to throw the exception.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static void IfIsNotInstanceOf<TType>(object instance, string message)
        {
            if (!(instance is TType))
            {
                DoThrow(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if specified double
        ///   is <see cref="double.NaN"/>.
        /// </summary>
        /// <param name="number">The double to test for <see cref="double.NaN"/> equality.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with no parameters,
        ///   or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="number"/> is <see cref="double.NaN"/>, then an exception of type
        ///   <typeparamref name="TEx"/> will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have a constructor which doesn't take any arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4", true), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsNaN(double number)
        {
            if (double.IsNaN(number))
            {
                DoThrow();
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> with given message
        ///   <paramref name="message"/> if and only if specified double is <see cref="double.NaN"/>.
        /// </summary>
        /// <param name="number">The double to test for <see cref="double.NaN"/> equality.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor which takes, as
        ///   parameters, either a <see cref="string"/> or a <see cref="string"/> and an
        ///   <see cref="System.Exception"/>. The same exception is thrown when
        ///   <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="number"/> is <see cref="double.NaN"/>, then an exception of type
        ///   <typeparamref name="TEx"/>, with the message specified by <paramref name="message"/>,
        ///   will be thrown. <br/> In order to do that, <typeparamref name="TEx"/> must have either
        ///   a constructor which takes a <see cref="string"/> and an <see cref="System.Exception"/>
        ///   as arguments, or a constructor which takes a <see cref="string"/> as only parameter.
        ///   <br/> If both constructors are available, then the one which takes a
        ///   <see cref="string"/> and an <see cref="System.Exception"/> will be used to throw the exception.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4", true), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsNaN(double number, string message)
        {
            if (double.IsNaN(number))
            {
                DoThrow(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if specified double
        ///   is not <see cref="double.NaN"/>.
        /// </summary>
        /// <param name="number">The double to test for <see cref="double.NaN"/> equality.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with no parameters,
        ///   or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="number"/> is not <see cref="double.NaN"/>, then an exception of type
        ///   <typeparamref name="TEx"/> will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have a constructor which doesn't take any arguments.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsNotNaN(double number)
        {
            if (!double.IsNaN(number))
            {
                DoThrow();
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> with given message
        ///   <paramref name="message"/> if and only if specified double is not <see cref="double.NaN"/>.
        /// </summary>
        /// <param name="number">The double to test for <see cref="double.NaN"/> equality.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor which takes, as
        ///   parameters, either a <see cref="string"/> or a <see cref="string"/> and an
        ///   <see cref="System.Exception"/>. The same exception is thrown when
        ///   <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="number"/> is not <see cref="double.NaN"/>, then an exception of type
        ///   <typeparamref name="TEx"/>, with the message specified by <paramref name="message"/>,
        ///   will be thrown. <br/> In order to do that, <typeparamref name="TEx"/> must have either
        ///   a constructor which takes a <see cref="string"/> and an <see cref="System.Exception"/>
        ///   as arguments, or a constructor which takes a <see cref="string"/> as only parameter.
        ///   <br/> If both constructors are available, then the one which takes a
        ///   <see cref="string"/> and an <see cref="System.Exception"/> will be used to throw the exception.
        /// </remarks>
#if (NET45 || NET46 || PORTABLE)

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif

        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsNotNaN(double number, string message)
        {
            if (!double.IsNaN(number))
            {
                DoThrow(message);
            }
        }
    }
}