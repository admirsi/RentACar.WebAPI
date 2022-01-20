using RentACar.WebAPI.Infrastructure.Database;
using RentACar.WebAPI.Interfaces;

using RentACar.WebAPI.Middlewares;
using RentACar.WebAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("RentACarDatabase");

builder.Services.AddDbContext<RentACarDbContext>(options => options.UseMySql(connectionString, new MariaDbServerVersion("10.6")));
builder.Services.AddScoped<IRentACarService, CarService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseMiddleware<ExceptionMiddleware>();
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
