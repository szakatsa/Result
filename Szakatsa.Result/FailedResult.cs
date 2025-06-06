using System;

namespace Szakatsa.Result
{
    public class FailedResult
    {
        private Exception[] _exceptions;

        public FailedResult(params Exception[] exceptions)
        {
            this._exceptions = exceptions;
        }

        public Exception[] Exceptions => this._exceptions;

        public Exception? Exception => this._exceptions.Length switch
        {
            0 => null,
            1 => this._exceptions[0],
            _ => new AggregateException(this._exceptions)
        };

        public FailedResult WithExceptions(params Exception[] exceptions)
        {
            Array.Resize(ref this._exceptions, this._exceptions.Length + exceptions.Length);
            Array.Copy(exceptions, this._exceptions, this._exceptions.Length);
            return this;
        }
    }

    public class FailedResult<TError> : FailedResult
    {
        public TError Error { get; }

        public FailedResult(TError error, params Exception[] exceptions) : base(exceptions)
        {
            Error = error;
        }
    }
}