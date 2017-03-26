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

#if !(NETSTD10 || NETSTD11)

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security;

#if !NET20

using System.Linq;

#endif

namespace PommaLabs.Thrower.Reflection.FastMember
{
    /// <summary>
    ///   Represents an abstracted view of the members defined for a type.
    /// </summary>
    [SecuritySafeCritical]
    public sealed class MemberSet : IEnumerable<Member>, IList<Member>
    {
        private Member[] members;

        internal MemberSet(Type type)
        {
            const BindingFlags publicInstance = BindingFlags.Public | BindingFlags.Instance;

#if NET20
            var properties = new List<MemberInfo>(type.GetProperties(publicInstance));
            properties.AddRange(new List<MemberInfo>(type.GetFields(publicInstance)));
            properties.Sort((p1, p2) => p1.Name.CompareTo(p2.Name));
            members = properties.ConvertAll<Member>(mi => new Member(mi)).ToArray();
#else
            members = type
                .GetProperties(publicInstance)
                .Cast<MemberInfo>()
                .Concat(type.GetFields(publicInstance).Cast<MemberInfo>())
                .OrderBy(x => x.Name)
                .Select(member => new Member(member))
                .ToArray();
#endif
        }

        /// <summary>
        ///   Return a sequence of all defined members.
        /// </summary>
        public IEnumerator<Member> GetEnumerator()
        {
            foreach (var member in members) yield return member;
        }

        /// <summary>
        ///   Get a member by index.
        /// </summary>
        public Member this[int index] => members[index];

        /// <summary>
        ///   The number of members defined for this type.
        /// </summary>
        public int Count => members.Length;

        Member IList<Member>.this[int index]
        {
            get { return members[index]; }
            set { throw new NotSupportedException(); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

        bool ICollection<Member>.Remove(Member item)
        {
            throw new NotSupportedException();
        }

        void ICollection<Member>.Add(Member item)
        {
            throw new NotSupportedException();
        }

        void ICollection<Member>.Clear()
        {
            throw new NotSupportedException();
        }

        void IList<Member>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void IList<Member>.Insert(int index, Member item)
        {
            throw new NotSupportedException();
        }

        bool ICollection<Member>.Contains(Member item)
        {
#if NET20
            foreach (var _item in members)
            {
                if (item == _item)
                {
                    return true;
                }
            }
            return false;
#else
            return members.Contains(item);
#endif
        }

        void ICollection<Member>.CopyTo(Member[] array, int arrayIndex)
        {
            members.CopyTo(array, arrayIndex);
        }

        bool ICollection<Member>.IsReadOnly => true;

        int IList<Member>.IndexOf(Member member) => Array.IndexOf<Member>(members, member);
    }

    /// <summary>
    ///   Represents an abstracted view of an individual member defined for a type.
    /// </summary>
    public sealed class Member
    {
        private readonly MemberInfo member;

        internal Member(MemberInfo member)
        {
            this.member = member;
        }

        /// <summary>
        ///   The name of this member.
        /// </summary>
        public string Name => member.Name;

        /// <summary>
        ///   The type of value stored in this member.
        /// </summary>
        public Type Type
        {
            get
            {
                if (member is FieldInfo) return ((FieldInfo) member).FieldType;
                if (member is PropertyInfo) return ((PropertyInfo) member).PropertyType;
                throw new NotSupportedException(member.GetType().Name);
            }
        }

        /// <summary>
        ///   Is the attribute specified defined on this type?
        /// </summary>
        /// <param name="attributeType">The attribute type.</param>
        public bool IsDefined(Type attributeType)
        {
            if (attributeType == null) throw new ArgumentNullException(nameof(attributeType));
#if NETSTD13
            foreach(var attrib in member.CustomAttributes)
            {
                if (attrib.AttributeType == attributeType) return true;
            }
            return false;
#else
            return Attribute.IsDefined(member, attributeType);
#endif
        }

        /// <summary>
        ///   Gets attribute type.
        /// </summary>
        /// <param name="attributeType">The attribute type.</param>
        /// <param name="inherit">
        ///   If true, specifies to also search the ancestors of element for custom attributes.
        /// </param>
        public Attribute GetAttribute(Type attributeType, bool inherit) => PortableTypeInfo
            .GetCustomAttributes(member, inherit)
            .FirstOrDefault(a => PortableTypeInfo.IsInstanceOf(a, attributeType));

        /// <summary>
        ///   Property can write?
        /// </summary>
        public bool CanWrite
        {
            get
            {
                var property = member as PropertyInfo;
                if (property == null)
                {
                    throw new NotSupportedException(member.GetType().Name);
                }
                return property.CanWrite;
            }
        }

        /// <summary>
        ///   Property can read?
        /// </summary>
        public bool CanRead
        {
            get
            {
                var property = member as PropertyInfo;
                if (property == null)
                {
                    throw new NotSupportedException(member.GetType().Name);
                }
                return property.CanRead;
            }
        }
    }
}

#endif