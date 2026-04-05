using CleanArchitecture.Application.Interfaces1;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories1;

public class CustomerRepository(AppDbContext context) : RepositoryBase<Customer>(context), ICustomerRepository
{
    public async Task<Customer?> GetByIdAsync(int id) =>
        await _dbSet.FirstOrDefaultAsync(c => c.CustomerId == id);
}