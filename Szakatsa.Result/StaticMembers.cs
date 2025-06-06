using System;

namespace Szakatsa.Result
{
    public partial class Result
    {
        public static SuccessfulResult Success() => new SuccessfulResult();
        public static SuccessfulResult<TValue> Success<TValue>(TValue value) => new SuccessfulResult<TValue>(value);
        public static FailedResult Fail(params Exception[] exceptions) => new FailedResult(exceptions);
        public static FailedResult<TError> Fail<TError>(TError error, params Exception[] exceptions) => new FailedResult<TError>(error, exceptions);

        public static implicit operator Result(SuccessfulResult success) => new Result(true);
        public static implicit operator Result(FailedResult fail) => new Result(false, fail.Exceptions);
    }

    public partial class Result<TValue>
    {
        public static implicit operator Result<TValue>(SuccessfulResult<TValue> success) => new Result<TValue>(success.Value);
        public static implicit operator Result<TValue>(FailedResult fail) => new Result<TValue>(fail.Exceptions);
    }

    public partial class Result<TValue, TError>
    {
        public static implicit operator Result<TValue, TError>(SuccessfulResult<TValue> success) => new Result<TValue, TError>(success.Value);
        public static implicit operator Result<TValue, TError>(FailedResult<TError> fail) => new Result<TValue, TError>(fail.Error, fail.Exceptions);
    }
}