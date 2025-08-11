using AutoMapper;
using Inlog.Desafio.Backend.Application.Interfaces;
using Inlog.Desafio.Backend.Application.Services;
using Inlog.Desafio.Backend.Domain.Excecao;
using Inlog.Desafio.Backend.Domain.Models.Veiculo;
using Inlog.Desafio.Backend.Domain.Repositories;
using Inlog.Desafio.Backend.Domain.Validacao;
using Inlog.Desafio.Backend.Infra.Database.Context;
using Inlog.Desafio.Backend.Infra.Database.Repositories;
using Inlog.Desafio.Backend.WebApi.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<InlogDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("RastreamentoVeiculoDbConnection"));
});


//Application Services
builder.Services.AddTransient<IVeiculoService,VeiculoService>();
builder.Services.AddTransient<IValidador<Veiculo>,VeiculoValidador>();
builder.Services.AddTransient<IValidador<Localizacao>,LocalizacaoValidador>();

//Data
builder.Services.AddTransient<IVeiculoRepository,VeiculoRepository>();
builder.Services.AddTransient<DbContext, InlogDbContext>();

builder.Services.AddScoped<ErrorContext>();


builder.Services.AddCors(option =>
{
    option.AddPolicy("CorsPolicy", builder => {
        builder.WithOrigins("http://localhost:5100")
         .AllowAnyMethod()
         .AllowAnyHeader();
     }  );

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();


app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
