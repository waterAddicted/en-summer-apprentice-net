using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using NLog.Web;
//using Ticket_Management.Api.Middleware;
using Ticket_Management.Api.Repositories;
using TMS.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);
//Insert dependency injection for Logger
builder.Logging.ClearProviders();
builder.Host.UseNLog();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Insert dependency injection for Logger
builder.Logging.ClearProviders();
builder.Host.UseNLog();

builder.Services.AddTransient<IEventRepository, EventRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
