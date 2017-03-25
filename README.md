![](http://pomma89.altervista.org/thrower/logo-64.png "Thrower Logo") Thrower
==================================================================================================================

*Fully managed library providing convenience methods to perform argument checks.*

## Summary ##

* Latest release version: `v4.1.2`
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
Raise.ArgumentException.IfIsNotValidEnum(enumValue, nameof(enumValue), "Given enum value is not defined");
Raise.ArgumentException.IfIsNotValidEmailAddress(email, nameof(email), "Given email address is not formally correct");
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

#### ArgumentNullException ####

![](http://pomma89.altervista.org/thrower/perf/RaiseVsThrow_ArgumentNullException-barplot.png "ArgumentNullException Barplot")

``` ini

BenchmarkDotNet=v0.10.1, OS=Microsoft Windows NT 6.2.9200.0
Processor=AMD A10 Extreme Edition Radeon R8, 4C+8G, ProcessorCount=4
Frequency=1949466 Hz, Resolution=512.9610 ns, Timer=TSC
  [Host]       : Clr 4.0.40319.42000, 32bit LegacyJIT-v4.6.1586.0
  LegacyJitX86 : Clr 4.0.40319.42000, 32bit LegacyJIT-v4.6.1586.0

Job=LegacyJitX86  Jit=LegacyJit  Platform=X86  
Runtime=Clr  

```
       Method |       Mean |    StdDev |  Gen 0 | Allocated |
------------- |----------- |---------- |------- |---------- |
        Raise | 27.6542 us | 0.3685 us |      - |     212 B |
 RaiseGeneric | 28.3600 us | 0.8988 us | 0.1053 |     252 B |
        Throw | 30.4583 us | 1.2295 us |      - |     244 B |

#### ArgumentOutOfRangeException ####

![](http://pomma89.altervista.org/thrower/perf/RaiseVsThrow_ArgumentOutOfRangeException-barplot.png "ArgumentOutOfRangeException Barplot")

``` ini

BenchmarkDotNet=v0.10.1, OS=Microsoft Windows NT 6.2.9200.0
Processor=AMD A10 Extreme Edition Radeon R8, 4C+8G, ProcessorCount=4
Frequency=1949466 Hz, Resolution=512.9610 ns, Timer=TSC
  [Host]       : Clr 4.0.40319.42000, 32bit LegacyJIT-v4.6.1586.0
  LegacyJitX86 : Clr 4.0.40319.42000, 32bit LegacyJIT-v4.6.1586.0

Job=LegacyJitX86  Jit=LegacyJit  Platform=X86  
Runtime=Clr  

```
       Method |       Mean |    StdDev |     Median | Allocated |
------------- |----------- |---------- |----------- |---------- |
        Raise | 26.9549 us | 1.5685 us | 27.4704 us |     216 B |
 RaiseGeneric | 28.1284 us | 1.8190 us | 29.0754 us |     256 B |
        Throw | 25.7824 us | 1.5455 us | 26.0318 us |     156 B |

#### FileNotFoundException ####

![](http://pomma89.altervista.org/thrower/perf/RaiseVsThrow_FileNotFoundException-barplot.png "FileNotFoundException Barplot")

``` ini

BenchmarkDotNet=v0.10.1, OS=Microsoft Windows NT 6.2.9200.0
Processor=AMD A10 Extreme Edition Radeon R8, 4C+8G, ProcessorCount=4
Frequency=1949466 Hz, Resolution=512.9610 ns, Timer=TSC
  [Host]       : Clr 4.0.40319.42000, 32bit LegacyJIT-v4.6.1586.0
  LegacyJitX86 : Clr 4.0.40319.42000, 32bit LegacyJIT-v4.6.1586.0

Job=LegacyJitX86  Jit=LegacyJit  Platform=X86  
Runtime=Clr  

```
       Method |       Mean |    StdDev |     Median |  Gen 0 | Allocated |
------------- |----------- |---------- |----------- |------- |---------- |
        Raise | 51.8919 us | 3.3312 us | 53.2313 us |      - |     440 B |
 RaiseGeneric | 59.0017 us | 3.5695 us | 60.1856 us | 1.5400 |   1.36 kB |
        Throw | 52.4837 us | 3.8547 us | 54.1780 us |      - |     380 B |

#### NotSupportedException ####

![](http://pomma89.altervista.org/thrower/perf/RaiseVsThrow_NotSupportedException-barplot.png "NotSupportedException Barplot")

``` ini

BenchmarkDotNet=v0.10.1, OS=Microsoft Windows NT 6.2.9200.0
Processor=AMD A10 Extreme Edition Radeon R8, 4C+8G, ProcessorCount=4
Frequency=1949466 Hz, Resolution=512.9610 ns, Timer=TSC
  [Host]       : Clr 4.0.40319.42000, 32bit LegacyJIT-v4.6.1586.0
  LegacyJitX86 : Clr 4.0.40319.42000, 32bit LegacyJIT-v4.6.1586.0

Job=LegacyJitX86  Jit=LegacyJit  Platform=X86  
Runtime=Clr  

```
       Method |       Mean |    StdDev |  Gen 0 | Allocated |
------------- |----------- |---------- |------- |---------- |
        Raise | 75.5129 us | 2.4288 us | 9.2773 |   5.53 kB |
 RaiseGeneric | 77.2580 us | 2.9541 us | 7.8939 |   5.55 kB |
        Throw | 45.8247 us | 1.6760 us | 4.0527 |    2.8 kB |

## About this repository and its maintainer ##

Everything done on this repository is freely offered on the terms of the project license. You are free to do everything you want with the code and its related files, as long as you respect the license and use common sense while doing it :-)

I maintain this project during my spare time, so I can offer limited assistance and I can offer **no kind of warranty**.

Development of this project is sponsored by [Finsa SpA](https://www.finsa.it), my current employer.
