// Copyright 2013 Marc Gravell
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except
// in compliance with the License. You may obtain a copy of the License at:
// 
// "http://www.apache.org/licenses/LICENSE-2.0"
// 
// Unless required by applicable law or agreed to in writing, software distributed under the License
// is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
// or implied. See the License for the specific language governing permissions and limitations under
// the License.

#if !NET35 && !PORTABLE

using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace PommaLabs.Thrower.Reflection.FastMember
{
    internal static class CallSiteCache
    {
        private static readonly Hashtable Getters = new Hashtable(), Setters = new Hashtable();

        internal static object GetValue(string name, object target)
        {
            var callSite = (CallSite<Func<CallSite, object, object>>) Getters[name];
            if (callSite == null)
            {
                var newSite = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, name, typeof(CallSiteCache), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
                lock (Getters)
                {
                    callSite = (CallSite<Func<CallSite, object, object>>) Getters[name];
                    if (callSite == null)
                    {
                        Getters[name] = callSite = newSite;
                    }
                }
            }
            return callSite.Target(callSite, target);
        }

        internal static void SetValue(string name, object target, object value)
        {
            var callSite = (CallSite<Func<CallSite, object, object, object>>) Setters[name];
            if (callSite == null)
            {
                var newSite = CallSite<Func<CallSite, object, object, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, name, typeof(CallSiteCache), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null) }));
                lock (Setters)
                {
                    callSite = (CallSite<Func<CallSite, object, object, object>>) Setters[name];
                    if (callSite == null)
                    {
                        Setters[name] = callSite = newSite;
                    }
                }
            }
            callSite.Target(callSite, target, value);
        }
    }
}

#endif