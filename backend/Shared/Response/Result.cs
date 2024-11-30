using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Shared.Response
{
    public class Result
    {
        public Result(bool isSuccess, Error error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }
        public Error Error { get; }

        // not data
        public static Result Success() => new(true, Error.None);

        public static Result Failure(Error error) => new(false, error);

        // if have data
        public static Result<T> Success<T>(T data) => new(true, Error.None, data);

        public static Result<T> Failure<T>(Error error) => new(false, error, default);
    }
}
