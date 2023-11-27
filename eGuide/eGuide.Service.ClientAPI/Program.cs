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
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


JsonSerializerOptions options = new()
{
    ReferenceHandler = ReferenceHandler.IgnoreCycles,
    WriteIndented = true
};


builder.Services.AddCors(options => {
    options.AddPolicy("eGuideOrigins",
        builder => {
            builder.WithOrigins("http://localhost:4201") // Replace with your frontend application's URL
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials(); // You might need this if your WebSocket server requires credentials
        });
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IBusiness<>), typeof(Business<>));

builder.Services.AddScoped<IUserBusiness, UserBusiness>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped(typeof(IVehicleBusiness), typeof(VehicleBusiness));
builder.Services.AddScoped(typeof(IVehicleRepository), typeof(VehicleRepository));

builder.Services.AddScoped(typeof(IUserVehicleBusiness), typeof(UserVehicleBusiness));
builder.Services.AddScoped(typeof(IUserVehicleRepository), typeof(UserVehicleRepository));

builder.Services.AddScoped(typeof(IStationBusiness), typeof(StationBusiness));
builder.Services.AddScoped(typeof(IStationRepository), typeof(StationRepository));

builder.Services.AddScoped(typeof(IConnectorBusiness), typeof(ConnectorBusiness));
builder.Services.AddScoped(typeof(IConnectorRepository), typeof(ConnectorRepository));

builder.Services.AddScoped(typeof(IServiceBusiness), typeof(ServiceBusiness));
builder.Services.AddScoped(typeof(IServiceRepository), typeof(ServiceRepository));

builder.Services.AddScoped(typeof(IUserStationBusiness), typeof(UserStationBusiness));
builder.Services.AddScoped(typeof(IUserStationRepository), typeof(UserStationRepository));

builder.Services.AddScoped(typeof(ILastVisitedStationsBusiness), typeof(LastVisitedStationsBusiness));
builder.Services.AddScoped(typeof(ILastVisitedStationsRepository), typeof(LastVisitedStationsRepository));

builder.Services.AddScoped(typeof(ISocialMediaBusiness), typeof(SocialMediaBusiness));
builder.Services.AddScoped(typeof(ISocialMediaRepository), typeof(SocialMediaRepository));

builder.Services.AddScoped(typeof(IWebsiteBusiness), typeof(WebsiteBusiness));
builder.Services.AddScoped(typeof(IWebsiteRepository), typeof(WebsiteRepository));


builder.Services.AddSingleton<IMongoClient>(new MongoClient("mongodb://localhost:27017"));
builder.Services.AddSingleton<IMongoDatabase>(provider =>
{
    var client = provider.GetRequiredService<IMongoClient>();
    return client.GetDatabase("eGuideDb");
});

builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId =builder.Configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});

builder.Services.AddAutoMapper(typeof(UserVehicleMapper));
builder.Services.AddAutoMapper(typeof(AdminProfileMapper));
builder.Services.AddAutoMapper(typeof(UserMapper));
builder.Services.AddAutoMapper(typeof(VehicleMapper));
builder.Services.AddDbContext<eGuideContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("eGuideContext")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("eGuideOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();