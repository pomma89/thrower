// File name: BankExample.cs
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

using System;

namespace PommaLabs.Thrower.Examples
{
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
}
