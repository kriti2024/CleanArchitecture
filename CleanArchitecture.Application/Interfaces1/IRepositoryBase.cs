namespace CleanArchitecture.Application.Interfaces1;

public interface IRepositoryBase<T> where T : class
{
    Task<IEnumerable<T>> FindAllAsync();
    Task<IEnumerable<T>> FindByConditionAsync(Func<T, bool> predicate);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task SaveChangesAsync();
}