// File name: IfIsNullTests.cs
// 
// Author(s): Alessio Parma <alessio.parma@gmail.com>
// 
// Copyright (c) 2013-2014 Alessio Parma <alessio.parma@gmail.com>
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

using System;
using NUnit.Framework;

namespace PommaLabs.Thrower.UnitTests
{
    sealed class IfIsNullTests : AbstractDiagnosticsTests
    {
        [Test]
        public void NotNullArgument()
        {
            Raise<ArgumentNullException>.IfIsNull("PINO");
        }

        [Test]
        public void NotNullArgument_WithMsg()
        {
            Raise<ArgumentNullException>.IfIsNull("PINO");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Not_NotNullArgument()
        {
            Raise<ArgumentNullException>.IfIsNotNull("PINO");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException), ExpectedMessage = TestMessage)]
        public void Not_NotNullArgument_WithMsg()
        {
            Raise<ArgumentNullException>.IfIsNotNull("PINO", TestMessage);
        }

        [Test]
        public void Not_NullArgument()
        {
            Raise<ArgumentNullException>.IfIsNotNull((object)null);
        }

        [Test]
        public void Not_NullArgument_WithMsg()
        {
            Raise<ArgumentNullException>.IfIsNotNull((object)null, TestMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullArgument()
        {
            Raise<ArgumentNullException>.IfIsNull((object)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException), ExpectedMessage = TestMessage)]
        public void NullArgument_WithMsg()
        {
            Raise<ArgumentNullException>.IfIsNull((object)null, TestMessage);
        }

        [Test]
        public void NotNullArgument_UsingDefaultRaise()
        {
            RaiseArgumentNullException.IfIsNull("PINO");
        }

        [Test]
        public void NotNullArgument_WithMsg_UsingDefaultRaise()
        {
            RaiseArgumentNullException.IfIsNull("PINO");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullArgument_UsingDefaultRaise()
        {
            RaiseArgumentNullException.IfIsNull((object) null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException), ExpectedMessage = TestMessage, MatchType = MessageMatch.StartsWith)]
        public void NullArgument_WithMsg_UsingDefaultRaise()
        {
            RaiseArgumentNullException.IfIsNull((object) null, "null", TestMessage);
        }
    }
}