using SearchRepository.Application.Interface;
using SearchRepository.Application.Services;
using SearchRepository.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAntiforgery();

builder.Services.CreateContextService(builder.Configuration);

builder.Services.AddDbContext<SearchRepositoryDBContext>();
builder.Services.AddScoped<ISearchRepository, SearchServices>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
