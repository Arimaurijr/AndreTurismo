using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EF_Turismo.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EF_TurismoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EF_TurismoContext") ?? throw new InvalidOperationException("Connection string 'EF_TurismoContext' not found.")));

// Add services to the container.

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
