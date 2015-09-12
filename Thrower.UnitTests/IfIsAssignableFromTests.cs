// File name: IfIsAssignableFromTests.cs
// 
// Author(s): Alessio Parma <alessio.parma@gmail.com>
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

using NUnit.Framework;
using System;

namespace PommaLabs.Thrower.UnitTests
{
    sealed class IfIsAssignableFromTests : AbstractDiagnosticsTests
    {
        [Test]
        public void BaseType()
        {
            Raise<InvalidOperationException>.IfIsAssignableFrom(new Derived(), typeof(Base));
        }

        [Test]
        public void BaseType_Generic()
        {
            Raise<InvalidOperationException>.IfIsAssignableFrom<Base>(new Derived());
        }

        [Test]
        public void BaseType_WithMsg()
        {
            Raise<InvalidOperationException>.IfIsAssignableFrom(new Derived(), typeof(Base), TestMessage);
        }

        [Test]
        public void BaseType_WithMsg_Generic()
        {
            Raise<InvalidOperationException>.IfIsAssignableFrom<Base>(new Derived(), TestMessage);
        }

        [Test]
        public void ConvertibleType()
        {
            Raise<InvalidCastException>.IfIsAssignableFrom(new Base(), typeof(Convertible));
        }

        [Test]
        public void ConvertibleType_Generic()
        {
            Raise<InvalidCastException>.IfIsAssignableFrom<Convertible>(new Base());
        }

        [Test]
        public void ConvertibleType_WithMsg()
        {
            Raise<InvalidCastException>.IfIsAssignableFrom(new Base(), typeof(Convertible), TestMessage);
        }

