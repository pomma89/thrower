
var camelCaseTokenizer = function (obj) {
    var previous = '';
    return obj.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
        var current = cur.toLowerCase();
        if(acc.length === 0) {
            previous = current;
            return acc.concat(current);
        }
        previous = previous.concat(current);
        return acc.concat([current, previous]);
    }, []);
}
lunr.tokenizer.registerFunction(camelCaseTokenizer, 'camelCaseTokenizer')
var searchModule = function() {
    var idMap = [];
    function y(e) { 
        idMap.push(e); 
    }
    var idx = lunr(function() {
        this.field('title', { boost: 10 });
        this.field('content');
        this.field('description', { boost: 5 });
        this.field('tags', { boost: 50 });
        this.ref('id');
        this.tokenizer(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
    });
    function a(e) { 
        idx.add(e); 
    }

    a({
        id:0,
        title:"MemberSet",
        content:"MemberSet",
        description:'',
        tags:''
    });

    a({
        id:1,
        title:"Raise",
        content:"Raise",
        description:'',
        tags:''
    });

    a({
        id:2,
        title:"TypeAccessor RuntimeTypeAccessor",
        content:"TypeAccessor RuntimeTypeAccessor",
        description:'',
        tags:''
    });

    a({
        id:3,
        title:"LogProvider",
        content:"LogProvider",
        description:'',
        tags:''
    });

    a({
        id:4,
        title:"IOExceptionHandler",
        content:"IOExceptionHandler",
        description:'',
        tags:''
    });

    a({
        id:5,
        title:"Logger",
        content:"Logger",
        description:'',
        tags:''
    });

    a({
        id:6,
        title:"EmailAddressValidator Options",
        content:"EmailAddressValidator Options",
        description:'',
        tags:''
    });

    a({
        id:7,
        title:"ThrowerException",
        content:"ThrowerException",
        description:'',
        tags:''
    });

    a({
        id:8,
        title:"PortableTypeInfo CastTo",
        content:"PortableTypeInfo CastTo",
        description:'',
        tags:''
    });

    a({
        id:9,
        title:"Raise",
        content:"Raise",
        description:'',
        tags:''
    });

    a({
        id:10,
        title:"LogLevel",
        content:"LogLevel",
        description:'',
        tags:''
    });

    a({
        id:11,
        title:"ValidateAttribute",
        content:"ValidateAttribute",
        description:'',
        tags:''
    });

    a({
        id:12,
        title:"TypeAccessor",
        content:"TypeAccessor",
        description:'',
        tags:''
    });

    a({
        id:13,
        title:"EnumerationValidator",
        content:"EnumerationValidator",
        description:'',
        tags:''
    });

    a({
        id:14,
        title:"StringExtensions",
        content:"StringExtensions",
        description:'',
        tags:''
    });

    a({
        id:15,
        title:"ILogProvider",
        content:"ILogProvider",
        description:'',
        tags:''
    });

    a({
        id:16,
        title:"PhoneNumberAttribute",
        content:"PhoneNumberAttribute",
        description:'',
        tags:''
    });

    a({
        id:17,
        title:"ArgumentOutOfRangeExceptionHandler",
        content:"ArgumentOutOfRangeExceptionHandler",
        description:'',
        tags:''
    });

    a({
        id:18,
        title:"EnumerationAttribute",
        content:"EnumerationAttribute",
        description:'',
        tags:''
    });

    a({
        id:19,
        title:"ObjectReader",
        content:"ObjectReader",
        description:'',
        tags:''
    });

    a({
        id:20,
        title:"ObjectAccessor",
        content:"ObjectAccessor",
        description:'',
        tags:''
    });

    a({
        id:21,
        title:"NotSupportedExceptionHandler",
        content:"NotSupportedExceptionHandler",
        description:'',
        tags:''
    });

    a({
        id:22,
        title:"HttpExceptionHandler",
        content:"HttpExceptionHandler",
        description:'',
        tags:''
    });

    a({
        id:23,
        title:"InvalidOperationExceptionHandler",
        content:"InvalidOperationExceptionHandler",
        description:'',
        tags:''
    });

    a({
        id:24,
        title:"FormattableObject",
        content:"FormattableObject",
        description:'',
        tags:''
    });

    a({
        id:25,
        title:"ObjectValidator",
        content:"ObjectValidator",
        description:'',
        tags:''
    });

    a({
        id:26,
        title:"EnvironmentExtensions",
        content:"EnvironmentExtensions",
        description:'',
        tags:''
    });

    a({
        id:27,
        title:"Member",
        content:"Member",
        description:'',
        tags:''
    });

    a({
        id:28,
        title:"EmailAddressAttribute",
        content:"EmailAddressAttribute",
        description:'',
        tags:''
    });

    a({
        id:29,
        title:"InvalidDataExceptionHandler",
        content:"InvalidDataExceptionHandler",
        description:'',
        tags:''
    });

    a({
        id:30,
        title:"ArgumentExceptionHandler",
        content:"ArgumentExceptionHandler",
        description:'',
        tags:''
    });

    a({
        id:31,
        title:"IndexOutOfRangeExceptionHandler",
        content:"IndexOutOfRangeExceptionHandler",
        description:'',
        tags:''
    });

    a({
        id:32,
        title:"ValidationError",
        content:"ValidationError",
        description:'',
        tags:''
    });

    a({
        id:33,
        title:"ObjectDisposedExceptionHandler",
        content:"ObjectDisposedExceptionHandler",
        description:'',
        tags:''
    });

    a({
        id:34,
        title:"EmailAddressValidator",
        content:"EmailAddressValidator",
        description:'',
        tags:''
    });

    a({
        id:35,
        title:"FileNotFoundExceptionHandler",
        content:"FileNotFoundExceptionHandler",
        description:'',
        tags:''
    });

    a({
        id:36,
        title:"InvalidCastExceptionHandler",
        content:"InvalidCastExceptionHandler",
        description:'',
        tags:''
    });

    a({
        id:37,
        title:"EquatableObject",
        content:"EquatableObject",
        description:'',
        tags:''
    });

    a({
        id:38,
        title:"RaiseBase",
        content:"RaiseBase",
        description:'',
        tags:''
    });

    a({
        id:39,
        title:"HttpExceptionInfo",
        content:"HttpExceptionInfo",
        description:'',
        tags:''
    });

    a({
        id:40,
        title:"GenericExceptionHandler",
        content:"GenericExceptionHandler",
        description:'',
        tags:''
    });

    a({
        id:41,
        title:"PortableTypeInfo",
        content:"PortableTypeInfo",
        description:'',
        tags:''
    });

    a({
        id:42,
        title:"PhoneNumberValidator",
        content:"PhoneNumberValidator",
        description:'',
        tags:''
    });

    a({
        id:43,
        title:"DirectoryNotFoundExceptionHandler",
        content:"DirectoryNotFoundExceptionHandler",
        description:'',
        tags:''
    });

    a({
        id:44,
        title:"ArgumentNullExceptionHandler",
        content:"ArgumentNullExceptionHandler",
        description:'',
        tags:''
    });

    a({
        id:45,
        title:"HttpException",
        content:"HttpException",
        description:'',
        tags:''
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.Reflection.FastMember/MemberSet',
        title:"MemberSet",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower/Raise',
        title:"Raise",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.Reflection.FastMember/RuntimeTypeAccessor',
        title:"TypeAccessor.RuntimeTypeAccessor",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.Logging/LogProvider',
        title:"LogProvider",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.ExceptionHandlers.IO/IOExceptionHandler',
        title:"IOExceptionHandler",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.Logging/Logger',
        title:"Logger",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.Validation/Options',
        title:"EmailAddressValidator.Options",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower/ThrowerException',
        title:"ThrowerException",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.Reflection/CastTo_1',
        title:"PortableTypeInfo.CastTo<T>",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower/Raise_1',
        title:"Raise<TEx>",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.Logging/LogLevel',
        title:"LogLevel",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.Validation/ValidateAttribute',
        title:"ValidateAttribute",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.Reflection.FastMember/TypeAccessor',
        title:"TypeAccessor",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.Validation/EnumerationValidator',
        title:"EnumerationValidator",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.Goodies/StringExtensions',
        title:"StringExtensions",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.Logging/ILogProvider',
        title:"ILogProvider",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.Validation/PhoneNumberAttribute',
        title:"PhoneNumberAttribute",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.ExceptionHandlers/ArgumentOutOfRangeExceptionHandler',
        title:"ArgumentOutOfRangeExceptionHandler",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.Validation/EnumerationAttribute',
        title:"EnumerationAttribute",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.Reflection.FastMember/ObjectReader',
        title:"ObjectReader",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.Reflection.FastMember/ObjectAccessor',
        title:"ObjectAccessor",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.ExceptionHandlers/NotSupportedExceptionHandler',
        title:"NotSupportedExceptionHandler",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.ExceptionHandlers.Net/HttpExceptionHandler',
        title:"HttpExceptionHandler",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.ExceptionHandlers/InvalidOperationExceptionHandler',
        title:"InvalidOperationExceptionHandler",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.Goodies/FormattableObject',
        title:"FormattableObject",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.Validation/ObjectValidator',
        title:"ObjectValidator",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.Goodies/EnvironmentExtensions',
        title:"EnvironmentExtensions",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.Reflection.FastMember/Member',
        title:"Member",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.Validation/EmailAddressAttribute',
        title:"EmailAddressAttribute",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.ExceptionHandlers.IO/InvalidDataExceptionHandler',
        title:"InvalidDataExceptionHandler",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.ExceptionHandlers/ArgumentExceptionHandler',
        title:"ArgumentExceptionHandler",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.ExceptionHandlers/IndexOutOfRangeExceptionHandler',
        title:"IndexOutOfRangeExceptionHandler",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.Validation/ValidationError',
        title:"ValidationError",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.ExceptionHandlers/ObjectDisposedExceptionHandler',
        title:"ObjectDisposedExceptionHandler",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.Validation/EmailAddressValidator',
        title:"EmailAddressValidator",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.ExceptionHandlers.IO/FileNotFoundExceptionHandler',
        title:"FileNotFoundExceptionHandler",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.ExceptionHandlers/InvalidCastExceptionHandler',
        title:"InvalidCastExceptionHandler",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.Goodies/EquatableObject_1',
        title:"EquatableObject<T>",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower/RaiseBase',
        title:"RaiseBase",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower/HttpExceptionInfo',
        title:"HttpExceptionInfo",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.ExceptionHandlers/GenericExceptionHandler_1',
        title:"GenericExceptionHandler<TException>",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.Reflection/PortableTypeInfo',
        title:"PortableTypeInfo",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.Validation/PhoneNumberValidator',
        title:"PhoneNumberValidator",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.ExceptionHandlers.IO/DirectoryNotFoundExceptionHandler',
        title:"DirectoryNotFoundExceptionHandler",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower.ExceptionHandlers/ArgumentNullExceptionHandler',
        title:"ArgumentNullExceptionHandler",
        description:""
    });

    y({
        url:'/Thrower/api/PommaLabs.Thrower/HttpException',
        title:"HttpException",
        description:""
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
