using Presentation.Api.DependencieInjection;
using Presentation.Api.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Repositories.AddRepositories(builder);
BasketServices.AddServices(builder);
ItemServices.AddServices(builder);

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
