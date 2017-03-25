// File name: TaskExtensions.cs
//
// Author(s): Alessio Parma <alessio.parma@gmail.com>
//
// The MIT License (MIT)
//
// Copyright (c) 2013-2018 Alessio Parma <alessio.parma@gmail.com>
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

using System;

#if !NET35

using System.Threading.Tasks;

#endif

namespace PommaLabs.Thrower.Goodies
{
    /// <summary>
    ///   Portable extensions for .NET tasks.
    /// </summary>
    public static class TaskExtensions
    {
#if !NET35

        private static readonly Action<Task> DefaultErrorContination = t =>
        {
            try { t.Wait(); }
            catch { }
        };

        /// <summary>
        ///   Fires given action on a dedicated task. Optional error handler is invoked when given
        ///   action throws an exception; if no handler is specified, then the exception is swallowed.
        /// </summary>
        /// <param name="action">The action which should be fired and forgot.</param>
        /// <param name="handler">The optional error handler.</param>
        public static void FireAndForget(Action action, Action<Exception> handler = null)
        {
            Raise.ArgumentNullException.IfIsNull(action, nameof(action));

            const TaskContinuationOptions flags = TaskContinuationOptions.ExecuteSynchronously | TaskContinuationOptions.OnlyOnFaulted;

#if !NET40
            var task = Task.Run(action);
#else
            var task = Task.Factory.StartNew(action, System.Threading.CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default);
#endif

            if (handler == null)
            {
                task.ContinueWith(DefaultErrorContination, flags);
            }
            else
            {
                task.ContinueWith(t => handler(t.Exception.GetBaseException()), flags);
            }
        }

#else

        /// <summary>
        ///   Fires given action on a dedicated task. Optional error handler is invoked when given
        ///   action throws an exception; if no handler is specified, then the exception is swallowed.
        /// </summary>
        /// <param name="action">The action which should be fired and forgot.</param>
        /// <param name="handler">The optional error handler.</param>
        /// <remarks>
        ///   Since .NET 3.5 does not support tasks, this method is simply a stub which runs given
        ///   action synchronously.
        /// </remarks>
        public static void FireAndForget(Action action, Action<Exception> handler = null)
        {
            Raise.ArgumentNullException.IfIsNull(action, nameof(action));

            try
            {
                action?.Invoke();
            }
            catch (Exception ex)
            {
                handler?.Invoke(ex);
            }
        }

#endif
    }
}