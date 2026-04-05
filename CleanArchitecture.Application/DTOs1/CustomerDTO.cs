namespace CleanArchitecture.Application.DTOs1;

public class CustomerDto
{
    public int CustomerId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public class CreateCustomerDto
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public class UpdateCustomerDto
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}