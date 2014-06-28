//
// IfIsNaNTests.cs
//
// Author(s):
//       Alessio Parma <alessio.parma@gmail.com>
//
// Copyright (c) 2013-2014 Alessio Parma <alessio.parma@gmail.com>
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

    public sealed class IfIsNaNTests : TestBase
    {
        [Test]
        public void CorrectDouble()
        {
            Raise<ArgumentOutOfRangeException>.IfIsNaN(5.0);
        }

        [Test]
        public void CorrectDouble_WithMsg()
        {
            Raise<ArgumentOutOfRangeException>.IfIsNaN(5.0, TestMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NaN()
        {
            Raise<ArgumentOutOfRangeException>.IfIsNaN(double.NaN);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException), ExpectedMessage = TestMessage)]
        public void NaN_WithMsg()
        {
            Raise<ArgumentOutOfRangeException>.IfIsNaN(double.NaN, TestMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Not_CorrectDouble()
        {
            Raise<ArgumentOutOfRangeException>.IfIsNotNaN(5.0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException), ExpectedMessage = TestMessage)]
        public void Not_CorrectDouble_WithMsg()
        {
            Raise<ArgumentOutOfRangeException>.IfIsNotNaN(5.0, TestMessage);
        }

        [Test]
        public void Not_NaN()
        {
            Raise<ArgumentOutOfRangeException>.IfIsNotNaN(double.NaN);
        }

        [Test]
        public void Not_NaN_WithMsg()
        {
            Raise<ArgumentOutOfRangeException>.IfIsNotNaN(double.NaN, TestMessage);
        }
    }
}