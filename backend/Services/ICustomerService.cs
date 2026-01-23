using backend.DTO;

namespace backend.Services;

public interface ICustomerService
{
    Task<Guid> InsertAsync(CustomerDto customer);
}