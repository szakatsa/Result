
# Szakatsa.Result

Szakatsa.Result is a lightweight, extensible C# library that provides a robust implementation of the Result pattern. It’s designed to encapsulate success and failure outcomes in a clean, expressive, and type-safe manner.



## Features

- Represent results with or without values
- Support for strongly-typed errors
- Multiple exceptions  per failure
- Minimal, dependency-free API
- Public domain licensing (Unlicense)


## Usage

### Basic Result (No Value)
    using Szakatsa.Result;

    Result successful = Result.Success();
    Result failed = Result.Fail(new NotImplementedException());

### Result With Value
    using Szakatsa.Result;

    Result<string> successfulWithValue = Result.Success("This is the value of the successful attempt");
    Result<string> failedWithValue = Result.Fail(new NotSupportedException("There is no value associated when an attempt fails"));


### Result with Value and typed Error
    Result<string, int> failedWithTypedError = Result.Fail(32); //e.g., an error code

### Checking Result State
    using Szakatsa.Result;

    Result<string, int> result = Result.Fail(64);

    if (result.IsSuccessful)
    {
        string value = result.Value;
    }
    else
    {
        int errorCode = result.Error;
        Exception[] exceptions = result.Exceptions;
        Exception? combinedException = result.Exception;
    }

The Exception property contains:
- null if no exceptions were registered
- A single exception if only one was registered
- An AggregateException if multiple exceptions were registered
## License
Szakatsa.Result is released under the Unlicense.

This means:
- ✅ You can freely use, modify, distribute, or sell the software
- ❌ No warranties or guarantees are provided
- 💼 Suitable for both personal and commercial use

This is free and unencumbered software released into the public domain.

Anyone is free to copy, modify, publish, use, compile, sell, or
distribute this software, either in source code form or as a compiled
binary, for any purpose, commercial or non-commercial, and by any
means.

In jurisdictions that recognize copyright laws, the author or authors
of this software dedicate any and all copyright interest in the
software to the public domain. We make this dedication for the benefit
of the public at large and to the detriment of our heirs and
successors. We intend this dedication to be an overt act of
relinquishment in perpetuity of all present and future rights to this
software under copyright law.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

For more information, please refer to <https://unlicense.org/>