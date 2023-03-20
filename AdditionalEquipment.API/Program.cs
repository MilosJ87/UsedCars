using Microsoft.EntityFrameworkCore;
using UsedCars.Common;
using UsedCars.Common.Extensions;
using UsedCars.DbContexts;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(VehicleProfile));
builder.Services.RegisterServices();

var dbConnectionString = builder.Configuration.GetConnectionString("DBConnectionString");
builder.Services.AddDbContext<UsedCarsContext>(options => options.UseSqlServer(dbConnectionString));
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
