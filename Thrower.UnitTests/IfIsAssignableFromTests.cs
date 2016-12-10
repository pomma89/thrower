// File name: IfIsAssignableFromTests.cs
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

using NUnit.Framework;
using Shouldly;
using System;

namespace PommaLabs.Thrower.UnitTests
{
    internal sealed class IfIsAssignableFromTests : AbstractTests
    {
        [Test]
        public void BaseType()
        {
            Raise.InvalidOperationException.IfIsAssignableFrom(new Derived(), typeof(Base));
        }

        [Test]
        public void BaseType_Generic()
        {
            Raise.InvalidOperationException.IfIsAssignableFrom<Base>(new Derived());
        }

        [Test]
        public void BaseType_WithMsg()
        {
            Raise.InvalidOperationException.IfIsAssignableFrom(new Derived(), typeof(Base), TestMessage);
        }

        [Test]
        public void BaseType_WithMsg_Generic()
        {
            Raise.InvalidOperationException.IfIsAssignableFrom<Base>(new Derived(), TestMessage);
        }

        [Test]
        public void ConvertibleType()
        {
            Raise.InvalidCastException.IfIsAssignableFrom(new Base(), typeof(Convertible));
        }

        [Test]
        public void ConvertibleType_Generic()
        {
            Raise.InvalidCastException.IfIsAssignableFrom<Convertible>(new Base());
        }

        [Test]
        public void ConvertibleType_WithMsg()
        {
            Raise.InvalidCastException.IfIsAssignableFrom(new Base(), typeof(Convertible), TestMessage);
        }

        [Test]
        public void ConvertibleType_WithMsg_Generic()
        {
            Raise.InvalidCastException.IfIsAssignableFrom<Convertible>(new Base(), TestMessage);
        }

