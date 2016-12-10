// File name: ArgumentNullExceptionTests.cs
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

namespace PommaLabs.Thrower.UnitTests.ExceptionHandlers
{
    internal sealed class ArgumentNullExceptionTests : AbstractTests
    {
        [Test]
        public void NotNullArgument_String()
        {
            Raise.ArgumentNullException.IfIsNull("PINO");
        }

        [Test]
        public void NotNullArgument_String_WithMsg()
        {
            Raise.ArgumentNullException.IfIsNull("PINO", "PINO", "GINO");
        }

        [Test]
        public void NotNullArgument_Struct()
        {
            Raise.ArgumentNullException.IfIsNull(37M);
        }

        [Test]
        public void NotNullArgument_Struct_WithArgName()
        {
            Raise.ArgumentNullException.IfIsNull(37M, "DECIMAL");
        }

        [Test]
        public void NotNullArgument_Struct_WithMsg()
        {
            Raise.ArgumentNullException.IfIsNull(37M, "DECIMAL", "GINO");
        }

        [Test]
        public void NotNullArgument_BoxedStruct()
        {
            object box = 37M;
            Raise.ArgumentNullException.IfIsNull(box);
        }

        [Test]
        public void NotNullArgument_BoxedStruct_WithMsg()
        {
            object box = 37M;
            Raise.ArgumentNullException.IfIsNull(box, "DECIMAL", "GINO");
        }

        [Test]
        public void NotNullArgument_NullableInt_WithoutValue()
        {
            Raise.ArgumentNullException.IfIsNull(new int?(21));
        }

        [Test]
        public void NotNullArgument_NullableInt_WithoutValue_WithArgName()
        {
            Raise.ArgumentNullException.IfIsNull(new int?(21), "null");
        }

        [Test]
        public void NotNullArgument_NullableInt_WithoutValue_WithMsg()
        {
            Raise.ArgumentNullException.IfIsNull(new int?(21), "null", TestMessage);
        }

        [Test]
        public void NotNullArgument_NullableInt_WithoutValue_ByRef()
        {
            var x = new int?(21);
            Raise.ArgumentNullException.IfIsNull(ref x, nameof(x));
        }

        [Test]
        public void NotNullArgument_NullableInt_WithoutValue_WithArgName_ByRef()
        {
            var x = new int?(21);
            Raise.ArgumentNullException.IfIsNull(ref x, nameof(x));
        }

        [Test]
        public void NotNullArgument_NullableInt_WithoutValue_WithMsg_ByRef()
        {
            var x = new int?(21);
            Raise.ArgumentNullException.IfIsNull(ref x, nameof(x), TestMessage);
        }

        [Test]
        public void NotNullArgument_BoxedNullableInt_WithValue()
        {
            object box = new int?(21);
            Raise.ArgumentNullException.IfIsNull(box);
        }

        [Test]
        public void NotNullArgument_BoxedNullableInt_WithValue_WithArgName()
        {
            object box = new int?(21);
            Raise.ArgumentNullException.IfIsNull(box, "null");
        }

        [Test]
        public void NotNullArgument_BoxedNullableInt_WithValue_WithMsg()
        {
            object box = new int?(21);
            Raise.ArgumentNullException.IfIsNull(box, "null", TestMessage);
        }

        [Test]
        public void NullArgument_NullObject()
        {
            Should.Throw<ArgumentNullException>(() => Raise.ArgumentNullException.IfIsNull((object) null));
        }

        [Test]
        public void NullArgument_NullObject_WithMsg()
        {
            Should.Throw<ArgumentNullException>(() => Raise.ArgumentNullException.IfIsNull((object) null, "null", TestMessage));
        }

        [Test]
        public void NullArgument_NullableInt_WithoutValue()
        {
            Should.Throw<ArgumentNullException>(() => Raise.ArgumentNullException.IfIsNull(new int?()));
        }

        [Test]
        public void NullArgument_NullableInt_WithoutValue_WithArgName()
        {
            Should.Throw<ArgumentNullException>(() => Raise.ArgumentNullException.IfIsNull(new int?(), "null"));
        }

        [Test]
        public void NullArgument_NullableInt_WithoutValue_WithMsg()
        {
            Should.Throw<ArgumentNullException>(() => Raise.ArgumentNullException.IfIsNull(new int?(), "null", TestMessage));
        }

        [Test]
        public void NullArgument_NullableInt_WithoutValue_ByRef()
        {
            var x = new int?();
            Should.Throw<ArgumentNullException>(() => Raise.ArgumentNullException.IfIsNull(ref x, nameof(x)));
        }

        [Test]
        public void NullArgument_NullableInt_WithoutValue_WithArgName_ByRef()
        {
            var x = new int?();
            Should.Throw<ArgumentNullException>(() => Raise.ArgumentNullException.IfIsNull(ref x, nameof(x)));
        }

        [Test]
        public void NullArgument_NullableInt_WithoutValue_WithMsg_ByRef()
        {
            var x = new int?();
            Should.Throw<ArgumentNullException>(() => Raise.ArgumentNullException.IfIsNull(ref x, nameof(x), TestMessage));
        }

        [Test]
        public void NullArgument_BoxedNullableInt_WithoutValue()
        {
            object box = new int?();
            Should.Throw<ArgumentNullException>(() => Raise.ArgumentNullException.IfIsNull(box));
        }

        [Test]
        public void NullArgument_BoxedNullableInt_WithoutValue_WithArgName()
        {
            object box = new int?();
            Should.Throw<ArgumentNullException>(() => Raise.ArgumentNullException.IfIsNull(box, "null"));
        }

        [Test]
        public void NullArgument_BoxedNullableInt_WithoutValue_WithMsg()
        {
            object box = new int?();
            Should.Throw<ArgumentNullException>(() => Raise.ArgumentNullException.IfIsNull(box, "null", TestMessage));
        }
    }
}