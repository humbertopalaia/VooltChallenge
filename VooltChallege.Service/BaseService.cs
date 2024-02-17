using VooltChallenge.Infra.Exceptions;
using VooltChallenge.Infra.Repository;

namespace VooltChallenge.Service;

public class BaseService<T>(IRepository<T> repository)
{
    private const string InvalidKeyMessage = "This key already exists or is invalid";

    protected IRepository<T> _repository = repository;

  
    public void VerifyKey(string key)
    {
        if(key.Contains(' ') || repository.GetByKey(key) != null)
            throw new NotAcceptableException(InvalidKeyMessage);
    }
}
