using backend.Models;
using backend.Configuration;
using Npgsql;
using Serilog;

namespace backend.Repository;

public class ShopRepository : IShopRepository
{
    private readonly NpgsqlDataSource _dataSource;

    public ShopRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public async Task<IReadOnlyList<Shops>> GetAllAsync()
    {
        Log.Information("Fetching all shops");

        var xmlPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "SqlQueries",
            "BarberShop.xml");

        var sql = SqlQueryReader.GetQuery(xmlPath, "GetAllShops");

        var shops = new List<Shops>();

        await using var connection = await _dataSource.OpenConnectionAsync();
        await using var command = new NpgsqlCommand(sql, connection);

        try
        {
            // 🔹 ONE SQL LOG (query only)
            Log.ForContext("SourceContext", "PostgreSql")
               .Information("Executing SQL: {Sql}", command.CommandText);

            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                shops.Add(new Shops
                {
                    Id = reader.GetGuid(0).ToString(),
                    Name = reader.GetString(1),
                    Address = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                    Language = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                    CreatedAt = reader.GetDateTime(4).ToString("O"),
                    UpdatedAt = reader.GetDateTime(5).ToString("O")
                });
            }

            Log.Information("Fetched {Count} shops", shops.Count);
        }
        catch (Exception ex)
        {
            Log.Error(
                ex,
                "Failed executing SQL: {Sql}",
                command.CommandText);

            throw;
        }

        return shops;
    }
}
