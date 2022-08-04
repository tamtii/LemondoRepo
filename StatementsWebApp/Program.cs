using Statements.Contracts.Extensions;
using Statements.Contracts.Interfaces.Repositories;
using Statements.Contracts.Interfaces.Services;
using Statements.Data.EF;
using Statements.Repository;
using Statements.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<StatementDbContext, StatementDbContext>();
builder.Services.AddScoped<IStatementRepository, StatementRepository>();
builder.Services.AddScoped<IStatementService, StatementService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}
app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();
app.UseStaticFiles();

app.Run();
