using UsedCars.Common.Extensions;
using UsedCars.Configuration;
using Newtonsoft.Json.Serialization;
using System;
using System.Text.Json.Serialization;
using UsedCars.DbContexts;
using Microsoft.EntityFrameworkCore;
using UsedCars.Extensions;
using UsedCars.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson(setupAction =>
{
    setupAction.SerializerSettings.ContractResolver =
       new CamelCasePropertyNamesContractResolver();
});


builder.Services.AddIdentityServer()
                .AddInMemoryApiScopes(InMemoryConfig.GetApiScopes())
                .AddInMemoryApiResources(InMemoryConfig.GetApiResources())
                .AddInMemoryIdentityResources(InMemoryConfig.GetIdentityResources())
                .AddTestUsers(InMemoryConfig.GetUsers())
                .AddInMemoryClients(InMemoryConfig.GetClients())
                .AddDeveloperSigningCredential();

builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", opt =>
                {
                    opt.RequireHttpsMetadata = false;
                    opt.Authority = "https://localhost:5005";
                    opt.Audience = "UsedCars";
                });

builder.Services.AddDistributedMemoryCache();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(VehicleProfile));

builder.Services.RegisterServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbConnectionString = builder.Configuration.GetConnectionString("DBConnectionString");

builder.Services.AddDbContext<UsedCarsContext>(options => options.UseSqlServer(dbConnectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();

app.UseHttpsRedirection();
app.UseRateLimiting();

app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});
app.MapControllers();

app.Run();