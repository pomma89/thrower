![](http://pomma89.altervista.it/thrower/logo64.png "Thrower Logo") Thrower
===========================================================================

Fully managed library providing convenience methods to perform argument checks.

[![Build status](https://ci.appveyor.com/api/projects/status/xjkp8gn0cf4s7qbg?svg=true)](https://ci.appveyor.com/project/pomma89/thrower)

| Item                                          | URL                                  |
| --------------------------------------------- | ------------------------------------ |
| ![](http://is.gd/1wCmXL) NuGet package        | https://nuget.org/packages/Thrower/  |
| ![](http://is.gd/4uKNfs) Tutorial             | https://code.google.com/p/des-sharp/wiki/Thrower_Tutorial |
| ![](http://is.gd/U2M21W) Documentation (HTML) | http://pomma89.altervista.it/thrower/html/index.html |
| ![](http://is.gd/I7ThMS) Documentation (PDF)  | http://pomma89.altervista.it/thrower/refman.pdf |

This library allows to write code like the following example:

```cs
/// <summary>
///   Simple example for Thrower.
/// </summary>
internal static class BankExample
{
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

        Console.Read();
    }
}

/// <summary>
///   My bank implementation.
/// </summary>
internal sealed class MyBank
{
    private bool isOpen;

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
        RaiseArgumentException.IfIsNullOrWhiteSpace(helloMsg, nameof(helloMsg), "Hello message is null or blank");
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
        RaiseInvalidOperationException.IfNot(isOpen, "Bank is still closed");
        RaiseArgumentOutOfRangeException.IfIsLessOrEqual(amount, 0, nameof(amount), "Zero or negative amount");
        Raise<OverNineThousandException>.If(amount > 9000M, "You are very rich!");
        Amount += amount;
    }

    /// <summary>
    ///   Opens the bank.
    /// </summary>
    public void Open()
    {
        isOpen = true;
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
```

As of now, I do not have plans to expand Thrower beyond what it currently is. There are many ways in which it can be improved, I know, but as of now the library suits my needs and I have not much time to improve it. If I will have time, I will try to make it better, of course.

## About this repository and its maintainer ##

Everything done on this repository is freely offered on the terms of the project license. You are free to do everything you want with the code and its related files, as long as you respect the license and use common sense while doing it :-)
