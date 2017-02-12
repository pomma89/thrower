// File name: PortableTypeInfoTests.cs
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

using NUnit.Framework;
using PommaLabs.Thrower.Reflection;
using System;
using System.Linq;

namespace PommaLabs.Thrower.UnitTests.Reflection
{
    internal sealed class PortableTypeInfoTests : AbstractTests
    {
        #region GetBaseType

        [Test]
        public void GetBaseType_ShouldReturnMyAbstractClass()
        {
            Assert.AreSame(typeof(MyAbstractClass), PortableTypeInfo.GetBaseType(typeof(MyClass)));
        }

        #endregion GetBaseType

        #region GetPublicProperties

        [Test]
        public void GetPublicProperties_ShouldReturnAllPropertiesOfMyStruct()
        {
            var props = PortableTypeInfo.GetPublicProperties<MyStruct>();
            Assert.AreEqual(1, props.Count(p => p.Name == nameof(MyStruct.A)));
            Assert.AreEqual(1, props.Count(p => p.Name == nameof(MyStruct.B)));
            Assert.AreEqual(1, props.Count(p => p.Name == nameof(MyStruct.C)));
            Assert.AreEqual(0, props.Count(p => p.Name == "P"));
        }

        [Test]
        public void GetPublicProperties_ShouldReturnAllPropertiesOfMyInterface()
        {
            var props = PortableTypeInfo.GetPublicProperties<MyInterface>();
            Assert.AreEqual(1, props.Count(p => p.Name == nameof(MyInterface.A)));
            Assert.AreEqual(1, props.Count(p => p.Name == nameof(MyInterface.B)));
            Assert.AreEqual(1, props.Count(p => p.Name == nameof(MyInterface.C)));
        }

        [Test]
        public void GetPublicProperties_ShouldReturnAllPropertiesOfMyClass()
        {
            var props = PortableTypeInfo.GetPublicProperties<MyClass>();
            Assert.AreEqual(1, props.Count(p => p.Name == nameof(MyClass.A)));
            Assert.AreEqual(1, props.Count(p => p.Name == nameof(MyClass.B)));
            Assert.AreEqual(1, props.Count(p => p.Name == nameof(MyClass.C)));
            Assert.AreEqual(1, props.Count(p => p.Name == nameof(MyAbstractClass.D)));
            Assert.AreEqual(0, props.Count(p => p.Name == "P"));
        }

        [Test]
        public void GetPublicProperties_ShouldReturnAllPropertiesOfMyAbstractClass()
        {
            var props = PortableTypeInfo.GetPublicProperties<MyAbstractClass>();
            Assert.AreEqual(1, props.Count(p => p.Name == nameof(MyAbstractClass.D)));
        }

        #endregion GetPublicProperties

        #region GetPublicPropertyValue

        [Test]
        public void GetPublicPropertyValue_ShouldGetAllValuesForMyStruct()
        {
            var x = new MyStruct
            {
                A = 21,
                B = "PINO",
                C = decimal.One
            };

            var props = PortableTypeInfo.GetPublicProperties<MyStruct>();

            Assert.AreEqual(x.A, PortableTypeInfo.GetPublicPropertyValue(x, props.First(p => p.Name == nameof(MyStruct.A))));
            Assert.AreEqual(x.B, PortableTypeInfo.GetPublicPropertyValue(x, props.First(p => p.Name == nameof(MyStruct.B))));
            Assert.AreEqual(x.C, PortableTypeInfo.GetPublicPropertyValue(x, props.First(p => p.Name == nameof(MyStruct.C))));

#if !(PORTABLE || NETSTD11)
            var typeAccessor = Thrower.Reflection.FastMember.TypeAccessor.Create<MyStruct>();
            Assert.AreEqual(x.A, PortableTypeInfo.GetPublicPropertyValue(typeAccessor, x, props.First(p => p.Name == nameof(MyStruct.A))));
            Assert.AreEqual(x.B, PortableTypeInfo.GetPublicPropertyValue(typeAccessor, x, props.First(p => p.Name == nameof(MyStruct.B))));
            Assert.AreEqual(x.C, PortableTypeInfo.GetPublicPropertyValue(typeAccessor, x, props.First(p => p.Name == nameof(MyStruct.C))));
#endif
        }

