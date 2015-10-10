// File name: RaiseNotSupportedExceptionTests.cs
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
    sealed class RaiseNotSupportedExceptionTests : AbstractTests
    {
        [Test, ExpectedException(typeof(NotSupportedException))]
        public void If_TrueShouldThrow()
        {
            RaiseNotSupportedException.If(true);
        }

        [Test, ExpectedException(typeof(NotSupportedException), ExpectedMessage = TestMessage)]
        public void If_TrueShouldThrow_WithMessage()
        {
            RaiseNotSupportedException.If(true, TestMessage);
        }

        [Test]
        public void If_FalseShouldNotThrow()
        {
            RaiseNotSupportedException.If(false);
        }

        [Test]
        public void If_FalseShouldNotThrow_WithMessage()
        {
            RaiseNotSupportedException.If(false, TestMessage);
        }

        [Test, ExpectedException(typeof(NotSupportedException))]
        public void IfNot_FalseShouldThrow()
        {
            RaiseNotSupportedException.IfNot(false);
        }

        [Test, ExpectedException(typeof(NotSupportedException), ExpectedMessage = TestMessage)]
        public void IfNot_FalseShouldThrow_WithMessage()
        {
            RaiseNotSupportedException.IfNot(false, TestMessage);
        }

        [Test]
        public void IfNot_TrueShouldNotThrow()
        {
            RaiseNotSupportedException.IfNot(true);
        }

        [Test]
        public void IfNot_TrueShouldNotThrow_WithMessage()
        {
            RaiseNotSupportedException.IfNot(true, TestMessage);
        }
    }
}
