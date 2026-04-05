using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces1;

public interface IOrderRepository : IRepositoryBase<Order>
{
    Task<Order?> GetByIdAsync(int id);
    Task<IEnumerable<Order>> GetByCustomerIdAsync(int customerId);
}