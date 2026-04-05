using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces1;

public interface ICustomerRepository : IRepositoryBase<Customer>
{
    Task<Customer?> GetByIdAsync(int id);
}