using System.Linq.Expressions;
using VooltChallenge.Domain.Entities;

namespace VooltChallenge.Infra.Repository;

public interface IRepository<T>
{
    T? GetByKey(string key);
    T Save(T entity);
}
