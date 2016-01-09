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
        #region IfIsNotValidEmailAddress

        [TestCase("a@b.c")]
        [TestCase("a.d@b.c")]
        [TestCase("pinogino123@bau.com")]
        [TestCase("123aaa123@mao.info")]
        [TestCase("a1@b.it")]
        public void IfIsNotValidEmailAddress_ValidEmail_NotInternational(string email)
        {
            RaiseArgumentException.IfIsNotValidEmailAddress(email);
            RaiseArgumentException.IfIsNotValidEmailAddress(email, false);
            RaiseArgumentException.IfIsNotValidEmailAddress(email, true);
        }

        [TestCase("伊昭傑@郵件.商務")]
        [TestCase("राम@मोहन.ईन्फो")]
        [TestCase("юзер@екзампл.ком")]
        [TestCase("θσερ@εχαμπλε.ψομ")]
        [TestCase("伊昭傑123@郵件.商務")]
        public void IfIsNotValidEmailAddress_ValidEmail_International(string email)
        {
            var hasThrown = false;
            try
            {
                RaiseArgumentException.IfIsNotValidEmailAddress(email);
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            RaiseArgumentException.IfNot(hasThrown);

            hasThrown = false;
            try
            {
                RaiseArgumentException.IfIsNotValidEmailAddress(email, false);
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            RaiseArgumentException.IfNot(hasThrown);

            RaiseArgumentException.IfIsNotValidEmailAddress(email, true);
        }

        [TestCase("ab.c")]
        [TestCase("a.d@b$.com")]
        [TestCase("pinogino123@@bau.com")]
        [TestCase("123aaa123@mao.info.it@a@snau")]
        [TestCase("a1@snau@b.it")]
        public void IfIsNotValidEmailAddress_NotValidEmail_NotInternational(string email)
        {
            var hasThrown = false;
            try
            {
                RaiseArgumentException.IfIsNotValidEmailAddress(email);
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            RaiseArgumentException.IfNot(hasThrown);

            hasThrown = false;
            try
            {
                RaiseArgumentException.IfIsNotValidEmailAddress(email, false);
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            RaiseArgumentException.IfNot(hasThrown);

            hasThrown = false;
            try
            {
                RaiseArgumentException.IfIsNotValidEmailAddress(email, true);
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
        public void IfIsNotValidEmailAddress_NotValidEmail_International(string email)
        {
            var hasThrown = false;
            try
            {
                RaiseArgumentException.IfIsNotValidEmailAddress(email);
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            RaiseArgumentException.IfNot(hasThrown);

            hasThrown = false;
            try
            {
                RaiseArgumentException.IfIsNotValidEmailAddress(email, false);
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            RaiseArgumentException.IfNot(hasThrown);

            hasThrown = false;
            try
            {
                RaiseArgumentException.IfIsNotValidEmailAddress(email, true);
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            RaiseArgumentException.IfNot(hasThrown);
        }

        #endregion IfIsNotValidEmailAddress

        #region IfIsNotValidPhoneNumber

        [TestCase("+393401234567")]
        [TestCase("0185/123456")]
        [TestCase("0185-123456")]
        [TestCase("340 123 4567")]
        [TestCase("340-12-34-567")]
        [TestCase("+1 709 239-5000")]
        [TestCase("+995 442 123456")]
        [TestCase("+995 595 555 555")]
        [TestCase("+7 840 123-45-67")]
        [TestCase("+7 940 555 555")]
        [TestCase("111")]
        [TestCase("+84 996 202 4961")]
        [TestCase("39 010 096 60")]
        public void IfIsNotValidPhoneNumber_ValidPhone(string phone)
        {
            RaiseArgumentException.IfIsNotValidPhoneNumber(phone);
            RaiseArgumentException.IfIsNotValidPhoneNumber(phone, nameof(phone), "TEST");
        }

        [TestCase("ab.c")]
        [TestCase("a.d@b$.com")]
        [TestCase("pinogino123@@bau.com")]
        [TestCase("123aaa123@mao.info.it@a@snau")]
        [TestCase("a1@snau@b.it")]
        [TestCase("39 010 096 60 snau")]
        public void IfIsNotValidPhoneNumber_NotValidPhone(string phone)
        {
            var hasThrown = false;
            try
            {
                RaiseArgumentException.IfIsNotValidPhoneNumber(phone);
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            RaiseArgumentException.IfNot(hasThrown);

            hasThrown = false;
            try
            {
                RaiseArgumentException.IfIsNotValidPhoneNumber(phone, nameof(phone), "TEST");
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            RaiseArgumentException.IfNot(hasThrown);
        }

        #endregion IfIsNotValidPhoneNumber
    }
}