        [Test]
        public void GetPublicPropertyValue_ShouldGetAllValuesForMyClass()
        {
            var x = new MyClass
            {
                A = 21,
                B = "PINO",
                C = decimal.One,
                D = Math.PI
            };

            var props = PortableTypeInfo.GetPublicProperties<MyClass>();

            Assert.AreEqual(x.A, PortableTypeInfo.GetPublicPropertyValue(x, props.First(p => p.Name == nameof(MyClass.A))));
            Assert.AreEqual(x.B, PortableTypeInfo.GetPublicPropertyValue(x, props.First(p => p.Name == nameof(MyClass.B))));
            Assert.AreEqual(x.C, PortableTypeInfo.GetPublicPropertyValue(x, props.First(p => p.Name == nameof(MyClass.C))));
            Assert.AreEqual(x.D, PortableTypeInfo.GetPublicPropertyValue(x, props.First(p => p.Name == nameof(MyClass.D))));

#if !(PORTABLE || NETSTD11)
            var typeAccessor = Thrower.Reflection.FastMember.TypeAccessor.Create<MyClass>();
            Assert.AreEqual(x.A, PortableTypeInfo.GetPublicPropertyValue(typeAccessor, x, props.First(p => p.Name == nameof(MyClass.A))));
            Assert.AreEqual(x.B, PortableTypeInfo.GetPublicPropertyValue(typeAccessor, x, props.First(p => p.Name == nameof(MyClass.B))));
            Assert.AreEqual(x.C, PortableTypeInfo.GetPublicPropertyValue(typeAccessor, x, props.First(p => p.Name == nameof(MyClass.C))));
            Assert.AreEqual(x.D, PortableTypeInfo.GetPublicPropertyValue(typeAccessor, x, props.First(p => p.Name == nameof(MyClass.D))));
#endif
        }

        #endregion GetPublicPropertyValue

        #region IsEnum

        [Test]
        public void IsEnum_ShouldReturnTrueWithEnum()
        {
            Assert.IsTrue(PortableTypeInfo.IsEnum(typeof(MyEnum)));
            Assert.IsTrue(PortableTypeInfo.IsEnum<MyEnum>());
        }

        [Test]
        public void IsEnum_ShouldReturnFalseWithStruct()
        {
            Assert.IsFalse(PortableTypeInfo.IsEnum(typeof(MyStruct)));
        }

        [Test]
        public void IsEnum_ShouldReturnFalseWithInterface()
        {
            Assert.IsFalse(PortableTypeInfo.IsEnum(typeof(MyInterface)));
        }

        [Test]
        public void IsEnum_ShouldReturnFalseWithClass()
        {
            Assert.IsFalse(PortableTypeInfo.IsEnum(typeof(MyClass)));
        }

        [Test]
        public void IsEnum_ShouldReturnFalseWithAbstractClass()
        {
            Assert.IsFalse(PortableTypeInfo.IsEnum(typeof(MyAbstractClass)));
        }

        [Test]
        public void IsEnum_ShouldReturnFalseWithPrimitive()
        {
            Assert.IsFalse(PortableTypeInfo.IsEnum(typeof(int)));
        }

        #endregion IsEnum

        #region IsAbstract

        [Test]
        public void IsAbstract_ShouldReturnFalseWithEnum()
        {
            Assert.IsFalse(PortableTypeInfo.IsAbstract(typeof(MyEnum)));
        }

        [Test]
        public void IsAbstract_ShouldReturnFalseWithStruct()
        {
            Assert.IsFalse(PortableTypeInfo.IsAbstract(typeof(MyStruct)));
        }

        [Test]
        public void IsAbstract_ShouldReturnTrueWithInterface()
        {
            Assert.IsTrue(PortableTypeInfo.IsAbstract(typeof(MyInterface)));
            Assert.IsTrue(PortableTypeInfo.IsAbstract<MyInterface>());
        }

        [Test]
        public void IsAbstract_ShouldReturnFalseWithClass()
        {
            Assert.IsFalse(PortableTypeInfo.IsAbstract(typeof(MyClass)));
        }

        [Test]
        public void IsAbstract_ShouldReturnTrueWithAbstractClass()
        {
            Assert.IsTrue(PortableTypeInfo.IsAbstract(typeof(MyAbstractClass)));
            Assert.IsTrue(PortableTypeInfo.IsAbstract<MyAbstractClass>());
        }

        [Test]
        public void IsAbstract_ShouldReturnFalseWithPrimitive()
        {
            Assert.IsFalse(PortableTypeInfo.IsAbstract(typeof(int)));
        }

        #endregion IsAbstract

        #region IsClass

        [Test]
        public void IsClass_ShouldReturnFalseWithEnum()
        {
            Assert.IsFalse(PortableTypeInfo.IsClass(typeof(MyEnum)));
        }

        [Test]
        public void IsClass_ShouldReturnFalseWithStruct()
        {
            Assert.IsFalse(PortableTypeInfo.IsClass(typeof(MyStruct)));
        }

        [Test]
        public void IsClass_ShouldReturnFalseWithInterface()
        {
            Assert.IsFalse(PortableTypeInfo.IsClass(typeof(MyInterface)));
            Assert.IsFalse(PortableTypeInfo.IsClass<MyInterface>());
        }

        [Test]
        public void IsClass_ShouldReturnTrueWithClass()
        {
            Assert.IsTrue(PortableTypeInfo.IsClass(typeof(MyClass)));
            Assert.IsTrue(PortableTypeInfo.IsClass<MyClass>());
        }

        [Test]
        public void IsClass_ShouldReturnTrueWithAbstractClass()
        {
            Assert.IsTrue(PortableTypeInfo.IsClass(typeof(MyAbstractClass)));
            Assert.IsTrue(PortableTypeInfo.IsClass<MyAbstractClass>());
        }

