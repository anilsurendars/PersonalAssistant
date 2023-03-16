namespace PersonalAssistant.Data.Repositories.Interfaces;

public interface IRepository<T> where T : class, new()
{
    Task<T> Get(int id);
    Task<T> GetLong(long id);
    Task<T> GetShort(short id);
    Task<T> GetString(string val);
    Task<IList<T>> GetAll();
    IQueryable<T> GetAllAsQuarable();
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    void Delete(T entity);
    void DeleteRange(IEnumerable<T> entities);
}
