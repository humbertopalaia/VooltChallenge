using System.Linq.Expressions;
using System.Text.Json;
using VooltChallenge.Domain.Entities;

namespace VooltChallenge.Infra.Repository;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private List<T>? _data;
    private string? _jsonFileName;
    public Repository()
    {
        VerifyLoadData();
    }

    private void VerifyLoadData()
    {
        _jsonFileName = $"{typeof(T).Name}.json";
        List<T>? tempData = null;

        if (File.Exists(_jsonFileName))
        {
            var fullTextFile = File.ReadAllText(_jsonFileName);
            if (!string.IsNullOrEmpty(fullTextFile))
                tempData = JsonSerializer.Deserialize<List<T>>(fullTextFile);

        }
        else
            File.Create(_jsonFileName);

        _data = tempData ?? [];
    }

    public T? GetByKey(string key)
    {
        if(_data  == null) return null;

        var entity = _data.Where(entity => entity.Key == key).FirstOrDefault();
        return entity;
    }

    public T Save(T entity)
    {
        if (_data == null) throw new Exception("Data object doesn't exists");

        var currentEntity = GetByKey(entity.Key);

        if (currentEntity is null)
            _data.Add(entity);
        else
        {
            var index = _data.IndexOf(currentEntity);
            _data[index] = entity;
        }

        SaveChanges();

        return entity;
    }

    public void Delete(T entity)
    {
        if(_data != null)
        {
            var currentEntity = GetByKey(entity.Key);

            if (currentEntity is not null)
            {
                var index = _data.IndexOf(currentEntity);
                _data.RemoveAt(index);
                SaveChanges();
            }
        }        
    }

    private void SaveChanges()
    {
        var fullTextFile = JsonSerializer.Serialize(_data);

        VerifyLoadData();

        if(!string.IsNullOrEmpty(_jsonFileName))
        {
            File.Delete(_jsonFileName);
            File.WriteAllText(_jsonFileName, fullTextFile);
        }        
    }
}
