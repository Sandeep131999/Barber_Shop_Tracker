using backend.Configuration;
using backend.Repository;
using backend.Services;
using Microsoft.Extensions.Options;
using Npgsql;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//*****************************************
// 0. Serilog Configuration
//*****************************************
SerilogConfigurator.Configure(builder.Configuration);
// builder.Host.UseSerilog();

//*****************************************
// 1. Framework services
//*****************************************
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//*****************************************
// 2. PostgreSQL configuration
//*****************************************
builder.Services.Configure<PostgresConfiguration>(
    builder.Configuration.GetSection("Postgres"));

//*****************************************
// 3. Npgsql data source (Singleton)
//*****************************************
builder.Services.AddSingleton<NpgsqlDataSource>(sp =>
{
    var options = sp.GetRequiredService<IOptions<PostgresConfiguration>>().Value;
    return new NpgsqlDataSourceBuilder(options.ConnectionString).Build();
});

//*****************************************
// 4. Application services
//*****************************************
builder.Services.AddScoped<IShopRepository, ShopRepository>();
builder.Services.AddScoped<IShopService, ShopService>();

var app = builder.Build();

//*****************************************
// 5. HTTP pipeline
//*****************************************
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.MapControllers();

app.Run();
