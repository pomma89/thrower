// File name: RaiseTests.cs
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
using System.Globalization;
using System.Threading.Tasks;

namespace PommaLabs.Thrower.UnitTests
{
    internal sealed class RaiseTests : AbstractTests
    {
        private static void ThreadTest()
        {
            for (var i = 0; i < 10000; ++i)
            {
                var msg = i.ToString(CultureInfo.InvariantCulture);
                try
                {
                    Raise<ArgumentException>.IfNot(false, msg);
                }
                catch (ArgumentException ex)
                {
                    Assert.AreEqual(msg, ex.Message);
                }
            }
        }

        private static void WrongThreadTest()
        {
            for (var i = 0; i < 10000; ++i)
            {
                var msg = i.ToString(CultureInfo.InvariantCulture);
                try
                {
                    Raise<NoCtorException>.If(true, msg);
                }
                catch (ThrowerException ex)
                {
                    Assert.AreNotEqual(msg, ex.Message);
                }
            }
        }

        private abstract class AbstractException : Exception
        {
            protected AbstractException()
            {
            }

            protected AbstractException(string msg) : base(msg)
            {
            }
        }

        private sealed class InternalCtorException : Exception
        {
            internal InternalCtorException()
            {
            }

            internal InternalCtorException(string msg) : base(msg)
            {
            }
        }

        private sealed class NoCtorException : Exception
        {
            public NoCtorException(int x) : base(x.ToString())
            {
            }
        }

        private sealed class PrivateCtorException : Exception
        {
            private PrivateCtorException()
            {
            }

            private PrivateCtorException(string msg) : base(msg)
            {
            }
        }

        [Test]
        [ExpectedException(typeof(ThrowerException))]
        public void AbstractException1()
        {
            Raise<AbstractException>.If(true);
        }

        [Test]
        [ExpectedException(typeof(ThrowerException))]
        public void AbstractException1_Not()
        {
            Raise<AbstractException>.IfNot(false);
        }

        [Test]
        [ExpectedException(typeof(ThrowerException))]
        public void AbstractException2()
        {
            Raise<AbstractException>.If(true, "msg");
        }

