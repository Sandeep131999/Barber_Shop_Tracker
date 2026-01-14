namespace backend.Configuration;

/// <summary>
/// Configuration class for PostgreSQL connection settings.
/// This class maps to the "Postgres" section in appsettings.json.
/// </summary>
public class PostgresConfiguration
{
    /// <summary>
    /// PostgreSQL connection string
    /// (e.g., Host=localhost;Port=5432;Database=barber_shop;Username=postgres;Password=your_password)
    /// </summary>
    public string ConnectionString { get; set; } = string.Empty;
}

