using BddAPI.Data;
using BddAPI.Exceptions;
using BddAPI.Mapping;
using BddAPI.Repositories;
using BddAPI.Services.Auth;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddDbContext<BddDbContext>(options => { options.UseSqlServer("name=ConnectionStrings:DefaultConnection"); });
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddCors(
    options =>
    {
        options.AddPolicy("AllowAll",
            policyBuilder => { policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
    });

builder.Services.AddControllers(options => { options.Filters.Add<BddExceptionFilter>(); });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowAll");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.UseSpa(spa =>
{
    if (app.Environment.IsDevelopment())
    {
        spa.UseProxyToSpaDevelopmentServer("http://localhost:5173");
    }
});

app.Run();