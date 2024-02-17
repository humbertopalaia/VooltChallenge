using System.Runtime.Serialization;

namespace VooltChallenge.Infra.Exceptions;

public class BaseException : Exception
{
    public string ErrorCode { get; }
    public int Status { get; protected init; } = 400;

    public BaseException(string? errorCode, string? message) : base(message)
    {
        if (string.IsNullOrEmpty(errorCode))
        {
            this.ErrorCode = Exceptions.ErrorCode.UnknowError;
            return;
        }

        this.ErrorCode = errorCode;
    }

    public BaseException(string errorCode) : base(errorCode)
    {
        ErrorCode = errorCode;
    }

    public BaseException(string errorCode, Exception? cause) : base(errorCode, cause)
    {
        ErrorCode = errorCode;
    }
}