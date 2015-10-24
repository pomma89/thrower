// File name: ValidateAttribute.cs
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
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Collections;

namespace PommaLabs.Thrower.Validation
{
    /// <summary>
    ///   Indicates that the property should be validated.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class ValidateAttribute : Attribute
    {
        /// <summary>
        ///   Indicates that the property is required, that is, it will be checked against null.
        /// 
        ///   Default value is false.
        /// </summary>
        public bool Required { get; set; } = false;

        /// <summary>
        ///   If the property is an <see cref="IEnumerable"/>, then this flag controls whether it
        ///   should enumerated or not.
        /// 
        ///   Default value is true.
        /// </summary>
        public bool Enumerable { get; set; } = true;

        /// <summary>
        ///   If the property is an <see cref="IEnumerable"/>, then this flag controls whether its
        ///   items are required or not.
        /// 
        ///   Default value is false.
        /// </summary>
        public bool EnumerableItemsRequired { get; set; } = false;

        /// <summary>
        ///   If the property is an <see cref="ICollection"/>, then this flag controls the minimum
        ///   value for <see cref="ICollection.Count"/>.
        /// 
        ///   Default value is
        ///   <code>
        ///     0L
        ///   </code>.
        /// </summary>
        public long CollectionItemsMinCount { get; set; } = 0L;

        /// <summary>
        ///   If the property is an <see cref="ICollection"/>, then this flag controls the maximum
        ///   value for <see cref="ICollection.Count"/>.
        /// 
        ///   Default value is <see cref="long.MaxValue"/>.
        /// </summary>
        public long CollectionItemsMaxCount { get; set; } = long.MaxValue;
    }
}
