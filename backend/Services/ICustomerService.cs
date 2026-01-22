using backend.DTO;

namespace backend.Services;

public interface ICustomerService
{
    Task CreateAsync(CustomerDto customer);
}
