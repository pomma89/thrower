// File name: RaiseVsThrow.cs
// 
// Author(s): Alessio Parma <alessio.parma@gmail.com>
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

using BenchmarkDotNet.Attributes;
using System;

namespace PommaLabs.Thrower.Benchmarks
{
    [Config("jobs=AllJits")]
    public class RaiseVsThrow
    {
        private static T Identity<T>(T value) => value;

        #region ArgumentNullException

        [Benchmark]
        public void Raise_ArgumentNullException()
        {
            try
            {
                var nullString = Identity<string>(null);
                RaiseArgumentNullException.IfIsNull(nullString, nameof(nullString));
            }
#pragma warning disable CC0004 // Catch block cannot be empty
#pragma warning disable RECS0022 // A catch clause that catches System.Exception and has an empty body
            catch
            {
            }
#pragma warning restore RECS0022 // A catch clause that catches System.Exception and has an empty body
#pragma warning restore CC0004 // Catch block cannot be empty
        }

        [Benchmark]
        public void Throw_ArgumentNullException()
        {
            try
            {
                var nullString = Identity<string>(null);
                if (nullString == null)
                {
                    throw new ArgumentNullException(nameof(nullString));
                }
            }
#pragma warning disable CC0004 // Catch block cannot be empty
#pragma warning disable RECS0022 // A catch clause that catches System.Exception and has an empty body
            catch
            {
            }
#pragma warning restore RECS0022 // A catch clause that catches System.Exception and has an empty body
#pragma warning restore CC0004 // Catch block cannot be empty
        }

        #endregion ArgumentNullException

        #region ArgumentOutOfRangeException

        [Benchmark]
        public void Raise_ArgumentOutOfRangeException_Integers()
        {
            try
            {
                var x = Identity(21);
                var y = Identity(3);
                RaiseArgumentOutOfRangeException.IfIsGreaterOrEqual(x, y, nameof(x));
            }
#pragma warning disable CC0004 // Catch block cannot be empty
#pragma warning disable RECS0022 // A catch clause that catches System.Exception and has an empty body
            catch
            {
            }
#pragma warning restore RECS0022 // A catch clause that catches System.Exception and has an empty body
#pragma warning restore CC0004 // Catch block cannot be empty
        }

        [Benchmark]
        public void Throw_ArgumentOutOfRangeException_Integers()
        {
            try
            {
                var x = Identity(21);
                var y = Identity(3);
                if (x >= y)
                {
                    throw new ArgumentOutOfRangeException(nameof(x));
                }
            }
#pragma warning disable CC0004 // Catch block cannot be empty
#pragma warning disable RECS0022 // A catch clause that catches System.Exception and has an empty body
            catch
            {
            }
#pragma warning restore RECS0022 // A catch clause that catches System.Exception and has an empty body
#pragma warning restore CC0004 // Catch block cannot be empty
        }

        #endregion ArgumentOutOfRangeException
    }
}
