using Data;
using GraphQL.AspNet.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var postgresConnection = new PostgresConnection(Environment.GetEnvironmentVariable("CONNECTION_STRING")!);

builder.Services.AddSingleton(postgresConnection);

builder.Services.AddGraphQL();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseGraphQL();

app.UseAuthorization();

app.MapControllers();

app.Run();
