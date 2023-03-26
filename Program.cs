using CatalogDemo.Data;
using CatalogDemo.Repositories;
using CatalogDemo.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configurations = builder.Configuration.GetSection(nameof(SqlDbSettings)).Get<SqlDbSettings>();
builder.Services.AddSqlServer<CatalogDemoDbContext>(configurations.GetConnectionString);
//builder.Services.AddSingleton<IRepository, InMemProductRepository>();

builder.Services.AddScoped<IContext, CatalogDemoDbContext>();
builder.Services.AddScoped<IRepository, ProductRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
