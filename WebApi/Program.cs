using Domain.Interfaces.Generics;
using Domain.Interfaces.ICategories;
using Domain.Interfaces.IFinanceSystem;
using Domain.Interfaces.InterfaceServices;
using Domain.Interfaces.IUserFinanceSystem;
using Domain.Services;
using Finance.Entities;
using Infra.Config;
using Infra.Repository.Generics;
using Infra.Repository.RepositoryCategories;
using Infra.Repository.RepositoryExpenses;
using Infra.Repository.RepositoryFinanceSystem;
using Infra.Repository.RepositoryUserFinanceSystem;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApi.Token;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BasicContext>(options =>
               options.UseSqlServer(
                   builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<BasicContext>();


// Interface and Repository
builder.Services.AddSingleton(typeof(InterfaceGeneric<>), typeof(RepositoryGenerics<>));
builder.Services.AddSingleton<InterfaceCategories, RepositoryCategories>();
builder.Services.AddSingleton<InterfaceExpenses, RepositoryExpenses>();
builder.Services.AddSingleton<InterfaceFinanceSystem, RepositoryFinanceSystem>();
builder.Services.AddSingleton<InterfaceUserFinanceSystem, RepositoryUserFinanceSystem>();

// Domain Service
builder.Services.AddSingleton<ICategoriesService, CategoriesService>();
builder.Services.AddSingleton<IExpensesService, ExpensesService>();
builder.Services.AddSingleton<IFinanceSystemService, FinanceSystemService>();
builder.Services.AddSingleton<IUserFinanceSystemService, UserFinanceSystemService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(option =>
             {
                 option.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = false,
                     ValidateAudience = false,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,

                     ValidIssuer = "Teste.Securiry.Bearer",
                     ValidAudience = "Teste.Securiry.Bearer",
                     IssuerSigningKey = JwtSecurityKey.Create("Secret_Key-12345678")
                 };

                 option.Events = new JwtBearerEvents
                 {
                     OnAuthenticationFailed = context =>
                     {
                         Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                         return Task.CompletedTask;
                     },
                     OnTokenValidated = context =>
                     {
                         Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                         return Task.CompletedTask;
                     }
                 };
             });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var devClient = "http://localhost:4200";

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().WithOrigins(devClient));

app.UseHttpsRedirection();

// NEW
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
