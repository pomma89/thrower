![](http://pomma89.altervista.it/thrower/logo64.png "Thrower Logo") Thrower
===========================================================================

Fully managed library providing convenience methods to perform argument checks.

[![Build status](https://ci.appveyor.com/api/projects/status/xjkp8gn0cf4s7qbg?svg=true)](https://ci.appveyor.com/project/pomma89/thrower)

| Item                                          | URL  |
| --------------------------------------------- | ------------------------------------ |
| ![](http://is.gd/1wCmXL) NuGet package        | https://nuget.org/packages/Thrower/ |
| ![](http://is.gd/4uKNfs) Tutorial             | https://code.google.com/p/des-sharp/wiki/Thrower_Tutorial |
| ![](http://is.gd/U2M21W) Documentation (HTML) | http://pomma89.altervista.it/thrower/html/index.html |
| ![](http://is.gd/I7ThMS) Documentation (PDF)  | http://pomma89.altervista.it/thrower/refman.pdf |

This library allows to write code like the following:

```cs
/// <summary>
///   Deposits given amount into the bank.
/// </summary>
/// <param name="amount">A positive amount of money.</param>
/// <exception cref="ArgumentOutOfRangeException">
///   Amount is zero or negative.
/// </exception>
/// <exception cref="InvalidOperationException">
///   Bank is closed.
/// </exception>
public void Deposit(double amount)
{
    Raise<InvalidOperationException>.IfNot(isOpen, "Bank is still closed");
    Raise<ArgumentOutOfRangeException>.If(amount <= 0, "Zero or negative amount");
    Amount += amount;
}
```

Where all calls to `Raise<TEx>.If` and `Raise<TEx>.IfNot` can be enabled by defining the `USETHROWER` conditional compilation symbol and can simply be undefined by not defining that symbol.

As of now, I do not have plans to expand Thrower beyond what it currently is. There are many ways in which it can be improved, I know, but as of now the library suits my needs and I have no time to improve it. If I will have time, I will try to make it better, of course.
