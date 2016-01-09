// File name: ObjectValidatorTests.cs
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
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using NUnit.Framework;
using PommaLabs.Thrower.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PommaLabs.Thrower.UnitTests.Validation
{
    internal sealed class ObjectValidatorTests : AbstractTests
    {
        [Test]
        public void Validate_TestClass()
        {
            IList<ValidationError> validationErrors;
            var result = ObjectValidator.Validate(new TestClass(), out validationErrors);

            var r = ObjectValidator.RootPlaceholder;

            Assert.IsFalse(result);
            Assert.AreEqual(9, validationErrors.Count);
            Assert.AreEqual(1, validationErrors.Count(ve => ve.Path == r + "." + nameof(TestClass.RequiredBooleanThatIsNull)));
            Assert.AreEqual(1, validationErrors.Count(ve => ve.Path == r + "." + nameof(TestClass.RequiredStringThatIsNull)));
            Assert.AreEqual(1, validationErrors.Count(ve => ve.Path == r + "." + nameof(TestClass.OptionalMyTupleWithNullProperty) + "." + nameof(TestClass.MyTuple.RequiredNullableDouble)));
            Assert.AreEqual(1, validationErrors.Count(ve => ve.Path == r + "." + nameof(TestClass.OptionalEnumerableWithNullRequiredItems) + "[0]"));
            Assert.AreEqual(1, validationErrors.Count(ve => ve.Path == r + "." + nameof(TestClass.OptionalEnumerableWithNullRequiredItems) + "[2]"));
            Assert.AreEqual(1, validationErrors.Count(ve => ve.Path == r + "." + nameof(TestClass.RequiredEnumerableWithRequiredItemsWithNullProperty) + "[0]." + nameof(TestClass.MyTuple.RequiredNullableDouble)));
            Assert.AreEqual(1, validationErrors.Count(ve => ve.Path == r + "." + nameof(TestClass.RequiredEnumerableWithRequiredItemsWithNullProperty) + "[1]." + nameof(TestClass.MyTuple.RequiredNullableDouble)));
            Assert.AreEqual(1, validationErrors.Count(ve => ve.Path == r + "." + nameof(TestClass.OptionalCollectionWhichShouldNotBeEmpty)));
            Assert.AreEqual(1, validationErrors.Count(ve => ve.Path == r + "." + nameof(TestClass.OptionalCollectionWhichShouldBeSmaller)));
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(10000)]
        public void Validate_TestClass_Concurrent(int threadCount)
        {
            var tasks = new Task[threadCount];
            for (var i = 0; i < tasks.Length; ++i)
            {
                tasks[i] = Task.Factory.StartNew(Validate_TestClass);
            }
            for (var i = 0; i < tasks.Length; ++i)
            {
                tasks[i].Wait();
            }
        }

        [Test, ExpectedException(typeof(ArgumentException), ExpectedMessage = "Following paths failed the validation checks:", MatchType = MessageMatch.StartsWith)]
        public void IfIsNotValid_ParameterNameOnly()
        {
            RaiseArgumentException.IfIsNotValid(new TestClass(), "TEST");
        }

        [Test, ExpectedException(typeof(ArgumentException), ExpectedMessage = "Pino Gino Nino - Following paths failed the validation checks:", MatchType = MessageMatch.StartsWith)]
        public void IfIsNotValid_MessageAndParameterName()
        {
            RaiseArgumentException.IfIsNotValid(new TestClass(), "TEST", "Pino Gino Nino");
        }

        public sealed class TestClass
        {
            public bool Boolean { get; set; } = false;

            [Validate(Required = true)]
            public bool RequiredBoolean { get; set; } = true;

            [Validate(Required = true)]
            public bool? RequiredBooleanThatIsNull { get; set; } = null;

            [Validate(Required = true)]
            public string RequiredString { get; set; } = "OK";

            [Validate(Required = true)]
            public string RequiredStringThatIsNull { get; set; } = null;

            [Validate]
            public MyTuple OptionalMyTuple { get; set; } = null;

            [Validate(Required = true)]
            public MyTuple RequiredMyTuple { get; set; } = new MyTuple();

            [Validate]
            public MyTuple OptionalMyTupleWithNullProperty { get; set; } = new MyTuple
            {
                RequiredNullableDouble = null
            };

            [Validate(EnumerableItemsRequired = true)]
            public IEnumerable<object> OptionalEnumerableWithNullRequiredItems { get; set; } = new object[]
            {
                null,
                new object(),
                null
            };

            [Validate(Required = true, EnumerableItemsRequired = true)]
            public List<MyTuple> RequiredEnumerableWithRequiredItemsWithNullProperty { get; set; } = new List<MyTuple>
            {
                new MyTuple {RequiredNullableDouble = null },
                new MyTuple {RequiredNullableDouble = null }
            };

            [Validate(CollectionItemsMinCount = 3)]
            public IList<int> OptionalCollectionWhichShouldNotBeEmpty { get; set; } = new List<int>();

            [Validate(CollectionItemsMinCount = 3, CollectionItemsMaxCount = 5)]
            public int[] OptionalCollection { get; set; } = new[] { 1, 2, 3, 4 };

            [Validate(CollectionItemsMinCount = 3, CollectionItemsMaxCount = 5)]
            public IList<int> OptionalCollectionWhichShouldBeSmaller { get; set; } = new[] { 1, 2, 3, 4, 5, 6 };

            public sealed class MyTuple
            {
                [Validate]
                public double Double { get; set; } = Math.PI;

                [Validate]
                public double? NullableDouble { get; set; } = Math.PI;

                [Validate(Required = true)]
                public double? RequiredNullableDouble { get; set; } = Math.PI;
            }
        }

        #region Standard .NET validation

#if (!NET35 && !NET40 && !PORTABLE)

        [Test]
        public void Validate_StandardNetValidation_ValidObject()
        {
            IList<ValidationError> validationErrors;
            ObjectValidator.Validate(new StandardNetValidationTestClass
            {
                RequiredString = "PINO",
                OptionalEmail = "a@b.it",
                OptionalPhone = "+393401234567",
                RequiredInteger = 7
            }, out validationErrors);

            Assert.That(validationErrors.Count, Is.EqualTo(0));
        }

        [Test]
        public void Validate_StandardNetValidation_NotValidObject_MissingRequiredString()
        {
            IList<ValidationError> validationErrors;
            ObjectValidator.Validate(new StandardNetValidationTestClass
            {
                RequiredString = null,
                OptionalEmail = "a@b.it",
                OptionalPhone = null,
                RequiredInteger = 7
            }, out validationErrors);

            Assert.That(validationErrors.Count, Is.EqualTo(1));
        }

        [Test]
        public void Validate_StandardNetValidation_NotValidObject_NotValidEmail()
        {
            IList<ValidationError> validationErrors;
            ObjectValidator.Validate(new StandardNetValidationTestClass
            {
                RequiredString = "PINO",
                OptionalEmail = "123@123@a.it",
                OptionalPhone = null,
                RequiredInteger = 7
            }, out validationErrors);

            Assert.That(validationErrors.Count, Is.EqualTo(1));
        }

        [Test]
        public void Validate_StandardNetValidation_NotValidObject_NotValidPhone()
        {
            IList<ValidationError> validationErrors;
            ObjectValidator.Validate(new StandardNetValidationTestClass
            {
                RequiredString = "PINO",
                OptionalEmail = "123@a.it",
                OptionalPhone = "ciao belli",
                RequiredInteger = 7
            }, out validationErrors);

            Assert.That(validationErrors.Count, Is.EqualTo(1));
        }

        [Test]
        public void Validate_StandardNetValidation_NotValidObject_IntegerOutOfRange()
        {
            IList<ValidationError> validationErrors;
            ObjectValidator.Validate(new StandardNetValidationTestClass
            {
                RequiredString = "PINO",
                OptionalEmail = "123@a.it",
                OptionalPhone = "+393401234567",
                RequiredInteger = 1
            }, out validationErrors);

            Assert.That(validationErrors.Count, Is.EqualTo(1));
        }

        [Test]
        public void Validate_StandardNetValidation_NotValidObject_ThreeErrors()
        {
            IList<ValidationError> validationErrors;
            ObjectValidator.Validate(new StandardNetValidationTestClass
            {
                RequiredString = "PINO",
                OptionalEmail = "123@a.it@snau",
                OptionalPhone = "+wow123",
                RequiredInteger = 1
            }, out validationErrors);

            Assert.That(validationErrors.Count, Is.EqualTo(3));
        }

        sealed class StandardNetValidationTestClass
        {
            [System.ComponentModel.DataAnnotations.Required]
            public string RequiredString { get; set; }

            [System.ComponentModel.DataAnnotations.EmailAddress]
            public string OptionalEmail { get; set; }

            [System.ComponentModel.DataAnnotations.Phone]
            public string OptionalPhone { get; set; }

            [System.ComponentModel.DataAnnotations.Required, System.ComponentModel.DataAnnotations.Range(5, 10)]
            public int RequiredInteger { get; set; }
        }

#endif

        #endregion Standard .NET validation
    }
}
