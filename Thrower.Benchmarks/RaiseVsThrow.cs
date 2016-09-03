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
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

#pragma warning disable CC0091 // Use static method

namespace PommaLabs.Thrower.Benchmarks
{
    [Config(typeof(Config))]
    public class RaiseVsThrow
    {
        private static readonly Random Rnd = new Random();

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static T Identity<T>(T value) => value;

        private class Config : ManualConfig
        {
            public Config()
            {
                Add(Job.AllJits);
                Add(GetColumns().ToArray());
                Add(CsvExporter.Default, HtmlExporter.Default, MarkdownExporter.GitHub, PlainExporter.Default);
                Add(new MemoryDiagnoser());
                Add(EnvironmentAnalyser.Default);
            }
        }

        #region ArgumentNullException

        [Benchmark]
        public Exception Raise_ArgumentNullException()
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
        public Exception RaiseGeneric_ArgumentNullException()
        {
            try
            {
                var nullString = Identity<string>(null);
                Raise<ArgumentNullException>.If(nullString == null, nameof(nullString));
            }
            catch (Exception ex)
            {
                return ex;
            }
            return default(Exception);
        }

        [Benchmark]
        public Exception Throw_ArgumentNullException()
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
        public Exception Raise_ArgumentOutOfRangeException_Integers()
        {
            try
            {
                var x = Identity(21);
                var y = Identity(3);
                Raise.ArgumentOutOfRangeException.IfIsGreaterOrEqual(x, y, nameof(x));
            }
            catch (Exception ex)
            {
                return ex;
            }
            return default(Exception);
        }

        [Benchmark]
        public Exception RaiseGeneric_ArgumentOutOfRangeException_Integers()
        {
            try
            {
                var x = Identity(21);
                var y = Identity(3);
                Raise<ArgumentOutOfRangeException>.If(x >= y, nameof(x));
            }
            catch (Exception ex)
            {
                return ex;
            }
            return default(Exception);
        }

        [Benchmark]
        public Exception Throw_ArgumentOutOfRangeException_Integers()
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

        #region NotSupportedException

        [Benchmark]
        public Exception Raise_NotSupportedException()
        {
            try
            {
                var b = Identity(Rnd.Next() % 2 == 0);
                Raise.NotSupportedException.If(b, Environment.UserDomainName);
            }
            catch (Exception ex)
            {
                return ex;
            }
            return default(Exception);
        }

        [Benchmark]
        public Exception RaiseGeneric_NotSupportedException()
        {
            try
            {
                var b = Identity(Rnd.Next() % 2 == 0);
                Raise<NotSupportedException>.If(b, Environment.UserDomainName);
            }
            catch (Exception ex)
            {
                return ex;
            }
            return default(Exception);
        }

        [Benchmark]
        public Exception Throw_NotSupportedException()
        {
            try
            {
                var b = Identity(Rnd.Next() % 2 == 0);
                if (b)
                {
                    throw new NotSupportedException(Environment.UserDomainName);
                }
            }
            catch (Exception ex)
            {
                return ex;
            }
            return default(Exception);
        }

        #endregion NotSupportedException

        #region FileNotFoundException

        private static readonly string NotExistingFilePath = Path.Combine(Environment.CurrentDirectory, Guid.NewGuid() + ".bench");

        [Benchmark]
        public FileNotFoundException Raise_FileNotFoundException()
        {
            try
            {
                Raise.FileNotFoundException.IfNotExists(NotExistingFilePath, NotExistingFilePath);
            }
            catch (FileNotFoundException ex)
            {
                return ex;
            }
            return default(FileNotFoundException);
        }

        [Benchmark]
        public FileNotFoundException RaiseGeneric_FileNotFoundException()
        {
            try
            {
                Raise<FileNotFoundException>.IfNot(File.Exists(NotExistingFilePath), NotExistingFilePath);
            }
            catch (FileNotFoundException ex)
            {
                return ex;
            }
            return default(FileNotFoundException);
        }

        [Benchmark]
        public FileNotFoundException Throw_FileNotFoundException()
        {
            try
            {
                if (!File.Exists(NotExistingFilePath))
                {
                    throw new FileNotFoundException(NotExistingFilePath, NotExistingFilePath);
                }
            }
            catch (FileNotFoundException ex)
            {
                return ex;
            }
            return default(FileNotFoundException);
        }

        #endregion FileNotFoundException
    }
}

#pragma warning restore CC0091 // Use static method
