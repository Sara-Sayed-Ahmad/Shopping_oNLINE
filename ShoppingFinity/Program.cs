using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShoppingFinity;
using ShoppingFinity.Model;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Security;
using Microsoft.Extensions.DependencyInjection;
using ShoppingFinity.Repository;

var builder = WebApplication.CreateBuilder(args);

//Connection for database 
builder.Services.AddDbContext<SystemDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("ShoppingFinity"));
    });

// Add services to the container.

builder.Services.AddControllers();

ConfigurationManager configuration = builder.Configuration;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ShoppingIRepository, Shopping_Repository>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

//add ConfigureServices
builder.Services
    .AddIdentity<User, IdentityRole>(options => {
        options.SignIn.RequireConfirmedAccount = false;
        options.User.RequireUniqueEmail = true;
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = false;
        options.SignIn.RequireConfirmedEmail = false;
        options.SignIn.RequireConfirmedPhoneNumber = false;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
    })
    .AddEntityFrameworkStores<SystemDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
        c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "ShoppingFinity List API");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
