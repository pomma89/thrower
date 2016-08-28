![](https://googledrive.com/host/0B8v0ikF4z2BiR29YQmxfSlE1Sms/Progetti/Thrower/logo-64.png "Thrower Logo") Thrower
==================================================================================================================

*Fully managed library providing convenience methods to perform argument checks.*

## Summary ##

* Latest release version: `v3.0.2`
* Build status on [AppVeyor](https://ci.appveyor.com): [![Build status](https://ci.appveyor.com/api/projects/status/xjkp8gn0cf4s7qbg?svg=true)](https://ci.appveyor.com/project/pomma89/thrower)
* [Doxygen](http://www.stack.nl/~dimitri/doxygen/index.html) documentation:
    + [HTML](https://goo.gl/iO6qZG)
    + [PDF](https://goo.gl/lZ7K9h)
* [NuGet](https://www.nuget.org) package(s):
    + [PommaLabs.Thrower](https://nuget.org/packages/Thrower/)

## Introduction ##

This library allows to write preconditions like the ones exposed in the following example:

```cs

/// <summary>
///   Simple example for Thrower.
/// </summary>
internal static class BankExample
{
    /// <summary>
    ///   My bank implementation.
    /// </summary>
    internal sealed class MyBank
    {
        /// <summary>
        ///   Stores whether this bank is open or not.
        /// </summary>
        private bool _isOpen;

        /// <summary>
        ///   The amount held into the bank.
        /// </summary>
        public decimal Amount { get; private set; }

        /// <summary>
        ///   Customers are very polite and say hello.
        /// </summary>
        /// <param name="helloMsg">The hello message.</param>
        /// <exception cref="ArgumentException">The hello message is null or blank.</exception>
        public void SayHello(string helloMsg)
        {
            // Preconditions
            Raise.ArgumentException.IfIsNullOrWhiteSpace(helloMsg, nameof(helloMsg), "Hello message is null or blank");

            Console.WriteLine(helloMsg);
        }

        /// <summary>
        ///   Deposits given amount into the bank.
        /// </summary>
        /// <param name="amount">A positive amount of money.</param>
        /// <exception cref="ArgumentOutOfRangeException">Amount is zero or negative.</exception>
        /// <exception cref="InvalidOperationException">Bank is closed.</exception>
        /// <exception cref="OverNineThousandException">Amount is over nine thousand!</exception>
        public void Deposit(decimal amount)
        {
            // Preconditions
            Raise.InvalidOperationException.IfNot(_isOpen, "Bank is still closed");
            Raise.ArgumentOutOfRangeException.IfIsLessOrEqual(amount, 0, nameof(amount), "Zero or negative amount");
            Raise<OverNineThousandException>.If(amount > 9000M, "You are too rich!");

            Amount += amount;
        }

        /// <summary>
        ///   Sends an email address from and to given addresses using the specified body.
        /// </summary>
        /// <param name="fromAddress">The address which sent the email. International characters are _not_ allowed.</param>
        /// <param name="toAddress">The address which will receive the email. International characters are allowed.</param>
        /// <param name="body">The message body.</param>
        /// <exception cref="ArgumentException">
        ///   Given email addresses are not valid. Given body is null, empty or blank.
        /// </exception>
        public void SendMail(string fromAddress, string toAddress, string body)
        {
            // Preconditions
            Raise.ArgumentException.IfIsNotValidEmailAddress(fromAddress, nameof(fromAddress), EmailAddressValidator.Options.AllowTopLevelDomains);
            Raise.ArgumentException.IfIsNotValidEmailAddress(toAddress, nameof(toAddress), EmailAddressValidator.Options.AllowInternational);
            Raise.ArgumentException.IfIsNullOrWhiteSpace(body, nameof(body), "The email body cannot be blank");

            Console.WriteLine($"From: {fromAddress}");
            Console.WriteLine($"To: {toAddress}");
            Console.WriteLine($"Message: {body}");
        }

        /// <summary>
        ///   Opens the bank.
        /// </summary>
        public void Open()
        {
            _isOpen = true;
        }
    }

    /// <summary>
    ///   Too rich for this bank.
    /// </summary>
    internal sealed class OverNineThousandException : Exception
    {
        /// <summary>
        ///   Without a custom message.
        /// </summary>
        public OverNineThousandException() : base("It's over nine thousand!")
        {
        }

        /// <summary>
        ///   With a custom message.
        /// </summary>
        /// <param name="msg">The custom message.</param>
        public OverNineThousandException(string msg) : base(msg + " - It's over nine thousand!")
        {
        }
    }

    /// <summary>
    ///   Simple example for Thrower.
    /// </summary>
    private static void Main()
    {
        var bank = new MyBank();

        try
        {
            // Say nothing!
            bank.SayHello("   ");
        }
        catch (ArgumentException ex)
        {
            // Polite people say meaningful things.
            Console.Error.WriteLine(ex.Message);
        }

        bank.SayHello("Good morning!"); // Everything OK!

        try
        {
            bank.Deposit(100);
        }
        catch (InvalidOperationException ex)
        {
            // Bank is still closed.
            Console.Error.WriteLine(ex.Message);
        }

        bank.Open();
        try
        {
            bank.Deposit(-1000);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            // Cannot deposit a negative amount.
            Console.Error.WriteLine(ex.Message);
        }

        try
        {
            bank.Deposit(9001M);
        }
        catch (OverNineThousandException ex)
        {
            // Cannot deposit more than 9000.
            Console.Error.WriteLine(ex.Message);
        }

        bank.Deposit(10); // Everything OK!
        Console.WriteLine("Amount: " + bank.Amount);

        // Send an email with current amount.
        bank.SendMail("info@mybank.org", "юзер@екзампл.ком", $"Your current amount is {bank.Amount}");

        Console.Read();
    }
}

```

You can find more examples under the [Thrower.Examples](https://github.com/pomma89/Thrower/tree/master/Thrower.Examples)
and [Thrower.UnitTests](https://github.com/pomma89/Thrower/tree/master/Thrower.UnitTests) projects.
In any case, usage of this library should be pretty straightforward.

## Exception handlers ##

`Raise` static class exposes an increasing number of what we call "exception handlers", that is,
custom objects which allow writing preconditions as shown in above example.

Each handler is tied to one specific exception and exposes methods to allow writing fluent preconditions
depending on which exception it has been defined for.

Let's see some examples.

### System ###

```cs

Raise.ArgumentNullException.IfIsNull(session, nameof(session), "Session object is mandatory");
Raise.ArgumentOutOfRangeException.IfIsGreater(loginAttemptCount, 5, nameof(loginAttemptCount), "Too many login attempts!");

```

### System.IO ###

```cs

Raise.FileNotFoundException.IfNotExists("C:\\temp.txt", "Cannot find temp file");
Raise.DirectoryNotFoundException.IfNotExists("C:\\Users\\dev", "Cannot find 'dev' home directory");
Raise.IOException.IfNot(outStream.CanWrite, "Specified output stream does not allow writing");

```

### System.Net ###

```cs

Raise.HttpException.IfNot(user.IsLoggedIn, HttpStatusCode.Unauthorized, "User should perform login");

```

## Benchmarks ##

Following benchmarks compare `Raise*` methods againt the common `if (true) throw exception` statements.

All benchmarks show that the time difference is really small and hardly noticeable;
therefore, using Thrower does not impose a penalty on your application performance, even on hot paths.

```ini

Host Process Environment Information:
BenchmarkDotNet.Core=v0.9.9.0
OS=Microsoft Windows NT 6.1.7601 Service Pack 1
Processor=Intel(R) Core(TM) i7-3630QM CPU 2.40GHz, ProcessorCount=8
Frequency=2338505 ticks, Resolution=427.6236 ns, Timer=TSC
CLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
GC=Concurrent Workstation
JitModules=clrjit-v4.6.1590.0

Type=RaiseVsThrow  Mode=Throughput

```
                                           Method | Platform |       Jit |     Median |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
------------------------------------------------- |--------- |---------- |----------- |---------- |------- |------ |------ |------------------- |
                      Raise_ArgumentNullException |      X64 | LegacyJit | 14.6587 us | 0.1218 us |  10.10 |     - |     - |             185,59 |
                RaiseStatic_ArgumentNullException |      X64 | LegacyJit | 17.5628 us | 0.1029 us |  14.36 |     - |     - |             256,63 |
                      Throw_ArgumentNullException |      X64 | LegacyJit | 15.6713 us | 0.4333 us |   9.14 |     - |     - |             194,65 |
       Raise_ArgumentOutOfRangeException_Integers |      X64 | LegacyJit | 11.2094 us | 0.1511 us |   7.62 |     - |     - |             137,79 |
 RaiseStatic_ArgumentOutOfRangeException_Integers |      X64 | LegacyJit | 11.2630 us | 0.2221 us |   6.87 |     - |     - |             124,72 |
       Throw_ArgumentOutOfRangeException_Integers |      X64 | LegacyJit | 11.6393 us | 0.2122 us |   7.25 |     - |     - |             131,22 |
                      Raise_NotSupportedException |      X64 | LegacyJit | 38.5153 us | 1.0735 us | 142.07 |     - |     - |           2.639,01 |
               RaiseGeneric_NotSupportedException |      X64 | LegacyJit | 42.3143 us | 0.5898 us | 169.05 |     - |     - |           3.139,10 |
                RaiseStatic_NotSupportedException |      X64 | LegacyJit | 38.4069 us | 0.6297 us | 155.50 |     - |     - |           2.855,48 |
                      Throw_NotSupportedException |      X64 | LegacyJit | 23.7628 us | 0.8847 us |  62.84 |     - |     - |           1.284,40 |
                      Raise_FileNotFoundException |      X64 | LegacyJit | 53.2149 us | 0.9557 us |      - |     - |     - |             311,87 |
                      Throw_FileNotFoundException |      X64 | LegacyJit | 50.6233 us | 0.3536 us |      - |     - |     - |             233,45 |
                      Raise_ArgumentNullException |      X64 |    RyuJit | 13.6926 us | 0.0397 us |   9.25 |     - |     - |             170,65 |
                RaiseStatic_ArgumentNullException |      X64 |    RyuJit | 15.7933 us | 0.2740 us |   8.52 |     - |     - |             181,26 |
                      Throw_ArgumentNullException |      X64 |    RyuJit | 16.0593 us | 3.8467 us |   9.66 |     - |     - |             205,28 |
       Raise_ArgumentOutOfRangeException_Integers |      X64 |    RyuJit | 13.2862 us | 0.0385 us |  10.57 |     - |     - |             198,03 |
 RaiseStatic_ArgumentOutOfRangeException_Integers |      X64 |    RyuJit |  8.6512 us | 0.1483 us |   7.41 |     - |     - |             134,07 |
       Throw_ArgumentOutOfRangeException_Integers |      X64 |    RyuJit |  8.6498 us | 0.1572 us |   7.17 |     - |     - |             129,52 |
                      Raise_NotSupportedException |      X64 |    RyuJit | 27.9515 us | 1.0770 us | 135.89 |     - |     - |           2.523,74 |
               RaiseGeneric_NotSupportedException |      X64 |    RyuJit | 29.9210 us | 0.8526 us | 148.00 |     - |     - |           2.761,79 |
                RaiseStatic_NotSupportedException |      X64 |    RyuJit | 26.9868 us | 0.6985 us | 151.22 |     - |     - |           2.778,91 |
                      Throw_NotSupportedException |      X64 |    RyuJit | 17.1639 us | 0.5002 us |  73.37 |     - |     - |           1.383,10 |
                      Raise_FileNotFoundException |      X64 |    RyuJit | 39.5122 us | 0.3098 us |   8.13 |     - |     - |             247,48 |
                      Throw_FileNotFoundException |      X64 |    RyuJit | 37.8486 us | 0.3952 us |   8.68 |     - |     - |             217,39 |
                      Raise_ArgumentNullException |      X86 | LegacyJit | 13.3714 us | 0.1751 us |   4.16 |     - |     - |              80,93 |
                RaiseStatic_ArgumentNullException |      X86 | LegacyJit | 16.7906 us | 0.2125 us |   5.00 |     - |     - |             110,53 |
                      Throw_ArgumentNullException |      X86 | LegacyJit | 16.2845 us | 0.2783 us |   5.30 |     - |     - |             116,32 |
       Raise_ArgumentOutOfRangeException_Integers |      X86 | LegacyJit | 12.8385 us | 0.0832 us |   4.54 |     - |     - |              89,78 |
 RaiseStatic_ArgumentOutOfRangeException_Integers |      X86 | LegacyJit | 13.1328 us | 0.4223 us |      - |     - |     - |              65,74 |
       Throw_ArgumentOutOfRangeException_Integers |      X86 | LegacyJit | 17.1409 us | 0.4553 us |      - |     - |     - |              61,00 |
                      Raise_NotSupportedException |      X86 | LegacyJit | 43.6108 us | 0.7787 us | 127.21 |     - |     - |           2.401,45 |
               RaiseGeneric_NotSupportedException |      X86 | LegacyJit | 43.7694 us | 1.9157 us | 130.03 |     - |     - |           2.462,43 |
                RaiseStatic_NotSupportedException |      X86 | LegacyJit | 41.0660 us | 0.9476 us | 145.76 |     - |     - |           2.723,65 |
                      Throw_NotSupportedException |      X86 | LegacyJit | 27.6131 us | 0.6346 us |  62.84 |     - |     - |           1.207,41 |
                      Raise_FileNotFoundException |      X86 | LegacyJit | 61.6230 us | 1.3517 us |      - |     - |     - |             192,57 |
                      Throw_FileNotFoundException |      X86 | LegacyJit | 45.0559 us | 0.5427 us |      - |     - |     - |             146,95 |

## About this repository and its maintainer ##

Everything done on this repository is freely offered on the terms of the project license. You are free to do everything you want with the code and its related files, as long as you respect the license and use common sense while doing it :-)

As of now, I do not have plans to expand Thrower much beyond what it currently is. There are many ways in which it can be improved, I know, but as of now the library suits my needs and I have not much time to improve it. If I will have time, I will try to make it better, of course.
