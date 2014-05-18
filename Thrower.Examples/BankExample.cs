//
// Throw.cs
//
// Author:
//       Alessio Parma <alessio.parma@gmail.com>
//
// Copyright (c) 2013 Alessio Parma <alessio.parma@gmail.com>
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

namespace Thrower.Examples
{
    using System;

    static class BankExample
    {
        static void Main()
        {
            var bank = new MyBank();
            try {
                bank.Deposit(100);
            } catch (InvalidOperationException ex) {
                Console.Error.WriteLine(ex.Message);
            }
            bank.Open();
            try {
                bank.Deposit(-1000);
            } catch (ArgumentOutOfRangeException ex) {
                Console.Error.WriteLine(ex.Message);
            }
            bank.Deposit(10); // Everything OK!
            Console.WriteLine("Amount: " + bank.Amount);
            Console.Read();
        }
    }

    sealed class MyBank
    {
        bool isOpen;

        /// <summary>
        ///   The amount held into the bank.
        /// </summary>
        public double Amount { get; private set; }

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

        /// <summary>
        ///   Opens the bank.
        /// </summary>
        public void Open()
        {
            isOpen = true;
        }
    }
}