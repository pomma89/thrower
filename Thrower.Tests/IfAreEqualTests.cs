//
// IfAreEqualTests.cs
//
// Author:
//       Alessio Parma <alessio.parma@gmail.com>
//
// Copyright (c) 2013 Alessio Parma <alessio.parma@gmail.com>
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

namespace Thrower.Tests
{
    using System;
    using NUnit.Framework;

    public sealed class IfAreEqualTests : TestBase
    {
        [Test]
        public void DifferentIntegers()
        {
            Raise<ArgumentNullException>.IfAreEqual(5, 50);
        }

        [Test]
        public void DifferentIntegers_WithMsg()
        {
            Raise<ArgumentNullException>.IfAreEqual(5, 50, TestMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Not_DifferentIntegers()
        {
            Raise<ArgumentException>.IfAreNotEqual(5, 50);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = TestMessage)]
        public void Not_DifferentIntegers_WithMsg()
        {
            Raise<ArgumentException>.IfAreNotEqual(5, 50, TestMessage);
        }

        [Test]
        public void Not_SameIntegers()
        {
            Raise<ArgumentException>.IfAreNotEqual(5, 5);
        }

        [Test]
        public void Not_SameIntegers_WithMsg()
        {
            Raise<ArgumentException>.IfAreNotEqual(5, 5, TestMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SameIntegers()
        {
            Raise<ArgumentNullException>.IfAreEqual(5, 5);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException), ExpectedMessage = TestMessage)]
        public void SameIntegers_WithMsg()
        {
            Raise<ArgumentNullException>.IfAreEqual(5, 5, TestMessage);
        }
    }
}