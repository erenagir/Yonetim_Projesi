using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;
using System.Xml.Xsl;
using X.Y�netim.Application.AutoMapper;
using X.Y�netim.Application.Services.Abstraction;
using X.Y�netim.Application.Services.Implementation;
using X.Y�netim.Application.Validators.Accounts;
using X.Y�netim.Application.Validators.Budgets;
using X.Y�netim.Domain.Repositories;
using X.Y�netim.Domain.UWork;
using X.Y�netim.Persistence.Context;
using X.Y�netim.Persistence.Repositories;
using X.Y�netim.Persistence.UWork;
using XY�netim.Api.Filters;

var builder = WebApplication.CreateBuilder(args);

//Logging
var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
        .CreateLogger();

Log.Logger.Information("Program Started...");

// Add services to the container. 
//ActionFilter registiration
builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new ExceptionHandlerFilter());
});




builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "JwtTokenWithIdentity", Version = "v1", Description = "JwtTokenWithIdentity test app" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
                    {
                        new OpenApiSecurityScheme
                        {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                        },
                            new string[] {}
                    }
    });
});
builder.Services.AddHttpContextAccessor();

//dbContext registiration
builder.Services.AddDbContext<XContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("XY�netim"));
});


// repository registiration
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


//UnitOfWork Registiration
builder.Services.AddScoped<IUWork, UWork>();


//Business Service Registiration
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IBudgetService, BudgetService>();
builder.Services.AddScoped<IExpenseService, ExpenseService>();
builder.Services.AddScoped<IIncomeService, IncomeService>();


//FluentValidation �stekte g�nderilen modele ait property'lerin istenen format� destekleyip desteklemedi�ini anlamam�z� sa�lar.
builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreateBudgetValidator));


//automapper
builder.Services.AddAutoMapper(typeof(DomainToDtoModel), typeof(ViewModelToDomain));


//FluentValidation �stekte g�nderilen modele ait property'lerin istenen format� destekleyip desteklemedi�ini anlamam�z� sa�lar.
builder.Services.AddValidatorsFromAssemblyContaining(typeof(LoginValidator));

// JWT kimlik do�rulama servisini ekleme
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.IncludeErrorDetails = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"], // Token� olu�turan taraf�n adresi
            ValidAudience = builder.Configuration["Jwt:Audiance"], // Token�n kullan�laca�� hedef adres
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SigningKey"])) // Gizli anahtar
        };
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
