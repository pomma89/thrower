// File name: EnumerationValidator.cs
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
using System.Linq;

namespace PommaLabs.Thrower.Validation
{
    public static class EnumerationValidator
    {
        public static bool IsDefined<TEnum>(TEnum value)
            where TEnum : struct
        {
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

        private static class CachedEnumValidator<TEnum>
            where TEnum : struct
        {
            static CachedEnumValidator()
            {
                EnumType = typeof(TEnum);

                HasFlagsAttribute = PortableTypeInfo
                    .GetCustomAttributes(EnumType, true)
                    ?.Any(a => a is FlagsAttribute) ?? false;

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