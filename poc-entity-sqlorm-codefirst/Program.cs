using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using poc_voya_entity.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<cryptoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cryptoContext2") ?? throw new InvalidOperationException("Connection string 'cryptoContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ICalculator, CalculatorService>();
builder.Services.AddScoped<ICrypto, CryptoService>();

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