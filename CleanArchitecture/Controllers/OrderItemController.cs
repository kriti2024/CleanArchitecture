using CleanArchitecture.Application.DTOs1;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderItemController(IOrderItemService service) : ControllerBase
{
    // GET /api/orderitems
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await service.GetAllAsync();
        return Ok(items);
    }

    // GET /api/orderitems/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await service.GetByIdAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    // GET /api/orderitems/order/{orderId}
    [HttpGet("order/{orderId}")]
    public async Task<IActionResult> GetByOrder(int orderId)
    {
        var items = await service.GetByOrderIdAsync(orderId);
        return Ok(items);
    }

    // POST /api/orderitems
    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderItemDto dto)
    {
        var item = await service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
    }

    // PATCH /api/orderitems/{id}
    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, UpdateOrderItemDto dto)
    {
        var item = await service.UpdateAsync(id, dto);
        return item is null ? NotFound() : Ok(item);
    }

    // DELETE /api/orderitems/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await service.DeleteAsync(id);
        return result ? NoContent() : NotFound();
    }
}