using eGuide.Business.Concrete;
using eGuide.Business.Interface;
using eGuide.Cache.Concrete;
using eGuide.Cache.Interface;
using eGuide.Common.Mappers;
using eGuide.Common.SignalR;
using eGuide.Data.Context.Context;
using eGuide.Data.Entities.Admin;
using eGuide.Infrastructure.Concrete;
using eGuide.Infrastructure.Conctrete;
using eGuide.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSignalR();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddControllers(options => {
//    options.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();
//    options.OutputFormatters.Add(new SystemTextJsonOutputFormatter(new JsonSerializerOptions(JsonSerializerDefaults.Web) {
//        ReferenceHandler = ReferenceHandler.Preserve,
//    }));
//});

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


JsonSerializerOptions options = new() {
    ReferenceHandler = ReferenceHandler.IgnoreCycles,
    WriteIndented = true
};

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICache, Cache>();

builder.Services.AddScoped(typeof(IAdminProfileBusiness), typeof(AdminProfileBusiness));
builder.Services.AddScoped(typeof(IAdminProfileRepository),typeof( AdminProfileRepository));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IBusiness<>), typeof(Business<>));

builder.Services.AddScoped(typeof(IConnectorBusiness), typeof(ConnectorBusiness));
builder.Services.AddScoped(typeof(IConnectorRepository), typeof(ConnectorRepository));

builder.Services.AddScoped(typeof(IStationFacilityBusiness), typeof(StationFacilityBusiness));
builder.Services.AddScoped(typeof(IStationFacilityRepository), typeof(StationFacilityRepository));

builder.Services.AddScoped(typeof(IChargingUnitBusiness), typeof(ChargingUnitBusiness));
builder.Services.AddScoped(typeof(IChargingUnitRepository), typeof(ChargingUnitRepository));

builder.Services.AddScoped(typeof(IStationChargingUnitBusiness), typeof(StationChargingUnitBusiness));
builder.Services.AddScoped(typeof(IStationChargingUnitRepository), typeof(StationChargingUnitRepository));

builder.Services.AddScoped(typeof(IStationBusiness), typeof(StationBusiness));
builder.Services.AddScoped(typeof(IStationRepository), typeof(StationRepository));

builder.Services.AddScoped(typeof(IVehicleBusiness), typeof(VehicleBusiness));
builder.Services.AddScoped(typeof(IVehicleRepository), typeof(VehicleRepository));

builder.Services.AddScoped(typeof(IStationModelBusiness), typeof(StationModelBusiness));
builder.Services.AddScoped(typeof(IStationModelRepository), typeof(StationModelRepository));

builder.Services.AddScoped(typeof(IUserStationBusiness), typeof(UserStationBusiness));
builder.Services.AddScoped(typeof(IUserStationRepository), typeof(UserStationRepository));

builder.Services.AddScoped(typeof(IWebsiteBusiness), typeof(WebsiteBusiness));
builder.Services.AddScoped(typeof(IWebsiteRepository), typeof(WebsiteRepository));

builder.Services.AddScoped(typeof(IWebsiteBusiness), typeof(WebsiteBusiness));
builder.Services.AddScoped(typeof(IWebsiteRepository), typeof(WebsiteRepository));

builder.Services.AddScoped(typeof(IServiceBusiness), typeof(ServiceBusiness));
builder.Services.AddScoped(typeof(IServiceRepository), typeof(ServiceRepository));

builder.Services.AddScoped(typeof(IFacilityBusiness), typeof(FacilityBusiness));
builder.Services.AddScoped(typeof(IFacilityRepository), typeof(FacilityRepository));

builder.Services.AddScoped(typeof(ISocialMediaBusiness), typeof(SocialMediaBusiness));
builder.Services.AddScoped(typeof(ISocialMediaRepository), typeof(SocialMediaRepository));

builder.Services.AddScoped(typeof(IColorBusiness), typeof(ColorBusiness));
builder.Services.AddScoped(typeof(IColorRepository), typeof(ColorRepository));

builder.Services.AddScoped<IUserBusiness, UserBusiness>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped(typeof(IUserVehicleBusiness), typeof(UserVehicleBusiness));
builder.Services.AddScoped(typeof(IUserVehicleRepository), typeof(UserVehicleRepository));

builder.Services.AddScoped(typeof(ILogBusiness), typeof(LogBusiness));
builder.Services.AddScoped(typeof(ILogRepository), typeof(LogRepository));

builder.Services.AddScoped(typeof(IContactFormBusiness), typeof(ContactFormBusiness));
builder.Services.AddScoped(typeof(IContactFormRepository), typeof(ContactFormRepository));

builder.Services.AddSingleton<IMongoClient>(new MongoClient("mongodb://localhost:27017/test"));

builder.Services.AddSingleton<IMongoDatabase>(provider => {
    var client = provider.GetRequiredService<IMongoClient>();
    return client.GetDatabase("eGuideDb");
});

builder.Services.AddCors(options => {
    options.AddPolicy("eGuideOrigins",
        builder => {
            builder.WithOrigins("http://localhost:4200") // Replace with your frontend application's URL
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials() // You might need this if your WebSocket server requires credentials
                    .SetIsOriginAllowed(origin => true);
        });
});
builder.Services.AddSignalR();

//builder.Services.AddCors(options => options.AddPolicy(name: "eGuideOrigins",
//    policy => { policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true); }));

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


app.UseCors("eGuideOrigins");

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<BroadCastHub>("/myHub");
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();