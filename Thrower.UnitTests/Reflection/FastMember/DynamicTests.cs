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

#if !(NET35 || PORTABLE || NETSTD11 || NETSTD12)

using Microsoft.CSharp.RuntimeBinder;
using NUnit.Framework;
using PommaLabs.Thrower.Reflection.FastMember;
using System.Dynamic;

namespace PommaLabs.Thrower.UnitTests.Reflection.FastMember
{
    [TestFixture]
    public class DynamicTests
    {
        [Test]
        public void TestReadValid()
        {
            dynamic expando = new ExpandoObject();
            expando.A = 123;
            expando.B = "def";
            var wrap = ObjectAccessor.Create((object) expando);

            Assert.AreEqual(123, wrap["A"]);
            Assert.AreEqual("def", wrap["B"]);
        }

        [Test]
        public void TestReadInvalid()
        {
            Assert.Throws<RuntimeBinderException>(() =>
            {
                dynamic expando = new ExpandoObject();
                var wrap = ObjectAccessor.Create((object) expando);
                Assert.AreEqual(123, wrap["C"]);
            });
        }

        [Test]
        public void TestWrite()
        {
            dynamic expando = new ExpandoObject();
            var wrap = ObjectAccessor.Create((object) expando);
            wrap["A"] = 123;
            wrap["B"] = "def";

            Assert.AreEqual(123, expando.A);
            Assert.AreEqual("def", expando.B);
        }

        [Test]
        public void DynamicByTypeWrapper()
        {
            var obj = new ExpandoObject();
            ((dynamic) obj).Foo = "bar";
            var accessor = TypeAccessor.Create(obj.GetType());

            Assert.AreEqual("bar", accessor[obj, "Foo"]);
            accessor[obj, "Foo"] = "BAR";
            string result = ((dynamic) obj).Foo;
            Assert.AreEqual("BAR", result);
        }
    }
}

#endif