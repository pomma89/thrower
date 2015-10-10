// Copyright 2015-2025 Finsa S.p.A. <finsa@finsa.it>
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

using NUnit.Framework;

namespace PommaLabs.Thrower.UnitTests
{
    [TestFixture]
    abstract class AbstractTests
    {
        #region Setup/Teardown

        [SetUp]
        public virtual void SetUp()
        {
            Assert.False(string.IsNullOrEmpty(RaiseBase.UseThrowerDefine));
            Assert.AreEqual(RaiseBase.UseThrowerDefine, RaiseBase.UseThrowerDefine);
        }

        [TearDown]
        public virtual void TearDown()
        {
        }

        #endregion Setup/Teardown

        protected const string TestMessage = "A long and complicated error message...";

        protected class Base { }

        protected class Derived : Base { }

        protected class Convertible
        {
            public static implicit operator Base(Convertible c)
            {
                return new Base();
            }
        }
    }
}
