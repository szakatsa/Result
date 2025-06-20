namespace SzakatsA.Result
{
    public class SuccessfulResult {}

    public class SuccessfulResult<TValue> : SuccessfulResult
    {
        public TValue Value { get; }

        public SuccessfulResult(TValue value)
        {
            Value = value;
        }
    }
}