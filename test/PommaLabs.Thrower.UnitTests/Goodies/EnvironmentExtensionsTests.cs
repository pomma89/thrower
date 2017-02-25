// File name: EnvironmentExtensionsTests.cs
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
using PommaLabs.Thrower.Goodies;
using System;
using System.IO;

namespace PommaLabs.Thrower.UnitTests.Goodies
{
    sealed class EnvironmentExtensionsTests : AbstractTests
    {
        [Test]
        public void MapPath_NullString()
        {
            Assert.Throws<ArgumentNullException>(() => EnvironmentExtensions.MapPath(null));
        }

        [Test]
        public void MapPath_EmptyOrBlankIsBasePath()
        {
            var emptyMap = EnvironmentExtensions.MapPath(String.Empty);
            var blankMap = EnvironmentExtensions.MapPath("   ");
            var baseMap = EnvironmentExtensions.MapPath("~");
            Assert.AreEqual(baseMap, emptyMap);
            Assert.AreEqual(baseMap, blankMap);
        }

        [Test]
        public void MapPath_BasePathIsAppDomainDirectory()
        {
            var basePath = EnvironmentExtensions.MapPath("~");
            Assert.AreEqual(AppDomain.CurrentDomain.BaseDirectory, basePath);
        }

        [Test]
        public void MapPath_RootedPathIsEqualToRelative()
        {
            var rootedPath = EnvironmentExtensions.MapPath("~/my/test");
            var relativePath = EnvironmentExtensions.MapPath("my/test");
            Assert.AreEqual(Path.GetFullPath(rootedPath), Path.GetFullPath(relativePath));
        }

        [Test]
        public void MapPath_MappedPathIsAlwaysRooted()
        {
            Assert.IsTrue(Path.IsPathRooted(EnvironmentExtensions.MapPath("~/my/test")));
            Assert.IsTrue(Path.IsPathRooted(EnvironmentExtensions.MapPath("my/test")));
            Assert.IsTrue(Path.IsPathRooted(EnvironmentExtensions.MapPath("C:/my/test")));
        }
    }
}