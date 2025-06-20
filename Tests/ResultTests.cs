using System;
using Xunit;

namespace SzakatsA.Result.Tests
{
    public class ResultTests
    {
        [Fact]
        public void Success_ReturnsSuccessfulResult()
        {
            var result = Result.Success();
            Assert.IsType<SuccessfulResult>(result);
        }

        [Fact]
        public void SuccessT_ReturnsSuccessfulResultWithValue()
        {
            var result = Result.Success(13);
            Assert.IsType<SuccessfulResult<int>>(result);
            var typed = (SuccessfulResult<int>)result;
            Assert.Equal(13, typed.Value);
        }

        [Fact]
        public void Fail_ReturnsFailedResultWithException()
        {
            var ex = new Exception("fail");
            var result = Result.Fail(ex);
            Assert.IsType<FailedResult>(result);
            Assert.Contains(ex, result.Exceptions);
        }

        [Fact]
        public void FailTError_ReturnsFailedResultWithErrorAndException()
        {
            var ex = new Exception("fail");
            var result = Result.Fail("my error", ex);
            Assert.IsType<FailedResult<string>>(result);
            var typed = (FailedResult<string>)result;
            Assert.Equal("my error", typed.Error);
            Assert.Contains(ex, typed.Exceptions);
        }

        [Fact]
        public void ResultT_FromSuccess_IsSuccessfulAndValue()
        {
            Result<int> result = Result.Success(42);
            Assert.True(result.IsSuccessful);
            Assert.Equal(42, result.Value);
            Assert.Empty(result.Exceptions);
        }

        [Fact]
        public void ResultT_FromFail_IsFailedAndHasExceptions()
        {
            var ex = new Exception("fail");
            Result<int> result = Result.Fail(ex);
            Assert.False(result.IsSuccessful);
            Assert.Contains(ex, result.Exceptions);
        }

        [Fact]
        public void ResultT_TError_FromSuccess_IsSuccessful()
        {
            Result<int, string> result = Result.Success(77);
            Assert.True(result.IsSuccessful);
            Assert.Equal(77, result.Value);
        }

        [Fact]
        public void ResultT_TError_FromFail_IsFailedAndHasError()
        {
            var ex = new Exception("fail");
            Result<int, string> result = Result.Fail("special error", ex);
            Assert.False(result.IsSuccessful);
            Assert.Equal("special error", result.Error);
            Assert.Contains(ex, result.Exceptions);
        }

        [Fact]
        public void Extensions_Convert_SuccessfulResult()
        {
            Result<int> result = Result.Success(5);
            Result<string> converted = result.Convert(x => x.ToString());
            Assert.True(converted.IsSuccessful);
            Assert.Equal("5", converted.Value);
        }

        [Fact]
        public void Extensions_Convert_FailedResult_PreservesExceptions()
        {
            var ex = new Exception("fail");
            Result<int> result = Result.Fail(ex);
            var converted = result.Convert(x => x.ToString());
            Assert.False(converted.IsSuccessful);
            Assert.Contains(ex, converted.Exceptions);
        }

        [Fact]
        public void ToSuccessfulResult_ThrowsIfNotSuccess()
        {
            Result<int> result = Result.Fail(new Exception("fail"));
            Assert.Throws<InvalidCastException>(() => result.ToSuccessfulResult());
        }

        [Fact]
        public void ToFailedResult_ThrowsIfNotFailed()
        {
            Result<int> result = Result.Success(1);
            Assert.Throws<InvalidCastException>(() => result.ToFailedResult());
        }
    }
}