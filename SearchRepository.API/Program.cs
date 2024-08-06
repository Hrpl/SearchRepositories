using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using SearchRepository.Application.Interface;
using SearchRepository.Application.Services;
using SearchRepository.Infrastructure;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAntiforgery();

builder.Services.AddDbContext<SearchRepositoryDBContext>();
builder.Services.AddScoped<ISearchRepository, SearchServices>();
builder.Services.AddScoped<ILoginServices, LoginServices>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = JwtOption.ISSUER,
            ValidateAudience = true,
            ValidAudience = JwtOption.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtOption.KEY))
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

app.UseCors(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public static class JwtOption
{
    public const string ISSUER = "MyAuthServer"; 
    public const string AUDIENCE = "MyAuthClient";
    public const string KEY = "qaz123wsx456edc789rfv000tgbdsgfjorjjwe324325432435435opewk";   // ключ для шифрации
    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}