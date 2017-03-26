using NUnit.Common;
using NUnitLite;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PommaLabs.Thrower.UnitTests
{
    internal static class Program
    {
        public static int Main(string[] args)
        {
#if NETSTD16
            return new AutoRun(Assembly.GetEntryAssembly()).Execute(args, new ColorConsoleWriter(), Console.In);
#else
            return new AutoRun().Execute(args);
#endif
        }
    }
}