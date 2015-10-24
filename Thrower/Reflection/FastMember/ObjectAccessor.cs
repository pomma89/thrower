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

#if !PORTABLE

using System;
#if !NET35
using System.Dynamic;
#endif

namespace PommaLabs.Thrower.Reflection.FastMember
{
    /// <summary>
    ///   Represents an individual object, allowing access to members by-name
    /// </summary>
    public abstract class ObjectAccessor
    {
        /// <summary>
        ///   Get or Set the value of a named member for the underlying object.
        /// </summary>
        public abstract object this[string name] { get; set; }

        /// <summary>
        ///   The object represented by this instance.
        /// </summary>
        public abstract object Target { get; }

        /// <summary>
        ///   Use the target types definition of equality.
        /// </summary>
        /// <param name="obj">The object.</param>
        public override bool Equals(object obj) => Target.Equals(obj);

        /// <summary>
        ///   Obtain the hash of the target object.
        /// </summary>
        public override int GetHashCode() => Target.GetHashCode();

        /// <summary>
        ///   Use the target's definition of a string representation.
        /// </summary>
        public override string ToString() => Target.ToString();

        /// <summary>
        ///   Wraps an individual object, allowing by-name access to that instance.
        /// </summary>
        /// <param name="target">The target object.</param>
        public static ObjectAccessor Create(object target) => Create(target, false);

        /// <summary>
        ///   Wraps an individual object, allowing by-name access to that instance
        /// </summary>
        /// <param name="target">The target object.</param>
        /// <param name="allowNonPublicAccessors">Allow usage of non public accessors.</param>
        public static ObjectAccessor Create(object target, bool allowNonPublicAccessors)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
#if !NET35
            var dlr = target as IDynamicMetaObjectProvider;
            if (dlr != null) return new DynamicWrapper(dlr); // use the DLR
#endif
            return new TypeAccessorWrapper(target, TypeAccessor.Create(target.GetType(), allowNonPublicAccessors));
        }
        sealed class TypeAccessorWrapper : ObjectAccessor
        {
            private readonly object target;
            private readonly TypeAccessor accessor;
            public TypeAccessorWrapper(object target, TypeAccessor accessor)
            {
                this.target = target;
                this.accessor = accessor;
            }
            public override object this[string name]
            {
                get { return accessor[target, name]; }
                set { accessor[target, name] = value; }
            }
            public override object Target => target;
        }

#if !NET35
        sealed class DynamicWrapper : ObjectAccessor
        {
            private readonly IDynamicMetaObjectProvider target;
            public override object Target => target;

            public DynamicWrapper(IDynamicMetaObjectProvider target)
            {
                this.target = target;
            }
            public override object this[string name]
            {
                get { return CallSiteCache.GetValue(name, target); }
                set { CallSiteCache.SetValue(name, target, value); }
            }
        }
#endif
    }
}

#endif
