// File name: ArgumentExceptionTests.cs
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
using PommaLabs.Thrower.ExceptionHandlers;
using PommaLabs.Thrower.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PommaLabs.Thrower.UnitTests.ExceptionHandlers
{
    internal sealed class ArgumentExceptionTests : AbstractTests
    {
        #region IfIsNotValidEmailAddress

        // Simple
        [TestCase("a@b.c")]
        [TestCase("a.d@b.c")]
        [TestCase("pinogino123@bau.com")]
        [TestCase("123aaa123@mao.info")]
        [TestCase("a1@b.it")]
        // IPv4 and IPv6
        [TestCase("valid.ipv4.addr@[123.1.72.10]")]
        [TestCase("valid.ipv6.addr@[IPv6:0::1]")]
        [TestCase("valid.ipv6.addr@[IPv6:2607:f0d0:1002:51::4]")]
        [TestCase("valid.ipv6.addr@[IPv6:fe80::230:48ff:fe33:bc33]")]
        [TestCase("valid.ipv6.addr@[IPv6:fe80:0000:0000:0000:0202:b3ff:fe1e:8329]")]
        [TestCase("valid.ipv6v4.addr@[IPv6:aaaa:aaaa:aaaa:aaaa:aaaa:aaaa:127.0.0.1]")]
        // Examples from Wikipedia
        [TestCase("niceandsimple@example.com")]
        [TestCase("very.common@example.com")]
        [TestCase("a.little.lengthy.but.fine@dept.example.com")]
        [TestCase("disposable.style.email.with+symbol@example.com")]
        [TestCase("user@[IPv6:2001:db8:1ff::a0b:dbd0]")]
        [TestCase("\"much.more unusual\"@example.com")]
        [TestCase("\"very.unusual.@.unusual.com\"@example.com")]
        [TestCase("\"very.(),:;<>[]\\\".VERY.\\\"very@\\\\ \\\"very\\\".unusual\"@strange.example.com")]
        [TestCase("postbox@com")]
        [TestCase("admin@mailserver1")]
        [TestCase("!#$%&'*+-/=?^_`{}|~@example.org")]
        [TestCase("\"()<>[]:,;@\\\\\\\"!#$%&'*+-/=?^_`{}| ~.a\"@example.org")]
        [TestCase("\" \"@example.org")]
        // Examples from https://github.com/Sembiance/email-validator
        [TestCase("\"\\e\\s\\c\\a\\p\\e\\d\"@sld.com")]
        [TestCase("\"back\\slash\"@sld.com")]
        [TestCase("\"escaped\\\"quote\"@sld.com")]
        [TestCase("\"quoted\"@sld.com")]
        [TestCase("\"quoted-at-sign@sld.org\"@sld.com")]
        [TestCase("&'*+-./=?^_{}~@other-valid-characters-in-local.net")]
        [TestCase("01234567890@numbers-in-local.net")]
        [TestCase("a@single-character-in-local.org")]
        [TestCase("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ@letters-in-local.org")]
        [TestCase("backticksarelegit@test.com")]
        [TestCase("bracketed-IP-instead-of-domain@[127.0.0.1]")]
        [TestCase("country-code-tld@sld.rw")]
        [TestCase("country-code-tld@sld.uk")]
        [TestCase("letters-in-sld@123.com")]
        [TestCase("local@dash-in-sld.com")]
        [TestCase("local@sld.newTLD")]
        [TestCase("local@sub.domains.com")]
        [TestCase("mixed-1234-in-{+^}-local@sld.net")]
        [TestCase("one-character-third-level@a.example.com")]
        [TestCase("one-letter-sld@x.org")]
        [TestCase("punycode-numbers-in-tld@sld.xn--3e0b707e")]
        [TestCase("single-character-in-sld@x.org")]
        [TestCase("the-character-limit@for-each-part.of-the-domain.is-sixty-three-characters.this-is-exactly-sixty-three-characters-so-it-is-valid-blah-blah.com")]
        [TestCase("the-total-length@of-an-entire-address.cannot-be-longer-than-two-hundred-and-fifty-four-characters.and-this-address-is-254-characters-exactly.so-it-should-be-valid.and-im-going-to-add-some-more-words-here.to-increase-the-length-blah-blah-blah-blah-bla.org")]
        [TestCase("uncommon-tld@sld.mobi")]
        [TestCase("uncommon-tld@sld.museum")]
        [TestCase("uncommon-tld@sld.travel")]
        public void IfIsNotValidEmailAddress_ValidEmail_NotInternational(string email)
        {
            try
            {
                Raise.ArgumentException.IfIsNotValidEmailAddress(email);
            }
            catch (Exception)
            {
                // If we get here, then we must ensure that the mail address is a top level domain.
                // Otherwise, we should mark this unit test as failed.
                Raise.ArgumentException.IfIsNotValidEmailAddress(email, EmailAddressValidator.Options.AllowTopLevelDomains);
            }

            Raise.ArgumentException.IfIsNotValidEmailAddress(email, EmailAddressValidator.Options.AllowTopLevelDomains);
            Raise.ArgumentException.IfIsNotValidEmailAddress(email, EmailAddressValidator.Options.AllowInternational | EmailAddressValidator.Options.AllowTopLevelDomains);
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
                Raise.ArgumentException.IfIsNotValidEmailAddress(email);
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            Raise.ArgumentException.IfNot(hasThrown);

            hasThrown = false;
            try
            {
                Raise.ArgumentException.IfIsNotValidEmailAddress(email, EmailAddressValidator.Options.AllowTopLevelDomains);
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            Raise.ArgumentException.IfNot(hasThrown);

            Raise.ArgumentException.IfIsNotValidEmailAddress(email, EmailAddressValidator.Options.AllowInternational | EmailAddressValidator.Options.AllowTopLevelDomains);
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
                Raise.ArgumentException.IfIsNotValidEmailAddress(email);
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            Raise.ArgumentException.IfNot(hasThrown);

            hasThrown = false;
            try
            {
                Raise.ArgumentException.IfIsNotValidEmailAddress(email, EmailAddressValidator.Options.None);
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            Raise.ArgumentException.IfNot(hasThrown);

            hasThrown = false;
            try
            {
                Raise.ArgumentException.IfIsNotValidEmailAddress(email, EmailAddressValidator.Options.AllowInternational);
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            Raise.ArgumentException.IfNot(hasThrown);
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
                Raise.ArgumentException.IfIsNotValidEmailAddress(email);
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            Raise.ArgumentException.IfNot(hasThrown);

            hasThrown = false;
            try
            {
                Raise.ArgumentException.IfIsNotValidEmailAddress(email, EmailAddressValidator.Options.None);
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            Raise.ArgumentException.IfNot(hasThrown);

            hasThrown = false;
            try
            {
                Raise.ArgumentException.IfIsNotValidEmailAddress(email, EmailAddressValidator.Options.AllowInternational);
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            Raise.ArgumentException.IfNot(hasThrown);
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
            Raise.ArgumentException.IfIsNotValidPhoneNumber(phone);
            Raise.ArgumentException.IfIsNotValidPhoneNumber(phone, nameof(phone), "TEST");
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
                Raise.ArgumentException.IfIsNotValidPhoneNumber(phone);
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            Raise.ArgumentException.IfNot(hasThrown);

            hasThrown = false;
            try
            {
                Raise.ArgumentException.IfIsNotValidPhoneNumber(phone, nameof(phone), "TEST");
            }
            catch (ArgumentException)
            {
                hasThrown = true;
            }
            Raise.ArgumentException.IfNot(hasThrown);
        }

        #endregion IfIsNotValidPhoneNumber

        #region IfIsEmpty - Collection

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        public void IfIsEmpty_FullList(int itemCount)
        {
            var list = Enumerable.Range(0, itemCount).ToList();
            Raise.ArgumentException.IfIsNullOrEmpty(list);
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        public void IfIsEmpty_FullDictionary(int itemCount)
        {
            var dict = Enumerable.Range(0, itemCount).ToDictionary(k => k, v => v.ToString());
            Raise.ArgumentException.IfIsNullOrEmpty(dict);
        }

        [Test, ExpectedException(typeof(ArgumentException), ExpectedMessage = ArgumentExceptionHandler.CollectionIsNullOrEmptyMessage, MatchType = MessageMatch.Contains)]
        public void IfIsEmpty_NullList()
        {
            List<string> list = null;
            Raise.ArgumentException.IfIsNullOrEmpty(list);
        }

        [Test, ExpectedException(typeof(ArgumentException), ExpectedMessage = ArgumentExceptionHandler.CollectionIsNullOrEmptyMessage, MatchType = MessageMatch.Contains)]
        public void IfIsEmpty_NullDictionary()
        {
            Dictionary<string, int> dict = null;
            Raise.ArgumentException.IfIsNullOrEmpty(dict);
        }

        [Test, ExpectedException(typeof(ArgumentException), ExpectedMessage = ArgumentExceptionHandler.CollectionIsNullOrEmptyMessage, MatchType = MessageMatch.Contains)]
        public void IfIsEmpty_EmptyList()
        {
            var list = new List<string>();
            Raise.ArgumentException.IfIsNullOrEmpty(list);
        }

        [Test, ExpectedException(typeof(ArgumentException), ExpectedMessage = ArgumentExceptionHandler.CollectionIsNullOrEmptyMessage, MatchType = MessageMatch.Contains)]
        public void IfIsEmpty_EmptyDictionary()
        {
            var dict = new Dictionary<string, int>();
            Raise.ArgumentException.IfIsNullOrEmpty(dict);
        }

        #endregion IfIsEmpty - Collection

        #region IfIs(Not)EqualTo

        [Test]
        public void IfIsEqualTo_DifferentIntegers()
        {
            Raise.ArgumentException.IfIsEqualTo(5, 50);
        }

        [Test]
        public void IfIsEqualTo_DifferentIntegers_WithMsg()
        {
            var x = 5;
            Raise.ArgumentException.IfIsEqualTo(x, 50, nameof(x), TestMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IfIsNotEqualTo_DifferentIntegers()
        {
            Raise.ArgumentException.IfIsNotEqualTo(5, 50);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = TestMessage)]
        public void IfIsNotEqualTo_DifferentIntegers_WithMsg()
        {
            var x = 5;
            Raise.ArgumentException.IfIsNotEqualTo(x, 50, nameof(x), TestMessage);
        }

        [Test]
        public void IfIsNotEqualTo_SameIntegers()
        {
            Raise.ArgumentException.IfIsNotEqualTo(5, 5);
        }

        [Test]
        public void IfIsNotEqualTo_SameIntegers_WithMsg()
        {
            var x = 5;
            Raise.ArgumentException.IfIsNotEqualTo(x, 5, nameof(x), TestMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IfIsEqualTo_SameIntegers()
        {
            Raise.ArgumentException.IfIsEqualTo(5, 5);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = TestMessage)]
        public void IfIsEqualTo_SameIntegers_WithMsg()
        {
            var x = 5;
            Raise.ArgumentException.IfIsEqualTo(x, 5, nameof(x), TestMessage);
        }

        #endregion IfIs(Not)EqualTo
    }
}