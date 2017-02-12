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

#if !(PORTABLE || NETSTD10)

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
        ///   Wraps an individual object, allowing by-name access to that instance.
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

        /// <summary>
        ///   Gets an <see cref="ICollection{T}"/> containing the keys of the <see cref="IDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <returns>
        ///   An <see cref="ICollection{T}"/> containing the keys of the object that implements <see cref="IDictionary{TKey, TValue}"/>.
        /// </returns>
        public abstract ICollection<string> Keys { get; }

        /// <summary>
        ///   Gets an <see cref="ICollection{T}"/> containing the values in the <see cref="IDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <returns>
        ///   An <see cref="ICollection{T}"/> containing the values in the object that implements <see cref="IDictionary{TKey, TValue}"/>.
        /// </returns>
        public abstract ICollection<object> Values { get; }

        /// <summary>
        ///   Gets the number of elements contained in the <see cref="ICollection{T}"/>.
        /// </summary>
        /// <returns>The number of elements contained in the <see cref="ICollection{T}"/>.</returns>
        public abstract int Count { get; }

        /// <summary>
        ///   Gets a value indicating whether the <see cref="ICollection{T}"/> is read-only.
        /// </summary>
        /// <returns>true if the <see cref="ICollection{T}"/> is read-only; otherwise, false.</returns>
        public bool IsReadOnly => true;

        /// <summary>
        ///   Determines whether the <see cref="IDictionary{TKey, TValue}"/> contains an element with
        ///   the specified key.
        /// </summary>
        /// <returns>
        ///   true if the <see cref="IDictionary{TKey, TValue}"/> contains an element with the key;
        ///   otherwise, false.
        /// </returns>
        /// <param name="key">The key to locate in the <see cref="IDictionary{TKey, TValue}"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null.</exception>
        public abstract bool ContainsKey(string key);

        /// <summary>
        ///   Adds an element with the provided key and value to the <see cref="IDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <param name="key">The object to use as the key of the element to add.</param>
        /// <param name="value">The object to use as the value of the element to add.</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null.</exception>
        /// <exception cref="ArgumentException">
        ///   An element with the same key already exists in the <see cref="IDictionary{TKey, TValue}"/>.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///   The <see cref="IDictionary{TKey, TValue}"/> is read-only.
        /// </exception>
        public void Add(string key, object value)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        ///   Removes the element with the specified key from the <see cref="IDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <returns>
        ///   true if the element is successfully removed; otherwise, false. This method also returns
        ///   false if <paramref name="key"/> was not found in the original <see cref="IDictionary{TKey, TValue}"/>.
        /// </returns>
        /// <param name="key">The key of the element to remove.</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null.</exception>
        /// <exception cref="NotSupportedException">
        ///   The <see cref="IDictionary{TKey, TValue}"/> is read-only.
        /// </exception>
        public bool Remove(string key)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        ///   Gets the value associated with the specified key.
        /// </summary>
        /// <returns>
        ///   true if the object that implements <see cref="IDictionary{TKey, TValue}"/> contains an
        ///   element with the specified key; otherwise, false.
        /// </returns>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="value">
        ///   When this method returns, the value associated with the specified key, if the key is
        ///   found; otherwise, the default value for the type of the <paramref name="value"/>
        ///   parameter. This parameter is passed uninitialized.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null.</exception>
        public abstract bool TryGetValue(string key, out object value);

        /// <summary>
        ///   Adds an item to the <see cref="ICollection{T}"/>.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="ICollection{T}"/>.</param>
        /// <exception cref="NotSupportedException">
        ///   The <see cref="ICollection{T}"/> is read-only.
        /// </exception>
        public void Add(KeyValuePair<string, object> item)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        ///   Removes all items from the <see cref="ICollection{T}"/>.
        /// </summary>
        /// <exception cref="NotSupportedException">
        ///   The <see cref="ICollection{T}"/> is read-only.
        /// </exception>
        public void Clear()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        ///   Determines whether the <see cref="ICollection{T}"/> contains a specific value.
        /// </summary>
        /// <returns>
        ///   true if <paramref name="item"/> is found in the <see cref="ICollection{T}"/>;
        ///   otherwise, false.
        /// </returns>
        /// <param name="item">The object to locate in the <see cref="ICollection{T}"/>.</param>
        public abstract bool Contains(KeyValuePair<string, object> item);

        /// <summary>
        ///   Copies the elements of the <see cref="ICollection{T}"/> to an <see cref="Array"/>,
        ///   starting at a particular <see cref="Array"/> index.
        /// </summary>
        /// <param name="array">
        ///   The one-dimensional <see cref="Array"/> that is the destination of the elements copied
        ///   from <see cref="ICollection{T}"/>. The <see cref="Array"/> must have zero-based indexing.
        /// </param>
        /// <param name="arrayIndex">
        ///   The zero-based index in <paramref name="array"/> at which copying begins.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="array"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   <paramref name="arrayIndex"/> is less than 0.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///   The number of elements in the source <see cref="ICollection{T}"/> is greater than the
        ///   available space from <paramref name="arrayIndex"/> to the end of the destination <paramref name="array"/>.
        /// </exception>
        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            foreach (var kv in this)
            {
                array[arrayIndex++] = kv;
            }
        }

        /// <summary>
        ///   Removes the first occurrence of a specific object from the <see cref="ICollection{T}"/>.
        /// </summary>
        /// <returns>
        ///   true if <paramref name="item"/> was successfully removed from the
        ///   <see cref="ICollection{T}"/>; otherwise, false. This method also returns false if
        ///   <paramref name="item"/> is not found in the original <see cref="ICollection{T}"/>.
        /// </returns>
        /// <param name="item">The object to remove from the <see cref="ICollection{T}"/>.</param>
        /// <exception cref="NotSupportedException">
        ///   The <see cref="ICollection{T}"/> is read-only.
        /// </exception>
        public bool Remove(KeyValuePair<string, object> item)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        ///   Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public abstract IEnumerator<KeyValuePair<string, object>> GetEnumerator();

        /// <summary>
        ///   Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        ///   An <see cref="IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion IDictionary<string, object> members

        private sealed class TypeAccessorWrapper : ObjectAccessor
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

            #endregion IDictionary<string, object> members
        }

#if !NET35

        private sealed class DynamicWrapper : ObjectAccessor
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

        #endregion IDictionary<string, object> members
        }

#endif
    }
}

#endif