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
using System.Threading;

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
        /// <summary>
        ///   The maximum number of concurrent fire and forget tasks. Default value is equal to <see cref="Environment.ProcessorCount"/>.
        /// </summary>
        public static int FireAndForgetLimit { get; set; } = Environment.ProcessorCount;

#if !NET35

        private const TaskContinuationOptions FireAndForgetFlags = TaskContinuationOptions.ExecuteSynchronously | TaskContinuationOptions.OnlyOnFaulted;

        private static readonly Action<Task> DefaultErrorContination = t =>
        {
            try { t.Wait(); }
            catch { }
        };

        private static int FireAndForgetCount;

        /// <summary>
        ///   Tries to fire given action on a dedicated task, but it ensures that the number of
        ///   concurrent tasks is never greater than <see cref="FireAndForgetLimit"/>; if the number
        ///   of concurrent tasks is already too high, then given action is executed synchronously.
        ///
        ///   Optional error handler is invoked when given action throws an exception; if no handler
        ///   is specified, then the exception is swallowed.
        /// </summary>
        /// <param name="action">The action which might be fired and forgot.</param>
        /// <param name="handler">The optional error handler.</param>
        /// <returns>
        ///   True if given action has actually been fired and forgot; otherwise, it returns false.
        /// </returns>
        public static bool TryFireAndForget(Action action, Action<Exception> handler = null)
        {
            Raise.ArgumentNullException.IfIsNull(action, nameof(action));

            if (FireAndForgetCount >= FireAndForgetLimit)
            {
                // Run sync, cannot start a new task.
                RunSync(action, handler);
                return false;
            }

            if (Interlocked.Increment(ref FireAndForgetCount) > FireAndForgetLimit)
            {
                // Run sync, cannot start a new task.
                RunSync(action, handler);
                Interlocked.Decrement(ref FireAndForgetCount);
                return false;
            }

            RunAsync(() =>
            {
                action?.Invoke();
                Interlocked.Decrement(ref FireAndForgetCount);
            }, handler);
            return true;
        }

        private static void RunAsync(Action action, Action<Exception> handler)
        {
#if !NET40
            var task = Task.Run(action);
#else
            var task = Task.Factory.StartNew(action, System.Threading.CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default);
#endif
            if (handler == null)
            {
                task.ContinueWith(DefaultErrorContination, FireAndForgetFlags);
            }
            else
            {
                task.ContinueWith(t => handler(t.Exception.GetBaseException()), FireAndForgetFlags);
            }
        }

#else

        /// <summary>
        ///   Tries to fire given action on a dedicated task, but it ensures that the number of
        ///   concurrent tasks is never greater than <see cref="FireAndForgetLimit"/>; if the number
        ///   of concurrent tasks is already too high, then given action is executed synchronously.
        ///
        ///   Optional error handler is invoked when given action throws an exception; if no handler
        ///   is specified, then the exception is swallowed.
        /// </summary>
        /// <param name="action">The action which might be fired and forgot.</param>
        /// <param name="handler">The optional error handler.</param>
        /// <returns>
        ///   True if given action has actually been fired and forgot; otherwise, it returns false.
        /// </returns>
        /// <remarks>
        ///   Since .NET 3.5 does not support tasks, this method is simply a stub which runs given
        ///   action synchronously.
        /// </remarks>
        public static bool TryFireAndForget(Action action, Action<Exception> handler = null)
        {
            Raise.ArgumentNullException.IfIsNull(action, nameof(action));

            // Run sync, cannot start a new task.
            RunSync(action, handler);
            return false;
        }

#endif

        private static void RunSync(Action action, Action<Exception> handler)
        {
            try
            {
                action?.Invoke();
            }
            catch (Exception ex)
            {
                handler?.Invoke(ex);
            }
        }
    }
}