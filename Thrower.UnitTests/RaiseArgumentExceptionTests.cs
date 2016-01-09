// File name: RaiseArgumentExceptionTests.cs
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

namespace PommaLabs.Thrower.UnitTests
{
    internal sealed class RaiseArgumentExceptionTests : AbstractTests
    {
        #region IfIsNotValidEmail

        [TestCase("a@b.c")]
        [TestCase("a.d@b.c")]
        [TestCase("pinogino123@bau.com")]
        [TestCase("123aaa123@mao.info")]
        [TestCase("a1@b.it")]
        public void IfIsNotValidEmail_ValidEmail_NotInternational(string email)
        {
            RaiseArgumentException.IfIsNotValidEmail(email);
            RaiseArgumentException.IfIsNotValidEmail(email, false);
            RaiseArgumentException.IfIsNotValidEmail(email, true);
        }

        [TestCase("伊昭傑@郵件.商務")]
        [TestCase("राम@मोहन.ईन्फो")]
        [TestCase("юзер@екзампл.ком")]
        [TestCase("θσερ@εχαμπλε.ψομ")]
        [TestCase("伊昭傑123@郵件.商務")]
        public void IfIsNotValidEmail_ValidEmail_International(string email)
        {
            var hasThrown = false;
            try
            {
                RaiseArgumentException.IfIsNotValidEmail(email);
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            RaiseArgumentException.IfNot(hasThrown);

            hasThrown = false;
            try
            {
                RaiseArgumentException.IfIsNotValidEmail(email, false);
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            RaiseArgumentException.IfNot(hasThrown);

            RaiseArgumentException.IfIsNotValidEmail(email, true);
        }

        [TestCase("ab.c")]
        [TestCase("a.d@b$.com")]
        [TestCase("pinogino123@@bau.com")]
        [TestCase("123aaa123@mao.info.it@a@snau")]
        [TestCase("a1@snau@b.it")]
        public void IfIsNotValidEmail_NotValidEmail_NotInternational(string email)
        {
            var hasThrown = false;
            try
            {
                RaiseArgumentException.IfIsNotValidEmail(email);
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            RaiseArgumentException.IfNot(hasThrown);

            hasThrown = false;
            try
            {
                RaiseArgumentException.IfIsNotValidEmail(email, false);
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            RaiseArgumentException.IfNot(hasThrown);

            hasThrown = false;
            try
            {
                RaiseArgumentException.IfIsNotValidEmail(email, true);
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            RaiseArgumentException.IfNot(hasThrown);
        }

        [TestCase("伊昭傑@@郵件.商務")]
        [TestCase("राम@मोहन.ईन्फो$")]
        [TestCase("юзер@snau@екзампл.ком")]
        [TestCase("θσερ@εχαμπλε.ψομ123#")]
        [TestCase("伊昭傑123@郵件.商務@伊昭傑123")]
        public void IfIsNotValidEmail_NotValidEmail_International(string email)
        {
            var hasThrown = false;
            try
            {
                RaiseArgumentException.IfIsNotValidEmail(email);
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            RaiseArgumentException.IfNot(hasThrown);

            hasThrown = false;
            try
            {
                RaiseArgumentException.IfIsNotValidEmail(email, false);
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            RaiseArgumentException.IfNot(hasThrown);

            hasThrown = false;
            try
            {
                RaiseArgumentException.IfIsNotValidEmail(email, true);
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            RaiseArgumentException.IfNot(hasThrown);
        }

        #endregion IfIsNotValidEmail
    }
}
