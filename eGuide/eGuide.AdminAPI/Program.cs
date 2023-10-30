using eGuide.Business.Concrete;
using eGuide.Business.Interface;
using eGuide.Common.Mappers;
using eGuide.Data.Context.Context;
using eGuide.Data.Entities.Admin;
using eGuide.Infrastructure.Concrete;
using eGuide.Infrastructure.Conctrete;
using eGuide.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IAdminAuthorizationBusiness, AdminAuthorizationBusiness>();
builder.Services.AddScoped<IAdminAuthorizationRepository, AdminAuthorizationRepository>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IBusiness<>), typeof(Business<>));

builder.Services.AddScoped(typeof(IConnectorBusiness), typeof(ConnectorBusiness));
builder.Services.AddScoped(typeof(IConnectorRepository), typeof(ConnectorRepository));

builder.Services.AddScoped(typeof(IStationFacilityBusiness), typeof(StationFacilityBusiness));
builder.Services.AddScoped(typeof(IStationFacilityRepository), typeof(StationFacilityRepository));

builder.Services.AddScoped(typeof(ISocketBusiness), typeof(SocketBusiness));
builder.Services.AddScoped(typeof(ISocketRepository), typeof(SocketRepository));

builder.Services.AddScoped(typeof(IStationSocketBusiness), typeof(StationSocketBusiness));
builder.Services.AddScoped(typeof(IStationSocketRepository), typeof(StationSocketRepository));

builder.Services.AddScoped(typeof(IStationBusiness), typeof(StationBusiness));
builder.Services.AddScoped(typeof(IStationRepository), typeof(StationRepository));

builder.Services.AddScoped(typeof(IVehicleBusiness), typeof(VehicleBusiness));
builder.Services.AddScoped(typeof(IVehicleRepository), typeof(VehicleRepository));

builder.Services.AddScoped(typeof(IStationModelBusiness), typeof(StationModelBusiness));
builder.Services.AddScoped(typeof(IStationModelRepository), typeof(StationModelRepository));

builder.Services.AddScoped(typeof(IWebsiteBusiness), typeof(WebsiteBusiness));
builder.Services.AddScoped(typeof(IWebsiteRepository), typeof(WebsiteRepository));

builder.Services.AddSingleton<IMongoClient>(new MongoClient("mongodb://localhost:27017"));
builder.Services.AddSingleton<IMongoDatabase>(provider =>
{
    var client = provider.GetRequiredService<IMongoClient>();
    return client.GetDatabase("eGuideDb"); // Replace with your database name
});

builder.Services.AddCors(options => {
    options.AddPolicy("AllowSpecificOrigin",
        builder => {
            builder.WithOrigins("http://localhost:55847") // Replace with your frontend application's URL
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials(); // You might need this if your WebSocket server requires credentials
        });
});

builder.Services.AddAutoMapper(typeof(AdminProfileMapper));
builder.Services.AddAutoMapper(typeof(BaseMapper<,,,>));
builder.Services.AddDbContext<eGuideContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("eGuideContext")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();