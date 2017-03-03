// File name: FormattableObjectTests.cs
//
// Author(s): Alessio Parma <alessio.parma@gmail.com>
//
// The MIT License (MIT)
//
// Copyright (c) 2013-2018 Alessio Parma <alessio.parma@gmail.com>
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
using PommaLabs.Thrower.Goodies;
using Shouldly;
using System;
using System.Collections.Generic;

namespace PommaLabs.Thrower.UnitTests.Goodies
{
    internal sealed class FormattableObjectTests : AbstractTests
    {
        [Test]
        public void IntegerPropertyShouldProduceToStringWithoutSquareBrackets()
        {
            (new ClassWithInteger() { X = 7 }).ToString().ShouldBe("X: 7");
        }

        [Test]
        public void StringPropertyShouldProduceToStringWithoutSquareBrackets()
        {
            (new ClassWithString() { X = "Pu <3 Pi" }).ToString().ShouldBe("X: \"Pu <3 Pi\"");
        }

        [Test]
        public void NullStringPropertyShouldProduceToStringWithoutSquareBrackets()
        {
            (new ClassWithString() { X = null }).ToString().ShouldBe("X: null");
        }

        private sealed class ClassWithInteger : FormattableObject
        {
            public int X { get; set; }

            protected override IEnumerable<KeyValuePair<string, string>> GetFormattingMembers()
            {
                yield return new KeyValuePair<string, string>(nameof(X), X.ToString());
            }
        }

        private sealed class ClassWithString : FormattableObject
        {
            public string X { get; set; }

            protected override IEnumerable<KeyValuePair<string, string>> GetFormattingMembers()
            {
                yield return new KeyValuePair<string, string>(nameof(X), X);
            }
        }
    }
}