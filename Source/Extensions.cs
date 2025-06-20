using System;

namespace SzakatsA.Result
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

        public static SuccessfulResult ToSuccessfulResult(this Result result) => result.IsSuccessful ? new SuccessfulResult() : throw new InvalidCastException("Cannot cast failed result to SuccessfulResult");
        public static SuccessfulResult<TValue> ToSuccessfulResult<TValue>(this Result<TValue> result) => result.IsSuccessful ? new SuccessfulResult<TValue>(result.Value) : throw new InvalidCastException("Cannot cast failed result to SuccessfulResult");
        public static FailedResult ToFailedResult(this Result result) => !result.IsSuccessful ? new FailedResult(result.Exceptions) : throw new InvalidCastException("Cannot cast successful result to FailedResult");
        public static FailedResult<TError> ToFailedResult<TValue, TError>(this Result<TValue, TError> result) => !result.IsSuccessful ? new FailedResult<TError>(result.Error, result.Exceptions) : throw new InvalidCastException("Cannot cast successful result to FailedResult");
    }
}