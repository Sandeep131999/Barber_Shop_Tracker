using backend.Models;
using backend.Configuration;
using Npgsql;
using Serilog;

namespace backend.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly NpgsqlDataSource _dataSource;

    public CustomerRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }


    public async Task<Guid>InsertAsync(Customers customer)
    {
        Log.Information("Inserting customer {@Customer}", customer);

        //To get the path
        var xmlPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "SqlQueries",
            "BarberShop.xml");

        var sql = SqlQueryReader.GetQuery(xmlPath, "InsertCustomer");

        await using var connection = await _dataSource.OpenConnectionAsync();
        await using var command = new NpgsqlCommand(sql, connection);

        // Parameterized query (safe)
        command.Parameters.AddWithValue("name", customer.Name);
        command.Parameters.AddWithValue("phone", (object?)customer.Phone ?? DBNull.Value);

        try
        {
            Log.ForContext("SourceContext", "PostgreSql")
               .Information("Executing INSERT SQL");

            //! means guid must no empty
            var customerId = (Guid)(await command.ExecuteScalarAsync())!;
            Log.Information("Customer inserted successfully with ID {CustomerId}", customerId);
            return customerId;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Failed inserting customer {@Customer}", customer);
            throw;
        }
    }
}
