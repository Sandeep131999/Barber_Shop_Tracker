using backend.DTO;
using backend.Models;
using backend.Repository;

namespace backend.Services;

/// <summary>
/// SERVICE implementation for customers.
/// </summary>
public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(CustomerDto customerDto)
    {
        // 1) Map DTO → Entity
        var customer = new Customers
        {
            Name = customerDto.Name,
            Phone = customerDto.Phone
        };

        // 2) Call repository
        await _repository.InsertAsync(customer);
    }
}
