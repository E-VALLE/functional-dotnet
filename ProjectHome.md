C# 3.0 and VB 9 provide strong elements of functional programming in mainstream languages (lambda expressions, extension methods, a weak version of type inference for local variables, etc.)

The library support for them, however, is pretty much limited to IEnumerable

&lt;T&gt;

 and LINQ. This project is intended to extend it by providing additional data structures, algorithms, and extension methods.

Thanks to the [LINQBridge library](http://www.albahari.com/nutshell/linqbridge.html) the libraries can be used with all versions of the .NET framework starting with 2.0. The C# 3.0 compiler is required to compile the libraries, of course.