namespace VooltChallenge.Infra.Exceptions;
public class NotFoundException : BaseException
{
    public NotFoundException(string message, string errorCode) : base(errorCode, message)
    {
        Status = 404;
    }

    public NotFoundException(string errorCode) : base(errorCode)
    {
        Status = 404;
    }
}