using backend.Models;

namespace backend.Repository;

/// <summary>
/// REPOSITORY = talks directly to the database.
/// Handles customer persistence.
/// </summary>
public interface ICustomerRepository
{
    /// <summary>
    /// Inserts a customer.
    /// </summary>
    Task InsertAsync(Customers customers);


    

}


