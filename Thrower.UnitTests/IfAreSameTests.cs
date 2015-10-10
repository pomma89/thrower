// File name: IfAreSameTests.cs
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
    sealed class IfAreSameTests : AbstractTests
    {
        [Test]
        public void DifferentObjects()
        {
            Raise<ArgumentNullException>.IfAreSame(new object(), new object());
        }

        [Test]
        public void DifferentObjects_WithMsg()
        {
            Raise<ArgumentNullException>.IfAreSame(new object(), new object(), TestMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Not_DifferentObjects()
        {
            Raise<ArgumentException>.IfAreNotSame(new object(), new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = TestMessage)]
        public void Not_DifferentObjects_WithMsg()
        {
            Raise<ArgumentException>.IfAreNotSame(new object(), new object(), TestMessage);
        }

        [Test]
        public void Not_SameObjects()
        {
            var obj = new object();
            Raise<ArgumentException>.IfAreNotSame(obj, obj);
        }

        [Test]
        public void Not_SameObjects_WithMsg()
        {
            var obj = new object();
            Raise<ArgumentException>.IfAreNotSame(obj, obj, TestMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void SameObjects()
        {
            var obj = new object();
            Raise<ArgumentException>.IfAreSame(obj, obj);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = TestMessage)]
        public void SameObjects_WithMsg()
        {
            var obj = new object();
            Raise<ArgumentException>.IfAreSame(obj, obj, TestMessage);
        }
    }
}
