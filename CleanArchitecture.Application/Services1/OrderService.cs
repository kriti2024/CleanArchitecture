using CleanArchitecture.Application.DTOs1;
using CleanArchitecture.Application.Interfaces1;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services1;

public class OrderService(IOrderRepository repository) : IOrderService
{
    public async Task<IEnumerable<OrderDto>> GetAllAsync()
    {
        var orders = await repository.FindAllAsync();
        return orders.Select(o => new OrderDto
        {
            OrderId = o.OrderId,
            CustomerId = o.CustomerId,
            TotalAmount = o.TotalAmount,
            Status = o.Status
        });
    }

    public async Task<OrderDto?> GetByIdAsync(int id)
    {
        var order = await repository.GetByIdAsync(id);
        if (order is null) return null;

        return new OrderDto
        {
            OrderId = order.OrderId,
            CustomerId = order.CustomerId,
            TotalAmount = order.TotalAmount,
            Status = order.Status
        };
    }

    public async Task<IEnumerable<OrderDto>> GetByCustomerIdAsync(int customerId)
    {
        var orders = await repository.GetByCustomerIdAsync(customerId);
        return orders.Select(o => new OrderDto
        {
            OrderId = o.OrderId,
            CustomerId = o.CustomerId,
            TotalAmount = o.TotalAmount,
            Status = o.Status
        });
    }

    public async Task<OrderDto> CreateAsync(CreateOrderDto dto)
    {
        var order = new Order
        {
            CustomerId = dto.CustomerId,
            TotalAmount = dto.TotalAmount,
            Status = dto.Status
        };

        repository.Create(order);
        await repository.SaveChangesAsync();

        return new OrderDto
        {
            OrderId = order.OrderId,
            CustomerId = order.CustomerId,
            TotalAmount = order.TotalAmount,
            Status = order.Status
        };
    }

    public async Task<OrderDto?> UpdateAsync(int id, UpdateOrderDto dto)
    {
        var order = await repository.GetByIdAsync(id);
        if (order is null) return null;

        order.TotalAmount = dto.TotalAmount;
        order.Status = dto.Status;

        repository.Update(order);
        await repository.SaveChangesAsync();

        return new OrderDto
        {
            OrderId = order.OrderId,
            CustomerId = order.CustomerId,
            TotalAmount = order.TotalAmount,
            Status = order.Status
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var order = await repository.GetByIdAsync(id);
        if (order is null) return false;

        repository.Delete(order);
        await repository.SaveChangesAsync();
        return true;
    }
}