        [Test]
        public void IsClass_ShouldReturnFalseWithPrimitive()
        {
            Assert.IsFalse(PortableTypeInfo.IsClass(typeof(int)));
        }

        #endregion IsClass

        #region IsInterface

        [Test]
        public void IsInterface_ShouldReturnFalseWithEnum()
        {
            Assert.IsFalse(PortableTypeInfo.IsInterface(typeof(MyEnum)));
        }

        [Test]
        public void IsInterface_ShouldReturnFalseWithStruct()
        {
            Assert.IsFalse(PortableTypeInfo.IsInterface(typeof(MyStruct)));
        }

        [Test]
        public void IsInterface_ShouldReturnTrueWithInterface()
        {
            Assert.IsTrue(PortableTypeInfo.IsInterface(typeof(MyInterface)));
            Assert.IsTrue(PortableTypeInfo.IsInterface<MyInterface>());
        }

        [Test]
        public void IsInterface_ShouldReturnFalseWithClass()
        {
            Assert.IsFalse(PortableTypeInfo.IsInterface(typeof(MyClass)));
        }

        [Test]
        public void IsInterface_ShouldReturnFalseWithAbstractClass()
        {
            Assert.IsFalse(PortableTypeInfo.IsInterface(typeof(MyAbstractClass)));
        }

        [Test]
        public void IsInterface_ShouldReturnFalseWithPrimitive()
        {
            Assert.IsFalse(PortableTypeInfo.IsInterface(typeof(int)));
        }

        #endregion IsInterface

        #region IsValueType

        [Test]
        public void IsValueType_ShouldReturnTrueWithEnum()
        {
            Assert.IsTrue(PortableTypeInfo.IsValueType(typeof(MyEnum)));
            Assert.IsTrue(PortableTypeInfo.IsValueType<MyEnum>());
        }

        [Test]
        public void IsValueType_ShouldReturnTrueWithStruct()
        {
            Assert.IsTrue(PortableTypeInfo.IsValueType(typeof(MyStruct)));
            Assert.IsTrue(PortableTypeInfo.IsValueType<MyStruct>());
        }

        [Test]
        public void IsValueType_ShouldReturnFalseWithInterface()
        {
            Assert.IsFalse(PortableTypeInfo.IsValueType(typeof(MyInterface)));
        }

        [Test]
        public void IsValueType_ShouldReturnFalseWithClass()
        {
            Assert.IsFalse(PortableTypeInfo.IsValueType(typeof(MyClass)));
        }

        [Test]
        public void IsValueType_ShouldReturnFalseWithAbstractClass()
        {
            Assert.IsFalse(PortableTypeInfo.IsValueType(typeof(MyAbstractClass)));
        }

        [Test]
        public void IsValueType_ShouldReturnTrueWithPrimitive()
        {
            Assert.IsTrue(PortableTypeInfo.IsValueType(typeof(int)));
            Assert.IsTrue(PortableTypeInfo.IsValueType<int>());
        }

        #endregion IsValueType

        #region IsPrimitive

        [Test]
        public void IsPrimitive_ShouldReturnFalseWithEnum()
        {
            Assert.IsFalse(PortableTypeInfo.IsPrimitive(typeof(MyEnum)));
            Assert.IsFalse(PortableTypeInfo.IsPrimitive<MyEnum>());
        }

        [Test]
        public void IsPrimitive_ShouldReturnFalseWithStruct()
        {
            Assert.IsFalse(PortableTypeInfo.IsPrimitive(typeof(MyStruct)));
            Assert.IsFalse(PortableTypeInfo.IsPrimitive<MyStruct>());
        }

        [Test]
        public void IsPrimitive_ShouldReturnFalseWithInterface()
        {
            Assert.IsFalse(PortableTypeInfo.IsPrimitive(typeof(MyInterface)));
        }

        [Test]
        public void IsPrimitive_ShouldReturnFalseWithClass()
        {
            Assert.IsFalse(PortableTypeInfo.IsPrimitive(typeof(MyClass)));
        }

        [Test]
        public void IsPrimitive_ShouldReturnFalseWithAbstractClass()
        {
            Assert.IsFalse(PortableTypeInfo.IsPrimitive(typeof(MyAbstractClass)));
        }

        [Test]
        public void IsPrimitive_ShouldReturnTrueWithPrimitive()
        {
            Assert.IsTrue(PortableTypeInfo.IsPrimitive(typeof(int)));
            Assert.IsTrue(PortableTypeInfo.IsPrimitive<int>());
        }

        #endregion IsPrimitive

        public enum MyEnum
        {
            A,
            B,
            C
        }

        public struct MyStruct
        {
            public int A { get; set; }
            public string B { get; set; }
            public decimal C { get; set; }
            private bool P { get; set; }
        }

        public interface MyInterface
        {
            int A { get; set; }
            string B { get; set; }
            decimal C { get; set; }
        }

        public abstract class MyAbstractClass
        {
            public double D { get; set; }
        }

        public class MyClass : MyAbstractClass, MyInterface
        {
            public int A { get; set; }
            public string B { get; set; }
            public decimal C { get; set; }
            private bool P { get; set; }
        }
    }
}