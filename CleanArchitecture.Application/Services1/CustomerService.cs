using CleanArchitecture.Application.DTOs1;
using CleanArchitecture.Application.Interfaces1;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services1;

public class CustomerService(ICustomerRepository repository) : ICustomerService
{
    public async Task<IEnumerable<CustomerDto>> GetAllAsync()
    {
        var customers = await repository.FindAllAsync();
        return customers.Select(c => new CustomerDto
        {
            CustomerId = c.CustomerId,
            FullName = c.FullName,
            Email = c.Email
        });
    }

    public async Task<CustomerDto?> GetByIdAsync(int id)
    {
        var customer = await repository.GetByIdAsync(id);
        if (customer is null) return null;

        return new CustomerDto
        {
            CustomerId = customer.CustomerId,
            FullName = customer.FullName,
            Email = customer.Email
        };
    }

    public async Task<CustomerDto> CreateAsync(CreateCustomerDto dto)
    {
        var customer = new Customer
        {
            FullName = dto.FullName,
            Email = dto.Email
        };

        repository.Create(customer);
        await repository.SaveChangesAsync();

        return new CustomerDto
        {
            CustomerId = customer.CustomerId,
            FullName = customer.FullName,
            Email = customer.Email
        };
    }

    public async Task<CustomerDto?> UpdateAsync(int id, UpdateCustomerDto dto)
    {
        var customer = await repository.GetByIdAsync(id);
        if (customer is null) return null;

        customer.FullName = dto.FullName;
        customer.Email = dto.Email;

        repository.Update(customer);
        await repository.SaveChangesAsync();

        return new CustomerDto
        {
            CustomerId = customer.CustomerId,
            FullName = customer.FullName,
            Email = customer.Email
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var customer = await repository.GetByIdAsync(id);
        if (customer is null) return false;

        repository.Delete(customer);
        await repository.SaveChangesAsync();
        return true;
    }
}