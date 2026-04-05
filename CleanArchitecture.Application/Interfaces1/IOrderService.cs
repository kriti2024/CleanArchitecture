using CleanArchitecture.Application.DTOs1;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetAllAsync();
    Task<OrderDto?> GetByIdAsync(int id);
    Task<IEnumerable<OrderDto>> GetByCustomerIdAsync(int customerId);
    Task<OrderDto> CreateAsync(CreateOrderDto dto);
    Task<OrderDto?> UpdateAsync(int id, UpdateOrderDto dto);
    Task<bool> DeleteAsync(int id);
}