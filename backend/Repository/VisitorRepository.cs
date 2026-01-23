using backend.Configuration;
using Npgsql;
using Serilog;
using backend.Models;

namespace backend.Repository;

public class VisitorRepository : IVisitorRepository
{
    private readonly NpgsqlDataSource _dataSource;

    public VisitorRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public async Task<Guid>InsertAsync(Visitor visits)
    {
        Log.Information("Inserting visits table");

        var xmlPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "SqlQueries",
            "BarberShop.xml");

        var sql = SqlQueryReader.GetQuery(xmlPath, "InsertVisits");

        await using var connection = await _dataSource.OpenConnectionAsync();
        await using var command = new NpgsqlCommand(sql, connection);

        // Parameterized query (safe)
        command.Parameters.AddWithValue("customer_id",visits.CustomerId);
        command.Parameters.AddWithValue("shop_id",visits.ShopId);
        command.Parameters.AddWithValue("barber_id",visits.BarberId);
        try
        {
            Log.ForContext("SourceContext", "PostgreSql").Information("Executing INSERT SQL");

            //! means guid must no empty
            var visitId = (Guid)(await command.ExecuteScalarAsync())!;
            Log.Information("Customer inserted successfully with ID {CustomerId}", visitId);
            return visitId;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Failed inserting customer {@Customer}", visits);
            throw;
        }
    }
}
