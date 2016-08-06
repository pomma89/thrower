// File name: PortableSerialization.cs
//
// Author(s): Alessio Parma <alessio.parma@gmail.com>
//
// The MIT License (MIT)
//
// Copyright (c) 2013-2016 Alessio Parma <alessio.parma@gmail.com>
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

#if PORTABLE

namespace System
{
    /// <summary>
    ///   Fake, this is used only to allow serialization on portable platforms.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true, Inherited = false)]
    public sealed class SerializableAttribute : Attribute
    {
        // This does nothing and should do nothing.
    }

    /// <summary>
    ///   Indicates that a field of a serializable class should not be serialized. This class cannot be inherited.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, Inherited = false)]
    public sealed class NonSerializedAttribute : Attribute
    {
        // This does nothing and should do nothing.
    }
}

#endif

#if (PORTABLE || NET35)

namespace System.Runtime.Serialization
{
    /// <summary>
    ///   Enables serialization of custom exception data in security-transparent code.
    /// </summary>
    public interface ISafeSerializationData
    {
        /// <summary>
        ///   This method is called when the instance is deserialized.
        /// </summary>
        /// <param name="deserialized">An object that contains the state of the instance.</param>
        void CompleteDeserialization(object deserialized);
    }
}

#endif