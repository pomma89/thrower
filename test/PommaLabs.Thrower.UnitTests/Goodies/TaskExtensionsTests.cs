// File name: TaskExtensionsTests.cs
//
// Author(s): Alessio Parma <alessio.parma@gmail.com>
//
// The MIT License (MIT)
//
// Copyright (c) 2013-2018 Alessio Parma <alessio.parma@gmail.com>
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
using System.Collections.Concurrent;

namespace PommaLabs.Thrower.UnitTests.Goodies
{
    internal sealed class TaskExtensionsTests : AbstractTests
    {
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        public void AllFiredActionsShouldBeExecuted(int count)
        {
            var stack = new ConcurrentStack<int>();
            for (var i = 0; i < count; ++i)
            {
                var localIndex = i;
                Thrower.Goodies.TaskExtensions.TryFireAndForget(() => stack.Push(localIndex));
            }

            var delay = 30 * count;
#if (NET35 || NET40)
            System.Threading.Thread.Sleep(delay);
#else
            System.Threading.Tasks.Task.Delay(delay).Wait();
#endif

            stack.Count.ShouldBe(count);
        }
    }
}