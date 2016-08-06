// File name: HttpExceptionTests.cs
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

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Net;
using System.Runtime.Serialization.Formatters;

namespace PommaLabs.Thrower.UnitTests.ExceptionHandlers
{
    internal sealed class HttpExceptionTests : AbstractTests
    {
        [Test, ExpectedException(typeof(HttpException))]
        public void If_TrueShouldThrow()
        {
            Raise.HttpException.If(true, HttpStatusCode.BadRequest);
        }

        [Test]
        public void If_TrueShouldThrow_CheckExceptionProperties()
        {
            try
            {
                Raise.HttpException.If(true, HttpStatusCode.BadRequest, TestMessage);
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
                Raise.HttpException.If(true, HttpStatusCode.BadRequest, TestMessage, new HttpExceptionInfo(TestMessage + "0", TestMessage + "1"));
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
            Raise.HttpException.If(true, HttpStatusCode.BadRequest, TestMessage);
        }

        [Test]
        public void If_FalseShouldNotThrow()
        {
            Raise.HttpException.If(false, HttpStatusCode.BadRequest);
        }

        [Test]
        public void If_FalseShouldNotThrow_WithMessage()
        {
            Raise.HttpException.If(false, HttpStatusCode.BadRequest, TestMessage);
        }

        [Test, ExpectedException(typeof(HttpException))]
        public void IfNot_FalseShouldThrow()
        {
            Raise.HttpException.IfNot(false, HttpStatusCode.BadRequest);
        }

        [Test]
        public void IfNot_FalseShouldThrow_CheckExceptionProperties()
        {
            try
            {
                Raise.HttpException.IfNot(false, HttpStatusCode.BadRequest, TestMessage);
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
                Raise.HttpException.IfNot(false, HttpStatusCode.BadRequest, TestMessage, new HttpExceptionInfo(TestMessage + "0", TestMessage + "1"));
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
            Raise.HttpException.IfNot(false, HttpStatusCode.BadRequest, TestMessage);
        }

        [Test]
        public void IfNot_TrueShouldNotThrow()
        {
            Raise.HttpException.IfNot(true, HttpStatusCode.BadRequest);
        }

        [Test]
        public void IfNot_TrueShouldNotThrow_WithMessage()
        {
            Raise.HttpException.IfNot(true, HttpStatusCode.BadRequest, TestMessage);
        }

        #region Serialization

        [Test]
        public void HttpException_IsProperlySerialized()
        {
            const HttpStatusCode statusCode = HttpStatusCode.MultipleChoices;
            const TransportType errorCode = TransportType.Connectionless;
            const string message = "Serialization test - Message";
            const string userMessage = "Serialization test - User message";

            var ex = new HttpException(statusCode, message, new HttpExceptionInfo
            {
                ErrorCode = errorCode,
                UserMessage = userMessage
            });

            var json = JsonConvert.SerializeObject(ex, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                TypeNameHandling = TypeNameHandling.Objects
            });
            JToken jobj = JsonConvert.DeserializeObject<JObject>(json);

#if !NET35

            // On .NET 3.5, properties are set at root level. Otherwise, they are stored here.
            jobj = jobj["SafeSerializationManager"]["m_serializedStates"][0];

#endif

            Console.WriteLine(json);

            Assert.That((jobj[nameof(HttpException.HttpStatusCode)] as JValue).Value, Is.EqualTo((int) statusCode));
            Assert.That((jobj[nameof(HttpException.ErrorCode)] as JValue).Value, Is.EqualTo((int) errorCode));
            Assert.That((jobj[nameof(HttpException.UserMessage)] as JValue).Value, Is.EqualTo(userMessage));

            var newEx = JsonConvert.DeserializeObject<HttpException>(json);

            Assert.That(newEx.HttpStatusCode, Is.EqualTo(statusCode));
            Assert.That(newEx.ErrorCode, Is.EqualTo(errorCode));
            Assert.That(newEx.Message, Is.EqualTo(message));
            Assert.That(newEx.UserMessage, Is.EqualTo(userMessage));
        }

        #endregion
    }
}