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

builder.Services.AddControllers(options => { options.Filters.Add<BddExceptionFilter>(); });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();