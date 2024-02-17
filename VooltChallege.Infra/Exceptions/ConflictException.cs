namespace VooltChallenge.Infra.Exceptions;

public class ConflictException : BaseException
{
    public ConflictException(string message, string errorCode) : base(errorCode, message)
    {
        Status = 409;
    }

    public ConflictException(string errorCode) : base(errorCode)
    {
        Status = 409;
    }
}