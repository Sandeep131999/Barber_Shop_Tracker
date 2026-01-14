using backend.Configuration;
using backend.Repository;
using backend.Services;
using Microsoft.Extensions.Options;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

//*****************************************
//1. Configure PostgreSQL from appsettings
//*****************************************
builder.Services.Configure<PostgresConfiguration>(builder.Configuration.GetSection("Postgres"));

//*****************************************
//2. Register Npgsql data source for PostgreSQL
//*****************************************
builder.Services.AddSingleton<NpgsqlDataSource>(sp =>
{
    var options = sp.GetRequiredService<IOptions<PostgresConfiguration>>().Value;
    return new NpgsqlDataSourceBuilder(options.ConnectionString).Build();
});

//*****************************************
//3. Register repository + service in DI
//*****************************************
builder.Services.AddScoped<IShopRepository, ShopRepository>();
builder.Services.AddScoped<IShopService, ShopService>();

var app = builder.Build();

//*****************************************
//4. Configure the HTTP request pipeline.
//*****************************************
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//*****************************************
//5. Map controllers for API endpoints
//*****************************************
app.MapControllers();

app.Run();

