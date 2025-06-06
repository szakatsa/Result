using System;

namespace Szakatsa.Result
{
    public static class Extensions
    {
        public static Result<T2> Convert<T1, T2>(this Result<T1> result, Func<T1, T2> converter)
        {
            if (result.IsSuccessful)
                return new Result<T2>(converter(result.Value));
            else
                return new Result<T2>(result.Exceptions);
        }

        public static Result<TV2, TE2> Convert<T1, TV2, TE2>(this Result<T1> result, Func<T1, TV2> valueConverter, TE2 error)
        {
            if (result.IsSuccessful)
                return new Result<TV2, TE2>(valueConverter(result.Value));
            else
                return new Result<TV2, TE2>(error, result.Exceptions);
        }
        
        public static Result<TV2, TE2> Convert<TV1, TV2, TE1, TE2>(this Result<TV1, TE1> result, Func<TV1, TV2> valueConverter, Func<TE1, TE2> errorConverter)
        {
            if (result.IsSuccessful)
                return new Result<TV2, TE2>(valueConverter(result.Value));
            else
                return new Result<TV2, TE2>(errorConverter(result.Error), result.Exceptions);
        }

        public static Result<T2> Convert<TV1, T2, TE1>(this Result<TV1, TE1> result, Func<TV1, T2> valueConverter)
        {
            if (result.IsSuccessful)
                return new Result<T2>(valueConverter(result.Value));
            else
                return new Result<T2>(result.Exceptions);
        }
    }
}