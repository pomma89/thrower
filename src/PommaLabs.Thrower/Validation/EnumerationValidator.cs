// File name: EnumerationValidator.cs
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
using System.Linq;

namespace PommaLabs.Thrower.Validation
{
    /// <summary>
    ///   An enumeration validator which ensures given enumeration value is defined in specified
    ///   enumeration type. This also works when enumeration has been decorated with <see cref="FlagsAttribute"/>.
    /// </summary>
    public static class EnumerationValidator
    {
        /// <summary>
        ///   Ensures given enumeration value is defined in specified enumeration type.
        /// </summary>
        /// <typeparam name="TEnum">The enumeration type.</typeparam>
        /// <param name="value">The enumeration value.</param>
        /// <returns>
        ///   True if given enumeration value is defined in specified enumeration type, false otherwise.
        /// </returns>
        /// <remarks>This also works when enumeration has been decorated with <see cref="FlagsAttribute"/>.</remarks>
        public static bool Validate<TEnum>(TEnum? value)
            where TEnum : struct
        {
            if (!PortableTypeInfo.IsEnum(CachedEnumValidator<TEnum>.EnumType))
            {
                return false;
            }
            return value.HasValue ? Validate(value.Value) : true;
        }

        /// <summary>
        ///   Ensures given enumeration value is defined in specified enumeration type.
        /// </summary>
        /// <typeparam name="TEnum">The enumeration type.</typeparam>
        /// <param name="value">The enumeration value.</param>
        /// <returns>
        ///   True if given enumeration value is defined in specified enumeration type, false otherwise.
        /// </returns>
        /// <remarks>This also works when enumeration has been decorated with <see cref="FlagsAttribute"/>.</remarks>
        public static bool Validate<TEnum>(TEnum value)
            where TEnum : struct
        {
            if (!PortableTypeInfo.IsEnum(CachedEnumValidator<TEnum>.EnumType))
            {
                return false;
            }
            if (Enum.IsDefined(CachedEnumValidator<TEnum>.EnumType, value))
            {
                return true;
            }
            if (CachedEnumValidator<TEnum>.HasFlagsAttribute)
            {
                var intValue = PortableTypeInfo.CastTo<int>.From(value);
                return (CachedEnumValidator<TEnum>.Mask & intValue) == intValue;
            }
            return false;
        }

        /// <summary>
        ///   Ensures given enumeration value is defined in specified enumeration type.
        /// </summary>
        /// <param name="enumType">The enumeration type.</param>
        /// <param name="value">The enumeration value.</param>
        /// <returns>
        ///   True if given enumeration value is defined in specified enumeration type, false otherwise.
        /// </returns>
        /// <remarks>This also works when enumeration has been decorated with <see cref="FlagsAttribute"/>.</remarks>
        public static bool Validate(Type enumType, object value)
        {
            bool? isReallyAnEnum = null;

            if (PortableTypeInfo.IsGenericType(enumType) && ReferenceEquals(PortableTypeInfo.GetGenericTypeDefinition(enumType), typeof(Nullable<>)))
            {
                var innerEnumType = PortableTypeInfo.GetGenericTypeArguments(enumType)[0];
                isReallyAnEnum = PortableTypeInfo.IsEnum(innerEnumType);

                if (isReallyAnEnum.Value && ReferenceEquals(value, null))
                {
                    // Nullable enum with null value, OK.
                    return true;
                }

                if (value.GetType() == enumType)
                {
                    if (!PortableTypeInfo.GetPublicPropertyValue<bool>(value, nameof(Nullable<byte>.HasValue)))
                    {
                        // OK if we are really handling an enumeration.
                        return isReallyAnEnum.Value;
                    }
                    value = PortableTypeInfo.GetPublicPropertyValue(value, nameof(Nullable<byte>.Value));
                }

                // Overwrite enumeration type with the inner one, since we are sure that value has
                // that type; in fact, above if ensures that condition.
                enumType = innerEnumType;
            }

            if ((isReallyAnEnum.HasValue && !isReallyAnEnum.Value) || !PortableTypeInfo.IsEnum(enumType))
            {
                // If we are not handling an enum, then exit now.
                return false;
            }
            if (Enum.IsDefined(enumType, value))
            {
                return true;
            }

            var hasFlagsAttribute = TypeHasFlagsAttribute(enumType);

            if (hasFlagsAttribute)
            {
                var mask = 0;
                foreach (var enumValue in Enum.GetValues(enumType))
                {
                    mask = mask | (int) enumValue;
                }
                var intValue = (int) value;
                return (mask & intValue) == intValue;
            }

            return false;
        }

        private static bool TypeHasFlagsAttribute(Type enumType) => PortableTypeInfo
             .GetCustomAttributes(enumType, true)
             ?.Any(a => a is FlagsAttribute) ?? false;

        private static class CachedEnumValidator<TEnum>
            where TEnum : struct
        {
            static CachedEnumValidator()
            {
                EnumType = typeof(TEnum);

                HasFlagsAttribute = TypeHasFlagsAttribute(EnumType);

                if (HasFlagsAttribute)
                {
                    var mask = 0;
                    foreach (var enumValue in Enum.GetValues(EnumType))
                    {
                        mask = mask | (int) enumValue;
                    }
                    Mask = mask;
                }
            }

            public static Type EnumType { get; }

            public static bool HasFlagsAttribute { get; }

            public static int Mask { get; }
        }
    }
}