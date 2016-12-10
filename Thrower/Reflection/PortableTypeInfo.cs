// File name: PortableTypeInfo.cs
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
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace PommaLabs.Thrower.Reflection
{
    /// <summary>
    ///   Portable version of some useful reflection methods.
    /// </summary>
    public static class PortableTypeInfo
    {
#if !(PORTABLE || NETSTD11)
        internal const BindingFlags PublicAndPrivateInstanceFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        internal const BindingFlags PublicInstanceFlags = BindingFlags.Public | BindingFlags.Instance;
#endif

        private static readonly object[] EmptyObjectArray = new object[0];

        /// <summary>
        ///   Represents an empty array of type <see cref="Type"/>. This property is read-only.
        /// </summary>
        public static Type[] EmptyTypes { get; } = new Type[0];

        /// <summary>
        ///   Gets the custom attributes for given type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="inherit">
        ///   True to search this type's inheritance chain to find the attributes; otherwise, false.
        /// </param>
        /// <returns>The custom attributes for given type.</returns>
        public static IList<Attribute> GetCustomAttributes(Type type, bool inherit)
        {
#if (PORTABLE || NETSTD11 || NETSTD13)
            return IntrospectionExtensions.GetTypeInfo(type).GetCustomAttributes().ToArray();
#else
            return type.GetCustomAttributes(inherit).Cast<Attribute>().ToArray();
#endif
        }

        /// <summary>
        ///   Gets the custom attributes for given member.
        /// </summary>
        /// <param name="memberInfo">The member.</param>
        /// <param name="inherit">
        ///   True to search this member's inheritance chain to find the attributes; otherwise, false.
        /// </param>
        /// <returns>The custom attributes for given member.</returns>
        public static IList<Attribute> GetCustomAttributes(MemberInfo memberInfo, bool inherit)
        {
#if (PORTABLE || NETSTD11 || NETSTD13)
            return memberInfo.GetCustomAttributes(inherit).ToArray();
#else
            return memberInfo.GetCustomAttributes(inherit).Cast<Attribute>().ToArray();
#endif
        }

        /// <summary>
        ///   Gets the constructors for given type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The constructors for given type.</returns>
        public static IList<ConstructorInfo> GetConstructors(Type type)
        {
#if (PORTABLE || NETSTD11 || NETSTD13)
            return IntrospectionExtensions.GetTypeInfo(type).DeclaredConstructors.ToArray();
#else
            return type.GetConstructors(PublicAndPrivateInstanceFlags);
#endif
        }

        /// <summary>
        ///   Gets the constructors for given type.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns>The constructors for given type.</returns>
        public static IList<ConstructorInfo> GetConstructors<T>() => GetConstructors(typeof(T));

        /// <summary>
        ///   Gets the base type of given type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The base type of given type.</returns>
        public static Type GetBaseType(Type type)
        {
#if (PORTABLE || NETSTD11 || NETSTD13)
            return IntrospectionExtensions.GetTypeInfo(type).BaseType;
#else
            return type.BaseType;
#endif
        }

        /// <summary>
        ///   Gets the generic type definition of given type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The generic type definition of given type.</returns>
        public static Type GetGenericTypeDefinition(Type type)
        {
#if (PORTABLE || NETSTD11 || NETSTD13)
            return IntrospectionExtensions.GetTypeInfo(type).GetGenericTypeDefinition();
#else
            return type.GetGenericTypeDefinition();
#endif
        }

        /// <summary>
        ///   Gets the generic type arguments of given type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The generic type arguments of given type.</returns>
        public static IList<Type> GetGenericTypeArguments(Type type)
        {
#if (PORTABLE || NETSTD11 || NETSTD13)
            return IntrospectionExtensions.GetTypeInfo(type).GenericTypeArguments;
#else
            return type.GetGenericArguments();
#endif
        }

        /// <summary>
        ///   Gets the interfaces for given type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The interfaces for given type.</returns>
        public static IList<Type> GetInterfaces(Type type)
        {
#if (PORTABLE || NETSTD11 || NETSTD13)
            return IntrospectionExtensions.GetTypeInfo(type).ImplementedInterfaces.ToArray();
#else
            return type.GetInterfaces();
#endif
        }

        /// <summary>
        ///   Gets all the public instance properties for given type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The public instance properties for given type.</returns>
        public static IList<PropertyInfo> GetPublicProperties(Type type)
        {
#if (PORTABLE || NETSTD11 || NETSTD13)
            var properties = new List<PropertyInfo>();
            while (type != null)
            {
                var typeInfo = IntrospectionExtensions.GetTypeInfo(type);
                properties.AddRange(typeInfo.DeclaredProperties.Where(p => p.GetMethod.IsPublic));
                type = typeInfo.BaseType;
            }
            return properties;
#else
            return type.GetProperties(PublicInstanceFlags);
#endif
        }

        /// <summary>
        ///   Gets all the instance properties for given type.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns>The instance properties for given type.</returns>
        public static IList<PropertyInfo> GetPublicProperties<T>() => GetPublicProperties(typeof(T));

        #region GetPublicPropertyValue

        /// <summary>
        ///   Gets the value of given property on given instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="propertyInfo">The property info.</param>
        /// <returns>The value of given property on given instance.</returns>
        public static object GetPublicPropertyValue(object instance, PropertyInfo propertyInfo)
        {
            Raise.ArgumentNullException.IfIsNull(instance, nameof(instance), "Instance cannot be null");
            Raise.ArgumentException.IfNot(propertyInfo.CanRead, nameof(propertyInfo), "Given property cannot be read");
            return propertyInfo.GetValue(instance, EmptyObjectArray);
        }

#if !(PORTABLE || NETSTD11)

        /// <summary>
        ///   Gets the value of given property on given instance.
        /// </summary>
        /// <param name="typeAccessor">The type accessor.</param>
        /// <param name="instance">The instance.</param>
        /// <param name="propertyInfo">The property info.</param>
        /// <returns>The value of given property on given instance.</returns>
        public static object GetPublicPropertyValue(FastMember.TypeAccessor typeAccessor, object instance, PropertyInfo propertyInfo)
        {
            Raise.ArgumentNullException.IfIsNull(instance, nameof(instance), "Instance cannot be null");
            Raise.ArgumentException.IfNot(propertyInfo.CanRead, nameof(propertyInfo), "Given property cannot be read");
            return typeAccessor[instance, propertyInfo.Name];
        }

#endif

        #endregion GetPublicPropertyValue

        #region IsAbstract

        /// <summary>
        ///   Determines whether the specified type is abstract.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>Whether the specified type is abstract.</returns>
        public static bool IsAbstract(Type type)
        {
#if (PORTABLE || NETSTD11 || NETSTD13)
            return IntrospectionExtensions.GetTypeInfo(type).IsAbstract;
#else
            return type.IsAbstract;
#endif
        }

        /// <summary>
        ///   Determines whether the specified type is abstract.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns>Whether the specified type is abstract.</returns>
        public static bool IsAbstract<T>() => IsAbstract(typeof(T));

        #endregion IsAbstract

        #region IsClass

        /// <summary>
        ///   Determines whether the specified type is a class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>Whether the specified type is a class.</returns>
        public static bool IsClass(Type type)
        {
#if (PORTABLE || NETSTD11 || NETSTD13)
            return IntrospectionExtensions.GetTypeInfo(type).IsClass;
#else
            return type.IsClass;
#endif
        }

        /// <summary>
        ///   Determines whether the specified type is a class.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns>Whether the specified type is a class.</returns>
        public static bool IsClass<T>() => IsClass(typeof(T));

        #endregion IsClass

        /// <summary>
        ///   Determines whether an instance of the current <see cref="Type"/> can be assigned from
        ///   an instance of the specified Type.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="type">The type.</param>
        /// <returns>
        ///   Whether an instance of the current <see cref="Type"/> can be assigned from an instance
        ///   of the specified Type.
        /// </returns>
        public static bool IsAssignableFrom(object obj, Type type)
        {
            if (ReferenceEquals(obj, null) || ReferenceEquals(type, null))
            {
                return false;
            }

#if (PORTABLE || NETSTD11 || NETSTD13)
            return IntrospectionExtensions.GetTypeInfo(obj.GetType()).IsAssignableFrom(IntrospectionExtensions.GetTypeInfo(type));
#else
            return obj.GetType().IsAssignableFrom(type);
#endif
        }

        #region IsEnum

        /// <summary>
        ///   Determines whether the specified type is an enumeration.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>Whether the specified type is an enumeration.</returns>
        public static bool IsEnum(Type type)
        {
#if (PORTABLE || NETSTD11 || NETSTD13)
            return IntrospectionExtensions.GetTypeInfo(type).IsEnum;
#else
            return type.IsEnum;
#endif
        }

        /// <summary>
        ///   Determines whether the specified type is an enumeration.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns>Whether the specified type is an enumeration.</returns>
        public static bool IsEnum<T>() => IsEnum(typeof(T));

        #endregion IsEnum

        #region IsGenericType

        /// <summary>
        ///   Determines whether the specified type is a generic type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>Whether the specified type is a generic type.</returns>
        public static bool IsGenericType(Type type)
        {
#if (PORTABLE || NETSTD11 || NETSTD13)
            return IntrospectionExtensions.GetTypeInfo(type).IsGenericType;
#else
            return type.IsGenericType;
#endif
        }

        /// <summary>
        ///   Determines whether the specified type is a generic type.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns>Whether the specified type is a generic type.</returns>
        public static bool IsGenericType<T>() => IsGenericType(typeof(T));

        #endregion IsGenericType

        #region IsGenericTypeDefinition

        /// <summary>
        ///   Determines whether the specified type is a generic type definition.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>Whether the specified type is a generic type definition.</returns>
        public static bool IsGenericTypeDefinition(Type type)
        {
#if (PORTABLE || NETSTD11 || NETSTD13)
            return IntrospectionExtensions.GetTypeInfo(type).IsGenericTypeDefinition;
#else
            return type.IsGenericTypeDefinition;
#endif
        }

        /// <summary>
        ///   Determines whether the specified type is a generic type definition.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns>Whether the specified type is a generic type definition.</returns>
        public static bool IsGenericTypeDefinition<T>() => IsGenericTypeDefinition(typeof(T));

        #endregion IsGenericTypeDefinition

        /// <summary>
        ///   Determines whether the specified object is an instance of the current <see cref="Type"/>.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="type">The type.</param>
        /// <returns>Whether the specified object is an instance of the current <see cref="Type"/>.</returns>
        public static bool IsInstanceOf(object obj, Type type)
        {
            if (ReferenceEquals(obj, null) || ReferenceEquals(type, null))
            {
                return false;
            }

#if (PORTABLE || NETSTD11 || NETSTD13)
            return IntrospectionExtensions.GetTypeInfo(type).IsAssignableFrom(IntrospectionExtensions.GetTypeInfo(obj.GetType()));
#else
            return type.IsInstanceOfType(obj);
#endif
        }

        #region IsInterface

        /// <summary>
        ///   Determines whether the specified type is an interface.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>Whether the specified type is an interface.</returns>
        public static bool IsInterface(Type type)
        {
#if (PORTABLE || NETSTD11 || NETSTD13)
            return IntrospectionExtensions.GetTypeInfo(type).IsInterface;
#else
            return type.IsInterface;
#endif
        }

        /// <summary>
        ///   Determines whether the specified type is an interface.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns>Whether the specified type is an interface.</returns>
        public static bool IsInterface<T>() => IsInterface(typeof(T));

        #endregion IsInterface

        #region IsPrimitive

        /// <summary>
        ///   Determines whether the specified type is primitive.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>Whether the specified type is primitive.</returns>
        public static bool IsPrimitive(Type type)
        {
#if (PORTABLE || NETSTD11 || NETSTD13)
            return IntrospectionExtensions.GetTypeInfo(type).IsPrimitive;
#else
            return type.IsPrimitive;
#endif
        }

        /// <summary>
        ///   Determines whether the specified type is primitive.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns>Whether the specified type is primitive.</returns>
        public static bool IsPrimitive<T>() => IsPrimitive(typeof(T));

        #endregion IsPrimitive

        #region IsValueType

        /// <summary>
        ///   Determines whether the specified type is a value type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>Whether the specified type is a value type.</returns>
        public static bool IsValueType(Type type)
        {
#if (PORTABLE || NETSTD11 || NETSTD13)
            return IntrospectionExtensions.GetTypeInfo(type).IsValueType;
#else
            return type.IsValueType;
#endif
        }

        /// <summary>
        ///   Determines whether the specified type is a value type.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns>Whether the specified type is a value type.</returns>
        public static bool IsValueType<T>() => IsValueType(typeof(T));

        #endregion IsValueType

        #region IsPublic

        /// <summary>
        ///   Determines whether the specified type is public.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>Whether the specified type is public.</returns>
        public static bool IsPublic(Type type)
        {
#if (PORTABLE || NETSTD11 || NETSTD13)
            return type.GetTypeInfo().IsPublic;
#else
            return type.IsPublic;
#endif
        }

        /// <summary>
        ///   Determines whether the specified type is public.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns>Whether the specified type is public.</returns>
        public static bool IsPublic<T>() => IsPublic(typeof(T));

        /// <summary>
        ///   Determines whether the specified type is nested public.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>Whether the specified type is nested public.</returns>
        public static bool IsNestedPublic(Type type)
        {
#if (PORTABLE || NETSTD11 || NETSTD13)
            return type.GetTypeInfo().IsNestedPublic;
#else
            return type.IsNestedPublic;
#endif
        }

        /// <summary>
        ///   Determines whether the specified type is nested public.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns>Whether the specified type is nested public.</returns>
        public static bool IsNestedPublic<T>() => IsNestedPublic(typeof(T));

        #endregion IsPublic

        #region CastTo

        /// <summary>
        ///   Class to cast to type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        /// <remarks>Found on StackOverflow: "http://stackoverflow.com/a/23391746/1880086".</remarks>
        public static class CastTo<T>
        {
            /// <summary>
            ///   Casts <typeparamref name="S"/> to <typeparamref name="T"/>. This does not cause
            ///   boxing for value types. Useful in generic methods.
            /// </summary>
            /// <param name="s">The value that should be cast.</param>
            /// <typeparam name="S">Source type to cast from. Usually a generic type.</typeparam>
            public static T From<S>(S s)
            {
                return Cache<S>.caster(s);
            }

            private static class Cache<S>
            {
                public static readonly Func<S, T> caster = Get();

                private static Func<S, T> Get()
                {
                    var p = Expression.Parameter(typeof(S), "s");
                    var c = Expression.ConvertChecked(p, typeof(T));
                    return Expression.Lambda<Func<S, T>>(c, p).Compile();
                }
            }
        }

        #endregion CastTo
    }
}