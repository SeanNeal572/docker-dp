using EventScheduler.Core;
using EventScheduler.Core.Repositories;
using EventScheduler.Db.Interfaces;
using EventScheduler.Db.Mssql;
using EventScheduler.Db.Postgres;
using EventScheduler.Db.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IEventRepository, EventRepository>();
switch (EnvironmentConfig.DbProvider)
{
    case "postgres": builder.Services.AddTransient<IAppDbContext, PostgresDbContext>(); break;
    case "mssql-dp": builder.Services.AddTransient<IAppDbContext, MssqlDbContext>(); break;
    default: throw new Exception("Invalid database provider");
}

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
