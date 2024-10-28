
# Version 11

This folder contains examples of all new features of the C# version 11.


Raw string literals -- 
Generic math support --
UTF-8 string literals -- 
Newlines in string interpolation expressions --
File-local types -- MR: Done
Auto-default structs -- MR
Extended nameof scope -- 
Numeric IntPtr -- MR
ref fields and scoped ref -- MR
Improved method group conversion to delegate -- MR


# File-local types

File-scoped types are types which can only be seen by source-code which
lives in the same file. This is similar to the private-modifier tagged
on a nested class, which can only be seen by code of the surrounding class
definition.

A common use-case for file-scoped types is for code-generators, which do
not want to pollute the namespace of the project where the code generator
runs.


## Ref Fields and Scoped Refs


## Pattern match Span<char> on a constant string

https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-11.0/pattern-match-span-of-char-on-string


## Required members 

https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/required

## Generic attributes

https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-11#generic-attributes
https://www.thomasclaudiushuber.com/2023/01/17/csharp-11-generic-attributes/

## List patterns

https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-11#list-patterns