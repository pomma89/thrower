# Changelog for PommaLabs.Thrower #

### v3.0.0 (2016-08-06) ###

* Completed the implementation of a more fluent validation.
* Added a build script based on FAKE.
* Updated examples and doc comments.
* HttpException properly serializes custom data.
* Library for .NET Standard 1.1.

### v2.2.4 (2016-06-12) ###

* Updated internal EmailValidator, now validation has a flag to enable top level domains.
  All validation calls now allow the specification of that flag.
* Started new implementation for more fluent validation.

### v2.2.3 (2016-04-02) ###

* Fixed issue #1 - IfIsNull does not handle Nullable&lt;T&gt; type.
* Extended RaiseArgumentException with IfIsNullOrEmpty for ICollection&lt;T&gt;.
* The CHANGELOG file has been moved to the root of the project.

### v2.2.2 (2016-03-05) ###

* Imported a fix for the IPv6 email address validation logic.

### v2.2.1 (2016-02-27) ###

* Fixed AssemblyVersion, now it will not change anymore between minor releases.

### v2.1.4 (2016-01-10) ###

* Added new methods to PortableTypeInfo.

### v2.1.3 (2016-01-09) ###

* Added methods for phone validation to RaiseArgumentException.

### v2.1.2 (2016-01-09) ###

* Added methods for email validation to RaiseArgumentException.
* RaiseArgumentException.IfIsNotValid also applies standard System.ComponentModel.DataAnnotations validation.

### v2.1.1 (2015-12-27) ###

* RaiseArgumentException now requires the argument name in the same way of other Raise* classes.

### v2.1.0 (2015-12-26) ###

* Calls to all Raise* methods cannot be deleted any more by not defining the USETHROWER compilation symbol.
  The definition of that symbol was the cause of common errors and was not helpful on the performance side.
* Added RaiseObjectDisposedException.
* Added methods for string validation to RaiseArgumentException.
* Initial support for DNX.

### v2.0.3 (2015-10-31) ###

* FastMember.ObjectAccessor now implements IDictionary&lt;string, object&gt;.
* Added HttpException for Web API projects.

### v2.0.2 (2015-10-24) ###

* Embedded FastMember.
* Added a simple reflection-based object validator.

### v2.0.1 (2015-10-10) ###

* All assemblies are now signed.
* Added RaiseNotSupportedException and RaiseIndexOutOfRangeException.
