using CleanArchitecture.Application.DTOs1;
using CleanArchitecture.Application.Interfaces1;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(ICustomerService service) : ControllerBase
{
    // GET /api/customers
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customers = await service.GetAllAsync();
        return Ok(customers);
    }

    // GET /api/customers/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var customer = await service.GetByIdAsync(id);
        return customer is null ? NotFound() : Ok(customer);
    }

    // POST /api/customers
    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerDto dto)
    {
        var customer = await service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = customer.CustomerId }, customer);
    }

    // PATCH /api/customers/{id}
    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, UpdateCustomerDto dto)
    {
        var customer = await service.UpdateAsync(id, dto);
        return customer is null ? NotFound() : Ok(customer);
    }

    // DELETE /api/customers/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await service.DeleteAsync(id);
        return result ? NoContent() : NotFound();
    }
}