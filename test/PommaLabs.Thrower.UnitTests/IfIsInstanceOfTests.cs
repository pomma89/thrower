// File name: IfIsInstanceOfTests.cs
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

using NUnit.Framework;
using Shouldly;
using System;

namespace PommaLabs.Thrower.UnitTests
{
    internal sealed class IfIsInstanceOfTests : AbstractTests
    {
        [Test]
        public void BaseType()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsInstanceOf(new Derived(), typeof(Base)));
        }

        [Test]
        public void BaseType_Generic()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsInstanceOf<Base>(new Derived()));
        }

        [Test]
        public void BaseType_WithMsg()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsInstanceOf(new Derived(), typeof(Base), TestMessage));
        }

        [Test]
        public void BaseType_WithMsg_Generic()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsInstanceOf<Base>(new Derived(), TestMessage));
        }

        [Test]
        public void ConvertibleType()
        {
            Raise.InvalidCastException.IfIsInstanceOf(new Base(), typeof(Convertible));
        }

        [Test]
        public void ConvertibleType_Generic()
        {
            Raise.InvalidCastException.IfIsInstanceOf<Convertible>(new Base());
        }

        [Test]
        public void ConvertibleType_WithMsg()
        {
            Raise.InvalidCastException.IfIsInstanceOf(new Base(), typeof(Convertible), TestMessage);
        }

        [Test]
        public void ConvertibleType_WithMsg_Generic()
        {
            Raise.InvalidCastException.IfIsInstanceOf<Convertible>(new Base(), TestMessage);
        }

        [Test]
        public void DerivedType()
        {
            Raise.InvalidOperationException.IfIsInstanceOf(new Base(), typeof(Derived));
        }

        [Test]
        public void DerivedType_Generic()
        {
            Raise.InvalidOperationException.IfIsInstanceOf<Derived>(new Base());
        }

        [Test]
        public void DerivedType_WithMsg()
        {
            Raise.InvalidOperationException.IfIsInstanceOf(new Base(), typeof(Derived), TestMessage);
        }

        [Test]
        public void DerivedType_WithMsg_Generic()
        {
            Raise.InvalidOperationException.IfIsInstanceOf<Derived>(new Base(), TestMessage);
        }

        [Test]
        public void DifferentType()
        {
            Raise.InvalidOperationException.IfIsInstanceOf(new object(), typeof(string));
        }

        [Test]
        public void DifferentType_Generic()
        {
            Raise.InvalidOperationException.IfIsInstanceOf<string>(new object());
        }

        [Test]
        public void DifferentType_WithMsg()
        {
            Raise.InvalidOperationException.IfIsInstanceOf(new object(), typeof(string), TestMessage);
        }

        [Test]
        public void DifferentType_WithMsg_Generic()
        {
            Raise.InvalidOperationException.IfIsInstanceOf<string>(new object(), TestMessage);
        }

        [Test]
        public void Not_BaseType()
        {
            Raise.InvalidOperationException.IfIsNotInstanceOf(new Derived(), typeof(Base));
        }

        [Test]
        public void Not_BaseType_Generic()
        {
            Raise.InvalidOperationException.IfIsNotInstanceOf<Base>(new Derived());
        }

        [Test]
        public void Not_BaseType_WithMsg()
        {
            Raise.InvalidOperationException.IfIsNotInstanceOf(new Derived(), typeof(Base), TestMessage);
        }

        [Test]
        public void Not_BaseType_WithMsg_Generic()
        {
            Raise.InvalidOperationException.IfIsNotInstanceOf<Base>(new Derived(), TestMessage);
        }

        [Test]
        public void Not_ConvertibleType()
        {
            Should.Throw<InvalidCastException>(() => Raise.InvalidCastException.IfIsNotInstanceOf(new Base(), typeof(Convertible)));
        }

        [Test]
        public void Not_ConvertibleType_Generic()
        {
            Should.Throw<InvalidCastException>(() => Raise.InvalidCastException.IfIsNotInstanceOf<Convertible>(new Base()));
        }

        [Test]
        public void Not_ConvertibleType_WithMsg()
        {
            Should.Throw<InvalidCastException>(() => Raise.InvalidCastException.IfIsNotInstanceOf(new Base(), typeof(Convertible), TestMessage));
        }

        [Test]
        public void Not_ConvertibleType_WithMsg_Generic()
        {
            Should.Throw<InvalidCastException>(() => Raise.InvalidCastException.IfIsNotInstanceOf<Convertible>(new Base(), TestMessage));
        }

        [Test]
        public void Not_DerivedType()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsNotInstanceOf(new Base(), typeof(Derived)));
        }

        [Test]
        public void Not_DerivedType_Generic()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsNotInstanceOf<Derived>(new Base()));
        }

        [Test]
        public void Not_DerivedType_WithMsg()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsNotInstanceOf(new Base(), typeof(Derived), TestMessage));
        }

        [Test]
        public void Not_DerivedType_WithMsg_Generic()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsNotInstanceOf<Derived>(new Base(), TestMessage));
        }

        [Test]
        public void Not_DifferentType()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsNotInstanceOf(new object(), typeof(string)));
        }

        [Test]
        public void Not_DifferentType_Generic()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsNotInstanceOf<string>(new object()));
        }

        [Test]
        public void Not_DifferentType_WithMsg()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsNotInstanceOf(new object(), typeof(string), TestMessage));
        }

        [Test]
        public void Not_DifferentType_WithMsg_Generic()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsNotInstanceOf<string>(new object(), TestMessage));
        }

        [Test]
        public void Not_ReferenceType_ToObject()
        {
            Should.Throw<InvalidCastException>(() => Raise.InvalidCastException.IfIsNotInstanceOf(new object(), typeof(string)));
        }

        [Test]
        public void Not_ReferenceType_ToObject_Generic()
        {
            Should.Throw<InvalidCastException>(() => Raise.InvalidCastException.IfIsNotInstanceOf<string>(new object()));
        }

        [Test]
        public void Not_ReferenceType_ToObject_WithMsg()
        {
            Should.Throw<InvalidCastException>(() => Raise.InvalidCastException.IfIsNotInstanceOf(new object(), typeof(string), TestMessage));
        }

        [Test]
        public void Not_ReferenceType_ToObject_WithMsg_Generic()
        {
            Should.Throw<InvalidCastException>(() => Raise.InvalidCastException.IfIsNotInstanceOf<string>(new object(), TestMessage));
        }

        [Test]
        public void Not_SameType()
        {
            Raise.InvalidOperationException.IfIsNotInstanceOf(new object(), typeof(object));
        }

        [Test]
        public void Not_SameType_Generic()
        {
            Raise.InvalidOperationException.IfIsNotInstanceOf<object>(new object());
        }

        [Test]
        public void Not_SameType_WithMsg()
        {
            Raise.InvalidOperationException.IfIsNotInstanceOf(new object(), typeof(object), TestMessage);
        }

        [Test]
        public void Not_SameType_WithMsg_Generic()
        {
            Raise.InvalidOperationException.IfIsNotInstanceOf<object>(new object(), TestMessage);
        }

        [Test]
        public void ReferenceType_ToObject()
        {
            Raise.InvalidCastException.IfIsInstanceOf(new object(), typeof(string));
        }

        [Test]
        public void ReferenceType_ToObject_Generic()
        {
            Raise.InvalidCastException.IfIsInstanceOf<string>(new object());
        }

        [Test]
        public void ReferenceType_ToObject_WithMsg()
        {
            Raise.InvalidCastException.IfIsInstanceOf(new object(), typeof(string), TestMessage);
        }

        [Test]
        public void ReferenceType_ToObject_WithMsg_Generic()
        {
            Raise.InvalidCastException.IfIsInstanceOf<string>(new object(), TestMessage);
        }

        [Test]
        public void SameType()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsInstanceOf(new object(), typeof(object)));
        }

        [Test]
        public void SameType_Generic()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsInstanceOf<object>(new object()));
        }

        [Test]
        public void SameType_WithMsg()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsInstanceOf(new object(), typeof(object), TestMessage));
        }

        [Test]
        public void SameType_WithMsg_Generic()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsInstanceOf<object>(new object(), TestMessage));
        }
    }
}