// Copyright 2013 Marc Gravell
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except
// in compliance with the License. You may obtain a copy of the License at:
//
// "http://www.apache.org/licenses/LICENSE-2.0"
//
// Unless required by applicable law or agreed to in writing, software distributed under the License
// is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
// or implied. See the License for the specific language governing permissions and limitations under
// the License.

#if !(PORTABLE || NETSTD10)

using NUnit.Framework;
using PommaLabs.Thrower.Reflection.FastMember;

namespace PommaLabs.Thrower.UnitTests.Reflection.FastMember
{
    [TestFixture]
    public class Anons
    {
        [Test]
        public void TestAnonTypeAccess()
        {
            var obj = new { A = 123, B = "def" };

            var accessor = ObjectAccessor.Create(obj);
            Assert.AreEqual(123, accessor["A"]);
            Assert.AreEqual("def", accessor["B"]);
        }

        [Test]
        public void TestAnonCtor()
        {
            var obj = new { A = 123, B = "def" };

            var accessor = TypeAccessor.Create(obj.GetType());
            Assert.IsFalse(accessor.CreateNewSupported);
        }

        [Test]
        public void TestPrivateTypeAccess()
        {
            var obj = new Private { A = 123, B = "def" };

            var accessor = ObjectAccessor.Create(obj);
            Assert.AreEqual(123, accessor["A"]);
            Assert.AreEqual("def", accessor["B"]);
        }

        [Test]
        public void TestPrivateTypeCtor()
        {
            var accessor = TypeAccessor.Create(typeof(Private));
            Assert.IsTrue(accessor.CreateNewSupported);
            var obj = accessor.CreateNew();
            Assert.IsNotNull(obj);
            Assert.IsInstanceOf(typeof(Private), obj);
        }

        private sealed class Private
        {
            public int A { get; set; }
            public string B { get; set; }
        }
    }
}

#endif