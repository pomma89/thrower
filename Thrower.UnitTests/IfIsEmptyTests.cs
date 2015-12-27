// File name: IfIsEmptyTests.cs
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
using System.Collections;
using System.Collections.Generic;

namespace PommaLabs.Thrower.UnitTests
{
    internal sealed class IfIsEmptyTests : AbstractTests
    {
        private const string BlankString = "   ";

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void IfIsEmpty_BlankString()
        {
            Raise<FormatException>.IfIsEmpty(BlankString);
        }

        [Test]
        [ExpectedException(typeof(FormatException), ExpectedMessage = TestMessage)]
        public void IfIsEmpty_BlankString_WithMsg()
        {
            Raise<FormatException>.IfIsEmpty(BlankString, TestMessage);
        }

        [Test]
        public void IfIsNullOrEmpty_BlankString()
        {
            RaiseArgumentException.IfIsNullOrEmpty(BlankString);
        }

        [Test]
        public void IfIsNullOrEmpty_BlankString_WithMsg()
        {
            RaiseArgumentException.IfIsNullOrEmpty(BlankString, nameof(TestMessage), TestMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IfIsNullOrWhiteSpace_BlankString()
        {
            RaiseArgumentException.IfIsNullOrWhiteSpace(BlankString);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = TestMessage)]
        public void IfIsNullOrWhiteSpace_BlankString_WithMsg()
        {
            RaiseArgumentException.IfIsNullOrWhiteSpace(BlankString, nameof(TestMessage), TestMessage);
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void IfIsEmpty_EmptyIntegerCollection()
        {
            Raise<FormatException>.IfIsEmpty<int>(new List<int>());
        }

        [Test]
        [ExpectedException(typeof(FormatException), ExpectedMessage = TestMessage)]
        public void IfIsEmpty_EmptyIntegerCollection_WithMsg()
        {
            Raise<FormatException>.IfIsEmpty<int>(new List<int>(), TestMessage);
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void IfIsEmpty_EmptyString()
        {
            Raise<FormatException>.IfIsEmpty(string.Empty);
        }

        [Test]
        [ExpectedException(typeof(FormatException), ExpectedMessage = TestMessage)]
        public void IfIsEmpty_EmptyString_WithMsg()
        {
            Raise<FormatException>.IfIsEmpty(string.Empty, TestMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IfIsNullOrEmpty_EmptyString()
        {
            RaiseArgumentException.IfIsNullOrEmpty(string.Empty);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = TestMessage)]
        public void IfIsNullOrEmpty_EmptyString_WithMsg()
        {
            RaiseArgumentException.IfIsNullOrEmpty(string.Empty, nameof(TestMessage), TestMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IfIsNullOrWhiteSpace_EmptyString()
        {
            RaiseArgumentException.IfIsNullOrWhiteSpace(string.Empty);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = TestMessage)]
        public void IfIsNullOrWhiteSpace_EmptyString_WithMsg()
        {
            RaiseArgumentException.IfIsNullOrWhiteSpace(string.Empty, nameof(TestMessage), TestMessage);
        }

        [Test]
        public void IfIsEmpty_FullIntegerCollection()
        {
            Raise<FormatException>.IfIsEmpty<int>(new List<int> { 1, 2, 3 });
        }

        [Test]
        public void IfIsEmpty_FullIntegerCollection_WithMsg()
        {
            Raise<FormatException>.IfIsEmpty<int>(new List<int> { 1, 2, 3 }, TestMessage);
        }

        [Test]
        public void IfIsEmpty_FullString()
        {
            Raise<FormatException>.IfIsEmpty("PINO");
        }

        [Test]
        public void IfIsEmpty_FullString_WithMsg()
        {
            Raise<FormatException>.IfIsEmpty("PINO", TestMessage);
        }

        [Test]
        public void IfIsNullOrEmpty_FullString()
        {
            RaiseArgumentException.IfIsNullOrEmpty("PINO");
        }

        [Test]
        public void IfIsNullOrEmpty_FullString_WithMsg()
        {
            RaiseArgumentException.IfIsNullOrEmpty("PINO", nameof(TestMessage), TestMessage);
        }

        [Test]
        public void IfIsNullOrWhiteSpace_FullString()
        {
            RaiseArgumentException.IfIsNullOrWhiteSpace("PINO");
        }

        [Test]
        public void IfIsNullOrWhiteSpace_FullString_WithMsg()
        {
            RaiseArgumentException.IfIsNullOrWhiteSpace("PINO", nameof(TestMessage), TestMessage);
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void IfIsEmpty_ICollection_EmptyIntegerCollection()
        {
            Raise<FormatException>.IfIsEmpty((ICollection) new List<int>());
        }

        [Test]
        [ExpectedException(typeof(FormatException), ExpectedMessage = TestMessage)]
        public void IfIsEmpty_ICollection_EmptyIntegerCollection_WithMsg()
        {
            Raise<FormatException>.IfIsEmpty((ICollection) new List<int>(), TestMessage);
        }

        [Test]
        public void IfIsEmpty_ICollection_FullIntegerCollection()
        {
            Raise<FormatException>.IfIsEmpty((ICollection) new List<int> { 1, 2, 3 });
        }

        [Test]
        public void IfIsEmpty_ICollection_FullIntegerCollection_WithMsg()
        {
            Raise<FormatException>.IfIsEmpty((ICollection) new List<int> { 1, 2, 3 }, TestMessage);
        }

        [Test]
        public void IfIsNotEmpty_BlankString()
        {
            Raise<FormatException>.IfIsNotEmpty(BlankString);
        }

        [Test]
        public void IfIsNotEmpty_BlankString_WithMsg()
        {
            Raise<FormatException>.IfIsNotEmpty(BlankString, TestMessage);
        }

        [Test]
        public void IfIsNotEmpty_EmptyIntegerCollection()
        {
            Raise<FormatException>.IfIsNotEmpty<int>(new List<int>());
        }

        [Test]
        public void IfIsNotEmpty_EmptyIntegerCollection_WithMsg()
        {
            Raise<FormatException>.IfIsNotEmpty<int>(new List<int>(), TestMessage);
        }

        [Test]
        public void IfIsNotEmpty_EmptyString()
        {
            Raise<FormatException>.IfIsNotEmpty(string.Empty);
        }

        [Test]
        public void IfIsNotEmpty_EmptyString_WithMsg()
        {
            Raise<FormatException>.IfIsNotEmpty(string.Empty, TestMessage);
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void IfIsNotEmpty_FullIntegerCollection()
        {
            Raise<FormatException>.IfIsNotEmpty<int>(new List<int> { 1, 2, 3 });
        }

        [Test]
        [ExpectedException(typeof(FormatException), ExpectedMessage = TestMessage)]
        public void IfIsNotEmpty_FullIntegerCollection_WithMsg()
        {
            Raise<FormatException>.IfIsNotEmpty<int>(new List<int> { 1, 2, 3 }, TestMessage);
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void IfIsNotEmpty_FullString()
        {
            Raise<FormatException>.IfIsNotEmpty("PINO");
        }

        [Test]
        [ExpectedException(typeof(FormatException), ExpectedMessage = TestMessage)]
        public void IfIsNotEmpty_FullString_WithMsg()
        {
            Raise<FormatException>.IfIsNotEmpty("PINO", TestMessage);
        }

        [Test]
        public void IfIsNotEmpty_ICollection_EmptyIntegerCollection()
        {
            Raise<FormatException>.IfIsNotEmpty((ICollection) new List<int>());
        }

        [Test]
        public void IfIsNotEmpty_ICollection_EmptyIntegerCollection_WithMsg()
        {
            Raise<FormatException>.IfIsNotEmpty((ICollection) new List<int>(), TestMessage);
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void IfIsNotEmpty_ICollection_FullIntegerCollection()
        {
            Raise<FormatException>.IfIsNotEmpty((ICollection) new List<int> { 1, 2, 3 });
        }

        [Test]
        [ExpectedException(typeof(FormatException), ExpectedMessage = TestMessage)]
        public void IfIsNotEmpty_ICollection_FullIntegerCollection_WithMsg()
        {
            Raise<FormatException>.IfIsNotEmpty((ICollection) new List<int> { 1, 2, 3 }, TestMessage);
        }
    }
}