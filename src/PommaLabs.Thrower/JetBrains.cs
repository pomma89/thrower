// File name: JetBrains.cs
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

using System;

namespace JetBrains.Annotations
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    internal sealed class ContractAnnotationAttribute : Attribute
    {
        public ContractAnnotationAttribute([NotNull] string contract) : this(contract, false)
        {
        }

        public ContractAnnotationAttribute([NotNull] string contract, bool forceFullStates)
        {
            Contract = contract;
            ForceFullStates = forceFullStates;
        }

        public string Contract { get; private set; }

        public bool ForceFullStates { get; private set; }
    }

    [AttributeUsage(AttributeTargets.Parameter)]
    internal sealed class NoEnumerationAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Delegate | AttributeTargets.Parameter | AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    internal sealed class NotNullAttribute : Attribute
    {
    }
}