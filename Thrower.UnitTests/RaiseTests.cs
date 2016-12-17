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
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT
// OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

        private sealed class BigCtorException : Exception
        {
            public BigCtorException(int x, decimal y, string z, KeyValuePair<string, string> t) : base(x.ToString())
            {
                X = x;
                Y = y;
                Z = z;
                T = t;
            }

            public int X { get; }

            public decimal Y { get; }

            public string Z { get; }

            public KeyValuePair<string, string> T { get; }
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
        public void AbstractException1()
        {
            Should.Throw<ThrowerException>(() => Raise<AbstractException>.If(true));
        }

        [Test]
        public void AbstractException1_Not()
        {
            Should.Throw<ThrowerException>(() => Raise<AbstractException>.IfNot(false));
        }

        [Test]
        public void AbstractException2()
        {
            Should.Throw<ThrowerException>(() => Raise<AbstractException>.If(true, "msg"));
        }

        [Test]
        public void AbstractException2_Not()
        {
            Should.Throw<ThrowerException>(() => Raise<AbstractException>.IfNot(false, "msg"));
        }

        [Test]
        public void ArgumentException()
        {
            Should.Throw<ArgumentException>(() => Raise<ArgumentException>.If(true));
        }

        [Test]
        public void ArgumentException_Not()
        {
            Should.Throw<ArgumentException>(() => Raise<ArgumentException>.IfNot(false));
        }

        [Test]
        public void ArgumentException_WithMsg()
        {
            try
            {
                Raise<ArgumentException>.If(true, "Pino");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Pino", ex.Message);
                Assert.Pass();
            }
        }

        [Test]
        public void ArgumentException_WithMsg_Not()
        {
            try
            {
                Raise<ArgumentException>.IfNot(false, "Pino");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Pino", ex.Message);
                Assert.Pass();
            }
        }

        [Test]
        public void ArgumentNullException()
        {
            Should.Throw<ArgumentNullException>(() => Raise<ArgumentNullException>.If(true));
        }

        [Test]
        public void ArgumentNullException_Not()
        {
            Should.Throw<ArgumentNullException>(() => Raise<ArgumentNullException>.IfNot(false));
        }

        [Test]
        public void ArgumentNullException_WithMsg()
        {
            try
            {
                Raise<ArgumentNullException>.If(true, "Pino");
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Pino", ex.Message);
                Assert.Pass();
            }
        }

        [Test]
        public void ArgumentNullException_WithMsg_Not()
        {
            try
            {
                Raise<ArgumentNullException>.IfNot(false, "Pino");
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Pino", ex.Message);
                Assert.Pass();
            }
        }

        [Test]
        public void ExceptionInternalConstructor1()
        {
            Should.Throw<InternalCtorException>(() => Raise<InternalCtorException>.If(true));
        }

        [Test]
        public void ExceptionInternalConstructor1_Not()
        {
            Should.Throw<InternalCtorException>(() => Raise<InternalCtorException>.IfNot(false));
        }

        [Test]
        public void ExceptionInternalConstructor2()
        {
            Should.Throw<InternalCtorException>(() => Raise<InternalCtorException>.If(true, "msg"));
        }

        [Test]
        public void ExceptionInternalConstructor2_Not()
        {
            Should.Throw<InternalCtorException>(() => Raise<InternalCtorException>.IfNot(false, "msg"));
        }

        [Test]
        public void ExceptionInternalConstructor3()
        {
            try
            {
                Raise<ThrowerException>.If(true, "A RANDOM MSG");
                Assert.Fail();
            }
            catch (ThrowerException ex)
            {
                Assert.AreNotEqual("A RANDOM MSG", ex.Message);
                Assert.Pass();
            }
        }

        [Test]
        public void ExceptionInternalConstructor3_Not()
        {
            try
            {
                Raise<ThrowerException>.IfNot(false, "A RANDOM MSG");
                Assert.Fail();
            }
            catch (ThrowerException ex)
            {
                Assert.AreNotEqual("A RANDOM MSG", ex.Message);
                Assert.Pass();
            }
        }

        [Test]
        public void ExceptionPrivateConstructor1()
        {
            Should.Throw<ThrowerException>(() => Raise<PrivateCtorException>.If(true));
        }

        [Test]
        public void ExceptionPrivateConstructor1_Not()
        {
            Should.Throw<ThrowerException>(() => Raise<PrivateCtorException>.IfNot(false));
        }

        [Test]
        public void ExceptionPrivateConstructor2()
        {
            Should.Throw<ThrowerException>(() => Raise<PrivateCtorException>.If(true, "msg"));
        }

        [Test]
        public void ExceptionPrivateConstructor2_Not()
        {
            Should.Throw<ThrowerException>(() => Raise<PrivateCtorException>.IfNot(false, "msg"));
        }

        [Test]
        public void ExceptionPrivateConstructor3()
        {
            try
            {
                Raise<PrivateCtorException>.If(true, "msg");
                Assert.Fail();
            }
            catch (ThrowerException)
            {
                Should.Throw<ThrowerException>(() => Raise<PrivateCtorException>.If(true, "msg"));
            }
        }

        [Test]
        public void ExceptionPrivateConstructor3_Not()
        {
            try
            {
                Raise<PrivateCtorException>.IfNot(false, "msg");
            }
            catch (ThrowerException)
            {
                Should.Throw<ThrowerException>(() => Raise<PrivateCtorException>.IfNot(false, "msg"));
            }
        }

        [Test]
        public void ExceptionWithoutConstructor1()
        {
            Should.Throw<ThrowerException>(() => Raise<NoCtorException>.If(true));
        }

        [Test]
        public void ExceptionWithoutConstructor1_Not()
        {
            Should.Throw<ThrowerException>(() => Raise<NoCtorException>.IfNot(false));
        }

        [Test]
        public void ExceptionWithoutConstructor2()
        {
            Should.Throw<ThrowerException>(() => Raise<NoCtorException>.If(true, "msg"));
        }

        [Test]
        public void ExceptionWithoutConstructor2_Not()
        {
            Should.Throw<ThrowerException>(() => Raise<NoCtorException>.IfNot(false, "msg"));
        }

        [Test]
        public void FalseCond()
        {
            Raise<Exception>.If(false);
        }

        [Test]
        public void InvalidOperationException()
        {
            Should.Throw<InvalidOperationException>(() => Raise<InvalidOperationException>.If(true));
        }

        [Test]
        public void InvalidOperationException_Not()
        {
            Should.Throw<InvalidOperationException>(() => Raise<InvalidOperationException>.IfNot(false));
        }

        [Test]
        public void InvalidOperationException_WithMsg()
        {
            try
            {
                Raise<InvalidOperationException>.If(true, "Pino");
                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Pino", ex.Message);
                Assert.Pass();
            }
        }

        [Test]
        public void InvalidOperationException_WithMsg_Not()
        {
            try
            {
                Raise<InvalidOperationException>.IfNot(false, "Pino");
                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Pino", ex.Message);
                Assert.Pass();
            }
        }

        [Test]
        public void ExtendedConstructor_FileNotFoundException()
        {
            const string msg = "Test MSG";
            const string path = "Test PATH";

            try
            {
                Raise<FileNotFoundException>.If(false, msg, path);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            try
            {
                Raise<FileNotFoundException>.If(true, msg, path);
            }
            catch (FileNotFoundException fex)
            {
                Assert.That(fex.Message, Is.EqualTo(msg));
                Assert.That(fex.FileName, Is.EqualTo(path));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void ExtendedConstructor_FileNotFoundException_Not()
        {
            const string msg = "Test MSG";
            const string path = "Test PATH";

            try
            {
                Raise<FileNotFoundException>.IfNot(true, msg, path);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            try
            {
                Raise<FileNotFoundException>.IfNot(false, msg, path);
            }
            catch (FileNotFoundException fex)
            {
                Assert.That(fex.Message, Is.EqualTo(msg));
                Assert.That(fex.FileName, Is.EqualTo(path));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void ExtendedConstructor_BigCtorException()
        {
            var x = 3;
            var y = decimal.MinValue;
            var z = "ZZZ";
            var t = new KeyValuePair<string, string>(z, z + z);

            try
            {
                Raise<BigCtorException>.If(false, x, y, z, t);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            try
            {
                Raise<BigCtorException>.If(true, x, y, z, t);
            }
            catch (BigCtorException fex)
            {
                Assert.That(fex.Message, Is.EqualTo(x.ToString()));
                Assert.That(fex.X, Is.EqualTo(x));
                Assert.That(fex.Y, Is.EqualTo(y));
                Assert.That(fex.Z, Is.EqualTo(z));
                Assert.That(fex.T, Is.EqualTo(t));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void ExtendedConstructor_BigCtorException_Not()
        {
            var x = 3;
            var y = decimal.MinValue;
            var z = "ZZZ";
            var t = new KeyValuePair<string, string>(z, z + z);

            try
            {
                Raise<BigCtorException>.IfNot(true, x, y, z, t);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            try
            {
                Raise<BigCtorException>.IfNot(false, x, y, z, t);
            }
            catch (BigCtorException fex)
            {
                Assert.That(fex.Message, Is.EqualTo(x.ToString()));
                Assert.That(fex.X, Is.EqualTo(x));
                Assert.That(fex.Y, Is.EqualTo(y));
                Assert.That(fex.Z, Is.EqualTo(z));
                Assert.That(fex.T, Is.EqualTo(t));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void ExtendedConstructor_TooManyArgs()
        {
            try
            {
                Raise<ArgumentException>.If(true, 1, "snau", 3.14M);
            }
            catch (ArgumentException aex)
            {
                Assert.Pass(aex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void ExtendedConstructor_TooManyArgs_Not()
        {
            try
            {
                Raise<ArgumentException>.IfNot(false, 1, "SNAFU", 3.14M);
            }
            catch (ArgumentException aex)
            {
                Assert.Pass(aex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
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