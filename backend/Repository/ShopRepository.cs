using backend.Models;
using Npgsql;

namespace backend.Repository;

/// <summary>
/// Concrete implementation of <see cref="IShopRepository"/>.
/// Uses Npgsql to read data from the PostgreSQL "shops" table.
/// </summary>
public class ShopRepository : IShopRepository
{
    private readonly NpgsqlDataSource _dataSource;

    public ShopRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public async Task<IReadOnlyList<Shops>> GetAllAsync()
    {
        const string sql = @"SELECT id, name, address, language, created_at, updated_at FROM shops";

        var shops = new List<Shops>();

        await using var connection = await _dataSource.OpenConnectionAsync();
        await using var command = new NpgsqlCommand(sql, connection);
        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            var shop = new Shops
            {
                Id = reader.GetGuid(0).ToString(),
                Name = reader.GetString(1),
                Address = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                Language = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                // store timestamps as ISO-8601 strings in this simple model
                CreatedAt = reader.GetDateTime(4).ToString("O"),
                UpdatedAt = reader.GetDateTime(5).ToString("O")
            };

            shops.Add(shop);
        }

        return shops;
    }
}

