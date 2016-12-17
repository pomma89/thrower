// File name: RaiseGeneric.cs
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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace PommaLabs.Thrower
{
    /// <summary>
    ///   Stores items shared by various <see cref="Raise{TEx}"/> instances.
    /// </summary>
    public abstract class RaiseBase
    {
        /// <summary>
        ///   Stores an empty array of <see cref="object"/> used to activate constructors without parameters.
        /// </summary>
        protected static readonly object[] NoCtorParams = new object[0];

        /// <summary>
        ///   Stores an empty array of <see cref="Type"/> used to seek constructors without parameters.
        /// </summary>
        protected static readonly Type[] NoCtorTypes = new Type[0];

        /// <summary>
        ///   Stores the types needed to seek the constructor which takes a string and an exception
        ///   as parameters to instance the exception.
        /// </summary>
        protected static readonly Type[] StrExCtorTypes = { typeof(string), typeof(Exception) };

        /// <summary>
        ///   Stores the type needed to seek the constructor which takes a string as parameter to
        ///   instance the exception.
        /// </summary>
        protected static readonly Type[] StrCtorType = { typeof(string) };
    }

    /// <summary>
    ///   Contains methods that throw specified exception <typeparamref name="TEx"/> if given
    ///   conditions will be verified.
    /// </summary>
    /// <typeparam name="TEx">The type of the exceptions thrown if conditions will be satisfied.</typeparam>
    /// <remarks>
    ///   In order to achieve a good speed, the class caches an instance of the constructors found
    ///   via reflection; therefore, constructors are looked for only once.
    /// </remarks>
    public sealed partial class Raise<TEx> : RaiseBase where TEx : Exception
    {
#pragma warning disable RECS0108 // Warns about static fields in generic types

        /// <summary>
        ///   Stores wheter the exception type is abstract or not. We do this both to provide better
        ///   error messages for the end user and to avoid calling wrong constructors.
        /// </summary>
        private static readonly bool ExTypeIsAbstract = PortableTypeInfo.IsAbstract(typeof(TEx));

        /// <summary>
        ///   Caches an instance of the constructor which takes no arguments. If it does not exist,
        ///   then this field will be null. There must be an instance for each type associated with <see cref="Raise{TEx}"/>.
        /// </summary>
        private static readonly ConstructorInfo NoArgsCtor = GetCtor(NoCtorTypes);

        /// <summary>
        ///   Caches an instance of the constructor which creates an exception with a message. If it
        ///   does not exist, then this field will be null. There must be an instance for each type
        ///   associated with <see cref="Raise{TEx}"/>.
        /// </summary>
        /// <remarks>
        ///   At first, we look for constructors which take a string and an inner exception, because
        ///   some standard exceptions (like ArgumentException or ArgumentNullException) have a
        ///   constructor which takes a string as a "parameter name", not as a message. If a
        ///   constructor with that signature is not found, then we look for a constructor with a
        ///   string as the only argument.
        /// </remarks>
        private static readonly ConstructorInfo MsgCtor = GetCtor(StrExCtorTypes) ?? GetCtor(StrCtorType);

        /// <summary>
        ///   Keeps the number of arguments required by the constructor who creates the exception
        ///   with a message.
        /// </summary>
        private static readonly int MsgArgCount = (MsgCtor == null) ? 0 : MsgCtor.GetParameters().Length;

#pragma warning restore RECS0108 // Warns about static fields in generic types

        /// <summary>
        ///   <see cref="Raise{TEx}"/> must not be instanced.
        /// </summary>
        private Raise()
        {
            throw new InvalidOperationException("This class should not be instantiated");
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if specified
        ///   condition is true.
        /// </summary>
        /// <param name="cond">The condition that determines whether an exception will be thrown.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with no parameters,
        ///   or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="cond"/> is true, then an exception of type
        ///   <typeparamref name="TEx"/> will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have a constructor which doesn't take any arguments.
        /// </remarks>
        [MethodImpl(Raise.MethodImplOptions)]
        public static void If(bool cond)
        {
            if (cond)
            {
                DoThrow();
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> with given message
        ///   <paramref name="message"/> if and only if specified condition is true.
        /// </summary>
        /// <param name="cond">The condition that determines whether an exception will be thrown.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor which takes, as
        ///   parameters, either a <see cref="string"/> or a <see cref="string"/> and an
        ///   <see cref="System.Exception"/>. The same exception is thrown when
        ///   <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="cond"/> is true, then an exception of type
        ///   <typeparamref name="TEx"/>, with the message specified by <paramref name="message"/>,
        ///   will be thrown. <br/> In order to do that, <typeparamref name="TEx"/> must have either
        ///   a constructor which takes a <see cref="string"/> and an <see cref="System.Exception"/>
        ///   as arguments, or a constructor which takes a <see cref="string"/> as only parameter.
        ///   <br/> If both constructors are available, then the one which takes a
        ///   <see cref="string"/> and an <see cref="System.Exception"/> will be used to throw the exception.
        /// </remarks>
        [MethodImpl(Raise.MethodImplOptions)]
        public static void If(bool cond, string message)
        {
            if (cond)
            {
                DoThrow(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if specified
        ///   condition is true.
        /// </summary>
        /// <param name="cond">The condition that determines whether an exception will be thrown.</param>
        /// <param name="firstParam">
        ///   The first parameter that will be used for the exception constructor, if needed.
        /// </param>
        /// <param name="otherParams">
        ///   Other parameters that will be used for the exception constructor, if needed.
        /// </param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with specified
        ///   parameters, or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="cond"/> is true, then an exception of type
        ///   <typeparamref name="TEx"/> will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have a constructor which takes specified arguments.
        ///   Moreover, each specified argument must not be null, otherwise type inference will fail.
        /// </remarks>
        [MethodImpl(Raise.MethodImplOptions)]
        public static void If(bool cond, object firstParam, params object[] otherParams)
        {
            if (cond)
            {
                DoThrow(firstParam, otherParams);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if specified
        ///   condition is false.
        /// </summary>
        /// <param name="cond">The condition that determines whether an exception will be thrown.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with no parameters,
        ///   or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="cond"/> is false, then an exception of type
        ///   <typeparamref name="TEx"/> will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have a constructor which doesn't take any arguments.
        /// </remarks>
        [MethodImpl(Raise.MethodImplOptions)]
        public static void IfNot(bool cond)
        {
            if (!cond)
            {
                DoThrow();
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> with given message
        ///   <paramref name="message"/> if and only if specified condition is false.
        /// </summary>
        /// <param name="cond">The condition that determines whether an exception will be thrown.</param>
        /// <param name="message">The message the thrown exception will have.</param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor which takes, as
        ///   parameters, either a <see cref="string"/> or a <see cref="string"/> and an
        ///   <see cref="System.Exception"/>. The same exception is thrown when
        ///   <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="cond"/> is false, then an exception of type
        ///   <typeparamref name="TEx"/>, with the message specified by <paramref name="message"/>,
        ///   will be thrown. <br/> In order to do that, <typeparamref name="TEx"/> must have either
        ///   a constructor which takes a <see cref="string"/> and an <see cref="System.Exception"/>
        ///   as arguments, or a constructor which takes a <see cref="string"/> as only parameter.
        ///   <br/> If both constructors are available, then the one which takes a
        ///   <see cref="string"/> and an <see cref="System.Exception"/> will be used to throw the exception.
        /// </remarks>
        [MethodImpl(Raise.MethodImplOptions)]
        public static void IfNot(bool cond, string message)
        {
            if (!cond)
            {
                DoThrow(message);
            }
        }

        /// <summary>
        ///   Throws an exception of type <typeparamref name="TEx"/> if and only if specified
        ///   condition is false.
        /// </summary>
        /// <param name="cond">The condition that determines whether an exception will be thrown.</param>
        /// <param name="firstParam">
        ///   The first parameter that will be used for the exception constructor, if needed.
        /// </param>
        /// <param name="otherParams">
        ///   Other parameters that will be used for the exception constructor, if needed.
        /// </param>
        /// <exception cref="ThrowerException">
        ///   <typeparamref name="TEx"/> has not a public or internal constructor with specified
        ///   parameters, or <typeparamref name="TEx"/> is abstract.
        /// </exception>
        /// <remarks>
        ///   If <paramref name="cond"/> is false, then an exception of type
        ///   <typeparamref name="TEx"/> will be thrown. <br/> In order to do that,
        ///   <typeparamref name="TEx"/> must have a constructor which takes specified arguments.
        ///   Moreover, each specified argument must not be null, otherwise type inference will fail.
        /// </remarks>
        [MethodImpl(Raise.MethodImplOptions)]
        public static void IfNot(bool cond, object firstParam, params object[] otherParams)
        {
            if (!cond)
            {
                DoThrow(firstParam, otherParams);
            }
        }

        #region Private methods

        private static ConstructorInfo GetCtor(IList<Type> ctorTypes)
        {
            return (from c in PortableTypeInfo.GetConstructors(typeof(TEx))
                    let args = c.GetParameters()
                    let zipArgs = MyZip(args, ctorTypes, (argType, ctorType) => new { argType, ctorType })
                    where args.Length == ctorTypes.Count &&
                          (c.IsPublic || c.IsAssembly) &&
                          zipArgs.All(t => ReferenceEquals(t.argType.ParameterType, t.ctorType))
                    select c).FirstOrDefault();
        }

        private static IEnumerable<TResult> MyZip<TFirst, TSecond, TResult>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
            Raise.ArgumentNullException.IfIsNull(first, nameof(first));
            Raise.ArgumentNullException.IfIsNull(second, nameof(second));
            Raise.ArgumentNullException.IfIsNull(resultSelector, nameof(resultSelector));

            using (IEnumerator<TFirst> e1 = first.GetEnumerator())
            using (IEnumerator<TSecond> e2 = second.GetEnumerator())
            {
                while (e1.MoveNext() && e2.MoveNext())
                {
#pragma warning disable CC0031 // Check for null before calling a delegate
                    yield return resultSelector(e1.Current, e2.Current);
#pragma warning restore CC0031 // Check for null before calling a delegate
                }
            }
        }

        private static void DoThrow()
        {
            // Checks whether the proper constructor exists. If not, then we produce an internal exception.
            if (ExTypeIsAbstract)
            {
                throw ThrowerException.AbstractEx;
            }

            if (NoArgsCtor == null)
            {
                throw ThrowerException.MissingNoParamsCtorEx;
            }

            // A proper constrctor exists: therefore, we can throw the exception.
            throw (TEx) NoArgsCtor.Invoke(NoCtorParams);
        }

        private static void DoThrow(string message)
        {
            // Checks whether the proper constructor exists. If not, then we produce an internal exception.
            if (ExTypeIsAbstract)
            {
                throw ThrowerException.AbstractEx;
            }

            if (MsgCtor == null)
            {
                throw ExTypeIsAbstract ? ThrowerException.AbstractEx : ThrowerException.MissingMsgCtorEx;
            }

            // A proper constrctor exists: therefore, we can throw the exception.
            var messageArgs = new object[MsgArgCount];
            messageArgs[0] = message;
            throw (TEx) MsgCtor.Invoke(messageArgs);
        }

        private static void DoThrow(object firstParam, object[] otherParams)
        {
            // Checks whether the proper constructor exists. If not, then we produce an internal exception.
            if (ExTypeIsAbstract)
            {
                throw ThrowerException.AbstractEx;
            }

            if (firstParam == null)
            {
                throw ThrowerException.NullArgEx;
            }

            // Build required types and parameters list.
            var paramCount = 1 + otherParams?.Length ?? 0;
            var ctorParams = new object[paramCount];
            ctorParams[0] = firstParam;
            var ctorTypes = new Type[paramCount];
            ctorTypes[0] = firstParam.GetType();
            if (paramCount > 1)
            {
                for (var i = 0; i < otherParams.Length; ++i)
                {
                    var p = otherParams[i];
                    if (p == null)
                    {
                        throw ThrowerException.NullArgEx;
                    }
                    ctorParams[i + 1] = p;
                    ctorTypes[i + 1] = p.GetType();
                }
            }

            // Retrieve constructor.
            var ctor = GetCtor(ctorTypes);

            // If it does not exist, then try to use the parameterless one.
            if (ctor == null)
            {
                DoThrow();
            }

            // Otherwise, invoke the costructor and throw the exception.
            throw (TEx) ctor.Invoke(ctorParams);
        }

        #endregion Private methods
    }
}