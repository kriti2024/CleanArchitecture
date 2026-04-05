namespace CleanArchitecture.Application.DTOs1;

public class OrderItemDto
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string productName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

public class CreateOrderItemDto
{
    public int OrderId { get; set; }
    public string productName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

public class UpdateOrderItemDto
{
    public string productName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}