        [Test]
        public void DerivedType()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsAssignableFrom(new Base(), typeof(Derived)));
        }

        [Test]
        public void DerivedType_Generic()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsAssignableFrom<Derived>(new Base()));
        }

        [Test]
        public void DerivedType_WithMsg()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsAssignableFrom(new Base(), typeof(Derived), TestMessage));
        }

        [Test]
        public void DerivedType_WithMsg_Generic()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsAssignableFrom<Derived>(new Base(), TestMessage));
        }

        [Test]
        public void DifferentType()
        {
            Raise.InvalidOperationException.IfIsAssignableFrom(5, typeof(string));
        }

        [Test]
        public void DifferentType_Generic()
        {
            Raise.InvalidOperationException.IfIsAssignableFrom<string>(5);
        }

        [Test]
        public void DifferentType_WithMsg()
        {
            Raise.InvalidOperationException.IfIsAssignableFrom(5, typeof(string), TestMessage);
        }

        [Test]
        public void DifferentType_WithMsg_Generic()
        {
            Raise.InvalidOperationException.IfIsAssignableFrom<string>(5, TestMessage);
        }

        [Test]
        public void Not_BaseType()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsNotAssignableFrom(new Derived(), typeof(Base)));
        }

        [Test]
        public void Not_BaseType_Generic()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsNotAssignableFrom<Base>(new Derived()));
        }

        [Test]
        public void Not_BaseType_WithMsg()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsNotAssignableFrom(new Derived(), typeof(Base), TestMessage));
        }

        [Test]
        public void Not_BaseType_WithMsg_Generic()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsNotAssignableFrom<Base>(new Derived(), TestMessage));
        }

        [Test]
        public void Not_ConvertibleType()
        {
            Should.Throw<InvalidCastException>(() => Raise.InvalidCastException.IfIsNotAssignableFrom(new Base(), typeof(Convertible)));
        }

        [Test]
        public void Not_ConvertibleType_Generic()
        {
            Should.Throw<InvalidCastException>(() => Raise.InvalidCastException.IfIsNotAssignableFrom<Convertible>(new Base()));
        }

        [Test]
        public void Not_ConvertibleType_WithMsg()
        {
            Should.Throw<InvalidCastException>(() => Raise.InvalidCastException.IfIsNotAssignableFrom(new Base(), typeof(Convertible), TestMessage));
        }

        [Test]
        public void Not_ConvertibleType_WithMsg_Generic()
        {
            Should.Throw<InvalidCastException>(() => Raise.InvalidCastException.IfIsNotAssignableFrom<Convertible>(new Base(), TestMessage));
        }

        [Test]
        public void Not_DerivedType()
        {
            Raise.InvalidOperationException.IfIsNotAssignableFrom(new Base(), typeof(Derived));
        }

        [Test]
        public void Not_DerivedType_Generic()
        {
            Raise.InvalidOperationException.IfIsNotAssignableFrom<Derived>(new Base());
        }

        [Test]
        public void Not_DerivedType_WithMsg()
        {
            Raise.InvalidOperationException.IfIsNotAssignableFrom(new Base(), typeof(Derived), TestMessage);
        }

        [Test]
        public void Not_DerivedType_WithMsg_Generic()
        {
            Raise.InvalidOperationException.IfIsNotAssignableFrom<Derived>(new Base(), TestMessage);
        }

        [Test]
        public void Not_DifferentType()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsNotAssignableFrom(5, typeof(string)));
        }

        [Test]
        public void Not_DifferentType_Generic()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsNotAssignableFrom<string>(5));
        }

        [Test]
        public void Not_DifferentType_WithMsg()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsNotAssignableFrom(5, typeof(string), TestMessage));
        }

        [Test]
        public void Not_DifferentType_WithMsg_Generic()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsNotAssignableFrom<string>(5, TestMessage));
        }

        [Test]
        public void Not_ReferenceType_ToObject()
        {
            Raise.InvalidCastException.IfIsNotAssignableFrom(new object(), typeof(string));
        }

        [Test]
        public void Not_ReferenceType_ToObject_Generic()
        {
            Raise.InvalidCastException.IfIsNotAssignableFrom<string>(new object());
        }

        [Test]
        public void Not_ReferenceType_ToObject_WithMsg()
        {
            Raise.InvalidCastException.IfIsNotAssignableFrom(new object(), typeof(string), TestMessage);
        }

        [Test]
        public void Not_ReferenceType_ToObject_WithMsg_Generic()
        {
            Raise.InvalidCastException.IfIsNotAssignableFrom<string>(new object(), TestMessage);
        }

        [Test]
        public void Not_SameType()
        {
            Raise.InvalidOperationException.IfIsNotAssignableFrom(new object(), typeof(object));
        }

        [Test]
        public void Not_SameType_Generic()
        {
            Raise.InvalidOperationException.IfIsNotAssignableFrom<object>(new object());
        }

        [Test]
        public void Not_SameType_WithMsg()
        {
            Raise.InvalidOperationException.IfIsNotAssignableFrom(new object(), typeof(object), TestMessage);
        }

        [Test]
        public void Not_SameType_WithMsg_Generic()
        {
            Raise.InvalidOperationException.IfIsNotAssignableFrom<object>(new object(), TestMessage);
        }

        [Test]
        public void ReferenceType_ToObject()
        {
            Should.Throw<InvalidCastException>(() => Raise.InvalidCastException.IfIsAssignableFrom(new object(), typeof(string)));
        }

        [Test]
        public void ReferenceType_ToObject_Generic()
        {
            Should.Throw<InvalidCastException>(() => Raise.InvalidCastException.IfIsAssignableFrom<string>(new object()));
        }

        [Test]
        public void ReferenceType_ToObject_WithMsg()
        {
            Should.Throw<InvalidCastException>(() => Raise.InvalidCastException.IfIsAssignableFrom(new object(), typeof(string), TestMessage));
        }

        [Test]
        public void ReferenceType_ToObject_WithMsg_Generic()
        {
            Should.Throw<InvalidCastException>(() => Raise.InvalidCastException.IfIsAssignableFrom<string>(new object(), TestMessage));
        }

        [Test]
        public void SameType()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsAssignableFrom(new object(), typeof(object)));
        }

        [Test]
        public void SameType_Generic()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsAssignableFrom<object>(new object()));
        }

        [Test]
        public void SameType_WithMsg()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsAssignableFrom(new object(), typeof(object), TestMessage));
        }

        [Test]
        public void SameType_WithMsg_Generic()
        {
            Should.Throw<InvalidOperationException>(() => Raise.InvalidOperationException.IfIsAssignableFrom<object>(new object(), TestMessage));
        }
    }
}