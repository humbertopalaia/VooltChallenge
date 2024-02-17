namespace VooltChallenge.Infra.Exceptions;
public class NotAcceptableException : BaseException
{
    public NotAcceptableException(string message, string errorCode) : base(errorCode, message)
    {
        Status = 406;
    }

    public NotAcceptableException(string errorCode) : base(errorCode)
    {
        Status = 406;
    }
}