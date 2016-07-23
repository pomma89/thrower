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
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT
// OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using BenchmarkDotNet.Analysers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnostics.Windows;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using System;
using System.Linq;

namespace PommaLabs.Thrower.Benchmarks
{
    [Config(typeof(Config))]
    public class RaiseVsThrow
    {
        private static T Identity<T>(T value) => value;

        private class Config : ManualConfig
        {
            public Config()
            {
                Add(Job.Default);
                Add(GetColumns().ToArray());
                Add(CsvExporter.Default, HtmlExporter.Default, MarkdownExporter.GitHub, PlainExporter.Default);
                Add(new MemoryDiagnoser());
                Add(EnvironmentAnalyser.Default);
            }
        }

        #region ArgumentNullException

        [Benchmark]
#pragma warning disable CC0091 // Use static method
        public Exception Raise_ArgumentNullException()
#pragma warning restore CC0091 // Use static method
        {
            try
            {
                var nullString = Identity<string>(null);
                Raise.ArgumentNullException.IfIsNull(nullString, nameof(nullString));
            }
            catch (Exception ex)
            {
                return ex;
            }
            return default(Exception);
        }

        [Benchmark]
#pragma warning disable CC0091 // Use static method
        public Exception RaiseStatic_ArgumentNullException()
#pragma warning restore CC0091 // Use static method
        {
            try
            {
                var nullString = Identity<string>(null);
#pragma warning disable CS0618 // Type or member is obsolete
                RaiseArgumentNullException.IfIsNull(nullString, nameof(nullString));
#pragma warning restore CS0618 // Type or member is obsolete
            }
            catch (Exception ex)
            {
                return ex;
            }
            return default(Exception);
        }

        [Benchmark]
#pragma warning disable CC0091 // Use static method
        public Exception Throw_ArgumentNullException()
#pragma warning restore CC0091 // Use static method
        {
            try
            {
                var nullString = Identity<string>(null);
                if (nullString == null)
                {
                    throw new ArgumentNullException(nameof(nullString));
                }
            }
            catch (Exception ex)
            {
                return ex;
            }
            return default(Exception);
        }

        #endregion ArgumentNullException

        #region ArgumentOutOfRangeException

        [Benchmark]
#pragma warning disable CC0091 // Use static method
        public Exception RaiseStatic_ArgumentOutOfRangeException_Integers()
#pragma warning restore CC0091 // Use static method
        {
            try
            {
                var x = Identity(21);
                var y = Identity(3);
                RaiseArgumentOutOfRangeException.IfIsGreaterOrEqual(x, y, nameof(x));
            }
            catch (Exception ex)
            {
                return ex;
            }
            return default(Exception);
        }

        [Benchmark]
#pragma warning disable CC0091 // Use static method
        public Exception Throw_ArgumentOutOfRangeException_Integers()
#pragma warning restore CC0091 // Use static method
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
            catch (Exception ex)
            {
                return ex;
            }
            return default(Exception);
        }

        #endregion ArgumentOutOfRangeException
    }
}