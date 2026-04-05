using CleanArchitecture.Application.Interfaces1;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories1;

public class OrderRepository(AppDbContext context) : RepositoryBase<Order>(context), IOrderRepository
{
    public async Task<Order?> GetByIdAsync(int id) =>
        await _dbSet
            .Include(o => o.Customer)
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.OrderId == id);

    public async Task<IEnumerable<Order>> GetByCustomerIdAsync(int customerId) =>
        await _dbSet
            .Where(o => o.CustomerId == customerId)
            .Include(o => o.OrderItems)
            .ToListAsync();
}