        [Test]
        public void ConvertibleType_WithMsg_Generic()
        {
            Raise<InvalidCastException>.IfIsAssignableFrom<Convertible>(new Base(), TestMessage);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DerivedType()
        {
            Raise<InvalidOperationException>.IfIsAssignableFrom(new Base(), typeof(Derived));
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DerivedType_Generic()
        {
            Raise<InvalidOperationException>.IfIsAssignableFrom<Derived>(new Base());
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException), ExpectedMessage = TestMessage)]
        public void DerivedType_WithMsg()
        {
            Raise<InvalidOperationException>.IfIsAssignableFrom(new Base(), typeof(Derived), TestMessage);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException), ExpectedMessage = TestMessage)]
        public void DerivedType_WithMsg_Generic()
        {
            Raise<InvalidOperationException>.IfIsAssignableFrom<Derived>(new Base(), TestMessage);
        }

        [Test]
        public void DifferentType()
        {
            Raise<InvalidOperationException>.IfIsAssignableFrom(5, typeof(string));
        }

        [Test]
        public void DifferentType_Generic()
        {
            Raise<InvalidOperationException>.IfIsAssignableFrom<string>(5);
        }

        [Test]
        public void DifferentType_WithMsg()
        {
            Raise<InvalidOperationException>.IfIsAssignableFrom(5, typeof(string), TestMessage);
        }

        [Test]
        public void DifferentType_WithMsg_Generic()
        {
            Raise<InvalidOperationException>.IfIsAssignableFrom<string>(5, TestMessage);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Not_BaseType()
        {
            Raise<InvalidOperationException>.IfIsNotAssignableFrom(new Derived(), typeof(Base));
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Not_BaseType_Generic()
        {
            Raise<InvalidOperationException>.IfIsNotAssignableFrom<Base>(new Derived());
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException), ExpectedMessage = TestMessage)]
        public void Not_BaseType_WithMsg()
        {
            Raise<InvalidOperationException>.IfIsNotAssignableFrom(new Derived(), typeof(Base), TestMessage);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException), ExpectedMessage = TestMessage)]
        public void Not_BaseType_WithMsg_Generic()
        {
            Raise<InvalidOperationException>.IfIsNotAssignableFrom<Base>(new Derived(), TestMessage);
        }

        [Test]
        [ExpectedException(typeof(InvalidCastException))]
        public void Not_ConvertibleType()
        {
            Raise<InvalidCastException>.IfIsNotAssignableFrom(new Base(), typeof(Convertible));
        }

        [Test]
        [ExpectedException(typeof(InvalidCastException))]
        public void Not_ConvertibleType_Generic()
        {
            Raise<InvalidCastException>.IfIsNotAssignableFrom<Convertible>(new Base());
        }

        [Test]
        [ExpectedException(typeof(InvalidCastException), ExpectedMessage = TestMessage)]
        public void Not_ConvertibleType_WithMsg()
        {
            Raise<InvalidCastException>.IfIsNotAssignableFrom(new Base(), typeof(Convertible), TestMessage);
        }

        [Test]
        [ExpectedException(typeof(InvalidCastException), ExpectedMessage = TestMessage)]
        public void Not_ConvertibleType_WithMsg_Generic()
        {
            Raise<InvalidCastException>.IfIsNotAssignableFrom<Convertible>(new Base(), TestMessage);
        }

        [Test]
        public void Not_DerivedType()
        {
            Raise<InvalidOperationException>.IfIsNotAssignableFrom(new Base(), typeof(Derived));
        }

        [Test]
        public void Not_DerivedType_Generic()
        {
            Raise<InvalidOperationException>.IfIsNotAssignableFrom<Derived>(new Base());
        }

        [Test]
        public void Not_DerivedType_WithMsg()
        {
            Raise<InvalidOperationException>.IfIsNotAssignableFrom(new Base(), typeof(Derived), TestMessage);
        }

        [Test]
        public void Not_DerivedType_WithMsg_Generic()
        {
            Raise<InvalidOperationException>.IfIsNotAssignableFrom<Derived>(new Base(), TestMessage);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Not_DifferentType()
        {
            Raise<InvalidOperationException>.IfIsNotAssignableFrom(5, typeof(string));
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Not_DifferentType_Generic()
        {
            Raise<InvalidOperationException>.IfIsNotAssignableFrom<string>(5);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException), ExpectedMessage = TestMessage)]
        public void Not_DifferentType_WithMsg()
        {
            Raise<InvalidOperationException>.IfIsNotAssignableFrom(5, typeof(string), TestMessage);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException), ExpectedMessage = TestMessage)]
        public void Not_DifferentType_WithMsg_Generic()
        {
            Raise<InvalidOperationException>.IfIsNotAssignableFrom<string>(5, TestMessage);
        }

        [Test]
        public void Not_ReferenceType_ToObject()
        {
            Raise<InvalidCastException>.IfIsNotAssignableFrom(new object(), typeof(string));
        }

        [Test]
        public void Not_ReferenceType_ToObject_Generic()
        {
            Raise<InvalidCastException>.IfIsNotAssignableFrom<string>(new object());
        }

        [Test]
        public void Not_ReferenceType_ToObject_WithMsg()
        {
            Raise<InvalidCastException>.IfIsNotAssignableFrom(new object(), typeof(string), TestMessage);
        }

        [Test]
        public void Not_ReferenceType_ToObject_WithMsg_Generic()
        {
            Raise<InvalidCastException>.IfIsNotAssignableFrom<string>(new object(), TestMessage);
        }

        [Test]
        public void Not_SameType()
        {
            Raise<InvalidOperationException>.IfIsNotAssignableFrom(new object(), typeof(object));
        }

        [Test]
        public void Not_SameType_Generic()
        {
            Raise<InvalidOperationException>.IfIsNotAssignableFrom<object>(new object());
        }

        [Test]
        public void Not_SameType_WithMsg()
        {
            Raise<InvalidOperationException>.IfIsNotAssignableFrom(new object(), typeof(object), TestMessage);
        }

        [Test]
        public void Not_SameType_WithMsg_Generic()
        {
            Raise<InvalidOperationException>.IfIsNotAssignableFrom<object>(new object(), TestMessage);
        }

        [Test]
        [ExpectedException(typeof(InvalidCastException))]
        public void ReferenceType_ToObject()
        {
            Raise<InvalidCastException>.IfIsAssignableFrom(new object(), typeof(string));
        }

        [Test]
        [ExpectedException(typeof(InvalidCastException))]
        public void ReferenceType_ToObject_Generic()
        {
            Raise<InvalidCastException>.IfIsAssignableFrom<string>(new object());
        }

        [Test]
        [ExpectedException(typeof(InvalidCastException), ExpectedMessage = TestMessage)]
        public void ReferenceType_ToObject_WithMsg()
        {
            Raise<InvalidCastException>.IfIsAssignableFrom(new object(), typeof(string), TestMessage);
        }

        [Test]
        [ExpectedException(typeof(InvalidCastException), ExpectedMessage = TestMessage)]
        public void ReferenceType_ToObject_WithMsg_Generic()
        {
            Raise<InvalidCastException>.IfIsAssignableFrom<string>(new object(), TestMessage);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SameType()
        {
            Raise<InvalidOperationException>.IfIsAssignableFrom(new object(), typeof(object));
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SameType_Generic()
        {
            Raise<InvalidOperationException>.IfIsAssignableFrom<object>(new object());
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException), ExpectedMessage = TestMessage)]
        public void SameType_WithMsg()
        {
            Raise<InvalidOperationException>.IfIsAssignableFrom(new object(), typeof(object), TestMessage);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException), ExpectedMessage = TestMessage)]
        public void SameType_WithMsg_Generic()
        {
            Raise<InvalidOperationException>.IfIsAssignableFrom<object>(new object(), TestMessage);
        }
    }
}
