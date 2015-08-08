// File name: IfIsContainedInTests.cs
// 
// Author(s): Alessio Parma <alessio.parma@gmail.com>
// 
// Copyright (c) 2013-2014 Alessio Parma <alessio.parma@gmail.com>
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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using NUnit.Framework;

namespace PommaLabs.Thrower.UnitTests
{
    sealed class IfIsContainedInTests : AbstractDiagnosticsTests
    {
        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void ElementContained()
        {
            Raise<ApplicationException>.IfIsContainedIn(1, new List<int> { 1, 2, 3 });
        }

        [Test]
        [ExpectedException(typeof(ApplicationException), ExpectedMessage = TestMessage)]
        public void ElementContained_WithMsg()
        {
            Raise<ApplicationException>.IfIsContainedIn(1, new List<int> { 1, 2, 3 }, TestMessage);
        }

        [Test]
        public void ElementNotContained()
        {
            Raise<ApplicationException>.IfIsContainedIn(1, new List<int>());
        }

        [Test]
        public void ElementNotContained_WithMsg()
        {
            Raise<ApplicationException>.IfIsContainedIn(1, new List<int>(), TestMessage);
        }

        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void IDictionary2_ElementContained()
        {
            Raise<ApplicationException>.IfIsContainedIn(1, 4, new Dictionary<int, int> { { 1, 4 }, { 2, 5 }, { 3, 6 } });
        }

        [Test]
        [ExpectedException(typeof(ApplicationException), ExpectedMessage = TestMessage)]
        public void IDictionary2_ElementContained_WithMsg()
        {
            Raise<ApplicationException>.IfIsContainedIn(1, 4, new Dictionary<int, int> { { 1, 4 }, { 2, 5 }, { 3, 6 } }, TestMessage);
        }

        [Test]
        public void IDictionary2_ElementNotContained()
        {
            Raise<ApplicationException>.IfIsContainedIn(1, 4, new Dictionary<int, int>());
        }

        [Test]
        public void IDictionary2_ElementNotContained_WithMsg()
        {
            Raise<ApplicationException>.IfIsContainedIn(1, 4, new Dictionary<int, int>(), TestMessage);
        }

        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void IDictionary_ElementContained()
        {
            Raise<ApplicationException>.IfIsContainedIn(1, new HybridDictionary { { 1, 4 }, { 2, 5 }, { 3, 6 } });
        }

        [Test]
        [ExpectedException(typeof(ApplicationException), ExpectedMessage = TestMessage)]
        public void IDictionary_ElementContained_WithMsg()
        {
            Raise<ApplicationException>.IfIsContainedIn(1, new HybridDictionary { { 1, 4 }, { 2, 5 }, { 3, 6 } }, TestMessage);
        }

        [Test]
        public void IDictionary_ElementNotContained()
        {
            Raise<ApplicationException>.IfIsContainedIn(1, new Dictionary<int, int>());
        }

        [Test]
        public void IDictionary_ElementNotContained_WithMsg()
        {
            Raise<ApplicationException>.IfIsContainedIn(1, new Dictionary<int, int>(), TestMessage);
        }

        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void List_ElementContained()
        {
            Raise<ApplicationException>.IfIsContainedIn(1, (IList)new List<int> { 1, 2, 3 });
        }

        [Test]
        [ExpectedException(typeof(ApplicationException), ExpectedMessage = TestMessage)]
        public void List_ElementContained_WithMsg()
        {
            Raise<ApplicationException>.IfIsContainedIn(1, (IList)new List<int> { 1, 2, 3 }, TestMessage);
        }

        [Test]
        public void List_ElementNotContained()
        {
            Raise<ApplicationException>.IfIsContainedIn(1, (IList)new List<int>());
        }

        [Test]
        public void List_ElementNotContained_WithMsg()
        {
            Raise<ApplicationException>.IfIsContainedIn(1, (IList)new List<int>(), TestMessage);
        }

        [Test]
        public void Not_ElementContained()
        {
            Raise<ApplicationException>.IfIsNotContainedIn(1, new List<int> { 1, 2, 3 });
        }

        [Test]
        public void Not_ElementContained_WithMsg()
        {
            Raise<ApplicationException>.IfIsNotContainedIn(1, new List<int> { 1, 2, 3 }, TestMessage);
        }

        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void Not_ElementNotContained()
        {
            Raise<ApplicationException>.IfIsNotContainedIn(1, new List<int>());
        }

        [Test]
        [ExpectedException(typeof(ApplicationException), ExpectedMessage = TestMessage)]
        public void Not_ElementNotContained_WithMsg()
        {
            Raise<ApplicationException>.IfIsNotContainedIn(1, new List<int>(), TestMessage);
        }

        [Test]
        public void Not_IDictionary2_ElementContained()
        {
            Raise<ApplicationException>.IfIsNotContainedIn(1, 4, new Dictionary<int, int> { { 1, 4 }, { 2, 5 }, { 3, 6 } });
        }

        [Test]
        public void Not_IDictionary2_ElementContained_WithMsg()
        {
            Raise<ApplicationException>.IfIsNotContainedIn(1, 4, new Dictionary<int, int> { { 1, 4 }, { 2, 5 }, { 3, 6 } }, TestMessage);
        }

        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void Not_IDictionary2_ElementNotContained()
        {
            Raise<ApplicationException>.IfIsNotContainedIn(1, 4, new Dictionary<int, int>());
        }

        [Test]
        [ExpectedException(typeof(ApplicationException), ExpectedMessage = TestMessage)]
        public void Not_IDictionary2_ElementNotContained_WithMsg()
        {
            Raise<ApplicationException>.IfIsNotContainedIn(1, 4, new Dictionary<int, int>(), TestMessage);
        }

        [Test]
        public void Not_IDictionary_ElementContained()
        {
            Raise<ApplicationException>.IfIsNotContainedIn(1, new HybridDictionary { { 1, 4 }, { 2, 5 }, { 3, 6 } });
        }

        [Test]
        public void Not_IDictionary_ElementContained_WithMsg()
        {
            Raise<ApplicationException>.IfIsNotContainedIn(1, new HybridDictionary { { 1, 4 }, { 2, 5 }, { 3, 6 } }, TestMessage);
        }

        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void Not_IDictionary_ElementNotContained()
        {
            Raise<ApplicationException>.IfIsNotContainedIn(1, new Dictionary<int, int>());
        }

        [Test]
        [ExpectedException(typeof(ApplicationException), ExpectedMessage = TestMessage)]
        public void Not_IDictionary_ElementNotContained_WithMsg()
        {
            Raise<ApplicationException>.IfIsNotContainedIn(1, new Dictionary<int, int>(), TestMessage);
        }

        [Test]
        public void Not_IList_ElementContained()
        {
            Raise<ApplicationException>.IfIsNotContainedIn(1, (IList)new List<int> { 1, 2, 3 });
        }

        [Test]
        public void Not_IList_ElementContained_WithMsg()
        {
            Raise<ApplicationException>.IfIsNotContainedIn(1, (IList)new List<int> { 1, 2, 3 }, TestMessage);
        }

        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void Not_IList_ElementNotContained()
        {
            Raise<ApplicationException>.IfIsNotContainedIn(1, (IList)new List<int>());
        }

        [Test]
        [ExpectedException(typeof(ApplicationException), ExpectedMessage = TestMessage)]
        public void Not_IList_ElementNotContained_WithMsg()
        {
            Raise<ApplicationException>.IfIsNotContainedIn(1, (IList)new List<int>(), TestMessage);
        }
    }
}