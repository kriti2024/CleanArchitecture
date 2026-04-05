using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Interfaces1;

namespace CleanArchitecture.Infrastructure.Repositories1;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public RepositoryBase(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> FindAllAsync() =>
        await _dbSet.ToListAsync();

    public async Task<IEnumerable<T>> FindByConditionAsync(Func<T, bool> predicate) =>
        await Task.FromResult(_dbSet.Where(predicate));

    public void Create(T entity) => _dbSet.Add(entity);

    public void Update(T entity) => _dbSet.Update(entity);

    public void Delete(T entity) => _dbSet.Remove(entity);

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}