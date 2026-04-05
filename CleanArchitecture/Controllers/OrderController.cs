using CleanArchitecture.Application.DTOs1;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IOrderService service) : ControllerBase
{
    // GET /api/orders
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await service.GetAllAsync();
        return Ok(orders);
    }

    // GET /api/orders/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await service.GetByIdAsync(id);
        return order is null ? NotFound() : Ok(order);
    }

    // GET /api/orders/customer/{customerId}
    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetByCustomer(int customerId)
    {
        var orders = await service.GetByCustomerIdAsync(customerId);
        return Ok(orders);
    }

    // POST /api/orders
    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderDto dto)
    {
        var order = await service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = order.OrderId }, order);
    }

    // PATCH /api/orders/{id}
    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, UpdateOrderDto dto)
    {
        var order = await service.UpdateAsync(id, dto);
        return order is null ? NotFound() : Ok(order);
    }

    // DELETE /api/orders/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await service.DeleteAsync(id);
        return result ? NoContent() : NotFound();
    }
}