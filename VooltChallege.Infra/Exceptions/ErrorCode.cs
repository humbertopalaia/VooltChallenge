using VooltChallenge.Domain.Entities;
using VooltChallenge.Domain.Entities.Blocks;

namespace VooltChallenge.Infra.Exceptions;

public static class ErrorCode
{
    public const string EntityNotFound = "{0}_NotFound";
    public const string UnauthorizedError = "UnauthorizedError";
    public const string UnknowError = "UnknowError";
    public const string NotAcceptable = "NotAcceptable";

    public static string NotFound<T>() where T : BaseEntity
        => string.Format(EntityNotFound, typeof(T).Name);
}
