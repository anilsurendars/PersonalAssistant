namespace PersonalAssistant.Data.Repositories.Interfaces;

public interface IRepository<T> where T : class, new()
{
    Task<T> GetByIdAsync(int id);
    Task<IList<T>> GetAllAsync();
    IQueryable<T> GetAllAsQuarable();
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    void Delete(T entity);
    void DeleteRange(IEnumerable<T> entities);
}
