# Changelog for PommaLabs.Thrower #

### v4.2.0 (2017-08-16)

* Added support for .NET Standard 2.0.

### v4.1.3 (2017-04-09)

* Removed TaskExtensions class, added by mistake.

### v4.1.2 (2017-03-25)

* Improved Cake build system.

### v4.1.0 (2017-03-19)

* Updated project to VS2017.
* Removed Portable DLL, now we target .NET Standard.
* Added logging capabilities via LibLog.

### v4.0.15 (2017-03-04)

* Improved FormattableObject formatting.
* Added ToEnum extension methods for strings.

### v4.0.13 (2017-02-25)

* Added some useful classes.

### v4.0.11 (2017-02-12)

* Added DLL for .NET Standard 1.0.
* Removed .NET 4.6 and .NET Standard 1.1/1.2 DLLs, since they were equivalent to .NET 4.5 and .NET Standard 1.0.

### v4.0.10 (2017-02-12)

* The project has been fully converted to .NET Core.
* Added GetTypeAssembly to PortableTypeInfo.

### v4.0.7 (2017-01-22)

* NuGet package references NETStandard.Library instead of many packages.
* FastMember: static members are now correctly ignored.

### v4.0.6 (2017-01-08)

* SerializableAttribute is no more defined as a polyfill for .NET Standard 1.3; instead, it is taken from System.Runtime.Serialization.Formatters package.
* Added new DLL for .NET Standard 1.2.
* Fixed a security setting on .NET Standard 1.3 which prevented FastMember to work properly.

### v4.0.5 (2016-12-25)

* EnumerationAttribute doc comments contained a few mistakes.
* EmailAddressAttribute and PhoneNumberAttribute now validate successfully null values.
* Fixed and enriched unit tests for object validation. 
* Validation attributes are now available for portable DLL thanks to Portable.DataAnnotations.

### v4.0.4 (2016-12-17)

* All code marked as Obsolete in v3 has now been completely removed.
* Added a new exception handler for InvalidCastException.
* Moved many methods from RaiseGeneric to specific exception handlers.
* Updated embedded FastMember library - now it also works on .NET Standard 1.3.
* Added a new method to validate enumerations - it also works with flags.
* Added new validation attributes for email, phone number and enumerations.

### v3.0.4 (2016-09-04)

* DLL for .NET Standard 1.3 was not properly generated. Now it is.
* Fixed some build issues for .NET Standard 1.1 and 1.3.

### v3.0.3 (2016-09-03)

* All Raise[...]Exception classes have been marked as obsolete and should produce a compilation error when used. Please use new Raise.* handlers.
* Added IfIsEqualTo and IfIsNotEqualTo to ArgumentExceptionHandler.
* Added IfIsNaN, IfIsPositiveInfinity, IfIsNegativeInfinity to ArgumentOutOfRangeExceptionHandler.
* Added a new method to Raise&lt;TExt&gt; which handles unknown constructors.

### v3.0.2 (2016-08-28)

* Added an exception handler for System.IO.DirectoryNotFoundException.
* Added an exception handler for System.IO.FileNotFoundException.
* Added an exception handler for System.IO.InvalidDataException.
* Added an exception handler for System.IO.IOException.
* Added a DLL compiled for .NET Standard 1.3.
* Added some unit tests for new handlers.
* Benchmarks are now executed against all JITs.
* New benchmarks for Raise.FileNotFoundException.

### v3.0.1 (2016-08-06)

* Completed the implementation of a more fluent validation.
* Added a build script based on FAKE.
* Updated examples and doc comments.
* HttpException properly serializes custom data.
* Library for .NET Standard 1.1.

### v2.2.4 (2016-06-12)

* Updated internal EmailValidator, now validation has a flag to enable top level domains.
  All validation calls now allow the specification of that flag.
* Started new implementation for more fluent validation.

### v2.2.3 (2016-04-02)

* Fixed issue #1 - IfIsNull does not handle Nullable&lt;T&gt; type.
* Extended RaiseArgumentException with IfIsNullOrEmpty for ICollection&lt;T&gt;.
* The CHANGELOG file has been moved to the root of the project.

### v2.2.2 (2016-03-05)

* Imported a fix for the IPv6 email address validation logic.

### v2.2.1 (2016-02-27)

* Fixed AssemblyVersion, now it will not change anymore between minor releases.

### v2.1.4 (2016-01-10)

* Added new methods to PortableTypeInfo.

### v2.1.3 (2016-01-09)

* Added methods for phone validation to RaiseArgumentException.

### v2.1.2 (2016-01-09)

* Added methods for email validation to RaiseArgumentException.
* RaiseArgumentException.IfIsNotValid also applies standard System.ComponentModel.DataAnnotations validation.

### v2.1.1 (2015-12-27)

* RaiseArgumentException now requires the argument name in the same way of other Raise* classes.

### v2.1.0 (2015-12-26)

* Calls to all Raise* methods cannot be deleted any more by not defining the USETHROWER compilation symbol.
  The definition of that symbol was the cause of common errors and was not helpful on the performance side.
* Added RaiseObjectDisposedException.
* Added methods for string validation to RaiseArgumentException.
* Initial support for DNX.

### v2.0.3 (2015-10-31)

* FastMember.ObjectAccessor now implements IDictionary&lt;string, object&gt;.
* Added HttpException for Web API projects.

### v2.0.2 (2015-10-24)

* Embedded FastMember.
* Added a simple reflection-based object validator.

### v2.0.1 (2015-10-10)

* All assemblies are now signed.
* Added RaiseNotSupportedException and RaiseIndexOutOfRangeException.
