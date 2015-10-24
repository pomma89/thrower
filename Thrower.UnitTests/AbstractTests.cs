// File name: AbstractTests.cs
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

namespace PommaLabs.Thrower.UnitTests
{
    [TestFixture]
    abstract class AbstractTests
    {
        #region Setup/Teardown

        [SetUp]
        public virtual void SetUp()
        {
            Assert.False(string.IsNullOrEmpty(RaiseBase.UseThrowerDefine));
            Assert.AreEqual(RaiseBase.UseThrowerDefine, RaiseBase.UseThrowerDefine);
        }

        [TearDown]
        public virtual void TearDown()
        {
        }

        #endregion Setup/Teardown

        protected const string TestMessage = "A long and complicated error message...";

        protected class Base { }

        protected class Derived : Base { }

        protected class Convertible
        {
            public static implicit operator Base(Convertible c)
            {
                return new Base();
            }
        }
    }
}