        [Test]
        [ExpectedException(typeof(ThrowerException))]
        public void AbstractException2_Not()
        {
            Raise<AbstractException>.IfNot(false, "msg");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ArgumentException()
        {
            Raise<ArgumentException>.If(true);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ArgumentException_Not()
        {
            Raise<ArgumentException>.IfNot(false);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ArgumentException_WithMsg()
        {
            try
            {
                Raise<ArgumentException>.If(true, "Pino");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Pino", ex.Message);
                throw;
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ArgumentException_WithMsg_Not()
        {
            try
            {
                Raise<ArgumentException>.IfNot(false, "Pino");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Pino", ex.Message);
                throw;
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullException()
        {
            Raise<ArgumentNullException>.If(true);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullException_Not()
        {
            Raise<ArgumentNullException>.IfNot(false);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullException_WithMsg()
        {
            try
            {
                Raise<ArgumentNullException>.If(true, "Pino");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Pino", ex.Message);
                throw;
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullException_WithMsg_Not()
        {
            try
            {
                Raise<ArgumentNullException>.IfNot(false, "Pino");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Pino", ex.Message);
                throw;
            }
        }

        [Test]
        [ExpectedException(typeof(InternalCtorException))]
        public void ExceptionInternalConstructor1()
        {
            Raise<InternalCtorException>.If(true);
        }

        [Test]
        [ExpectedException(typeof(InternalCtorException))]
        public void ExceptionInternalConstructor1_Not()
        {
            Raise<InternalCtorException>.IfNot(false);
        }

        [Test]
        [ExpectedException(typeof(InternalCtorException))]
        public void ExceptionInternalConstructor2()
        {
            Raise<InternalCtorException>.If(true, "msg");
        }

        [Test]
        [ExpectedException(typeof(InternalCtorException))]
        public void ExceptionInternalConstructor2_Not()
        {
            Raise<InternalCtorException>.IfNot(false, "msg");
        }

        [Test]
        public void ExceptionInternalConstructor3()
        {
            try
            {
                Raise<ThrowerException>.If(true, "A RANDOM MSG");
            }
            catch (ThrowerException ex)
            {
                Assert.AreNotEqual("A RANDOM MSG", ex.Message);
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void ExceptionInternalConstructor3_Not()
        {
            try
            {
                Raise<ThrowerException>.IfNot(false, "A RANDOM MSG");
            }
            catch (ThrowerException ex)
            {
                Assert.AreNotEqual("A RANDOM MSG", ex.Message);
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        [ExpectedException(typeof(ThrowerException))]
        public void ExceptionPrivateConstructor1()
        {
            Raise<PrivateCtorException>.If(true);
        }

        [Test]
        [ExpectedException(typeof(ThrowerException))]
        public void ExceptionPrivateConstructor1_Not()
        {
            Raise<PrivateCtorException>.IfNot(false);
        }

        [Test]
        [ExpectedException(typeof(ThrowerException))]
        public void ExceptionPrivateConstructor2()
        {
            Raise<PrivateCtorException>.If(true, "msg");
        }

        [Test]
        [ExpectedException(typeof(ThrowerException))]
        public void ExceptionPrivateConstructor2_Not()
        {
            Raise<PrivateCtorException>.IfNot(false, "msg");
        }

        [Test]
        [ExpectedException(typeof(ThrowerException))]
        public void ExceptionPrivateConstructor3()
        {
            try
            {
                Raise<PrivateCtorException>.If(true, "msg");
            }
            catch (ThrowerException)
            {
                Raise<PrivateCtorException>.If(true, "msg");
            }
            Assert.Fail();
        }

        [Test]
        [ExpectedException(typeof(ThrowerException))]
        public void ExceptionPrivateConstructor3_Not()
        {
            try
            {
                Raise<PrivateCtorException>.IfNot(false, "msg");
            }
            catch (ThrowerException)
            {
                Raise<PrivateCtorException>.IfNot(false, "msg");
            }
            Assert.Fail();
        }

        [Test]
        [ExpectedException(typeof(ThrowerException))]
        public void ExceptionWithoutConstructor1()
        {
            Raise<NoCtorException>.If(true);
        }

        [Test]
        [ExpectedException(typeof(ThrowerException))]
        public void ExceptionWithoutConstructor1_Not()
        {
            Raise<NoCtorException>.IfNot(false);
        }

        [Test]
        [ExpectedException(typeof(ThrowerException))]
        public void ExceptionWithoutConstructor2()
        {
            Raise<NoCtorException>.If(true, "msg");
        }

        [Test]
        [ExpectedException(typeof(ThrowerException))]
        public void ExceptionWithoutConstructor2_Not()
        {
            Raise<NoCtorException>.IfNot(false, "msg");
        }

        [Test]
        public void FalseCond()
        {
            Raise<Exception>.If(false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InvalidOperationException()
        {
            Raise<InvalidOperationException>.If(true);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InvalidOperationException_Not()
        {
            Raise<InvalidOperationException>.IfNot(false);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InvalidOperationException_WithMsg()
        {
            try
            {
                Raise<InvalidOperationException>.If(true, "Pino");
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Pino", ex.Message);
                throw;
            }
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InvalidOperationException_WithMsg_Not()
        {
            try
            {
                Raise<InvalidOperationException>.IfNot(false, "Pino");
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Pino", ex.Message);
                throw;
            }
        }

        [Test]
        public void ThreadedUsage1()
        {
            var tasks = new Task[10];
            for (var i = 0; i < tasks.Length; ++i)
            {
                tasks[i] = Task.Factory.StartNew(ThreadTest);
            }
            for (var i = 0; i < tasks.Length; ++i)
            {
                tasks[i].Wait();
            }
        }

        [Test]
        public void ThreadedUsage2()
        {
            var tasks = new Task[10];
            for (var i = 0; i < tasks.Length; ++i)
            {
                tasks[i] = (i % 2 == 0) ? Task.Factory.StartNew(ThreadTest) : Task.Factory.StartNew(WrongThreadTest);
            }
            for (var i = 0; i < tasks.Length; ++i)
            {
                tasks[i].Wait();
            }
        }

        [Test]
        public void TrueCond()
        {
            Raise<Exception>.IfNot(true);
        }
    }
}