
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System;
using System.Text.Json.Serialization;
using UsedCars.Configuration;
using UsedCars.DbContexts;
using UsedCars.Extensions;
using UsedCars.GenericRepository;
using UsedCars.Profiles;
using UsedCars.Repository.AdditionalEquipment;
using UsedCars.Repository.Category;
using UsedCars.Services;
using UsedCars.Services.ModelService;
using UsedCars.Services.VehicleService;

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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IAdditionalService, AdditionalEquipmentRepo>();
builder.Services.AddScoped<IModelRepo, ModelRepo>();
builder.Services.AddScoped<IMakeRepo, MakeRepo>();
builder.Services.AddScoped<IVehicleRepo, VehicleRepo>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
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
