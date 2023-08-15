using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Xml.Xsl;
using X.Y�netim.Application.AutoMapper;
using X.Y�netim.Domain.Repositories;
using X.Y�netim.Persistence.Context;
using X.Y�netim.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//dbContext registiration
builder.Services.AddDbContext<XContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("XY�netim"));
});
// repository registiration
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//automapper

builder.Services.AddAutoMapper(typeof(DomainToDtoModel), typeof(ViewModelToDomain));


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
