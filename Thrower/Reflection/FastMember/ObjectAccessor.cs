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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
#if !NET35
using System.Dynamic;
#endif

namespace PommaLabs.Thrower.Reflection.FastMember
{
    /// <summary>
    ///   Represents an individual object, allowing access to members by-name.
    /// </summary>
    public abstract class ObjectAccessor : IDictionary<string, object>
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

        #region IDictionary<string, object> members

        public abstract ICollection<string> Keys { get; }
        public abstract ICollection<object> Values { get; }
        public abstract int Count { get; }
        public bool IsReadOnly => true;
        public abstract bool ContainsKey(string key);
        public void Add(string key, object value)
        {
            throw new NotSupportedException();
        }
        public bool Remove(string key)
        {
            throw new NotSupportedException();
        }
        public abstract bool TryGetValue(string key, out object value);
        public void Add(KeyValuePair<string, object> item)
        {
            throw new NotSupportedException();
        }
        public void Clear()
        {
            throw new NotSupportedException();
        }
        public abstract bool Contains(KeyValuePair<string, object> item);
        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            foreach (var kv in this)
            {
                array[arrayIndex++] = kv;
            }
        }
        public bool Remove(KeyValuePair<string, object> item)
        {
            throw new NotSupportedException();
        }
        public abstract IEnumerator<KeyValuePair<string, object>> GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

        sealed class TypeAccessorWrapper : ObjectAccessor, IDictionary<string, object>
        {
            private readonly TypeAccessor _accessor;
            private readonly MemberSet _members;

            public TypeAccessorWrapper(object target, TypeAccessor accessor)
            {
                Target = target;
                _accessor = accessor;
                _members = accessor.GetMembers();
            }

            public override object this[string name]
            {
                get { return _accessor[Target, name]; }
                set { _accessor[Target, name] = value; }
            }

            public override object Target { get; }

            #region IDictionary<string, object> members

            public override ICollection<string> Keys => _members.Select(x => x.Name).ToArray();

            public override ICollection<object> Values => _members.Select(x => _accessor[Target, x.Name]).ToArray();

            public override int Count => _members.Count;

            public override bool ContainsKey(string key) => _members.Any(x => x.Name == key);

            public override bool TryGetValue(string key, out object value)
            {
                if (ContainsKey(key))
                {
                    value = _accessor[Target, key];
                    return true;
                }
                value = null;
                return false;
            }

            public override bool Contains(KeyValuePair<string, object> item) => _members.Any(x => x.Name == item.Key && _accessor[Target, item.Key] == item.Value);

            public override IEnumerator<KeyValuePair<string, object>> GetEnumerator()
            {
                foreach (var m in _members)
                {
                    yield return new KeyValuePair<string, object>(m.Name, _accessor[Target, m.Name]);
                }
            }

            #endregion
        }

#if !NET35
        sealed class DynamicWrapper : ObjectAccessor
        {
            public DynamicWrapper(IDynamicMetaObjectProvider target)
            {
                Target = target;
            }

            public override object this[string name]
            {
                get { return CallSiteCache.GetValue(name, Target); }
                set { CallSiteCache.SetValue(name, Target, value); }
            }

            public override object Target { get; }

            #region IDictionary<string, object> members

            public override ICollection<string> Keys
            {
                get { throw new NotSupportedException(); }               
            }

            public override ICollection<object> Values
            {
                get { throw new NotSupportedException(); }  
            }

            public override int Count
            {
                get { throw new NotSupportedException(); }  
            }

            public override bool ContainsKey(string key)
            {
                throw new NotSupportedException();
            }

            public override bool TryGetValue(string key, out object value)
            {
                throw new NotSupportedException();
            }

            public override bool Contains(KeyValuePair<string, object> item)
            {
                throw new NotSupportedException();
            }

            public override IEnumerator<KeyValuePair<string, object>> GetEnumerator()
            {
                throw new NotSupportedException();
            }

            #endregion
        }
#endif
    }
}

#endif
