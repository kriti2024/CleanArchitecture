using CleanArchitecture.Application.DTOs1;

public interface IOrderItemService
{
    Task<IEnumerable<OrderItemDto>> GetAllAsync();
    Task<OrderItemDto?> GetByIdAsync(int id);
    Task<IEnumerable<OrderItemDto>> GetByOrderIdAsync(int orderId);
    Task<OrderItemDto> CreateAsync(CreateOrderItemDto dto);
    Task<OrderItemDto?> UpdateAsync(int id, UpdateOrderItemDto dto);
    Task<bool> DeleteAsync(int id);
}