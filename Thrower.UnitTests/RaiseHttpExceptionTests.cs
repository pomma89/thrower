// File name: RaiseHttpExceptionTests.cs
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
using System.Net;

namespace PommaLabs.Thrower.UnitTests
{
    internal sealed class RaiseHttpExceptionTests : AbstractTests
    {
        [Test, ExpectedException(typeof(HttpException))]
        public void If_TrueShouldThrow()
        {
            RaiseHttpException.If(true, HttpStatusCode.BadRequest);
        }

        [Test]
        public void If_TrueShouldThrow_CheckExceptionProperties()
        {
            try
            {
                RaiseHttpException.If(true, HttpStatusCode.BadRequest, TestMessage);
            }
            catch (HttpException ex)
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, ex.HttpStatusCode);
                Assert.AreEqual(TestMessage, ex.Message);
                Assert.AreEqual(HttpException.DefaultErrorCode, ex.ErrorCode);
                Assert.AreEqual(HttpException.DefaultUserMessage, ex.UserMessage);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            try
            {
                RaiseHttpException.If(true, HttpStatusCode.BadRequest, TestMessage, new HttpExceptionInfo(TestMessage + "0", TestMessage + "1"));
            }
            catch (HttpException ex)
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, ex.HttpStatusCode);
                Assert.AreEqual(TestMessage, ex.Message);
                Assert.AreEqual(TestMessage + "0", ex.ErrorCode);
                Assert.AreEqual(TestMessage + "1", ex.UserMessage);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test, ExpectedException(typeof(HttpException), ExpectedMessage = TestMessage)]
        public void If_TrueShouldThrow_WithMessage()
        {
            RaiseHttpException.If(true, HttpStatusCode.BadRequest, TestMessage);
        }

        [Test]
        public void If_FalseShouldNotThrow()
        {
            RaiseHttpException.If(false, HttpStatusCode.BadRequest);
        }

        [Test]
        public void If_FalseShouldNotThrow_WithMessage()
        {
            RaiseHttpException.If(false, HttpStatusCode.BadRequest, TestMessage);
        }

        [Test, ExpectedException(typeof(HttpException))]
        public void IfNot_FalseShouldThrow()
        {
            RaiseHttpException.IfNot(false, HttpStatusCode.BadRequest);
        }

        [Test]
        public void IfNot_FalseShouldThrow_CheckExceptionProperties()
        {
            try
            {
                RaiseHttpException.IfNot(false, HttpStatusCode.BadRequest, TestMessage);
            }
            catch (HttpException ex)
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, ex.HttpStatusCode);
                Assert.AreEqual(TestMessage, ex.Message);
                Assert.AreEqual(HttpException.DefaultErrorCode, ex.ErrorCode);
                Assert.AreEqual(HttpException.DefaultUserMessage, ex.UserMessage);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            try
            {
                RaiseHttpException.IfNot(false, HttpStatusCode.BadRequest, TestMessage, new HttpExceptionInfo(TestMessage + "0", TestMessage + "1"));
            }
            catch (HttpException ex)
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, ex.HttpStatusCode);
                Assert.AreEqual(TestMessage, ex.Message);
                Assert.AreEqual(TestMessage + "0", ex.ErrorCode);
                Assert.AreEqual(TestMessage + "1", ex.UserMessage);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test, ExpectedException(typeof(HttpException), ExpectedMessage = TestMessage)]
        public void IfNot_FalseShouldThrow_WithMessage()
        {
            RaiseHttpException.IfNot(false, HttpStatusCode.BadRequest, TestMessage);
        }

        [Test]
        public void IfNot_TrueShouldNotThrow()
        {
            RaiseHttpException.IfNot(true, HttpStatusCode.BadRequest);
        }

        [Test]
        public void IfNot_TrueShouldNotThrow_WithMessage()
        {
            RaiseHttpException.IfNot(true, HttpStatusCode.BadRequest, TestMessage);
        }
    }
}