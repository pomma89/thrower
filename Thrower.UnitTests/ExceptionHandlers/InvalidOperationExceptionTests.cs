// File name: InvalidOperationExceptionTests.cs
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

using NUnit.Framework;
using System;

namespace PommaLabs.Thrower.UnitTests.ExceptionHandlers
{
    internal sealed class InvalidOperationExceptionTests : AbstractTests
    {
        [Test, ExpectedException(typeof(InvalidOperationException))]
        public void If_TrueShouldThrow()
        {
            Raise.InvalidOperationException.If(true);
        }

        [Test, ExpectedException(typeof(InvalidOperationException), ExpectedMessage = TestMessage)]
        public void If_TrueShouldThrow_WithMessage()
        {
            Raise.InvalidOperationException.If(true, TestMessage);
        }

        [Test]
        public void If_FalseShouldNotThrow()
        {
            Raise.InvalidOperationException.If(false);
        }

        [Test]
        public void If_FalseShouldNotThrow_WithMessage()
        {
            Raise.InvalidOperationException.If(false, TestMessage);
        }

        [Test, ExpectedException(typeof(InvalidOperationException))]
        public void IfNot_FalseShouldThrow()
        {
            Raise.InvalidOperationException.IfNot(false);
        }

        [Test, ExpectedException(typeof(InvalidOperationException), ExpectedMessage = TestMessage)]
        public void IfNot_FalseShouldThrow_WithMessage()
        {
            Raise.InvalidOperationException.IfNot(false, TestMessage);
        }

        [Test]
        public void IfNot_TrueShouldNotThrow()
        {
            Raise.InvalidOperationException.IfNot(true);
        }

        [Test]
        public void IfNot_TrueShouldNotThrow_WithMessage()
        {
            Raise.InvalidOperationException.IfNot(true, TestMessage);
        }
    }
}