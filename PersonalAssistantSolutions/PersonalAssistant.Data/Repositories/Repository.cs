namespace PersonalAssistant.Data.Repositories;

public class Repository<T> : IRepository<T> where T : class, new()
{
    protected readonly PersonalAssistantDatabaseContext _context;

    public Repository(PersonalAssistantDatabaseContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        try
        {
            _context.Set<T>().Add(entity);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void AddRange(IEnumerable<T> entities)
    {
        try
        {
            _context.Set<T>().AddRange(entities);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Delete(T entity)
    {
        try
        {
            _context.Set<T>().Remove(entity);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        try
        {
            _context.Set<T>().RemoveRange(entities);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<T> Get(int id)
    {
        try
        {
            return await _context.Set<T>().FindAsync(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<T> GetShort(short id)
    {
        try
        {
            return await _context.Set<T>().FindAsync(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<T> GetLong(long id)
    {
        try
        {
            return await _context.Set<T>().FindAsync(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<T> GetString(string val)
    {
        try
        {
            return await _context.Set<T>().FindAsync(val);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IList<T>> GetAll()
    {
        try
        {
            return await _context.Set<T>().ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IQueryable<T> GetAllAsQuarable()
    {
        try
        {
            return _context.Set<T>().AsQueryable();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Update(T entity)
    {
        try
        {
            _context.Set<T>().Update(entity);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        try
        {
            _context.Set<T>().UpdateRange(entities);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
