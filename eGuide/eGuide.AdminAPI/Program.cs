using eGuide.Business.Concrete;
using eGuide.Business.Interface;
using eGuide.Common.Mappers;
using eGuide.Data.Context.Context;
using eGuide.Data.Entities.Admin;
using eGuide.Infrastructure.Concrete;
using eGuide.Infrastructure.Conctrete;
using eGuide.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

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

builder.Services.AddAutoMapper(typeof(AdminProfileMapper));
builder.Services.AddDbContext<eGuideContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("eGuideContext")));
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