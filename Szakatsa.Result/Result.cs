using System;
using System.Diagnostics.CodeAnalysis;

namespace Szakatsa.Result
{
    public partial class Result
    {
        private readonly Exception[] _exceptions;
        
        public virtual bool IsSuccessful { get; }
        public bool IsFailed => !IsSuccessful;
        
        public Result(bool isSuccessful, params Exception[] exceptions)
        {
            IsSuccessful = isSuccessful;
            _exceptions = exceptions;
        }
        
        public Exception[] Exceptions => this._exceptions;

        public Exception? Exception => this._exceptions.Length switch
        {
            0 => null,
            1 => this._exceptions[0],
            _ => new AggregateException(this._exceptions)
        };
    }

    public partial class Result<TValue> : Result
    {
        #if !NETSTANDARD2_0 && !NETSTANDARD2_1
        [MemberNotNullWhen(true, nameof(Value))]
        #endif
        public override bool IsSuccessful => base.IsSuccessful;
        public TValue? Value { get; }

        public Result(TValue value) : base(true)
        {
            Value = value;
        }

        public Result(params Exception[] exceptions) : base(false, exceptions) {}
    }

    public partial class Result<TValue, TError> : Result<TValue>
    {
        #if !NETSTANDARD2_0 && !NETSTANDARD2_1
        [MemberNotNullWhen(false, nameof(Error))]
        #endif
        public override bool IsSuccessful => base.IsSuccessful;
        public TError? Error { get; }

        public Result(TValue value) : base(value) {}

        public Result(TError error, params Exception[] exceptions) : base(exceptions)
        {
            Error = error;
        }
    }
}