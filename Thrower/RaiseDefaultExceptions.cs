// File name: RaiseDefaultExceptions.cs
// 
// Author(s): Alessio Parma <alessio.parma@gmail.com>
// 
// The MIT License (MIT)
// 
// Copyright (c) 2014-2016 Alessio Parma <alessio.parma@gmail.com>
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

namespace PommaLabs.Thrower
{
    public sealed class RaiseArgumentNullException : RaiseBase
    {
        public static void IfIsNull<TArg>(TArg arg)
        {
            if (ReferenceEquals(arg, null))
            {
                throw new ArgumentNullException();
            }
        }

        public static void IfIsNull<TArg>(TArg arg, string parameterName)
        {
            if (ReferenceEquals(arg, null))
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        public static void IfIsNull<TArg>(TArg arg, string parameterName, string message)
        {
            if (ReferenceEquals(arg, null))
            {
                throw new ArgumentNullException(parameterName, message);
            }
        }
    }

    public sealed class RaiseArgumentOutOfRangeException : RaiseBase
    {
        #region Less - Without parameter name, without message

        public static void IfIsLess<TArg>(TArg arg1, TArg arg2)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(arg1, null) || arg1.CompareTo(arg2) < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public static void IfIsLess(IComparable arg1, IComparable arg2)
        {
            if (ReferenceEquals(arg1, null) || arg1.CompareTo(arg2) < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        #endregion Less - Without parameter name, without message

        #region Less - With parameter name, without message

        public static void IfIsLess<TArg>(TArg arg1, TArg arg2, string parameterName)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(arg1, null) || arg1.CompareTo(arg2) < 0)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        public static void IfIsLess(IComparable arg1, IComparable arg2, string parameterName)
        {
            if (ReferenceEquals(arg1, null) || arg1.CompareTo(arg2) < 0)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        #endregion Less - With parameter name, without message

        #region Less - With parameter name, with message

        public static void IfIsLess<TArg>(TArg arg1, TArg arg2, string parameterName, string message)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(arg1, null) || arg1.CompareTo(arg2) < 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, arg1, message);
            }
        }

        public static void IfIsLess(IComparable arg1, IComparable arg2, string parameterName, string message)
        {
            if (ReferenceEquals(arg1, null) || arg1.CompareTo(arg2) < 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, arg1, message);
            }
        }

        #endregion Less - With parameter name, with message

        #region Greater - With parameter name, without message

        public static void IfIsGreater<TArg>(TArg arg1, TArg arg2, string parameterName)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(arg1, null) || arg1.CompareTo(arg2) > 0)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        public static void IfIsGreater(IComparable arg1, IComparable arg2, string parameterName)
        {
            if (ReferenceEquals(arg1, null) || arg1.CompareTo(arg2) > 0)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        #endregion Greater - With parameter name, without message

        #region GreaterOrEqual - With parameter name, without message

        public static void IfIsGreaterOrEqual<TArg>(TArg arg1, TArg arg2, string parameterName)
            where TArg : IComparable<TArg>
        {
            if (ReferenceEquals(arg1, null) || arg1.CompareTo(arg2) >= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        public static void IfIsGreaterOrEqual(IComparable arg1, IComparable arg2, string parameterName)
        {
            if (ReferenceEquals(arg1, null) || arg1.CompareTo(arg2) >= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        #endregion GreaterOrEqual - With parameter name, without message
    }
}
