// File name: PortableTypeInfo.cs
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
using System.Collections.Generic;
using System.Reflection;

#if PORTABLE

using IntrospectionExtensions = System.Reflection.IntrospectionExtensions;

#endif

namespace PommaLabs.Thrower.Core
{
    /// <summary>
    ///   Portable version of some useful reflection methods.
    /// </summary>
    static class PortableTypeInfo
    {
        /// <summary>
        ///   Gets the constructors for given type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The constructors for given type.</returns>
        public static IEnumerable<System.Reflection.ConstructorInfo> GetConstructors(Type type)
        {
#if PORTABLE
            return IntrospectionExtensions.GetTypeInfo(type).DeclaredConstructors;
#else
            return type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
#endif
        }        

        /// <summary>
        ///   Determines whether the specified type is abstract.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>Whether the specified type is abstract.</returns>
        public static bool IsAbstract(System.Type type)
        {
#if PORTABLE
            return IntrospectionExtensions.GetTypeInfo(type).IsAbstract;
#else
            return type.IsAbstract;
#endif
        }

        /// <summary>
        ///   Determines whether an instance of the current <see cref="T:System.Type"/> can be
        ///   assigned from an instance of the specified Type.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="type">The type.</param>
        /// <returns>
        ///   Whether an instance of the current <see cref="T:System.Type"/> can be assigned from an
        ///   instance of the specified Type.
        /// </returns>
        public static bool IsAssignableFrom(object obj, System.Type type)
        {
            if (ReferenceEquals(obj, null) || ReferenceEquals(type, null))
            {
                return false;
            }

#if PORTABLE
            return IntrospectionExtensions.GetTypeInfo(obj.GetType()).IsAssignableFrom(IntrospectionExtensions.GetTypeInfo(type));
#else
            return obj.GetType().IsAssignableFrom(type);
#endif
        }

        /// <summary>
        ///   Determines whether the specified object is an instance of the current <see cref="T:System.Type"/>.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="type">The type.</param>
        /// <returns>Whether the specified object is an instance of the current <see cref="T:System.Type"/>.</returns>
        public static bool IsInstanceOf(object obj, System.Type type)
        {
            if (ReferenceEquals(obj, null) || ReferenceEquals(type, null))
            {
                return false;
            }

#if PORTABLE
            return IntrospectionExtensions.GetTypeInfo(type).IsAssignableFrom(IntrospectionExtensions.GetTypeInfo(obj.GetType()));
#else
            return type.IsInstanceOfType(obj);
#endif
        }
    }
}
