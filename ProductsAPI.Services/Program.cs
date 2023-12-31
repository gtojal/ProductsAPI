using MediatR;
using ProductsAPI.Application.Interfaces.Services;
using ProductsAPI.Application.Services;
using ProductsAPI.Infra.IoC.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServerConfig(builder.Configuration); //SqlServer
builder.Services.AddMongoDBConfig(builder.Configuration); //MongoDB
builder.Services.AddDependencyInjection(); //Servi�os
builder.Services.AddMediatRConfig(); //MediatR
builder.Services.AddJwtBearer(builder.Configuration); //JWT   

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
