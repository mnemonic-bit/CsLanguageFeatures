
# Version 11

This folder contains examples of all new features of the C# version 11.


Raw string literals -- 
UTF-8 string literals -- 
Newlines in string interpolation expressions --
Generic math support --
Extended nameof scope -- 


## Auto-default structs

Further reading:

* https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct#struct-initialization-and-default-values


# File-local types

File-scoped types are types which can only be seen by source-code which
lives in the same file. This is similar to the private-modifier tagged
on a nested class, which can only be seen by code of the surrounding class
definition.

A common use-case for file-scoped types is for code-generators, which do
not want to pollute the namespace of the project where the code generator
runs.

Further reading:

* https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-11#file-local-types


## Improved method group conversion to delegate

This feature allows the compiler to re-use an existing delegate instance
that has been created from a method group.

Further reading:

* https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-11#improved-method-group-conversion-to-delegate


## Numeric IntPtr

There are two new keywords, nint and nuint, which are just type aliases to
System.IntPtr and System.UIntPtr.

Further reading:

* https://learn.microsoft.com/en-us/dotnet/api/system.intptr?view=net-8.0
* https://learn.microsoft.com/en-us/dotnet/api/system.uintptr?view=net-8.0


## Ref Fields and Scoped Refs

Further reading:

* https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/declarations#scoped-ref


## Pattern match Span<char> on a constant string

* https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-11.0/pattern-match-span-of-char-on-string


## Required members 

* https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/required


## Generic attributes

* https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-11#generic-attributes
* https://www.thomasclaudiushuber.com/2023/01/17/csharp-11-generic-attributes/


## List patterns

* https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-11#list-patterns
