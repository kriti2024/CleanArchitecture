using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.DTOs1;

public class OrderDto
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; }
}

public class CreateOrderDto
{
    public int CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; }
}

public class UpdateOrderDto
{
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; }
}