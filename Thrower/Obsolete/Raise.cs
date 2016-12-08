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
        [Obsolete("Please use Raise.* or Raise<TEx>.If(Not) overloads, this method has been deprecated and it will be removed in v4"), SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static void IfIsNotContainedIn<TArg1, TArg2>(TArg1 arg1, TArg2 arg2, System.Collections.Generic.IDictionary<TArg1, TArg2> dictionary,
            string message)
        {
            if (ReferenceEquals(dictionary, null) || !dictionary.Contains(new System.Collections.Generic.KeyValuePair<TArg1, TArg2>(arg1, arg2)))
            {
                DoThrow(message);
            }
        }
    }
}