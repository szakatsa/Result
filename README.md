
# Szakatsa.Result

The project aims for a good implementation for the Result problem



## Usage

### Without value
    using Szakatsa.Result;

    Result successful = Result.Success();
    Result failed = Result.Fail(new NotImplementedException());

### With value
    using Szakatsa.Result;

    Result<string> successfulWithValue = Result.Success("This is the value of the successful attempt");
    Result<string> failedWithValue = Result.Fail(new NotSupportedException("There is no value associated when an attempt fails"));


### With value and typed error
    Result<string, int> failedWithTypedError = Result.Fail(32); //An error code for example

### Checking
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
The exception property will have null value if there were no exceptions registered, the single exception if only one exception was registered, and an AggregateException containing all other exceptions if there were multiple exceptions registered.
## License
The library is licensed under the unlicense license:

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