using ApiUsuarios.Data.Interfaces;
using ApiUsuarios.Data.Repositories;
using ApiUsuarios.Services.Configurations;
using ApiUsuarios.Services.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Adicionando as configurações do Swagger
SwaggerConfiguration.AddSwagger(builder);

//adicionando as configurações do AutoMapper
AutoMapperConfiguration.AddAutoMapper(builder);

// Adicionando as injeções de dependência do projeto
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IEscolaridadeRepository, EscolaridadeRepository>();
builder.Services.AddCorsPolicy();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<ExceptionMiddleware>();
app.UseCorsPolicy();
app.Run();

public partial class Program { }
