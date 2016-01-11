// File name: ObjectAccessorTests.cs
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

#if !PORTABLE

using NUnit.Framework;
using PommaLabs.Thrower.Reflection.FastMember;
using System.Collections.Generic;

namespace PommaLabs.Thrower.UnitTests.Reflection.FastMember
{
    internal sealed class ObjectAccessorTests : AbstractTests
    {
        [Test]
        public void Create_AsIDictionary()
        {
            var myStruct = new MyStruct
            {
                A = 21,
                B = "Pu <3 Pi",
                C = 3.14M
            };

            var dict = ObjectAccessor.Create(myStruct) as IDictionary<string, object>;

            Assert.AreEqual(3, dict.Count);
            Assert.IsTrue(dict.Keys.Contains(nameof(MyStruct.A)) && dict.Keys.Contains(nameof(MyStruct.B)) && dict.Keys.Contains(nameof(MyStruct.C)));
            Assert.AreEqual(myStruct.A, dict[nameof(MyStruct.A)]);
            Assert.AreEqual(myStruct.B, dict[nameof(MyStruct.B)]);
            Assert.AreEqual(myStruct.C, dict[nameof(MyStruct.C)]);
        }

        public struct MyStruct
        {
            public int A { get; set; }
            public string B { get; set; }
            public decimal C { get; set; }
            private bool P { get; set; }
        }
    }
}

#endif