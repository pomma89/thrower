![](http://pomma89.altervista.org/thrower/logo-64.png "Thrower Logo") Thrower
==================================================================================================================

*Fully managed library providing convenience methods to perform argument checks.*

## Summary ##

* Latest release version: `v4.0.1`
* Build status on [AppVeyor](https://ci.appveyor.com): [![Build status](https://ci.appveyor.com/api/projects/status/xjkp8gn0cf4s7qbg?svg=true)](https://ci.appveyor.com/project/pomma89/thrower)
* [Doxygen](http://www.stack.nl/~dimitri/doxygen/index.html) documentation:
    + [HTML](http://pomma89.altervista.org/thrower/doc/html/index.html)
    + [CHM](http://pomma89.altervista.org/thrower/doc/refman.chm)
    + [PDF](http://pomma89.altervista.org/thrower/doc/refman.pdf)
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

If you need an exception handler for an exception which is defined inside the .NET Framework itself, please let me know.
I will evaluate whether it can be added safely and, if possible, I will gladly add it.

Let's see some examples.

### System ###

```cs

Raise.ArgumentNullException.IfIsNull(session, nameof(session), "Session object is mandatory");
Raise.ArgumentException.IfIsNullOrWhiteSpace(userName, nameof(userName), "User name cannot be null, empty or blank");
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

## Generic exception handler ##

If a standard handler has not been provided for an exception you would like to use, then you can try using the generic exception handler.
Through the usage of reflection, it will try to discover required exception constructors and it will use them when it will need to create an exception object.

Let's see some examples.

```cs

// If condition is true, given exception type will be thrown
// using the empty constructor.
Raise<FileNotFoundException>.If(condition);

// If condition is true, given exception type will be thrown 
// using a constructor which accepts a string as first and only argument,
// or a constructor which accepts a string and an Exception as only arguments.
Raise<FileNotFoundException>.If(condition, message);

// If condition is true, given exception type will be thrown 
// using a constructor which accepts all given parameters.
// Types are read from objects themselves, therefore no nulls are allowed.
Raise<FileNotFoundException>.If(condition, message, fileName);

```

## Benchmarks ##

All benchmarks were implemented and run using the wonderful [BenchmarkDotNet](https://github.com/PerfDotNet/BenchmarkDotNet) library.

### Raise VS Throw ###

In this benchmark we try to understand how great is the speed difference between the standard .NET `if (true) throw exception` statement
and our fluent syntax based on the `Raise` static classes.

As we can see by the results, the speed difference, if any, is really small.
Therefore, using Thrower does not impose a penalty on your application performance, even on hot paths.

```ini

Host Process Environment Information:
BenchmarkDotNet.Core=v0.9.9.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=AMD A10 Extreme Edition Radeon R8, 4C+8G, ProcessorCount=4
Frequency=1949466 ticks, Resolution=512.9610 ns, Timer=TSC
CLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
GC=Concurrent Workstation
JitModules=clrjit-v4.6.1586.0

Type=RaiseVsThrow  Mode=Throughput  

```
                                            Method | Platform |       Jit |     Median |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
-------------------------------------------------- |--------- |---------- |----------- |---------- |------- |------ |------ |------------------- |
                       Raise_ArgumentNullException |      X64 | LegacyJit | 19.4598 us | 2.2264 us |  70.26 |     - |     - |             202,91 |
                RaiseGeneric_ArgumentNullException |      X64 | LegacyJit | 20.5114 us | 2.2677 us |  82.38 |     - |     - |             245,60 |
                       Throw_ArgumentNullException |      X64 | LegacyJit | 21.2052 us | 1.8214 us |  76.53 |     - |     - |             221,82 |
        Raise_ArgumentOutOfRangeException_Integers |      X64 | LegacyJit | 16.0512 us | 0.3671 us |  45.22 |     - |     - |             139,63 |
 RaiseGeneric_ArgumentOutOfRangeException_Integers |      X64 | LegacyJit | 21.2193 us | 0.6900 us |  60.94 |     - |     - |             203,39 |
        Throw_ArgumentOutOfRangeException_Integers |      X64 | LegacyJit | 16.7877 us | 0.5422 us |  36.41 |     - |     - |             112,75 |
                       Raise_NotSupportedException |      X64 | LegacyJit | 68.8451 us | 2.6265 us | 850.26 |     - |     - |           2.707,33 |
                RaiseGeneric_NotSupportedException |      X64 | LegacyJit | 69.1418 us | 2.2036 us | 832.85 |     - |     - |           2.675,19 |
                       Throw_NotSupportedException |      X64 | LegacyJit | 37.9874 us | 1.2729 us | 463.49 |     - |     - |           1.491,24 |
                       Raise_FileNotFoundException |      X64 | LegacyJit | 46.6647 us | 1.8406 us |  86.67 |     - |     - |             263,40 |
                RaiseGeneric_FileNotFoundException |      X64 | LegacyJit | 58.1295 us | 1.8440 us | 322.36 |     - |     - |             971,09 |
                       Throw_FileNotFoundException |      X64 | LegacyJit | 44.6001 us | 1.7770 us |  78.14 |     - |     - |             242,28 |
                       Raise_ArgumentNullException |      X64 |    RyuJit | 19.3501 us | 0.3927 us |  59.06 |     - |     - |             172,85 |
                RaiseGeneric_ArgumentNullException |      X64 |    RyuJit | 20.8158 us | 0.8918 us |  68.60 |     - |     - |             207,16 |
                       Throw_ArgumentNullException |      X64 |    RyuJit | 21.2471 us | 0.4470 us |  58.42 |     - |     - |             170,82 |
        Raise_ArgumentOutOfRangeException_Integers |      X64 |    RyuJit | 19.0926 us | 0.5794 us |  57.75 |     - |     - |             172,35 |
 RaiseGeneric_ArgumentOutOfRangeException_Integers |      X64 |    RyuJit | 20.8386 us | 1.6873 us |  80.82 |     - |     - |             245,02 |
        Throw_ArgumentOutOfRangeException_Integers |      X64 |    RyuJit | 16.4849 us | 1.5610 us |  36.56 |     - |     - |             113,32 |
                       Raise_NotSupportedException |      X64 |    RyuJit | 64.9682 us | 6.1236 us | 964.69 |     - |     - |           3.065,50 |
                RaiseGeneric_NotSupportedException |      X64 |    RyuJit | 66.7680 us | 6.4114 us | 851.00 |     - |     - |           2.737,36 |
                       Throw_NotSupportedException |      X64 |    RyuJit | 36.4718 us | 4.1340 us | 499.68 |     - |     - |           1.603,28 |
                       Raise_FileNotFoundException |      X64 |    RyuJit | 45.0476 us | 5.6415 us | 108.35 |     - |     - |             325,82 |
                RaiseGeneric_FileNotFoundException |      X64 |    RyuJit | 54.6205 us | 6.0381 us | 268.42 |     - |     - |             810,22 |
                       Throw_FileNotFoundException |      X64 |    RyuJit | 43.0069 us | 4.8986 us |  84.47 |     - |     - |             260,59 |
                       Raise_ArgumentNullException |      X86 | LegacyJit | 28.5803 us | 2.6866 us |  26.08 |     - |     - |              83,76 |
                RaiseGeneric_ArgumentNullException |      X86 | LegacyJit | 28.4951 us | 3.1659 us |  32.04 |     - |     - |             122,46 |
                       Throw_ArgumentNullException |      X86 | LegacyJit | 30.1121 us | 1.6242 us |  24.62 |     - |     - |              94,57 |
        Raise_ArgumentOutOfRangeException_Integers |      X86 | LegacyJit | 27.7911 us | 1.7208 us |  26.90 |     - |     - |              91,69 |
 RaiseGeneric_ArgumentOutOfRangeException_Integers |      X86 | LegacyJit | 29.7994 us | 2.7528 us |  40.08 |     - |     - |             115,39 |
        Throw_ArgumentOutOfRangeException_Integers |      X86 | LegacyJit | 26.9246 us | 2.3180 us |  21.48 |     - |     - |              75,81 |
                       Raise_NotSupportedException |      X86 | LegacyJit | 84.1955 us | 6.2050 us | 901.09 |     - |     - |           2.856,95 |
                RaiseGeneric_NotSupportedException |      X86 | LegacyJit | 81.5286 us | 8.9884 us | 885.70 |     - |     - |           2.822,94 |
                       Throw_NotSupportedException |      X86 | LegacyJit | 44.1595 us | 5.8223 us | 366.13 |     - |     - |           1.181,60 |
                       Raise_FileNotFoundException |      X86 | LegacyJit | 53.6902 us | 5.3819 us |  64.03 |     - |     - |             212,89 |
                RaiseGeneric_FileNotFoundException |      X86 | LegacyJit | 65.1958 us | 6.4757 us | 215.12 |     - |     - |             655,93 |
                       Throw_FileNotFoundException |      X86 | LegacyJit | 53.6464 us | 5.7552 us |  54.25 |     - |     - |             187,31 |

## About this repository and its maintainer ##

Everything done on this repository is freely offered on the terms of the project license. You are free to do everything you want with the code and its related files, as long as you respect the license and use common sense while doing it :-)

As of now, I do not have plans to expand Thrower much beyond what it currently is. There are many ways in which it can be improved, I know, but as of now the library suits my needs and I have not much time to improve it. If I will have time, I will try to make it better, of course.
