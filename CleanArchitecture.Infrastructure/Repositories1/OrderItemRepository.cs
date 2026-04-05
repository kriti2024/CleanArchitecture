using CleanArchitecture.Application.Interfaces1;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories1;

public class OrderItemRepository(AppDbContext context) : RepositoryBase<OrderItem>(context), IOrderItemRepository
{
    public async Task<OrderItem?> GetByIdAsync(int id) =>
        await _dbSet.Include(oi => oi.Order).FirstOrDefaultAsync(oi => oi.Id == id);

    public async Task<IEnumerable<OrderItem>> GetByOrderIdAsync(int orderId) =>
        await _dbSet.Where(oi => oi.OrderId == orderId).ToListAsync();
}