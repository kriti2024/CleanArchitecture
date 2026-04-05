using CleanArchitecture.Application.DTOs1;
using CleanArchitecture.Application.Interfaces1;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services1;

public class OrderItemService(IOrderItemRepository repository) : IOrderItemService
{
    public async Task<IEnumerable<OrderItemDto>> GetAllAsync()
    {
        var items = await repository.FindAllAsync();
        return items.Select(i => new OrderItemDto
        {
            Id = i.Id,
            OrderId = i.OrderId,
            productName = i.productName,
            Quantity = i.Quantity,
            UnitPrice = i.UnitPrice
        });
    }

    public async Task<OrderItemDto?> GetByIdAsync(int id)
    {
        var item = await repository.GetByIdAsync(id);
        if (item is null) return null;

        return new OrderItemDto
        {
            Id = item.Id,
            OrderId = item.OrderId,
            productName = item.productName,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice
        };
    }

    public async Task<IEnumerable<OrderItemDto>> GetByOrderIdAsync(int orderId)
    {
        var items = await repository.GetByOrderIdAsync(orderId);
        return items.Select(i => new OrderItemDto
        {
            Id = i.Id,
            OrderId = i.OrderId,
            productName = i.productName,
            Quantity = i.Quantity,
            UnitPrice = i.UnitPrice
        });
    }

    public async Task<OrderItemDto> CreateAsync(CreateOrderItemDto dto)
    {
        var item = new OrderItem
        {
            OrderId = dto.OrderId,
            productName = dto.productName,
            Quantity = dto.Quantity,
            UnitPrice = dto.UnitPrice
        };

        repository.Create(item);
        await repository.SaveChangesAsync();

        return new OrderItemDto
        {
            Id = item.Id,
            OrderId = item.OrderId,
            productName = item.productName,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice
        };
    }

    public async Task<OrderItemDto?> UpdateAsync(int id, UpdateOrderItemDto dto)
    {
        var item = await repository.GetByIdAsync(id);
        if (item is null) return null;

        item.productName = dto.productName;
        item.Quantity = dto.Quantity;
        item.UnitPrice = dto.UnitPrice;

        repository.Update(item);
        await repository.SaveChangesAsync();

        return new OrderItemDto
        {
            Id = item.Id,
            OrderId = item.OrderId,
            productName = item.productName,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await repository.GetByIdAsync(id);
        if (item is null) return false;

        repository.Delete(item);
        await repository.SaveChangesAsync();
        return true;
    }
}