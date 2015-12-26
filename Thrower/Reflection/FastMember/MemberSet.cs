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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PommaLabs.Thrower.Reflection.FastMember
{
    /// <summary>
    ///   Represents an abstracted view of the members defined for a type.
    /// </summary>
    public sealed class MemberSet : IEnumerable<Member>, IList<Member>
    {
        private Member[] members;

        internal MemberSet(Type type)
        {
            members = type
                .GetProperties()
                .Cast<MemberInfo>()
                .Concat(type.GetFields().Cast<MemberInfo>()).OrderBy(x => x.Name, StringComparer.InvariantCulture)
                .Select(member => new Member(member))
                .ToArray();
        }

        /// <summary>
        ///   Return a sequence of all defined members.
        /// </summary>
        public IEnumerator<Member> GetEnumerator()
        {
            foreach (var member in members) yield return member;
        }

        /// <summary>
        ///   Get a member by index
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

        bool ICollection<Member>.Contains(Member item) => members.Contains(item);

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
                switch (member.MemberType)
                {
                    case MemberTypes.Field: return ((FieldInfo) member).FieldType;
                    case MemberTypes.Property: return ((PropertyInfo) member).PropertyType;
                    default: throw new NotSupportedException(member.MemberType.ToString());
                }
            }
        }

        /// <summary>
        ///   Is the attribute specified defined on this type.
        /// </summary>
        /// <param name="attributeType">The attribute type.</param>
        public bool IsDefined(Type attributeType)
        {
            if (attributeType == null) throw new ArgumentNullException(nameof(attributeType));
            return Attribute.IsDefined(member, attributeType);
        }
    }
}

#endif