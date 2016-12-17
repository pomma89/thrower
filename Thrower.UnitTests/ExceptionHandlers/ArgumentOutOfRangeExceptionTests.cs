// File name: ArgumentOutOfRangeExceptionTests.cs
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
    internal sealed class ArgumentOutOfRangeExceptionTests : AbstractTests
    {
        [Test]
        public void IfIsNaN_CorrectDouble()
        {
            Raise.ArgumentOutOfRangeException.IfIsNaN(5.0);
        }

        [Test]
        public void IfIsNaN_CorrectDouble_WithMsg()
        {
            Raise.ArgumentOutOfRangeException.IfIsNaN(5.0, TestMessage);
        }

        [Test]
        public void IfIsNaN_NaN()
        {
            Should.Throw<ArgumentOutOfRangeException>(() => Raise.ArgumentOutOfRangeException.IfIsNaN(double.NaN));
        }

        [Test]
        public void IfIsNaN_NaN_WithMsg()
        {
            Should.Throw<ArgumentOutOfRangeException>(() => Raise.ArgumentOutOfRangeException.IfIsNaN(double.NaN, TestMessage));
        }

        [Test]
        public void IfIsPositiveInfinity_CorrectDouble()
        {
            Raise.ArgumentOutOfRangeException.IfIsPositiveInfinity(5.0);
        }

        [Test]
        public void IfIsPositiveInfinity_CorrectDouble_WithMsg()
        {
            Raise.ArgumentOutOfRangeException.IfIsPositiveInfinity(5.0, TestMessage);
        }

        [Test]
        public void IfIsPositiveInfinity_PositiveInfinity()
        {
            Should.Throw<ArgumentOutOfRangeException>(() => Raise.ArgumentOutOfRangeException.IfIsPositiveInfinity(double.PositiveInfinity));
        }

        [Test]
        public void IfIsPositiveInfinity_PositiveInfinity_WithMsg()
        {
            Should.Throw<ArgumentOutOfRangeException>(() => Raise.ArgumentOutOfRangeException.IfIsPositiveInfinity(double.PositiveInfinity, TestMessage));
        }

        [Test]
        public void IfIsNegativeInfinity_CorrectDouble()
        {
            Raise.ArgumentOutOfRangeException.IfIsNegativeInfinity(5.0);
        }

        [Test]
        public void IfIsNegativeInfinity_CorrectDouble_WithMsg()
        {
            Raise.ArgumentOutOfRangeException.IfIsNegativeInfinity(5.0, TestMessage);
        }

        [Test]
        public void IfIsNegativeInfinity_NegativeInfinity()
        {
            Should.Throw<ArgumentOutOfRangeException>(() => Raise.ArgumentOutOfRangeException.IfIsNegativeInfinity(double.NegativeInfinity));
        }

        [Test]
        public void IfIsNegativeInfinity_NegativeInfinity_WithMsg()
        {
            Should.Throw<ArgumentOutOfRangeException>(() => Raise.ArgumentOutOfRangeException.IfIsNegativeInfinity(double.NegativeInfinity, TestMessage));
        }
    }
}