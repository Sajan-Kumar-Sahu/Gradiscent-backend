using FluentValidation;
using Gradiscent.Api.Middleware;
using Gradiscent.Application;
using Gradiscent.Application.Authentication.Common;
using Gradiscent.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b=>b.MigrationsAssembly("Gradiscent.Persistence"))
    );

builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblyContaining<AssemblyReference>();

builder.Services.AddValidatorsFromAssembly(Assembly.Load("Gradiscent.Application"));

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(typeof(AssemblyReference).Assembly);
});

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly);
});

builder.Services.Configure<JwtOptions>(
    builder.Configuration.GetSection("JwtSettings"));

builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseMiddleware<ValidationExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
