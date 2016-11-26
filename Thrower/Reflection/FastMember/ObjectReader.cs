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

#if !(PORTABLE || NETSTD11)

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace PommaLabs.Thrower.Reflection.FastMember
{
    /// <summary>
    ///   Provides a means of reading a sequence of objects as a data-reader, for example for use
    ///   with SqlBulkCopy or other data-base oriented code.
    /// </summary>
    public class ObjectReader : DbDataReader
    {
        private readonly TypeAccessor _accessor;
        private readonly string[] _memberNames;
        private readonly Type[] _effectiveTypes;
        private readonly BitArray _allowNull;
        private IEnumerator _source;
        private object _current;
        private bool _active = true;

        /// <summary>
        ///   Creates a new ObjectReader instance for reading the supplied data.
        /// </summary>
        /// <param name="source">The sequence of objects to represent.</param>
        /// <param name="members">The members that should be exposed to the reader.</param>
        public static ObjectReader Create<T>(IEnumerable<T> source, params string[] members)
        {
            return new ObjectReader(typeof(T), source, members);
        }

        /// <summary>
        ///   Creates a new ObjectReader instance for reading the supplied data.
        /// </summary>
        /// <param name="type">The expected Type of the information to be read.</param>
        /// <param name="source">The sequence of objects to represent.</param>
        /// <param name="members">The members that should be exposed to the reader.</param>
        public ObjectReader(Type type, IEnumerable source, params string[] members)
        {
            if (source == null) throw new ArgumentOutOfRangeException(nameof(source));

            var allMembers = members == null || members.Length == 0;

            this._accessor = TypeAccessor.Create(type);
            if (_accessor.GetMembersSupported)
            {
                var typeMembers = this._accessor.GetMembers();

                if (allMembers)
                {
                    members = new string[typeMembers.Count];
                    for (int i = 0; i < members.Length; i++)
                    {
                        members[i] = typeMembers[i].Name;
                    }
                }

                this._allowNull = new BitArray(members.Length);
                this._effectiveTypes = new Type[members.Length];
                for (int i = 0; i < members.Length; i++)
                {
                    Type memberType = null;
                    var allowNull = true;
                    var hunt = members[i];
                    foreach (var member in typeMembers)
                    {
                        if (member.Name == hunt)
                        {
                            if (memberType == null)
                            {
                                var tmp = member.Type;
                                memberType = Nullable.GetUnderlyingType(tmp) ?? tmp;

                                allowNull = !(PortableTypeInfo.IsValueType(memberType) && memberType == tmp);

                                // but keep checking, in case of duplicates
                            }
                            else
                            {
                                memberType = null; // duplicate found; say nothing
                                break;
                            }
                        }
                    }
                    this._allowNull[i] = allowNull;
                    this._effectiveTypes[i] = memberType ?? typeof(object);
                }
            }
            else if (allMembers)
            {
                throw new InvalidOperationException("Member information is not available for this type; the required members must be specified explicitly");
            }

            this._current = null;
            this._memberNames = (string[]) members.Clone();

            this._source = source.GetEnumerator();
        }

        /// <summary>
        ///   Gets a value indicating the depth of nesting for the current row.
        /// </summary>
        /// <returns>The depth of nesting for the current row.</returns>
        public override int Depth
        {
            get { return 0; }
        }

#if !NETSTD13

        /// <summary>
        ///   Returns a <see cref="DataTable"/> that describes the column metadata of the <see cref="DbDataReader"/>.
        /// </summary>
        /// <returns>A <see cref="DataTable"/> that describes the column metadata.</returns>
        /// <exception cref="InvalidOperationException">
        ///   The <see cref="DbDataReader"/> is closed.
        /// </exception>
        public override DataTable GetSchemaTable()
        {
            // these are the columns used by DataTable load
            var table = new DataTable
            {
                Columns =
                {
                    {"ColumnOrdinal", typeof(int)},
                    {"ColumnName", typeof(string)},
                    {"DataType", typeof(Type)},
                    {"ColumnSize", typeof(int)},
                    {"AllowDBNull", typeof(bool)}
                }
            };
            var rowData = new object[5];
            for (int i = 0; i < _memberNames.Length; i++)
            {
                rowData[0] = i;
                rowData[1] = _memberNames[i];
                rowData[2] = _effectiveTypes == null ? typeof(object) : _effectiveTypes[i];
                rowData[3] = -1;
                rowData[4] = _allowNull == null ? true : _allowNull[i];
                table.Rows.Add(rowData);
            }
            return table;
        }

        /// <summary>
        ///   Closes the <see cref="DbDataReader"/> object.
        /// </summary>
        public override void Close()
        {
            Shutdown();
        }

#endif

        /// <summary>
        ///   Gets a value that indicates whether this <see cref="DbDataReader"/> contains one or
        ///   more rows.
        /// </summary>
        /// <returns>
        ///   true if the <see cref="DbDataReader"/> contains one or more rows; otherwise false.
        /// </returns>
        public override bool HasRows => _active;

        /// <summary>
        ///   Advances the reader to the next result when reading the results of a batch of statements.
        /// </summary>
        /// <returns>true if there are more result sets; otherwise false.</returns>
        public override bool NextResult()
        {
            _active = false;
            return false;
        }

        /// <summary>
        ///   Advances the reader to the next record in a result set.
        /// </summary>
        /// <returns>true if there are more rows; otherwise false.</returns>
        public override bool Read()
        {
            if (_active)
            {
                var tmp = _source;
                if (tmp != null && tmp.MoveNext())
                {
                    _current = tmp.Current;
                    return true;
                }
                else
                {
                    _active = false;
                }
            }
            _current = null;
            return false;
        }

        /// <summary>
        ///   Gets the number of rows changed, inserted, or deleted by execution of the SQL statement.
        /// </summary>
        /// <returns>
        ///   The number of rows changed, inserted, or deleted. -1 for SELECT statements; 0 if no
        ///   rows were affected or the statement failed.
        /// </returns>
        public override int RecordsAffected { get; } = 0;

        /// <summary>
        ///   Releases the managed resources used by the <see cref="DbDataReader"/> and optionally
        ///   releases the unmanaged resources.
        /// </summary>
        /// <param name="disposing">
        ///   true to release managed and unmanaged resources; false to release only unmanaged resources.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing) Shutdown();
        }

        private void Shutdown()
        {
            _active = false;
            _current = null;
            var tmp = _source as IDisposable;
            _source = null;
            if (tmp != null) tmp.Dispose();
        }

        /// <summary>
        ///   Gets the number of columns in the current row.
        /// </summary>
        /// <returns>The number of columns in the current row.</returns>
        /// <exception cref="NotSupportedException">
        ///   There is no current connection to an instance of SQL Server.
        /// </exception>
        public override int FieldCount => _memberNames.Length;

        /// <summary>
        ///   Gets a value indicating whether the <see cref="DbDataReader"/> is closed.
        /// </summary>
        /// <returns>true if the <see cref="DbDataReader"/> is closed; otherwise false.</returns>
        /// <exception cref="InvalidOperationException">
        ///   The <see cref="DbDataReader"/> is closed.
        /// </exception>
        public override bool IsClosed => _source == null;

        /// <summary>
        ///   Gets the value of the specified column as a Boolean.
        /// </summary>
        /// <returns>The value of the specified column.</returns>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
        public override bool GetBoolean(int ordinal)
        {
            return (bool) this[ordinal];
        }

        public override byte GetByte(int ordinal)
        {
            return (byte) this[ordinal];
        }

        public override long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            var s = (byte[]) this[i];
            var available = s.Length - (int) fieldOffset;
            if (available <= 0) return 0;

            var count = Math.Min(length, available);
            Buffer.BlockCopy(s, (int) fieldOffset, buffer, bufferoffset, count);
            return count;
        }

        public override char GetChar(int i)
        {
            return (char) this[i];
        }

        public override long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            var s = (string) this[i];
            var available = s.Length - (int) fieldoffset;
            if (available <= 0) return 0;

            var count = Math.Min(length, available);
            s.CopyTo((int) fieldoffset, buffer, bufferoffset, count);
            return count;
        }

        protected override DbDataReader GetDbDataReader(int i)
        {
            throw new NotSupportedException();
        }

        public override string GetDataTypeName(int i)
        {
            return (_effectiveTypes == null ? typeof(object) : _effectiveTypes[i]).Name;
        }

        public override DateTime GetDateTime(int i)
        {
            return (DateTime) this[i];
        }

        public override decimal GetDecimal(int i)
        {
            return (decimal) this[i];
        }

        public override double GetDouble(int i)
        {
            return (double) this[i];
        }

        public override Type GetFieldType(int i)
        {
            return _effectiveTypes == null ? typeof(object) : _effectiveTypes[i];
        }

        public override float GetFloat(int i)
        {
            return (float) this[i];
        }

        public override Guid GetGuid(int i)
        {
            return (Guid) this[i];
        }

        public override short GetInt16(int i)
        {
            return (short) this[i];
        }

        public override int GetInt32(int i)
        {
            return (int) this[i];
        }

        public override long GetInt64(int i)
        {
            return (long) this[i];
        }

        public override string GetName(int i)
        {
            return _memberNames[i];
        }

        public override int GetOrdinal(string name)
        {
            return Array.IndexOf(_memberNames, name);
        }

        public override string GetString(int i)
        {
            return (string) this[i];
        }

        public override object GetValue(int i)
        {
            return this[i];
        }

        public override IEnumerator GetEnumerator()
        {
#if NETSTD13
            throw new NotImplementedException(); // https://github.com/dotnet/corefx/issues/4646
#else
            return new DbEnumerator(this);
#endif
        }

        public override int GetValues(object[] values)
        {
            // duplicate the key fields on the stack
            var members = this._memberNames;
            var current = this._current;
            var accessor = this._accessor;

            var count = Math.Min(values.Length, members.Length);
            for (int i = 0; i < count; i++) values[i] = accessor[current, members[i]] ?? DBNull.Value;
            return count;
        }

        public override bool IsDBNull(int ordinal)
        {
            return this[ordinal] is DBNull;
        }

        public override object this[string name]
        {
            get { return _accessor[_current, name] ?? DBNull.Value; }
        }

        /// <summary>
        ///   Gets the value of the current object in the member specified.
        /// </summary>
        public override object this[int i]
        {
            get { return _accessor[_current, _memberNames[i]] ?? DBNull.Value; }
        }
    }
}

#endif