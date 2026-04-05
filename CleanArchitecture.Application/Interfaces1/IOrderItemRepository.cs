using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces1;

public interface IOrderItemRepository : IRepositoryBase<OrderItem>
{
    Task<OrderItem?> GetByIdAsync(int id);
    Task<IEnumerable<OrderItem>> GetByOrderIdAsync(int orderId);
}