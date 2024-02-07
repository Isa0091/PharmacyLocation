using Isa0091.Domain.Mvc.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using PharmacyLocation.Core.Data;
using PharmacyLocation.Core.Provider.PharmacyNearbyProduct;
using PharmacyLocation.Data;
using PharmacyLocation.Data.Repos;
using PharmacyLocation.Handlers.Helpers;
using PharmacyLocation.Settings;
using Serilog;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) =>
{
    lc.ReadFrom.Configuration(ctx.Configuration);
});

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddDbContext<PharmacyLocationContext>(options =>
{
    options.UseSqlServer(connectionString);

});

//Profiles
//builder.Services.AddAutoMapper(typeof(InvoiceAccountProfile));


//Repos
builder.Services.AddScoped<IFavoriteUserProductRepo, FavoriteUserProductRepo>();
builder.Services.AddScoped<IPharmacyProductRepo, PharmacyProductRepo>();
builder.Services.AddScoped<IPharmacyRepo, PharmacyRepo>();
builder.Services.AddScoped<IProductRepo, ProductRepo>();

//helpers
builder.Services.AddScoped<IPharmacyNearbyProductHelper, PharmacyNearbyProductHelper>();

builder.Services.AddMediatR(new Assembly[] { typeof(PharmacyLocation.Handlers.DummyMarker).Assembly });
builder.Services.Configure<DefaultPaginationSettings>(builder.Configuration.GetSection(nameof(DefaultPaginationSettings)));


builder.Services.AddControllers(o => o.Filters.Add(new ApiExceptionFilter()))
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// automapper
//builder.Services.AddAutoMapper(typeof(AccountProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var context = app.Services.CreateScope().ServiceProvider.GetService<PharmacyLocationContext>();

if (context?.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
    context?.Database.Migrate();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
