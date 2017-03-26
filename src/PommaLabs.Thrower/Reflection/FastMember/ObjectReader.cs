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
#pragma warning disable CC0022 // Should dispose object
        public static ObjectReader Create<T>(IEnumerable<T> source, params string[] members) => new ObjectReader(typeof(T), source, members);
#pragma warning restore CC0022 // Should dispose object

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
        public override int Depth => 0;

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
                rowData[4] = _allowNull == null || _allowNull[i];
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
        public override int RecordsAffected => 0;

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
        public override bool GetBoolean(int ordinal) => (bool) this[ordinal];

        /// <summary>
        ///   Gets the value of the specified column as a byte.
        /// </summary>
        /// <returns>The value of the specified column.</returns>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
        public override byte GetByte(int ordinal) => (byte) this[ordinal];

        /// <summary>
        ///   Reads a stream of bytes from the specified column, starting at location indicated by
        ///   <paramref name="dataOffset"/>, into the buffer, starting at the location indicated by <paramref name="bufferOffset"/>.
        /// </summary>
        /// <returns>The actual number of bytes read.</returns>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <param name="dataOffset">The index within the row from which to begin the read operation.</param>
        /// <param name="buffer">The buffer into which to copy the data.</param>
        /// <param name="bufferOffset">The index with the buffer to which the data will be copied.</param>
        /// <param name="length">The maximum number of characters to read.</param>
        /// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
        public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length)
        {
            var s = (byte[]) this[ordinal];
            var available = s.Length - (int) dataOffset;
            if (available <= 0) return 0;

            var count = Min(length, available);
            Buffer.BlockCopy(s, (int) dataOffset, buffer, bufferOffset, count);
            return count;
        }

        /// <summary>
        ///   Gets the value of the specified column as a single character.
        /// </summary>
        /// <returns>The value of the specified column.</returns>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
        public override char GetChar(int ordinal) => (char) this[ordinal];

        /// <summary>
        ///   Reads a stream of characters from the specified column, starting at location indicated
        ///   by <paramref name="dataOffset"/>, into the buffer, starting at the location indicated
        ///   by <paramref name="bufferOffset"/>.
        /// </summary>
        /// <returns>The actual number of characters read.</returns>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <param name="dataOffset">The index within the row from which to begin the read operation.</param>
        /// <param name="buffer">The buffer into which to copy the data.</param>
        /// <param name="bufferOffset">The index with the buffer to which the data will be copied.</param>
        /// <param name="length">The maximum number of characters to read.</param>
        public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length)
        {
            var s = (string) this[ordinal];
            var available = s.Length - (int) dataOffset;
            if (available <= 0) return 0;

            var count = Min(length, available);
            s.CopyTo((int) dataOffset, buffer, bufferOffset, count);
            return count;
        }

        /// <summary>
        ///   Returns a <see cref="DbDataReader"/> object for the requested column ordinal that can
        ///   be overridden with a provider-specific implementation.
        /// </summary>
        /// <returns>A <see cref="DbDataReader"/> object.</returns>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        protected override DbDataReader GetDbDataReader(int ordinal)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        ///   Gets name of the data type of the specified column.
        /// </summary>
        /// <returns>A string representing the name of the data type.</returns>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
        public override string GetDataTypeName(int ordinal) => (_effectiveTypes == null ? typeof(object) : _effectiveTypes[ordinal]).Name;

        /// <summary>
        ///   Gets the value of the specified column as a <see cref="DateTime"/> object.
        /// </summary>
        /// <returns>The value of the specified column.</returns>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
        public override DateTime GetDateTime(int ordinal) => (DateTime) this[ordinal];

        /// <summary>
        ///   Gets the value of the specified column as a <see cref="decimal"/> object.
        /// </summary>
        /// <returns>The value of the specified column.</returns>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
        public override decimal GetDecimal(int ordinal) => (decimal) this[ordinal];

        /// <summary>
        ///   Gets the value of the specified column as a double-precision floating point number.
        /// </summary>
        /// <returns>The value of the specified column.</returns>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
        public override double GetDouble(int ordinal) => (double) this[ordinal];

        /// <summary>
        ///   Gets the data type of the specified column.
        /// </summary>
        /// <returns>The data type of the specified column.</returns>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
        public override Type GetFieldType(int ordinal) => _effectiveTypes == null ? typeof(object) : _effectiveTypes[ordinal];

        /// <summary>
        ///   Gets the value of the specified column as a single-precision floating point number.
        /// </summary>
        /// <returns>The value of the specified column.</returns>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
        public override float GetFloat(int ordinal) => (float) this[ordinal];

        /// <summary>
        ///   Gets the value of the specified column as a globally-unique identifier (GUID).
        /// </summary>
        /// <returns>The value of the specified column.</returns>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
        public override Guid GetGuid(int ordinal) => (Guid) this[ordinal];

        /// <summary>
        ///   Gets the value of the specified column as a 16-bit signed integer.
        /// </summary>
        /// <returns>The value of the specified column.</returns>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
        public override short GetInt16(int ordinal) => (short) this[ordinal];

        /// <summary>
        ///   Gets the value of the specified column as a 32-bit signed integer.
        /// </summary>
        /// <returns>The value of the specified column.</returns>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
        public override int GetInt32(int ordinal) => (int) this[ordinal];

        /// <summary>
        ///   Gets the value of the specified column as a 64-bit signed integer.
        /// </summary>
        /// <returns>The value of the specified column.</returns>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
        public override long GetInt64(int ordinal) => (long) this[ordinal];

        /// <summary>
        ///   Gets the name of the column, given the zero-based column ordinal.
        /// </summary>
        /// <returns>The name of the specified column.</returns>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        public override string GetName(int ordinal) => _memberNames[ordinal];

        /// <summary>
        ///   Gets the column ordinal given the name of the column.
        /// </summary>
        /// <returns>The zero-based column ordinal.</returns>
        /// <param name="name">The name of the column.</param>
        /// <exception cref="IndexOutOfRangeException">
        ///   The name specified is not a valid column name.
        /// </exception>
        public override int GetOrdinal(string name) => Array.IndexOf(_memberNames, name);

        /// <summary>
        ///   Gets the value of the specified column as an instance of <see cref="string"/>.
        /// </summary>
        /// <returns>The value of the specified column.</returns>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
        public override string GetString(int ordinal) => (string) this[ordinal];

        /// <summary>
        ///   Gets the value of the specified column as an instance of <see cref="object"/>.
        /// </summary>
        /// <returns>The value of the specified column.</returns>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        public override object GetValue(int ordinal) => this[ordinal];

        /// <summary>
        ///   Returns an <see cref="IEnumerator"/> that can be used to iterate through the rows in
        ///   the data reader.
        /// </summary>
        /// <returns>
        ///   An <see cref="IEnumerator"/> that can be used to iterate through the rows in the data reader.
        /// </returns>
        public override IEnumerator GetEnumerator() => new DbEnumerator(this, false);

        /// <summary>
        ///   Populates an array of objects with the column values of the current row.
        /// </summary>
        /// <returns>The number of instances of <see cref="object"/> in the array.</returns>
        /// <param name="values">
        ///   An array of <see cref="object"/> into which to copy the attribute columns.
        /// </param>
        public override int GetValues(object[] values)
        {
            // duplicate the key fields on the stack
            var members = this._memberNames;
            var current = this._current;
            var accessor = this._accessor;

            var count = Min(values.Length, members.Length);
            for (int i = 0; i < count; i++) values[i] = accessor[current, members[i]] ?? DBNull.Value;
            return count;
        }

        /// <summary>
        ///   Gets a value that indicates whether the column contains nonexistent or missing values.
        /// </summary>
        /// <returns>
        ///   true if the specified column is equivalent to <see cref="DBNull"/>; otherwise false.
        /// </returns>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        public override bool IsDBNull(int ordinal) => this[ordinal] is DBNull;

        /// <summary>
        ///   Gets the value of the current object in the member specified.
        /// </summary>
        /// <param name="name">Member name.</param>
        public override object this[string name] => _accessor[_current, name] ?? DBNull.Value;

        /// <summary>
        ///   Gets the value of the current object in the member specified.
        /// </summary>
        /// <param name="ordinal">Member ordinal.</param>
        public override object this[int ordinal] => _accessor[_current, _memberNames[ordinal]] ?? DBNull.Value;

        /// <summary>
        ///   This avoids a reference to a library for .NET standard.
        /// </summary>
        /// <param name="x">X.</param>
        /// <param name="y">Y.</param>
        /// <returns>Minimum.</returns>
        private static int Min(int x, int y) => x < y ? x : y;
    }
}

#endif